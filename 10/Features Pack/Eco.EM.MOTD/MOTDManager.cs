using Eco.Core.Plugins;
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
    public class MOTDManager : Singleton<MOTDManager>, IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public string GetStatus() => "EM MOTD Active";

        private const string _configFile = "MOTDConfig.json";
        private const string _dataFile = "MOTDData.json";
        private const string _motdFile = "MOTD.txt";
        internal const string ID = "EM_MOTD_Config";
        private const string _subPath = "/EM/MOTD";

        PluginConfig<MOTDConfig> config;
        public MOTDConfig Config => this.config.Config;
        public static MOTDData Data { get; private set; }

        public IPluginConfig PluginConfig => config;

        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();

        public MOTDManager()
        {
            this.config = new PluginConfig<MOTDConfig>("EM-MOTD");
            Data = LoadData();

            if (!File.Exists(Path.Combine(Defaults.SaveLocation + _subPath, _dataFile)))
                SaveData();

            this.SaveConfig();

            LoadMOTD();
        }

        public void Initialize(TimedTask timer)
        {            
            UserManager.OnUserLoggedIn.Add(u =>
            {
                Data.DisplayMOTD(u);
            });
        }

        public override string ToString() => Localizer.DoStr("EM - MOTD");

        private MOTDData LoadData()
        {
            return FileManager<MOTDData>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _dataFile);
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

        public string GetCategory() => "Elixr Mods";

        public object GetEditObject() => this.config.Config;

        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
    }
}
