using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.EM.MOTD;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System.IO;
using System.Linq;
using System.Net;

namespace EM.ECO.MOTD
{
    public class MOTDManager : IInitializablePlugin, IModKitPlugin
    {
        public string GetStatus() => "EM MOTD Active";

        private const string _configFile = "MOTDConfig.json";
        private const string _dataFile = "MOTDData.json";
        private const string _motdFile = "MOTD.txt";
        internal const string ID = "EM_MOTD_Config";
        private const string _subPath = "/EM/MOTD";

        public static MOTDConfig Config { get; private set; }
        public static MOTDData Data { get; private set; }

        public MOTDManager()
        {
            Config = LoadConfig();
            Data = LoadData();

            if (!File.Exists(Path.Combine(Defaults.SaveLocation + _subPath, _dataFile)))
                SaveData();

            if (!File.Exists(Path.Combine(Defaults.SaveLocation + _subPath, _configFile)))
                SaveConfig();

            LoadMOTD();
        }

        public void Initialize(TimedTask timer)
        {            
            UserManager.OnUserLoggedIn.Add(u =>
            {
                u.OnEnterWorld.Add(Data.OnEnterMOTD(u));
            });
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM - MOTD");
        }

        private MOTDConfig LoadConfig()
        {
            return FileManager<MOTDConfig>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _configFile);
        }

        private MOTDData LoadData()
        {
            return FileManager<MOTDData>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<MOTDConfig>.WriteTypeHandledToFile(Config, Defaults.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<MOTDData>.WriteTypeHandledToFile(Data, Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void CreateMOTDFile(string path)
        {
            using StreamWriter sw = File.CreateText(path);
            sw.Write(MOTDTEMPLATE._template);
        }

        public static void LoadMOTD()
        {
            var path = Path.Combine(Defaults.SaveLocation + _subPath, _motdFile);
            char _ignore = '#';

            if (!File.Exists(path))
                CreateMOTDFile(path);

            string message = "";

            var lines = File.ReadLines(path).Where(l => !l.StartsWith(_ignore));

            Data.SetTitle(lines.First());

            var body = lines.Where(l => l != lines.First());

            foreach (var s in body)
            {
                message += $"{s}\n";
            }

            Data.SetBody(message);
        }
    }
}
