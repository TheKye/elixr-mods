namespace Eco.EM.Homes
{
    using Eco.Gameplay.Players;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using System.IO;
    using Eco.EM.Framework;
    using Eco.EM.Framework.FileManager;
    using Eco.Shared.Localization;

    public class HomeManager : IModKitPlugin, IInitializablePlugin
    {
        private const string _configFile = "HomesConfig";
        private const string _logFile = "HomesLogs";
        private const string _dataFile = "HomesData";
        private const string _subPath = "/EM/Homes";
        internal const string ID = "EM_Homes_Config";

        public static HomeConfig Config { get; set; }
        public static HomeData Data { get; private set; }

        public HomeManager()
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
                {
                    Data.Users.Add(u.Name, new HomeUserData());
                    SaveData();
                }

                if (Data.GetHomeUserData(u.Name).Homes == null)
                {
                    Data.GetHomeUserData(u.Name).ClearHomes();
                    SaveData();
                }
            });
        }

        public static HomeConfig LoadConfig()
        {
            return FileManager<HomeConfig>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _configFile);
        }

        private HomeData LoadData()
        {
            return FileManager<HomeData>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<HomeConfig>.WriteTypeHandledToFile(Config, Base.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<HomeData>.WriteTypeHandledToFile(Data, Base.SaveLocation + _subPath, _dataFile);
        }

        public static void Log(string port)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(port);
            stream.Close();
        }

        public string GetStatus()
        {
            return "EM Home Management Active";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM - Homes");
        }
    }
}
