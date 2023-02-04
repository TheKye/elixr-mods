using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.IO;

namespace Eco.EM.QOL
{
    public class QOLManager : IModKitPlugin, IInitializablePlugin
    {
        private const string _configFile = "QOLConfig";
        private const string _logFile = "QOLLogs";
        private const string _dataFile = "QOLData";
        internal const string ID = "EM_OQL_Config";
        private const string _subPath = "/EM/QOL";

        public static QOLConfig Config { get; private set; }
        public static QOLData Data { get; private set; }

        public QOLManager()
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
            UserManager.OnUserLoggedIn.Add(u =>
            {
                if (!Data.Users.ContainsKey(u.Name))
                    Data.Users.Add(u.Name, new QOLUserData());
            });
            Log.WriteLine(Localizer.DoStr(
                "\n||| Elixr Mods and NidToolbox Presents   |||\n" +
                "|||           The QOL Mod!               |||\n" +
                "|||     Please be sure to show both      |||\n" +
                "|||     Some Support For this Mod!       |||\n" +
                "|||     For bugs and feedback join       |||\n" +
                "|||     The Eco Modding Community        |||\n" +
                "|||     Discord! discord.gg/5BdXErQ      |||"
                ));
        }

        public string GetStatus() => "EM QOL Plugin Active";

        public override string ToString()
        {
            return Localizer.DoStr("EM - QOL");
        }

        private QOLConfig LoadConfig()
        {
            return FileManager<QOLConfig>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _configFile);
        }

        private QOLData LoadData()
        {
            return FileManager<QOLData>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<QOLConfig>.WriteTypeHandledToFile(Config, Base.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<QOLData>.WriteTypeHandledToFile(Data, Base.SaveLocation + _subPath, _dataFile);
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