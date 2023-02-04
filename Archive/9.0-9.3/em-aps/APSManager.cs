using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.Gameplay.Players;
using System.IO;

namespace Eco.EM.APS
{
    public class APSManager: IModKitPlugin, IInitializablePlugin
    {
        private const string _configFile = "APSConfig";
        private const string _logFile = "APSLogs";
        private const string _dataFile = "APSData";
        internal const string ID = "EM_APS_Config";
        private const string _subPath = "/EM/AvancedPlayerSettings";

        public static APSConfig Config { get; private set; }
        public static APSData Data { get; private set; }

        public APSManager()
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
            
        }

        public string GetStatus() => "APS System Active";

        private APSConfig LoadConfig()
        {
            return FileManager<APSConfig>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _configFile);
        }

        private APSData LoadData()
        {
            return FileManager<APSData>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<APSConfig>.WriteTypeHandledToFile(Config, Base.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<APSData>.WriteTypeHandledToFile(Data, Base.SaveLocation + _subPath, _dataFile);
        }

        public static void Log(string tpr)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(tpr);
            stream.Close();
        }
    }
}
