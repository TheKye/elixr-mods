using Eco.EM.Framework.FileManager;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using System.Diagnostics;
using System.Reflection;
using Eco.Core.Plugins;
using Eco.EM.Framework.VersioningTools;

namespace Eco.EM.Framework
{
    public static class Base
    {
        internal const string oldLocation = "ElixrMods";
        internal const string saveLocation = "/Configs/Mods";
        internal const string fileFormat = ".json";
        public static string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public const string appName = "<color=purple>[EM Framework]:</color> ";
        public const string appNameCon = "[EM Framework]: ";

        public static List<User> OnlineUsers => UserManager.OnlineUsers.ToList();
        public static List<User> Users => UserManager.Users.ToList();
        public static List<User> Admins => UserManager.Admins.ToList();
        public static List<User> OnlineAdmins => OnlineUsers.Where(u => u.IsAdmin == true).ToList();

        public static string SaveLocation => GetRelevantDirectory();
        public static string AssemblyLocation => Directory.GetCurrentDirectory();

        public static double UTime => DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

        static string GetRelevantDirectory()
        {
            if (saveLocation.StartsWith("/"))
            {
                return AssemblyLocation + saveLocation;
            }

            return saveLocation;
        }

        static void CreateDirectoryIfNotExist() => CreateDirectoryIfNotExist(SaveLocation);
        public static void CreateDirectoryIfNotExist(string Path)
        {
            if (!Directory.Exists(SaveLocation))
            {
                Directory.CreateDirectory(SaveLocation);
            }
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
        }

        static string GetPathOf(string FileName)
        {
            if (FileName.Contains(fileFormat))
            {
                return Path.Combine(SaveLocation, FileName);
            }

            return Path.Combine(SaveLocation, FileName + fileFormat);
        }

        public static bool ConfigExists(string FileName) => File.Exists(GetPathOf(FileName));
        static string GetPath(string FileName)
        {
            if (!FileName.EndsWith(fileFormat))
            {
                FileName += fileFormat;
            }

            return Path.Combine(SaveLocation, FileName);
        }

        public static User GetUserByName(string UserName) => UserManager.FindUserByName(UserName);
        public static Player GetPlayerByName(string PlayerName) => GetUserByName(PlayerName).Player;
        public static User GetUser(string Filter) => UserManager.Users.FirstOrDefault(u => u.Name == Filter || u.SlgId == Filter || u.SteamId == Filter);

        public static string WhoAmI(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.SteamId))
                return user.SteamId;
            return user.SlgId;
        }

        // Sanitize strings
        public static string Sanitize(string dirty)
        {
            char[] whitespace = { ' ' };
            return dirty.TrimStart(whitespace).TrimEnd(whitespace).ToLower();
        }

        public static string CleanSanitize(string dirty)
        {
            char[] whitespace = { ' ' };
            return dirty.Replace(" ", "").TrimStart(whitespace).TrimEnd(whitespace).ToLower();
        }

        public static void Debug(string s)
        {
            Log.WriteWarningLineLocStr(Localizer.DoStr(s));
        }

        public static BaseConfig Config
        {
            get
            {
                return FileManager<BaseConfig>.ReadFromFile(SaveLocation, "Base.EM");
            }
            set
            {
                FileManager<BaseConfig>.WriteToFile(value, SaveLocation, "Base.EM");
            }
        }     
    }

    [LocDisplayName("EM Base Plugin")]
    public class BasePlugin : Singleton<BasePlugin>, IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public EMVersioning Versions = new EMVersioning();
       
        private PluginConfig<BaseConfig> config;
        public BasePlugin()
        {
            this.config = new PluginConfig<BaseConfig>("EMBase");
        }

        public IPluginConfig PluginConfig => this.config;
        public BaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();

        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
        public string GetStatus() => $"Loaded and using Version: {Base.version}, All Systems Active";

        public void Initialize(TimedTask timer)
        {
            if (Config.VersionDisplayEnabled)
                Versions.GetInit();

            if (Config.VanillaStackSizeChanger)
                StackSizeController.Obj.InitializeStackConfig(Config, true);
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM Framework");
        }
    }
}