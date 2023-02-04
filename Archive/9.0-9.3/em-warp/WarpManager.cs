using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Utils;
using Eco.Simulation.Time;
using System.Collections.Generic;
using System.IO;

namespace Eco.EM.Warp
{
    public class WarpManager : IModKitPlugin, IInitializablePlugin
    {
        private const string _configFile = "WarpConfig";
        private const string _logFile = "WarpLogs";
        private const string _dataFile = "WarpData";
        internal const string ID = "EM_Community_Warps_Config";
        private const string _subPath = "/EM/CommunityWarps";

        public static WarpConfig Config { get; set; }
        public static WarpData Data { get; private set; }

        public WarpManager()
        {
            Config = LoadConfig();
            Data = LoadData();

            if (!File.Exists(Base.SaveLocation + _subPath + _dataFile))
                SaveData();

            if (!File.Exists(Base.SaveLocation + _subPath + _configFile))
                SaveConfig();
        }

        public void Initialize(TimedTask timer)
        {
            // create a new temporary list to store the warp points and clear the warp point list
            var points = new List<WarpPoint>();
            points.AddRange(Data.ListPoints());
            Data.ListPoints().Clear();

            Base.Debug($"The World Time is: {WorldTime.Seconds}");

            // if world time is 0 skip this as we don't want the old warp points anyway
            if (WorldTime.Seconds >= 600 && points?.Count > 0)
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
                    if (WorldObjectManager.ForceAdd(typeof(WarpPointObject), null ,p.Location, p.Rotation) is WarpPointObject obj)
                    {
                        obj.SetName(p.PointName);
                        Data.Points.Add(p);
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
            return FileManager<WarpConfig>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _configFile);
        }

        private WarpData LoadData()
        {
            return FileManager<WarpData>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<WarpConfig>.WriteTypeHandledToFile(Config, Base.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<WarpData>.WriteTypeHandledToFile(Data, Base.SaveLocation + _subPath, _dataFile);
        }

        public static void Log(string tpr)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(tpr);
            stream.Close();
        }
    }
}
