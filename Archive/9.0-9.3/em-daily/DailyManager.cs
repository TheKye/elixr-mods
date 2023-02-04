using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using System;
using System.IO;

namespace Eco.EM.Daily
{
    public class DailyManager : IModKitPlugin, IInitializablePlugin
    {
        private const string _configFile = "DailyConfig";
        private const string _logFile = "DailyLogs";
        private const string _dataFile = "DailyData";
        private const string _packsFile = "DailyPacks";
        internal const string ID = "EM_DailyRewards_Config";
        private const string _subPath = "/EM/DailyRewards";

        public static DailyConfig Config { get; private set; }
        public static DailyData Data { get; private set; }
        public static RewardPackData PackData { get; private set; }

        public DailyManager()
        {
            Config = LoadConfig();
            Data = LoadData();
            PackData = LoadPacks();

            if (!File.Exists(Base.SaveLocation + _subPath + _dataFile))
                SaveData();

            if (!File.Exists(Base.SaveLocation + _subPath + _configFile))
                SaveConfig();

            if (!File.Exists(Base.SaveLocation + _subPath + _packsFile))
                SavePacks();
        }

        public void Initialize(TimedTask timer)
        {
            UserManager.OnUserLoggedIn.Add(u =>
            {
                if (!Data.Users.ContainsKey(u.Name))
                    Data.Users.Add(u.Name, new DailyUserData());
            });
        }

        public string GetStatus() => "EM Daily Plugin Active";

        public override string ToString()
        {
            return Localizer.DoStr("EM - Daily");
        }

        private DailyConfig LoadConfig()
        {
            return FileManager<DailyConfig>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _configFile);
        }

        private DailyData LoadData()
        {
            return FileManager<DailyData>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _dataFile);
        }

        private RewardPackData LoadPacks()
        {
            return FileManager<RewardPackData>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _packsFile);
        }

        public static void SaveConfig()
        {
            FileManager<DailyConfig>.WriteTypeHandledToFile(Config, Base.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<DailyData>.WriteTypeHandledToFile(Data, Base.SaveLocation + _subPath, _dataFile);
        }

        public static void SavePacks()
        {
            FileManager<RewardPackData>.WriteTypeHandledToFile(PackData, Base.SaveLocation + _subPath, _packsFile);
        }


        public static void Log(string entry)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(entry);
            stream.Close();
        }

        // Converts a date time to string, full format
        internal static string DTtoString(DateTime dt)
        {
            return dt.ToString("F");
        }

        // Converts string to DateTime for processing
        internal static DateTime StringtoDT(string s)
        {
            return DateTime.TryParse(s, out DateTime dt) ? dt : DateTime.MinValue;
        }
    }
}