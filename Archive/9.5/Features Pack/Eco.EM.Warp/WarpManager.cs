using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Core.Utils.Logging;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.EM.Framework.Logging;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Utils;
using Eco.Simulation.Time;
using Eco.WorldGenerator;
using System.Collections.Generic;
using System.IO;

namespace Eco.EM.Warp
{
    public class WarpManager : Singleton<WarpManager>, IModKitPlugin, IInitializablePlugin
    {
        private const string _configFile = "WarpConfig";
        private const string _logFile = "WarpLogs";
        private const string _dataFile = "WarpData";
        internal const string ID = "EM_Community_Warps_Config";
        internal const string _subPath = "/EM/CommunityWarps";
        public NLogWriter logger = LoggingUtils.RegisterNewLogger("EMWarps");

        public static WarpConfig Config { get; set; }
        public static WarpData Data { get; internal set; }

        public WarpManager()
        {
            Config = LoadConfig();
            Data = LoadData();

            if (!File.Exists(Defaults.SaveLocation + _subPath + _dataFile))
                SaveData();

            if (!File.Exists(Defaults.SaveLocation + _subPath + _configFile))
                SaveConfig();
        }

        public void Initialize(TimedTask timer)
        {
            // create a new temporary list to store the warp points and clear the warp point list
            var points = new List<WarpPoint>();
            points.AddRange(Data.ListPoints());
            Data.ListPoints().Clear();

            if (points?.Count > 0)
            {
                foreach (var p in points)
                {
                    // If the warp point is present add it back to our points list.
                    if (World.World.GetBlock((Vector3i)p.Location) is WorldObjectBlock warpObjectBlock)
                    {
                        if (warpObjectBlock.WorldObjectHandle.Object is WarpPointObject) Data.Points.Add(p);
                        continue;
                    }

                    // if the warp point is not present attempt to place one and add it back if we can.
                    if (WorldObjectManager.ForceAdd(typeof(WarpPointObject), null, p.Location, p.Rotation) is WarpPointObject obj)
                    {
                        obj.SetName(p.PointName);
                        Data.Points.Add(p);
                        ConsoleColors.PrintConsoleMultiColored("[EM Warp Manager] ", System.ConsoleColor.Magenta, $"A Warp Point was missing it's object, this has been returned: ", System.ConsoleColor.Yellow, $"{p.PointName} at: {p.Location}", System.ConsoleColor.Green);
                    }
                }
            }

            UserManager.OnUserLoggedIn.Add(u =>
            {
                if (!Data.Users.ContainsKey(u.Name))
                    Data.Users.Add(u.Name, new WarpUserData());
            });

            SaveData();
        }


        public string GetStatus() => "EM Community Warps System Active";

        public override string ToString()
        {
            return Localizer.DoStr("EM - Warps");
        }

        public static WarpConfig LoadConfig()
        {
            return FileManager<WarpConfig>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _configFile);
        }

        internal WarpData LoadData()
        {
            return FileManager<WarpData>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<WarpConfig>.WriteTypeHandledToFile(Config, Defaults.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<WarpData>.WriteTypeHandledToFile(Data, Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void Log(string tpr)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Defaults.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(tpr);
            stream.Close();
        }
    }

    // Need to start before WorldGenerator in order to listen for world generation finished event and before the warps manager to ensure proper removal on new world
    [Priority(PriorityAttribute.High)] 
    public class WarpsHandler : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus() => "";

        public void Initialize(TimedTask timer)
        {
            //Reset Warp Points on new world generation to prevent adding of old warp points on a new world
            WorldGeneratorPlugin.OnFinishGenerate.AddUnique(HandleWorldReset);
        }

        public void HandleWorldReset()
        {
            WarpManager.Obj.LoadData();

            ConsoleColors.PrintConsoleMultiColored(Defaults.appNameCon, System.ConsoleColor.Magenta, "New World Detected - Removing All Old Warps", System.ConsoleColor.White);
            if (WarpManager.Data.Points?.Count > 0)
                WarpManager.Data.Points.Clear();
            if (WarpManager.Data.Users?.Count > 0)
                WarpManager.Data.Users.Clear();

            WarpManager.Data = new();
            WarpManager.SaveData();
        }
    }
}
