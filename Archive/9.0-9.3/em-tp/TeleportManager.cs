using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using System.IO;

namespace Eco.EM.TP
{
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
                    Data.Users.Add(u.Name, new TeleportUserData());
            });
        }

        public string GetStatus() => "Teleport System Active";

        public override string ToString()
        {
            return Localizer.DoStr("EM - Teleportation");
        }

        public static TeleportConfig LoadConfig()
        {
            return FileManager<TeleportConfig>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _configFile);
        }

        private TeleportData LoadData()
        {
            return FileManager<TeleportData>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<TeleportConfig>.WriteTypeHandledToFile(Config, Base.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<TeleportData>.WriteTypeHandledToFile(Data, Base.SaveLocation + _subPath, _dataFile);
        }

        public static void Log(string tpr)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(tpr);
            stream.Close();
        }
    }
}
