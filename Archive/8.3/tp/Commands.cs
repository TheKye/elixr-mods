namespace Eco.EM.TP
{

    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Math;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Shared.Utils;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Shared.Localization;
    using System.IO;
    using Eco.Core.Plugins;
    using Eco.EM;

    public class NewTeleportationCommands : IChatCommandHandler
    {
        private static TeleportConfig Config => NewTeleportation.Instance.TeleportConfig.Config;
        private static TeleportLogs Logs => NewTeleportation.Instance.TeleportLogs;

        [ChatCommand( "Backs up and wipes all teleportation logs, (this will reset day counters for limits)","wipe-tp", ChatAuthorizationLevel.Admin)]
        public static void WipeTPList(User user)
        {
            NewTeleportation.Instance.Export();
            Logs.List.Clear();
            Logs.Requests.Clear();
            NewTeleportation.Instance.Save();

            ChatBase.Send(new ChatBase.Message(Localizer.DoStr("All teleport logs have been wiped, a backup was stored before."), user));
        }

        [ChatCommand( "Sets the calorie cost to use tp.", "tp-cost",ChatAuthorizationLevel.Admin)]
        public static void TpCost(User user, int CalorieCost)
        {
            Config.CalorieCost = CalorieCost;
            NewTeleportation.Instance.Save();

            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr("Teleportation cost has been set to {0}"), CalorieCost), user));
        }

        [ChatCommand( "Sets the length in seconds a request will be avaiable for before expiring.","tp-expiry", ChatAuthorizationLevel.Admin)]
        public static void TpExpiry(User user, int Seconds)
        {
            if (Seconds < 10)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error(Localizer.DoStr("Error: Expiry must be greater then or equal to 10.")), user));
                return;
            }

            Config.Expiry = Seconds;
            NewTeleportation.Instance.Save();

            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr("Teleportation requests will now expire after {0} seconds."), Seconds.ToString()), user));
        }

        [ChatCommand("Teleport to a friend. Admins can use this to teleport to specific co-ordinates","tp-cooldown",  ChatAuthorizationLevel.Admin)]
        public static void TpCooldown(User user, int CooldownSeconds)
        {
            Config.CooldownSeconds = CooldownSeconds;
            NewTeleportation.Instance.Save();

            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr("Teleportation cooldown has been set to {0} seconds."), CooldownSeconds), user));
        }

        [ChatCommand( "Teleport to a friend. Admins can use this to teleport to specific co-ordinates", "tpr",ChatAuthorizationLevel.User)]
        public static void TPR(User user, string Username)
        {
            Load();

            if (user.Stomach.Calories < Config.CalorieCost)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr("Error: You're too hungry to teleport"), user));
                return;
            }

            if (user.Name == Username)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr("Teleported to yourself. No calories burnt!"), user));
                return;
            }

            var log = new TeleportLog();
            var fromDate = Base.UTime - Config.CooldownSeconds;
            if (Logs.List.Count > 0)
                log = Logs.List.SingleOrDefault(
                    l =>
                    l.Date > fromDate &&
                    (
                        l.UserId == user.SteamId ||
                        l.UserId == user.SlgId
                    ));

            if (log != null && !string.IsNullOrWhiteSpace(log.UserId))
            {
                var timespanleft = 15 - (log.Date - fromDate);

                string localizedmessage = Localizer.DoStr("Error: Teleport is on cooldown");
                localizedmessage += $" ({timespanleft} seconds)";
                ChatBase.Send(new ChatBase.Message(localizedmessage, user));
                return;
            }

            var targetuser = Base.GetUserByName(Username);
            if (targetuser == null)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr("Error: User not found"), user));
                return;
            }

            if (!targetuser.LoggedIn)
            {
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr("{0} is Offline."), targetuser.Name), user));
                return;
            }

           // if (Logs.Requests => targetuser && Logs.Requests.Count > 0)
           // {
          //      ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr("{0} has a request already pending, please wait for them to accept or the request to expire."), targetuser.Name), user));
          //      return;
           // }

            if (Logs.Requests == null)
                Logs.Requests = new List<TeleportRequest>();

            Logs.Requests.Add(new TeleportRequest()
            {
                Requester = Base.WhoAmI(user),
                Receiver = Base.WhoAmI(targetuser),
                Timestamp = Base.UTime
            });

            var RequesterMessage = string.Format(Localizer.DoStr("A request has been sent to {0}"), targetuser.Name);
            var ReceiverMessage = string.Format(Localizer.DoStr("{0} wants to teleport to you. Type /tpa to accept, or it will expire in {1} seconds."), user.Name, Config.Expiry);

            ChatBase.Send(new ChatBase.Message(RequesterMessage, user));
            ChatBase.Send(new ChatBase.Message(ReceiverMessage, targetuser));

            SaveLogs();
        }

        [ChatCommand( "Accept the last requested teleport", "tpa",ChatAuthorizationLevel.User)]
        public static void TpAccept(User user, string Username = "")
        {
            Load();

            if (Logs.Requests == null)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr("You do not have any pending requests"), user));
                return;
            }

            ChatBase.Send(new ChatBase.Message(Logs.Requests.Count.ToString()));

            if (Logs.Requests.Count == 0)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr("You do not have any pending requests"), user));
                return;
            }

            var requesterId = Base.WhoAmI(user);
            var request = Logs.Requests.FirstOrDefault(r => r.Receiver == requesterId);
            var fromDate = request.Timestamp - Config.Expiry;

            // Take this opportunity to wipe any requests which may have expired


            if (request?.Requester == string.Empty)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr("You do not have any pending requests"), user));
                return;
            }

            var Requester = Base.GetUser(request.Requester);
            var Receiver = Base.GetUser(request.Receiver);

            if (Requester == null)
            {
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr("User: {0} is offline!"), Requester.Name), Receiver));
                return;
            }

            Requester.Player.SetPosition(Receiver.Position);
            Requester.Stomach.Calories -= Config.CalorieCost;

            Logs.List.Add(new TeleportLog()
            {
                Date = Base.UTime,
                UserId = Base.WhoAmI(Requester),
                TeleportedTo = Receiver.Name
            });

            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr("You have been teleported to {0}"), Receiver.Name), Requester));
            Logs.Requests.Remove(request);
            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr("{0} has been teleported to you."), Requester.Name), Receiver));
            Save();
        }

        public void ClearRequests(User user)
        {
            var requesterId = Base.WhoAmI(user);
            var request = Logs.Requests.FirstOrDefault(r => r.Receiver == requesterId);
            var fromDate = request.Timestamp - Config.Expiry;
            Logs.Requests.Where(r => r.Timestamp < fromDate).ForEach(r => { Logs.Requests.Remove(request); });
            Save();
        }

        private static void LoadConfig() => NewTeleportation.Instance.LoadConfig();
        private static void LoadLogs() => NewTeleportation.Instance.LoadLogs();
        private static void Load() => NewTeleportation.Instance.Load();

        private static void SaveConfig() => NewTeleportation.Instance.SaveConfig();
        private static void SaveLogs() => NewTeleportation.Instance.SaveLogs();
        private static void Save() => NewTeleportation.Instance.Save();
    }

    public class NewTeleportation : IModKitPlugin, IInitializablePlugin
    {
        public static NewTeleportation Instance { get; } = new NewTeleportation();

        const string _configFileName = "EMTeleportConfig";
        const string _logsFileName = "EMTeleportLogs";

        public PluginConfig<TeleportConfig> TeleportConfig;
        public TeleportLogs TeleportLogs;

        public IPluginConfig PluginConfig => TeleportConfig;
        public static string Receiver { get; internal set; }

        public NewTeleportation()
        {
            LoadConfig();
            LoadLogs();
        }

        public object GetEditObject() => TeleportConfig.Config;

        public void OnEditObjectChanged(object o, string param) => SaveConfig();

        public void Initialize(TimedTask timer) { }

        public override string ToString() => "Teleport";
        public string GetStatus() => "Active";

        public void LoadConfig()
        {
            TeleportConfig = new PluginConfig<TeleportConfig>(_configFileName);
        }
        public void LoadLogs()
        {
            TeleportLogs = FileManager<TeleportLogs>.ReadFromFile(Base.SaveLocation, _logsFileName);
        }
        public void Load()
        {
            LoadConfig();
            LoadLogs();
        }

        public void Export() => FileManager<TeleportLogs>.WriteToFile(TeleportLogs, Base.SaveLocation, _logsFileName);

        public void SaveConfig()
        {
            TeleportConfig.SaveAsync();
        }
        public void SaveLogs()
        {
            FileManager<TeleportLogs>.WriteToFile(TeleportLogs, Base.SaveLocation, _logsFileName);
        }
        public void Save()
        {
            SaveConfig();
            SaveLogs();
        }
    }
}