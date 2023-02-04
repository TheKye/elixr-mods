namespace Eco.EM
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class MOTD : IChatCommandHandler, IModKitPlugin
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        public MOTD()
        {
            Load();
        }

        private static void Load()
        {
            if (!loaded)
            {
                try
                {
                    motds = FileManager<MOTDs>.ReadFromFile(Base.SaveLocation, filename);
                    if (motds == null)
                        motds = new MOTDs();

                    if (motds.Messages == null)
                        motds.Messages = new List<string>();

                    loaded = true;

                    if (motds.Messages.Count > 0)
                        Enable(null);
                }
                catch (Exception)
                {
                    motds.Messages = FileManager<List<string>>.ReadFromFile(Base.SaveLocation, filename);
                    if (motds.Messages == null)
                        motds.Messages = new List<string>();

                    loaded = true;

                    if (motds.Messages.Count > 0)
                        Enable(null);
                }
            }
        }

        public static void MotdReload()
        {
            if (loaded)
            {
                loaded = false;
                try
                {
                    motds = FileManager<MOTDs>.ReadFromFile(Base.SaveLocation, filename);
                    if (motds == null)
                        motds = new MOTDs();

                    if (motds.Messages == null)
                        motds.Messages = new List<string>();

                    loaded = true;

                    if (motds.Messages.Count > 0)
                        Enable(null);
                }
                catch (Exception)
                {
                    motds.Messages = FileManager<List<string>>.ReadFromFile(Base.SaveLocation, filename);
                    if (motds.Messages == null)
                        motds.Messages = new List<string>();

                    loaded = true;

                    if (motds.Messages.Count > 0)
                        Enable(null);
                }

            }
        }

        private static bool Save()
        {
            try
            {
                FileManager<MOTDs>.WriteToFile(motds, Base.SaveLocation, filename);
                
                return true;
            }
            catch (Exception e)
            {
                ChatBase.Send(new ChatBase.Message(
                   appName + "Error: An unexpected error occured while saving MOTD List\n" + e.Message
                ));

                return false;
            }
        }

        [ChatCommand("motd-interval", "Set the interval at which MOTDs will be displayed", ChatAuthorizationLevel.Admin)]
        public static void SetInterval(User user, int Seconds)
        {
            try
            {
                Load();

                motds.Interval = Seconds;
                if (Timer != null)
                    Timer = new Timer(DoSend, null, 0, motds.Interval * 1000);

                Save();

                ChatBase.Send(new ChatBase.Message(appName + $"MOTD Interval has been set to {Seconds} seconds", user));
            }
            catch (Exception e)
            {
                ChatBase.Send(new ChatBase.Message(appName + $"Error: {e.Message}", user));
            }
        }

        [ChatCommand("motd-mode", "Toggles the mode between Slow and Fast.", ChatAuthorizationLevel.Admin)]
        public static void ToggleMode(User user)
        {
            try
            {
                Load();
                motds.SlowMode = !motds.SlowMode;
                Save();

                var verb = (motds.SlowMode) ? "Slow" : "Fast";

                ChatBase.Send(new ChatBase.Message(appName + $"MOTD Mode has been toggled to {verb}", user));
            }
            catch (Exception e)
            {
                ChatBase.Send(new ChatBase.Message(appName + $"Error: {e.Message}", user));
            }
        }

        [ChatCommand("motd-on", "Swtich on MOTDs", ChatAuthorizationLevel.Admin)]
        public static void Enable(User user)
        {
            Load();

            if (motds.Messages.Count == 0)
            {
                if (user != null)
                    ChatBase.Send(new ChatBase.Message(appName + "Error: No MOTDs in list to enable", user));
                return;
            }

            Timer = new Timer(DoSend, null, 0, motds.Interval * 1000);

            if (user != null)
                ChatBase.Send(new ChatBase.Message(appName + "MOTD has been Enabled", user));
        }

        [ChatCommand("motd-off", "Swtich off MOTDs", ChatAuthorizationLevel.Admin)]
        public static void Disable(User user)
        {
            if (Timer == null)
            {
                ChatBase.Send(new ChatBase.Message(appName + "Error: MOTD is not active.", user));
                return;
            }

            Timer.Dispose();
            ChatBase.Send(new ChatBase.Message(appName + "MOTD has been disabled", user));
        }

        [ChatCommand("motd-add", "Add a new Message to the MOTD list", ChatAuthorizationLevel.Admin)]
        public static void Add(User user, string Message)
        {
            Load();

            if (string.IsNullOrWhiteSpace(Message))
            {
                ChatBase.Send(new ChatBase.Message(appName + "Syntax Error: /motd-add <message>", user));
                return;
            }

            motds.Messages.Add(Message);

            Save();

            ChatBase.Send(new ChatBase.Message(appName + $"Message Added: {Message}", user));
        }

        [ChatCommand("motd-remove", "Remove a message from the MOTD List", ChatAuthorizationLevel.Admin)]
        public static void Remove(User user, int MOTDID)
        {
            if (motds.Messages.Count <= MOTDID)
            {
                ChatBase.Send(new ChatBase.Message(appName + "Error: ID is out of range, please use /motd-list to get the Message ID.", user));
                return;
            }

            motds.Messages.RemoveAt(MOTDID);

            Save();

            ChatBase.Send(new ChatBase.Message(appName + "MOTD Deleted.", user));
        }

        [ChatCommand("motd-list", "List all messages in MOTD list", ChatAuthorizationLevel.Admin)]
        public static void List(User user)
        {
            Load();
            string MOTDList = "MOTD Message List\n";

            int count = 0;
            foreach (var msg in motds.Messages)
            {
                MOTDList += $"{count} {msg}\n";
                count++;
            }

            ChatBase.Send(new ChatBase.Message(MOTDList, user));
        }

        [ChatCommand("motd-send", "Skip the timer and send the next message.", ChatAuthorizationLevel.Admin)]
        public static void ManualDoSend()
        {
            ChatBase.Send(new ChatBase.Message(
                Send()
            ));
        }

        [ChatCommand("motd-reload", "Reload MOTD Settings", ChatAuthorizationLevel.Admin)]
        public static void Motdreload(User user)
        {
            MotdReload();
            ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + "MOTD Configs Reloaded"), user));
        }

        public static void DoSend(object state)
        {
            ChatBase.Send(new ChatBase.Message(
                Send()
            ));
        }

        private static string Send()
        {
            if (motds.Messages.Count == 0)
                return appName + "No MOTD Messages to send";

            var Message = string.Empty;

            if (motds.SlowMode)
            {
                Message = motds.Messages[MessageStep];
                MessageStep++;

                if (MessageStep >= motds.Messages.Count)
                    MessageStep = 0;
            }
            else
                foreach (string message in motds.Messages)
                    Message += message + "\n";

            return Message;
        }

        public string GetStatus()
        {
            Load();
            return "Running";
        }

        // DO NOT MODIFY THESE VALUES!
        private static Timer Timer;
        private static MOTDs motds = new MOTDs();
        private static int MessageStep = 0;
        private static bool loaded = false;
        private static string filename = "MOTD";
    }
}