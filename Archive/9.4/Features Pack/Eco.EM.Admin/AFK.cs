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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Eco.Gameplay;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Items;

namespace Eco.EM.Admin
{
    public class AFK : IModKitPlugin, IChatCommandHandler, IInitializablePlugin
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        static readonly List<UserHistory> UserHistory = new();
        public Timer Timer;
        static AFKConfiguration config = new();

        public static Action<string, bool> isAfk;

        public void Initialize(TimedTask timer)
        {
            UserManager.OnUserLoggedIn.Add(u =>
            {
                Skill.AllItems.OfType<SkillScroll>().ForEach(x =>
                {
                    u.Inventory.AddItem(x, u);
                    x.OnUsed(u.Player, u.Inventory.NonEmptyStacks.Where(y => y.Item.TypeID == x.TypeID).First());
                    u.Inventory.TryRemoveItem(x.Type, u);
                });

                u.Skillset.Skills.ForEach(x =>
                {
                    if (x.Level == 0)
                        x.ForceSetLevel(1);
                });
            });


            DeleteOld();
            UpdateHistory();
            Load();
            Timer = new(Timer_tick, null, 1500, 1500);
        }

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

        static void Timer_tick(object state)
        {
            if (!config.Enabled)
            {
                return;
            }

            foreach (var user in Base.OnlineUsers)
            {
                if (IsAfk(user))
                {
                    isAfk?.Invoke($"{user.Name} Is AFK", true);
                    user.Client.Disconnect(Localizer.DoStr("[EM] AFK Monitor"), Localizer.DoStr("Kicked for idling"));
                    DeleteForUser(user);
                }
            }

            DeleteOld();
            UpdateHistory();
        }

        static void UpdateHistory()
        {
            var datenow = DateTime.Now.Ticks;

            Base.OnlineUsers.ForEach(u =>
            {
                UserHistory.Add(new UserHistory()
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
            var maxdate = DateTime.Now.Subtract(new TimeSpan(0, config.Interval, 0)).Ticks;
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
            if (!UserHistory.Any(uh => uh.UserId == user.Id))
                return false;
            if (user.IsAdmin && !config.KickAdmins)
                return false;

            var history = UserHistory.Where(uh => uh.UserId == user.Id).OrderBy(uh => uh.Timestamp).ToList();
            if (history.Count == 0)
            {
                return false;
            }

            var first = history.FirstOrDefault();

            bool PossiblyAfk = !history.Any(h => h.Position != first.Position && h.Rotation != first.Rotation);
            if (!PossiblyAfk)
                return false;

            var last = history.LastOrDefault();
            var difference = new TimeSpan(last.Timestamp).TotalSeconds - new TimeSpan(first.Timestamp).TotalSeconds;
            if (difference >= (config.Interval * 60))
                return true;

            if (difference >= (config.Interval * 60) / 1.1)
                ChatBaseExtended.CBInfoPane(Localizer.DoStr("AFK Warning"), Localizer.DoStr("If you continue to AFK, you will be automatically kicked from the server."), "AFK", user, ChatBase.PanelType.InfoPanel);

            return false;
        }

        public string GetStatus()
        {
            if (config.Enabled)
                return Localizer.DoStr(string.Format("AFK Monitor is running... (Idle Timer: {0} Minutes)", config.Interval / 60000));

            return Localizer.DoStr("AFK Monitor is stopped...");
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM - AFK Manager");
        }

        [ChatCommand("Elixr Mods AFK Monitor Plugin", ChatAuthorizationLevel.Admin)]
        public static void afk(IChatClient user)
        {
            ChatBaseExtended.CBInfo(string.Format("The Current Afk Timer is set to {0} Minutes", config.Interval), user);
        }

        [ChatSubCommand("afk", "Sets the length in minutes to let a player afk for.", "afk-timer", ChatAuthorizationLevel.Admin)]
        public static void AFKTimer(IChatClient user, int Minutes)
        {
            if (Minutes == 0)
            {
                config.Enabled = false;
                UserHistory.Clear();
                Save();
                ChatBaseExtended.CBInfo(string.Format("AFK Timer Has Been Disabled"), user);
                return;
            }
            if (!config.Enabled)
                config.Enabled = true;
            config.Interval = Minutes;
            Save();

            ChatBaseExtended.CBInfo(string.Format("Players will now be booted if they are idling for {0} minutes", Minutes), user);
        }



        [ChatSubCommand("afk", "Enables/Disables AFK Monitor", "enable-afk", ChatAuthorizationLevel.Admin)]
        public static void AFKEnable(IChatClient user, bool overrideEnable = false)
        {
            bool enabled = !overrideEnable || (config.Enabled = !config.Enabled);
            if (!enabled)
                UserHistory.Clear();
            Save();
            ChatBaseExtended.CBInfo(string.Format("AFK Monitor has been {0}", enabled ? Text.Positive("Enabled") : Text.Negative("Disabled")), user);
        }

        [ChatSubCommand("afk", "Enables AFK Monitor", "afk-kickadmin", ChatAuthorizationLevel.Admin)]
        public static void AFKKickAdmins(IChatClient user, bool kick = false)
        {
            config.KickAdmins = kick;
            Save();

            ChatBaseExtended.CBInfo(string.Format("AFK Monitor has been {0}", Text.Positive("Enabled")), user);
        }

        [ChatSubCommand("afk", "Reload afk Config", "afk-reload", ChatAuthorizationLevel.Admin)]
        public static void AfkReload(IChatClient user)
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

        private static readonly string filename = "AFKConfig";
        private static readonly string folderName = "/EM/AFK";
        private static readonly string logFolder = "/EM/AFK";
        private static readonly string logFile = "AFKLogs";
        private static bool loaded = false;
    }
}