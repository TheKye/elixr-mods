namespace Eco.EM.TP
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using System;
    using Eco.Shared.Localization;
    using Eco.EM.Framework;
    using Eco.EM.Framework.ChatBase;
    using Eco.EM.Framework.Groups;

    public class TeleportCommands : IChatCommandHandler
    {

        [ChatCommand("Elixr Mods Teleport Plugin", ChatAuthorizationLevel.Admin)]
        public static void Teleportation() { }

        [ChatCommand("Lets you know how many teleports you have left for the day")]
        public static void Teleports(User user)
        {
            var userData = TeleportManager.Data.GetTeleportUserData(user.Name);
            var total = TeleportManager.Data.GetMaxTeleports(user) - userData.Teleports;

            if (TeleportManager.Data.GetMaxTeleports(user) == int.MaxValue)
                ChatBaseExtended.CBInfoBox($"You have an unlimited amount of Teleports left today", user);
            else if (TeleportManager.Data.GetMaxTeleports(user) <= userData.Teleports)
                ChatBaseExtended.CBInfoBox($"You have no Teleports left today, you get a total amount of: {TeleportManager.Data.GetMaxTeleports(user)} Teleports Per Day", user);
            else
                ChatBaseExtended.CBInfoBox($"You have {total} Teleports left today, you get a total amount of: {TeleportManager.Data.GetMaxTeleports(user)} Teleports Per Day", user);
        }

        [ChatSubCommand("Teleportation", "Configures a setting in the teleport config. Settings: max,cost, expiry, cooldown.", "tp-config", ChatAuthorizationLevel.Admin)]
        public static void ConfigureTP(User user, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            if (!TeleportManager.Config.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Base.appName + $"{setting} is not a valid configuration option. Please use: Max, Cost, Expiry or Cooldown", user);
                return;
            }

            switch (setting)
            {
                case "max":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>TP Max Teleports</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Teleport Calorie Cost</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                case "expiry":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Teleportation Expiry</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Teleportation Cooldown Seconds</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Base.appName + $"Teleportation {setting} has been set to {value}.", user);
                    break;
            }

            TeleportManager.SaveConfig();
        }

        [ChatSubCommand("Teleportation", "Configures a setting a groups teleport config. Settings: max,cost,cooldown.", "tp-grpconfig", ChatAuthorizationLevel.Admin)]
        public static void GroupConfigureTP(User user, string groupName, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{groupName} could not be found.", user);
                return;
            }

            var groupConfig = group.Permissions.Find(p => p.Identifier == TeleportManager.ID) as TeleportConfig;

            if (groupConfig == null)
            {
                groupConfig = TeleportManager.Config.DeepCopy();
                group.AddPermission(groupConfig);
            }

            if (setting == "expiry")
            {
                ChatBaseExtended.CBError(Base.appName + $"Groups cannot have a different expiry to the serverwide set.", user);
                return;
            }

            if (setting == "max" && value < TeleportManager.Config.MaxTeleports && value != 0 && value != -1)
            {
                ChatBaseExtended.CBError(Base.appName + $"Groups cannot have a smaller maximum value than the serverwide maximum {TeleportManager.Config.MaxTeleports}. Reduce the serverwide maximum first.", user);
                return;
            }

            if (!groupConfig.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Base.appName + $"{setting} is not a valid configuration option.", user);
                return;
            }

            switch (setting)
            {
                case "max":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>TP Max Teleports</color> for {group.GroupName} has been changed to <color=green>{value}</color>.", user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Teleport Calorie Cost</color> for {group.GroupName} has been changed to <color=green>{value}</color>.", user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Teleportation Cooldown Seconds</color> for {group.GroupName} has been changed to <color=green>{value}</color>.", user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Base.appName + $"Teleportation {setting} for {group.GroupName} has been set to {value}.", user);
                    break;
            }

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("Teleportation", "Teleport to a friend.", "tpr", ChatAuthorizationLevel.User)]
        public static void Request(User user, string dest)
        {
            DateTime check = DateTime.Now;
            TeleportManager.Data.ClearExpired(check);
            TeleportManager.Data.ClearCoolDown(check, user);
            TeleportManager.Data.ResetTeleports(check);

            var userData = TeleportManager.Data.GetTeleportUserData(user.Name);

            // The Many conditions to check before we can teleport
            if (userData == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"Your data could not be found. Something has gone terribly wrong. Contact an admin.", user);
                return;
            }

            if (TeleportManager.Data.GetMaxTeleports(user) == 0)
            {
                ChatBaseExtended.CBError(Base.appName + $"You do not have access to use this command.", user); // Add the time remaining here??
                return;
            }

            if (userData.Teleports >= TeleportManager.Data.GetMaxTeleports(user))
            {
                ChatBaseExtended.CBError(Base.appName + $"You have exhausted all your teleports today. ({TeleportManager.Data.GetMaxTeleports(user) - userData.Teleports} out of {TeleportManager.Data.GetMaxTeleports(user)})", user); // Add the time remaining here??
                return;
            }

            if (userData.PendingRequest)
            {
                ChatBaseExtended.CBError(Base.appName + $"You have a pending request. Please wait for it to be accepted or to expire.", user);
                return;
            }

            if (userData.OnCoolDown)
            {
                ChatBaseExtended.CBError(Base.appName + $"Your ability to teleport is on cool down. It will reset in {Math.Ceiling(TeleportManager.Data.GetMinCoolDownTime(user) - check.Subtract(userData.CoolDownSetTime).TotalSeconds)} seconds.", user);
                return;
            }

            if (user.Stomach.Calories < TeleportManager.Data.GetMinCalorieCost(user))
            {
                ChatBaseExtended.CBError(Base.appName + "You are too hungry to teleport.", user);
                return;
            }

            var targetUser = Base.GetUserByName(dest);
            if (user == targetUser)
            {
                ChatBaseExtended.CBInfo(Base.appName + "Teleported to yourself. No calories burnt!", user);
                return;
            }

            if (targetUser == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{dest} could not be found to teleport to.", user);
                return;
            }

            if (!targetUser.IsOnline)
            {
                ChatBaseExtended.CBError(Base.appName + $"{targetUser.Name} is not online to teleport to.", user);
                return;
            }

            var targetData = TeleportManager.Data.GetTeleportUserData(targetUser.Name);

            if (targetData.PendingAccept)
            {
                ChatBaseExtended.CBInfoBox(Base.appName + $"{targetUser.Name} already has a pending request. Please wait for it to be accepted or to expire.", user);
                return;
            }

            TeleportRequest tpr = new TeleportRequest(user.Name, targetUser.Name);

            if (!TeleportManager.Data.AddRequest(tpr))
            {
                ChatBaseExtended.CBError(Base.appName + $"You have a pending request. Please wait for it to be accepted or to expire.", user);
                return;
            }

            targetData.SetPendingAccept(true);
            userData.SetPendingRequest(true);

            ChatBaseExtended.CBInfoBox(Base.appName + $"You have sent a request to {targetUser.Name}. Please wait for it to be accepted or to expire.", user);
            ChatBaseExtended.CBInfoBox(Base.appName + $"You have recieved a teleport request from {user.Name}. Please type /tpa to accept, it will expire in {TeleportManager.Config.Expiry} seconds.", targetUser);
        }

        [ChatSubCommand("Teleportation", "Accept the requested teleport.", "tpa", ChatAuthorizationLevel.User)]
        public static void Accept(User user)
        {
            DateTime check = DateTime.Now;
            TeleportManager.Data.ClearExpired(check);

            var targetData = TeleportManager.Data.GetTeleportUserData(user.Name);

            TeleportRequest tpr = TeleportManager.Data.GetTeleportRequestViaReceiver(user.Name);

            if (tpr == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"You do not have a pending teleport request to accept.", user);
                return;
            }

            User srcUser = Base.GetUserByName(tpr.Requester);
            var srcData = TeleportManager.Data.GetTeleportUserData(srcUser.Name);

            targetData.SetPendingAccept(false);
            srcData.SetPendingRequest(false);
            TeleportManager.Data.ClearRequest(tpr);

            if (!srcUser.IsOnline)
            {
                ChatBaseExtended.CBError(Base.appName + $"{srcUser.Name} is no longer online.", user);
                return;
            }

            srcData.SetCoolDown();
            srcData.Teleport();
            srcUser.Player.SetPosition(user.Player.Position);
            srcUser.Stomach.BurnCalories(TeleportManager.Data.GetMinCalorieCost(srcUser));

            var total = TeleportManager.Data.GetMaxTeleports(srcUser) - srcData.Teleports;
            if (TeleportManager.Data.GetMaxTeleports(user) == int.MaxValue)
                ChatBaseExtended.CBInfo(Base.appName + $"You teleported to {user.Name}. You have an unlimited amount of Teleports left today", srcUser);
            else
                ChatBaseExtended.CBInfo(Base.appName + $"You teleported to {user.Name}. You have {total} Teleports left today", srcUser);

            ChatBaseExtended.CBInfo(Base.appName + $"{srcUser.Name} teleported to you.", user);
            ChatBaseExtended.CBInfo(Base.appName + $"You teleported to {user.Name}. You have {TeleportManager.Data.GetMaxTeleports(user) - srcData.Teleports} Teleports left today", srcUser);

            TeleportManager.Log(tpr.Log());
            TeleportManager.SaveData();
        }

        [ChatSubCommand("Teleportation", "Teleport Target Player To Yourself or Everyone to yourself, Admin Only", "tphere", ChatAuthorizationLevel.Admin)]
        public static void TeleportHere(User user, string username)
        {
            if (username.ToLower() == "all")
            {
                if (Base.OnlineUsers.Count >= 2)
                {
                    foreach (var pl in Base.OnlineUsers)
                    {
                        if (pl == user)
                        {
                            continue;
                        }
                        else
                        {
                            pl.Player.SetPosition(user.Position);
                            if (TeleportManager.Config.postMessge)
                                ChatBaseExtended.CBWarning(Base.appName + $"The Admin: {user}, Has summoned you!", pl);
                        }
                    }
                    ChatBaseExtended.CBInfo(Base.appName + $"Everyone online Has Been Summoned!", user);
                    return;
                }
                else
                {
                    ChatBaseExtended.CBError(Base.appName + $"There is no one online right now, please try again later.", user);
                    return;
                }
            }

            var tpPlayer = Base.GetUserByName(username);
            if (tpPlayer == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"Could not find User: {username}, did you type the name correctly?", user);
                return;
            }
            if(tpPlayer == user)
            {
                ChatBaseExtended.CBError(Base.appName + $"What are you trying to pull here?", user);
                return;
            }
            if (!tpPlayer.IsOnline)
            {
                ChatBaseExtended.CBError(Base.appName + $"{tpPlayer} is not online right now.", user);
                return;
            }
            else
            {
                tpPlayer.Player.SetPosition(user.Position);
                if (TeleportManager.Config.postMessge)
                    ChatBaseExtended.CBWarning(Base.appName + $"The Admin: {user}, Has summoned you!", tpPlayer);
                return;
            }

        }

        [ChatSubCommand("Teleportation", "Teleport all members of a specific group to yourself", "tphere-grp", ChatAuthorizationLevel.Admin)]
        public static void TeleportGroupHere(User user, string groupName)
        {
            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"the group {groupName} could not be found.", user);
                return;
            }

            foreach (var usr in group.GroupUsers)
            {
                var pl = Base.GetUserByName(usr.Name);
                if (pl.IsOnline)
                {
                    if(pl == user)
                    {
                        continue;
                    }
                    pl.Player.SetPosition(user.Position);
                    if (TeleportManager.Config.postMessge)
                        ChatBaseExtended.CBWarning(Base.appName + $"The Admin: {user}, Has summoned you!", pl);
                }
            }
            return;
        }

        [ChatSubCommand("Teleportation", "Turn On or off Notification messages for tphere", "tpmessage", ChatAuthorizationLevel.Admin)]
        public static void TeleportHereMessage(User user, bool input)
        {

            TeleportManager.Config.UpdateConfigBool(input);
            TeleportManager.SaveConfig();
            switch (input)
            {
                case true:
                    ChatBaseExtended.CBInfo(Base.appName + $"Teleport Here Message is now set too On, it will now notify users when they are being teleported too you using this command.", user);
                    break;
                case false:
                    ChatBaseExtended.CBInfo(Base.appName + $"Teleport Here Message is now set too Off, Players will no longer be notified if you use the tphere command.", user);
                    break;
            }
        }

        [ChatSubCommand("Teleportation", "Reloads the Teleportation Config if you edit the files directly ( Only Works with default Config!)", "tp-reload", ChatAuthorizationLevel.Admin)]
        public static void tpReload(User user)
        {
            TeleportManager.Config = TeleportManager.LoadConfig();
            ChatBaseExtended.CBInfo(Base.appName + "Teleportation Config Reloaded, use /tp-settings to see if the reload worked.");
        }

        [ChatSubCommand("Teleportation", "Check The Current Settings of your teleportation configuration", "tp-settings", ChatAuthorizationLevel.Admin)]
        public static void tpSettings(User user)
        {
            string _message = "";
            var group = GroupsManager.API.AllGroups();
            _message += "Default Server Values \n";
            _message += "Calorie Cost: " + TeleportManager.Config.CalorieCost + "\n";
            _message += "Max Teleports: " + TeleportManager.Config.MaxTeleports + "\n";
            _message += "Cooldown: " + TeleportManager.Config.CooldownSeconds + "\n";
            _message += "Teleport Expiriy Time: " + TeleportManager.Config.Expiry + "\n";

            if (group != null)
            {
                _message += "\n<color=green>Group Settings</color> \n\n";
                group.ForEach(grp =>
                {
                    var tpPermission = grp.Permissions.Find(p => p.Identifier == TeleportManager.ID);
                    if (tpPermission != null)
                    {
                        var config = (TeleportConfig)tpPermission;
                        _message += "Group Name: " + $"<color=green>{grp.GroupName}</color>" + "\n";
                        _message += "Calorie Cost: " + config.CalorieCost + "\n";
                        _message += "Max Teleports: " + config.MaxTeleports + "\n";
                        _message += "Cooldown: " + config.CooldownSeconds + "\n";
                        _message += "Teleport Expiriy Time: " + config.Expiry + "\n";
                        _message += "\n";
                    }
                });
            }

            ChatBaseExtended.CBInfoPane("TP Configuration Settings", _message, "PM", user);
        }
    }
}