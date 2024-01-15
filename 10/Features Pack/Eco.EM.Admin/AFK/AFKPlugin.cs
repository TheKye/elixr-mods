using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.FileManager;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.EM.Framework.Utils;
using Eco.Core.Utils.Logging;
using Eco.EM.Framework.Logging;
using System.Drawing;
using Eco.Shared.Math;

namespace Eco.EM.Admin
{
    [ChatCommandHandler]
    public class AFKPlugin : Singleton<AFKPlugin>, IModKitPlugin, IInitializablePlugin
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        public static List<UserHistory> UserHistory = new();
        public Timer Timer;
        public static AFKConfiguration config = new();

        public static Action<string, bool> isAfk;

        public void Initialize(TimedTask timer)
        {
            foreach (var u in UserHistory)
            {
                DeleteOld(PlayerUtils.GetUser(u.UserId.ToString()));
            }

            Load();
            Timer = new(Timer_tick, null, 10000, 10000);
        }

        public AFKPlugin()
        {
            if (File.Exists(Path.Combine(Defaults.SaveLocation, filename)))
            {
                if (!Directory.Exists(Path.Combine(Defaults.SaveLocation + folderName)))
                    Directory.CreateDirectory(Path.Combine(Defaults.SaveLocation + folderName));

                File.Move(Path.Combine(Defaults.SaveLocation, filename), Path.Combine(Defaults.SaveLocation + folderName, filename));
            }
            Load();
        }

        static void Timer_tick(object state)
        {
            if (!config.Enabled)
            {
                return;
            }

            foreach (var user in PlayerUtils.OnlineUsers.ToList())
            {
                if (IsAfk(user))
                {
                    isAfk?.Invoke($"{user.Name} Is AFK", true);
                    user.Client.Disconnect(Localizer.DoStr("[EM] AFK Monitor"), Localizer.DoStr("Kicked for idling"));
                    DeleteForUser(user);
                    Log($"[{DateTime.Now:hh:mm:ss}] - {user.Name} - Kicked For Afk \n");
                }

                DeleteOld(user);
                UpdateHistory(user);
            }
        }

        static void UpdateHistory(User user)
        {
            var datenow = DateTime.Now.Ticks;

            UserHistory.Add(new UserHistory()
            {
                Timestamp = datenow,
                Position = user.Position,
                Rotation = user.Rotation,
                Facing = user.FacingDir,
                UserId = user.Id
            });
        }

        static void DeleteOld(User user)
        {
            var maxdate = DateTime.Now.Subtract(new TimeSpan(0, config.Interval, 0)).Ticks;
            UserHistory.Where(uh => uh.Timestamp <= maxdate && uh.UserId == user.Id).ToList().ForEach(uh =>
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

        // Write an AFK Detection system for User class with a warning message if they are close to the afk time
        
        
        
        
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

            bool PossiblyAfk = !history.Any(h => user.Position.XYZi() != first.Position.XYZi() && user.Rotation != first.Rotation && user.FacingDir != first.Facing);
            if (!PossiblyAfk)
                return false;

            var last = history.LastOrDefault();
            var difference = new TimeSpan(last.Timestamp).TotalSeconds - new TimeSpan(first.Timestamp).TotalSeconds;
            if (difference >= (config.Interval * 60))
                return true;
            if (difference >= (config.Interval * 60) / 1.09)
                ChatBaseExtended.CBInfoPane(Localizer.DoStr("AFK Warning"), Localizer.DoStr("If you continue to AFK, you will be automatically kicked from the server."), "AFK", user, ChatBase.PanelType.InfoPanel);

            return false;
        }

        public string GetStatus()
        {
            if (config.Enabled)
                return Localizer.DoStr(string.Format("AFK Monitor is running... (Idle Timer: {0} Minutes)", config.Interval / 60000));

            return Localizer.DoStr("AFK Monitor is stopped...");
        }

        public override string ToString() => Localizer.DoStr("EM - AFK Manager");

        private static void Load()
        {
            if (!loaded)
            {
                config = FileManager<AFKConfiguration>.ReadFromFile(Defaults.SaveLocation + folderName, filename);
                if (config == null)
                    config = new AFKConfiguration();
                loaded = true;
                Save();
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
        internal static bool Save()
        {
            try
            {
                FileManager<AFKConfiguration>.WriteToFile(config, Defaults.SaveLocation + folderName, filename);

                return true;
            }
            catch (Exception e)
            {
                ChatBaseExtended.CBError("Error: An unexpected error occurred while saving AFK Monitor Config\n" + e.Message);

                return false;
            }
        }
        public static void Log(string port)
        {
            LoggingUtils.Logger.Write(port);
        }

        public string GetCategory() => "Utilities";

        private static readonly string filename = "AFKConfig";
        private static readonly string folderName = "/EM/AFK";
        private static bool loaded = false;
    }
}