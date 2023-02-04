namespace Eco.EM
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class AFK : IModKitPlugin, IChatCommandHandler
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        static Timer timer = new Timer(timer_tick, null, 0, 0);
        static List<UserHistory> UserHistory = new List<UserHistory>();
        static AFKConfiguration config = new AFKConfiguration();

        public AFK()
        {

        }

        static void timer_tick(object state)
        {
            Load();

            if (!config.Enabled)
            {
                timer = null;
                return;
            }

            foreach (var user in Base.OnlineUsers)
            {
                if (IsAfk(user))
                {
                    user.Client.Disconnect(Localizer.DoStr("[EM] AFK Monitor"), "Kicked for idling");
                    DeleteForUser(user);
                }
            }

            UpdateHistory();
            DeleteOld();

            timer = new Timer(timer_tick, null, 15000, 0);
        }

        static void UpdateHistory()
        {
            var datenow = DateTime.Now.Ticks;

            Base.OnlineUsers.ForEach(u =>
            {
                UserHistory.Add(new EM.UserHistory()
                {
                    Timestamp = datenow,
                    Position = u.Position,
                    Rotation = u.Rotation,
                    UserId = u.Id
                });
            });
        }

        static void DeleteOld()
        {
            var maxdate = DateTime.Now.Subtract(new TimeSpan(1, 0, 0)).Ticks;
            UserHistory.Where(uh => uh.Timestamp <= maxdate).ToList().ForEach(uh =>
            {
                UserHistory.Remove(uh);
            });
        }

        static void DeleteForUser(User user)
        {
            UserHistory.Where(uh => uh.UserId == user.Id).ToList().ForEach(uh =>
            {
                UserHistory.Remove(uh);
            });
        }

        static bool IsAfk(User user)
        {
            if (UserHistory.Count(uh => uh.UserId == user.Id) == 0)
                return false;

            var history = UserHistory.Where(uh => uh.UserId == user.Id).OrderBy(uh => uh.Timestamp).ToList();
            if (history.Count == 0)
                return false;

            var first = history.FirstOrDefault();

            bool PossiblyAfk = (history.Count(h => h.Position != first.Position && h.Rotation != first.Rotation) < 1);
            if (!PossiblyAfk)
                return false;

            var last = history.LastOrDefault();
            var difference = new TimeSpan(last.Timestamp).TotalSeconds - new TimeSpan(first.Timestamp).TotalSeconds;
            if (difference >= (config.Interval / 1000))
                return true;

            if (difference >= (config.Interval * 0.8 / 1000))
                user.Player.OpenInfoPanel(Localizer.DoStr("AFK Warning"), Localizer.DoStr("If you continue to AFK, you will be automatically kicked from the server."));

            return false;
        }

        public string GetStatus()
        {
            if (config.Enabled)
                return Localizer.DoStr(string.Format("AFK Monitor is running... (Idle Timer: {0} Minutes)", config.Interval / 60000));

            return Localizer.DoStr("AFK Monitor is stopped...");
        }

        [ChatCommand("afk-timer", "Sets the length in minutes to let a player afk for.", ChatAuthorizationLevel.Admin)]
        public static void AFKTimer(User user, int Minutes)
        {
            config.Interval = Minutes * 60 * 1000;
            Save();

            ChatBase.Send(new ChatBase.Message(Localizer.DoStr(string.Format("Players will now be booted if they are idling for {0} minutes", Minutes)), user));
        }

        [ChatCommand("afk-on", "Enables AFK Monitor", ChatAuthorizationLevel.Admin)]
        public static void AFKOn(User user)
        {
            config.Enabled = true;
            Save();
            timer = new Timer(timer_tick, null, 0, 0);

            ChatBase.Send(new ChatBase.Message(Localizer.DoStr(string.Format("AFK Monitor has been {0}", Text.Positive(Localizer.DoStr("Enabled")))), user));
        }

        [ChatCommand("afk-off", "Disables AFK Monitor", ChatAuthorizationLevel.Admin)]
        public static void AFKOff(User user)
        {
            config.Enabled = false;
            UserHistory.Clear();
            Save();
            timer = null;

            ChatBase.Send(new ChatBase.Message(Localizer.DoStr(string.Format("AFK Monitor has been {0}", Text.Negative(Localizer.DoStr("Disabled")))), user));
        }
        [ChatCommand("afk-reload", "Reload afk Config", ChatAuthorizationLevel.Admin)]
        public static void reload(User user)
        {
            Reload();
            ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + "AFK configs Reloaded"), user));
        }

        private static void Load()
        {
            if (!loaded)
            {
                config = FileManager<AFKConfiguration>.ReadFromFile(Base.SaveLocation, filename);
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
                config = FileManager<AFKConfiguration>.ReadFromFile(Base.SaveLocation, filename);
                if (config == null)
                    config = new AFKConfiguration();
                loaded = true;
            }
        }
        private static bool Save()
        {
            try
            {
                FileManager<AFKConfiguration>.WriteToFile(config, Base.SaveLocation, filename);

                return true;
            }
            catch (Exception e)
            {
                ChatBase.Send(new ChatBase.Message(
                    Localizer.DoStr("Error: An unexpected error occured while saving AFK Monitor Config\n") + e.Message
                ));

                return false;
            }
        }

        private static string filename = "AFKConfig";
        private static bool loaded = false;
    }
}