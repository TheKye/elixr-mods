using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.FileManager;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.IO;
using System.Threading;

namespace Eco.EM.Admin
{
    public class AFK : IModKitPlugin, IInitializablePlugin, IChatCommandHandler
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        static Timer afkCheck = new Timer(Tick, null, 0, 0);
        static AFKConfiguration config = new AFKConfiguration();

        public AFK()
        {
            if (File.Exists(Path.Combine(Base.SaveLocation, filename)))
            {
                if (!Directory.Exists(Path.Combine(Base.SaveLocation + folderName)))
                    Directory.CreateDirectory(Path.Combine(Base.SaveLocation + folderName));

                File.Move(Path.Combine(Base.SaveLocation, filename), Path.Combine(Base.SaveLocation + folderName, filename));
            }
            Load();
        }

        public void Initialize(TimedTask timer)
        {
            UserManager.OnUserLoggedIn.Add(u =>
            {
                u.SetState("lastMoved", DateTime.Now.Ticks);
                u.OnMoved.Add(() => u.SetState("lastMoved", DateTime.Now.Ticks));
            });

            afkCheck = new Timer(Tick, null, config.AFKCheck, 0);
        }

        static void Tick(object state)
        {
            if (!config.Enabled) { afkCheck = null; return; }

            var checkTime = DateTime.Now.Ticks;
            foreach (var user in Base.OnlineUsers)
            {
                var idleTime = checkTime - (long)user.GetState("lastMoved");
                if (idleTime >= TimeSpan.TicksPerMillisecond * config.Interval)
                    user.Client.Disconnect(Localizer.DoStr("[EM] AFK Monitor"), "Kicked for idling");
                else if (idleTime >= TimeSpan.TicksPerMillisecond * config.Interval / 2)
                    ChatBaseExtended.CBInfoPane("AFK Warning", Localizer.DoStr("If you continue to AFK, you will be automatically kicked from the server."), "AFKWarning", user, true, true);
            }

            afkCheck = new Timer(Tick, null, config.AFKCheck, 0);
        }

        public string GetStatus() => config.Enabled? 
            Localizer.DoStr(string.Format("AFK Monitor is running... (Idle Timer: {0} Minutes)", config.Interval / 60000)):
            Localizer.DoStr("AFK Monitor is stopped...");

        public override string ToString() => Localizer.DoStr("EM - AFK Manager");

        [ChatCommand("Elixr Mods AFK Monitor Plugin", ChatAuthorizationLevel.Admin)]
        public static void afk(User user) 
        {
            ChatBaseExtended.CBInfo(string.Format("The Current Afk Timer is set to {0} Minutes", config.Interval / 60000), user);
        }

        [ChatSubCommand("afk", "Sets the length in minutes to let a player afk for.", "afk-timer", ChatAuthorizationLevel.Admin)]
        public static void AFKTimer(User user, int Minutes)
        {
            if(Minutes == 0)
            {
                config.Enabled = false;
                Save();
                afkCheck = null;
                ChatBaseExtended.CBInfo(string.Format("AFK Timer Has Been Disabled"), user);
                return;
            }

            if (!config.Enabled)
                config.Enabled = true;
            config.Interval = Minutes * 60 * 1000;
            Save();

            ChatBaseExtended.CBInfo(string.Format("Players will now be booted if they are idling for {0} minutes", Minutes), user);
        }

        [ChatSubCommand("afk", "Enables AFK Monitor", "afk-on", ChatAuthorizationLevel.Admin)]
        public static void AFKOn(User user)
        {
            config.Enabled = true;
            Save();
            afkCheck = new Timer(Tick, null, 0, 0);

            ChatBaseExtended.CBInfo(string.Format("AFK Monitor has been {0}", Text.Positive("Enabled")), user);
        }

        [ChatSubCommand("afk", "Disables AFK Monitor", "afk-off", ChatAuthorizationLevel.Admin)]
        public static void AFKOff(User user)
        {
            config.Enabled = false;
            Save();
            afkCheck = null;

            ChatBaseExtended.CBInfo(string.Format("AFK Monitor has been {0}", Text.Negative("Disabled")), user);
        }
        [ChatSubCommand("afk", "Reload afk Config", "afk-reload", ChatAuthorizationLevel.Admin)]
        public static void AfkReload(User user)
        {
            Reload();
            ChatBaseExtended.CBInfo(appName + "AFK configs Reloaded", user);
        }

        private static void Load()
        {
            if (!loaded)
            {
                config = FileManager<AFKConfiguration>.ReadFromFile(Base.SaveLocation + folderName, filename);
                if (config == null)
                    config = new AFKConfiguration();
                loaded = true;
            }
        }
        public static void Reload()
        {
            if (loaded)
            {
                loaded = false;
                if (config == null)
                    config = new AFKConfiguration();
                loaded = true;
            }
        }
        private static bool Save()
        {
            try
            {
                FileManager<AFKConfiguration>.WriteToFile(config, Base.SaveLocation + folderName, filename);

                return true;
            }
            catch (Exception e)
            {
                ChatBaseExtended.CBError("Error: An unexpected error occurred while saving AFK Monitor Config\n" + e.Message);

                return false;
            }
        }

        private static string filename = "AFKConfig";
        private static string folderName = "/EM/AFK";
        private static bool loaded = false;
    }
}