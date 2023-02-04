namespace Eco.EM.TP
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using System;
    using Eco.Shared.Localization;
    using Eco.EM.Framework;
    using Eco.EM.Framework.ChatBase;
    using Eco.EM.Framework.Groups;
    using Eco.Gameplay.Systems.Messaging.Chat.Commands;
    using Eco.EM.Framework.Utils;

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
                ChatBaseExtended.CBInfoBox(Localizer.DoStr("You have an unlimited amount of Teleports left today"), user);
            else if (TeleportManager.Data.GetMaxTeleports(user) <= userData.Teleports)
                ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("You have no Teleports left today, you get a total amount of: {0} Teleports Per Day"), TeleportManager.Data.GetMaxTeleports(user)), user);
            else
                ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("You have {0} Teleports left today, you get a total amount of: {1} Teleports Per Day"), total, TeleportManager.Data.GetMaxTeleports(user)), user);
        }

        [ChatSubCommand("Teleportation", "Configures a setting in the teleport config. Settings: max,cost, expiry, cooldown.", "tp-config", ChatAuthorizationLevel.Admin)]
        public static void ConfigureTP(User user, string setting, int value)
        {
            setting = StringUtils.Sanitize(setting);

            if (!TeleportManager.Config.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is not a valid configuration option. Please use: Max, Cost, Expiry or Cooldown"),setting), user);
                return;
            }

            switch (setting)
            {
                case "max":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>TP Max Teleports</color> has been changed to <color=green>{0}</color>."),value), user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Teleport Calorie Cost</color> has been changed to <color=green>{0}</color>."), value), user);
                    break;
                case "expiry":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Teleportation Expiry</color> has been changed to <color=green>{0}</color>."), value), user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Teleportation Cooldown Seconds</color> has been changed to <color=green>{0}</color>."), value), user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("Teleportation {0} has been set to {1}."), setting, value), user);
                    break;
            }

            TeleportManager.SaveConfig();
        }

        [ChatSubCommand("Teleportation", "Configures a setting a groups teleport config. Settings: max,cost,cooldown.", "tp-grpconfig", ChatAuthorizationLevel.Admin)]
        public static void GroupConfigureTP(User user, string groupName, string setting, int value)
        {
            setting = StringUtils.Sanitize(setting);

            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} could not be found."), groupName), user);
                return;
            }

            if (group.Permissions.Find(p => p.Identifier == TeleportManager.ID) is not TeleportConfig groupConfig)
            {
                groupConfig = TeleportManager.Config.DeepCopy();
                group.AddPermission(groupConfig);
            }

            if (setting == "expiry")
            {
                ChatBaseExtended.CBError(Defaults.appName + $"Groups cannot have a different expiry to the serverwide set.", user);
                return;
            }

            if (setting == "max" && value < TeleportManager.Config.MaxTeleports && value != 0 && value != -1)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("Groups cannot have a smaller maximum value than the serverwide maximum {0}. Reduce the serverwide maximum first."), TeleportManager.Config.MaxTeleports), user);
                return;
            }

            if (!groupConfig.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is not a valid configuration option."), setting), user);
                return;
            }

            switch (setting)
            {
                case "max":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>TP Max Teleports</color> for {0} has been changed to <color=green>{1}</color>."),group.GroupName, value), user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Teleport Calorie Cost</color> for {0} has been changed to <color=green>{1}</color>."), group.GroupName, value), user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Teleportation Cooldown Seconds</color> for {0} has been changed to <color=green>{1}</color>."), group.GroupName, value), user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("Teleportation {0} for {1} has been set to {2}."),setting, group.GroupName, value), user);
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
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("Your data could not be found. Something has gone terribly wrong. Contact an admin."), user);
                return;
            }

            if (TeleportManager.Data.GetMaxTeleports(user) == 0)
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You do not have access to use this command."), user); // Add the time remaining here??
                return;
            }

            if (userData.Teleports >= TeleportManager.Data.GetMaxTeleports(user) && TeleportManager.Data.GetMaxTeleports(user) != 99)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("You have exhausted all your teleports today. ({0} out of {1})"), TeleportManager.Data.GetMaxTeleports(user) - userData.Teleports, TeleportManager.Data.GetMaxTeleports(user)), user); // Add the time remaining here??
                return;
            }

            if (userData.PendingRequest)
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You have a pending request. Please wait for it to be accepted or to expire."), user);
                return;
            }

            if (userData.OnCoolDown)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("Your ability to teleport is on cool down. It will reset in {0} seconds."), Math.Ceiling(TeleportManager.Data.GetMinCoolDownTime(user) - check.Subtract(userData.CoolDownSetTime).TotalSeconds)), user);
                return;
            }

            if (user.Stomach.Calories < TeleportManager.Data.GetMinCalorieCost(user))
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You are too hungry to teleport."), user);
                return;
            }

            var targetUser = PlayerUtils.GetUserByName(dest);
            if (user == targetUser)
            {
                ChatBaseExtended.CBInfo(Defaults.appName + Localizer.DoStr("Teleported to yourself. No calories burnt!"), user);
                return;
            }

            if (targetUser == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} could not be found to teleport to."),dest), user);
                return;
            }

            if (!targetUser.IsOnline)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is not online to teleport to."), targetUser.Name), user);
                return;
            }

            var targetData = TeleportManager.Data.GetTeleportUserData(targetUser.Name);

            if (targetData.PendingAccept)
            {
                ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("{0} already has a pending request. Please wait for it to be accepted or to expire."), targetUser.Name), user);
                return;
            }

            TeleportRequest tpr = new(user.Name, targetUser.Name);

            if (!TeleportManager.Data.AddRequest(tpr))
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You have a pending request. Please wait for it to be accepted or to expire."), user);
                return;
            }

            targetData.SetPendingAccept(true);
            userData.SetPendingRequest(true);

            ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("You have sent a request to {0}. Please wait for it to be accepted or to expire."), targetUser.Name), user);
            ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("You have recieved a teleport request from {0}. Please type /tpa to accept, it will expire in {1} seconds."), user.Name, TeleportManager.Config.Expiry), targetUser);
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
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You do not have a pending teleport request to accept."), user);
                return;
            }

            User srcUser = PlayerUtils.GetUserByName(tpr.Requester);
            var srcData = TeleportManager.Data.GetTeleportUserData(srcUser.Name);

            targetData.SetPendingAccept(false);
            srcData.SetPendingRequest(false);
            TeleportManager.Data.ClearRequest(tpr);

            if (!srcUser.IsOnline)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is no longer online."), srcUser.Name), user);
                return;
            }

            srcData.SetCoolDown();
            srcData.Teleport();
            srcUser.Player.SetPosition(user.Player.Position);
            srcUser.Stomach.BurnCalories(TeleportManager.Data.GetMinCalorieCost(srcUser), false);

            var total = TeleportManager.Data.GetMaxTeleports(srcUser) - srcData.Teleports ;
            if (TeleportManager.Data.GetMaxTeleports(srcUser) == 99)
            {
                ChatBaseExtended.CBInfo(Defaults.appName + string.Format(Localizer.DoStr("You teleported to {0}. You have an unlimited amount of Teleports left today"), user.Name), srcUser);

            }
            else
            {
                ChatBaseExtended.CBInfo(Defaults.appName + string.Format(Localizer.DoStr("You teleported to {0}. You have {1} Teleports left today"), user.Name, total), srcUser);

            }

            ChatBaseExtended.CBInfo(Defaults.appName + string.Format(Localizer.DoStr("{0} teleported to you."), srcUser.Name), user);

            TeleportManager.Log(tpr.Log());
            TeleportManager.SaveData();
        }

        [ChatSubCommand("Teleportation", "Teleport Target Player To Yourself or Everyone to yourself, Admin Only", "tphere", ChatAuthorizationLevel.Admin)]
        public static void TeleportHere(User user, string username)
        {
            if (username.ToLower() == "all")
            {
                if (PlayerUtils.OnlineUsers.Count >= 2)
                {
                    foreach (var pl in PlayerUtils.OnlineUsers)
                    {
                        if (pl == user)
                        {
                            continue;
                        }
                        else
                        {
                            pl.Player.SetPosition(user.Position);
                            if (TeleportManager.Config.postMessge)
                                ChatBaseExtended.CBWarning(Defaults.appName + string.Format(Localizer.DoStr("The Admin: {0}, Has summoned you!"), user), pl);
                        }
                    }
                    ChatBaseExtended.CBInfo(Defaults.appName + Localizer.DoStr("Everyone online Has Been Summoned!"), user);
                    return;
                }
                else
                {
                    ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("There is no one online right now, please try again later."), user);
                    return;
                }
            }

            var tpPlayer = PlayerUtils.GetUserByName(username);
            if (tpPlayer == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("Could not find User: {0}, did you type the name correctly?"), username), user);
                return;
            }
            if(tpPlayer == user)
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("What are you trying to pull here?"), user);
                return;
            }
            if (!tpPlayer.IsOnline)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is not online right now."), tpPlayer), user);
                return;
            }
            else
            {
                tpPlayer.Player.SetPosition(user.Position);
                if (TeleportManager.Config.postMessge)
                    ChatBaseExtended.CBWarning(Defaults.appName + string.Format(Localizer.DoStr("The Admin: {0}, Has summoned you!"), user), tpPlayer);
                return;
            }

        }

        [ChatSubCommand("Teleportation", "Teleport all members of a specific group to yourself", "tphere-grp", ChatAuthorizationLevel.Admin)]
        public static void TeleportGroupHere(User user, string groupName)
        {
            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("the group {0} could not be found."), groupName), user);
                return;
            }

            foreach (var usr in group.GroupUsers)
            {
                var pl = PlayerUtils.GetUserByName(usr.Name);
                if (pl.IsOnline)
                {
                    if(pl == user)
                    {
                        continue;
                    }
                    pl.Player.SetPosition(user.Position);
                    if (TeleportManager.Config.postMessge)
                        ChatBaseExtended.CBWarning(Defaults.appName + string.Format(Localizer.DoStr("The Admin: {0}, Has summoned you!"), user), pl);
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
                    ChatBaseExtended.CBInfo(Defaults.appName + Localizer.DoStr("Teleport Here Message is now set too On, it will now notify users when they are being teleported too you using this command."), user);
                    break;
                case false:
                    ChatBaseExtended.CBInfo(Defaults.appName + Localizer.DoStr("Teleport Here Message is now set too Off, Players will no longer be notified if you use the tphere command."), user);
                    break;
            }
        }

        [ChatSubCommand("Teleportation", "Reloads the Teleportation Config if you edit the files directly ( Only Works with default Config!)", "tp-reload", ChatAuthorizationLevel.Admin)]
        public static void tpReload(User user)
        {
            TeleportManager.Config = TeleportManager.LoadConfig();
            ChatBaseExtended.CBInfo(Defaults.appName + Localizer.DoStr("Teleportation Config Reloaded, use /tp-settings to see if the reload worked."), user);
        }

        [ChatSubCommand("Teleportation", "Check The Current Settings of your teleportation configuration", "tp-settings", ChatAuthorizationLevel.Admin)]
        public static void tpSettings(User user)
        {
            string _message = "";
            var group = GroupsManager.API.AllGroups();
            _message += Localizer.DoStr("Default Server Values \n");
            _message += Localizer.DoStr("Calorie Cost: ") + TeleportManager.Config.CalorieCost + "\n";
            _message += Localizer.DoStr("Max Teleports: ") + TeleportManager.Config.MaxTeleports + "\n";
            _message += Localizer.DoStr("Cooldown: ") + TeleportManager.Config.CooldownSeconds + "\n";
            _message += Localizer.DoStr("Teleport Expiriy Time: ") + TeleportManager.Config.Expiry + "\n";

            if (group != null)
            {
                _message += Localizer.DoStr("\n<color=green>Group Settings</color> \n\n");
                group.ForEach(grp =>
                {
                    var tpPermission = grp.Permissions.Find(p => p.Identifier == TeleportManager.ID);
                    if (tpPermission != null)
                    {
                        var config = (TeleportConfig)tpPermission;
                        _message += Localizer.DoStr("Group Name: ") + $"<color=green>{grp.GroupName}</color>" + "\n";
                        _message += Localizer.DoStr("Calorie Cost: ") + config.CalorieCost + "\n";
                        _message += Localizer.DoStr("Max Teleports: ") + config.MaxTeleports + "\n";
                        _message += Localizer.DoStr("Cooldown: ") + config.CooldownSeconds + "\n";
                        _message += Localizer.DoStr("Teleport Expiriy Time: ") + config.Expiry + "\n";
                        _message += "\n";
                    }
                });
            }

            ChatBaseExtended.CBInfoPane(Localizer.DoStr("TP Configuration Settings"), _message, "TP", user);
        }
    }
}