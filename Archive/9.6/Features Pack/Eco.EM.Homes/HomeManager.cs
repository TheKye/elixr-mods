namespace Eco.EM.Homes
{
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
    using Eco.EM.Framework.Utils;
    using Eco.WorldGenerator;

    [Priority(PriorityAttribute.High)] // Need to start before WorldGenerator in order to listen for world generation finished event
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

            if (!File.Exists(Defaults.SaveLocation + _subPath + _dataFile))
                SaveData();

            if (!File.Exists(Defaults.SaveLocation + _subPath + _configFile))
                SaveConfig();

        }

        public void Initialize(TimedTask timer)
        {
            //Reset Saved home Data on new world generation
            WorldGeneratorPlugin.OnFinishGenerate.AddUnique(HandleWorldReset);

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

        public void HandleWorldReset()
        {
            ConsoleColors.PrintConsoleMultiColored(Defaults.appNameCon, System.ConsoleColor.Magenta, "New World Detected - Removing All Old Homes", System.ConsoleColor.White);
            Data.ResetHomeData();
            SaveData();
        }

        public static HomeConfig LoadConfig()
        {
            return FileManager<HomeConfig>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _configFile);
        }

        private HomeData LoadData()
        {
            return FileManager<HomeData>.ReadTypeHandledFromFile(Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void SaveConfig()
        {
            FileManager<HomeConfig>.WriteTypeHandledToFile(Config, Defaults.SaveLocation + _subPath, _configFile);
        }

        public static void SaveData()
        {
            FileManager<HomeData>.WriteTypeHandledToFile(Data, Defaults.SaveLocation + _subPath, _dataFile);
        }

        public static void Log(string port)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Defaults.SaveLocation + _subPath, _logFile));
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

        public string GetCategory() => "Elixr Mods";
    }
}
