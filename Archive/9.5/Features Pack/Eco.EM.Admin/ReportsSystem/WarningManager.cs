using Eco.Gameplay.Players;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using System.IO;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.Shared.Localization;
using Eco.Core.Utils.Logging;
using Eco.EM.Framework.Logging;
using Eco.Simulation.Time;
using System.Threading;
using Eco.EM.Framework.Utils;
using Eco.WorldGenerator;

namespace Eco.EM.Admin.ReportsSystem
{
    public class WarningManager : IModKitPlugin, IInitializablePlugin
    {
        private const string _configFile = "WarningsConfig";
        private const string _logFile = "WarningsLogs";
        private const string _dataFile = "WarningsData";
        private const string _subPath = "/EM/Warnings";
        internal const string ID = "EM_Warnings_Config";
        public NLogWriter logger = LoggingUtils.RegisterNewLogger("EM-Warnings");
        public Timer Timer;
        public static WarningConfig Config { get; set; }
        public static WarningData Data { get; private set; }

        public WarningManager()
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
            // Data will be overwritten on new world, config will not.
            //Wipe Groups File on new world generation only if config option is set too true
            WorldGeneratorPlugin.OnFinishGenerate.AddUnique(HandleWorldReset);
            Timer = new(Timer_tick, null, 900000, 900000);

        }
        public void HandleWorldReset()
        {
            ConsoleColors.PrintConsoleMultiColored(Defaults.appNameCon, System.ConsoleColor.Magenta, "New World Detected - Removing All Old Bans", System.ConsoleColor.White);
            logger.Write("New World Detected, Removing All Old Bans");
            if (!File.Exists(Defaults.SaveLocation + _subPath + _dataFile))
                File.Delete(Defaults.SaveLocation + _subPath + _dataFile);

            SaveData();
        }
        static void Timer_tick(object state)
        {
            foreach (var u in PlayerUtils.Users)
            {
                var data = Data.GetWarningDataUser(u.Name);
                if (data == null) return;

                Data.BanExpire(data, u);
            }
        }

        public static WarningConfig LoadConfig()
        {
            return FileManager<WarningConfig>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _configFile);
        }

        private WarningData LoadData()
        {
            return FileManager<WarningData>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<WarningConfig>.WriteTypeHandledToFile(Config, Defaults.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<WarningData>.WriteTypeHandledToFile(Data, Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void Log(string port)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Defaults.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(port);
            stream.Close();
        }

        public string GetStatus()
        {
            return "EM Warning Management Active";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM - Warnings / Bans");
        }
    }
}
