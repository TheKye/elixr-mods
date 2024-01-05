using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.WorldGenerator;
using System.IO;

namespace Eco.EM.TP
{
    [Priority(PriorityAttribute.High)] // Need to start before WorldGenerator in order to listen for world generation finished event
    public class TeleportManager: IModKitPlugin, IInitializablePlugin
    {
        private const string _configFile = "TeleportConfig";
        private const string _logFile = "TeleportLogs";
        private const string _dataFile = "TeleportData";
        internal const string ID = "EM_Teleport_Config";
        private const string _subPath = "/EM/Teleport";

        public static TeleportConfig Config { get; set; }
        public static TeleportData Data { get; private set; }

        public TeleportManager()
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

            // Clear User Data on new world
            WorldGeneratorPlugin.OnFinishGenerate.AddUnique(HandleWorldReset);

            UserManager.OnUserLoggedIn.Add(u =>
            {
                if (!Data.Users.ContainsKey(u.Name))
                    Data.Users.Add(u.Name, new TeleportUserData());
            });
        }

        public void HandleWorldReset()
        {
            ConsoleColors.PrintConsoleMultiColored(Defaults.appNameCon, System.ConsoleColor.Magenta, "New World Detected - Removing All Old Teleport Logs", System.ConsoleColor.White);
            if (Data.Users.Count > 0)
                Data.Users.Clear();
            SaveData();
        }

        public string GetStatus() => "Teleport System Active";

        public override string ToString()
        {
            return Localizer.DoStr("EM - Teleportation");
        }

        public static TeleportConfig LoadConfig()
        {
            return FileManager<TeleportConfig>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _configFile);
        }

        private TeleportData LoadData()
        {
            return FileManager<TeleportData>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<TeleportConfig>.WriteTypeHandledToFile(Config, Defaults.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<TeleportData>.WriteTypeHandledToFile(Data, Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void Log(string tpr)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Defaults.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(tpr);
            stream.Close();
        }

        public string GetCategory() => "Elixr Mods";
    }
}
