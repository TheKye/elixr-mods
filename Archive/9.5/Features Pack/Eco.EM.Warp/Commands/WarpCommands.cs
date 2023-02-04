namespace Eco.EM.Warp
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using System;
    using Eco.Shared.Math;
    using Eco.EM.Framework;
    using Eco.EM.Framework.ChatBase;
    using Eco.EM.Framework.Groups;
    using Eco.Gameplay.Objects;
    using Eco.World;
    using Eco.Gameplay.Systems.Messaging.Chat.Commands;
    using Eco.EM.Framework.Utils;

    public class WarpCommands : IChatCommandHandler
    {
        [ChatCommand("Elixr Mods Community Warp Plugin", ChatAuthorizationLevel.Admin)]
        public static void Warp() { }

        [ChatCommand("Lets you know how many warps you have left for the day")]
        public static void Warps(User user)
        {
            var userData = WarpManager.Data.GetWarpUserData(user.Name);
            var total = WarpManager.Data.GetMaxTeleports(user) - userData.Teleports;
            if (WarpManager.Data.GetMaxTeleports(user) == int.MaxValue)
                ChatBaseExtended.CBInfo(Localizer.DoStr("You have an unlimited amount of warps left today"), user);
            else if(WarpManager.Data.GetMaxTeleports(user) <= userData.Teleports)
            {
                ChatBaseExtended.CBError(string.Format(Localizer.DoStr("You have no warps left today, you get a total amount of: {0} Warps Per Day"), WarpManager.Data.GetMaxTeleports(user)), user);
            }
            else
                ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("You have {0} warps left today, you get a total amount of: {1} Warps Per Day"), total, WarpManager.Data.GetMaxTeleports(user)), user);
        }

        [ChatSubCommand("Warp", "Configures a setting for the server warp config.", "warp-config", ChatAuthorizationLevel.Admin)]
        public static void ConfigureWarp(User user, string setting, int value)
        {
            setting = StringUtils.Sanitize(setting);

            if (!WarpManager.Config.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is not a valid configuration option."), setting), user);
                return;
            }
            
            switch (setting)
            {
                case "max":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Warps Max Teleports</color> has been changed to <color=green>{0}</color>"),value), user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Warp Teleport Calorie Cost</color> has been changed to <color=green>{0}</color>"),value), user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Warp Cooldown Seconds</color> has been changed to <color=green>{0}</color>"),value), user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("Warps {0} has been changed to {1}"),setting, value), user);
                    break;
            }

            WarpManager.SaveConfig();
        }

        [ChatSubCommand("Warp", "Configures a setting for a groups warp config. Settings: max, cooldown, cost.", "warp-grpconfig", ChatAuthorizationLevel.Admin)]
        public static void GroupConfigureWarp(User user, string groupName, string setting, int value)
        {
            setting = StringUtils.Sanitize(setting);

            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} could not be found."), groupName), user);
                return;
            }

            if (group.Permissions.Find(p => p.Identifier == WarpManager.ID) is not WarpConfig groupConfig)
            {
                groupConfig = WarpManager.Config.DeepCopy();
                group.AddPermission(groupConfig);
            }

            if (setting == Localizer.DoStr("max") && value < WarpManager.Config.MaxTeleports && value != 0 && value != -1)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("Groups cannot have a smaller maximum value than the serverwide maximum {0}. Reduce the serverwide maximum first."), WarpManager.Config.MaxTeleports), user);
                return;
            }

            if (!groupConfig.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is not a valid configuration option."),setting), user);
                return;
            }

            switch (setting)
            {
                case "max":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Warps Max Teleports</color> for {0} has been changed to <color=green>{1}</color>"), group.GroupName, value), user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Warp Teleport Calorie Cost</color> for {0} has been changed to <color=green>{1}</color>"), group.GroupName, value), user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Warp Cooldown Seconds</color> for {0} has been changed to <color=green>{1}</color>"), group.GroupName, value), user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("Warps {0} for {1} has been changed to {2}"),setting, group.GroupName, value), user);
                    break;
            }

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("Warp", "Warp to specified named warp", "warpto", ChatAuthorizationLevel.User)]
        public static void Warpto(User user, string pointName)
        {
            if (string.IsNullOrWhiteSpace(pointName))
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You must specify where you want to warp to."), user);
                return;
            }

            DateTime check = DateTime.Now;
            WarpManager.Data.ClearCoolDown(check, user);
            WarpManager.Data.ResetTeleports(check);

            var userData = WarpManager.Data.GetWarpUserData(user.Name);

            // The Many conditions to check before we can teleport
            if (userData == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("Your data could not be found. Something has gone terribly wrong. Contact an admin."), user);
                return;
            }

            if (userData.Teleports >= WarpManager.Data.GetMaxTeleports(user))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("You have exhausted all your teleports today. ({0} out of {1})"), WarpManager.Data.GetMaxTeleports(user) - userData.Teleports, WarpManager.Data.GetMaxTeleports(user)), user); // Add the time remaining here??
                return;
            }

            if (userData.OnCoolDown)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("Your ability to teleport is on cool down. It will reset in {0} seconds."),Math.Ceiling(WarpManager.Data.GetMinCoolDownTime(user) - check.Subtract(userData.CoolDownSetTime).TotalSeconds)), user);
                return;
            }

            pointName = StringUtils.Sanitize(pointName);

            var warp = WarpManager.Data.GetPoint(pointName);

            if (warp == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} does not exist as a community warp location."), pointName), user);
                return;
            }

            var minCalories = WarpManager.Data.GetMinCalorieCost(user);
            if (user.Stomach.Calories < minCalories)
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You are too hungry to warp."), user);
                return;
            }

            var total = WarpManager.Data.GetMaxTeleports(user) - userData.Teleports;
            if (WarpManager.Data.GetMaxTeleports(user) == int.MaxValue)
                ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("Warped to {0}, you have an unlimited amount of warps left today"), pointName), user);
            else
                ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("Warped to {0}, you have {1} warps left today"), pointName, total), user);

            userData.SetCoolDown();
            userData.Teleport();
            user.Player.SetPositionAndRotation((Vector3)warp.Location.WorldPosition3i + warp.Rotation.Forward, warp.Rotation);
            

            user.Stomach.BurnCalories(minCalories, false);

            WarpManager.SaveData();
        }

        public static void SignWarpto(User user, string pointName)
        {
            if (string.IsNullOrWhiteSpace(pointName))
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You must specify where you want to warp to."), user);
                return;
            }

            var userData = WarpManager.Data.GetWarpUserData(user.Name);

            if (userData == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("Your data could not be found. Something has gone terribly wrong. Contact an admin."), user);
                return;
            }

            pointName = StringUtils.Sanitize(pointName);

            var warp = WarpManager.Data.GetPoint(pointName);

            if (warp == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} does not exist as a community warp location."), pointName), user);
                return;
            }

            var minCalories = WarpManager.Data.GetMinCalorieCost(user);
            if (user.Stomach.Calories < minCalories)
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You are too hungry to warp."), user);
                return;
            }
            user.Player.SetPositionAndRotation((Vector3)warp.Location.WorldPosition3i + warp.Rotation.Forward, warp.Rotation);
            user.Stomach.BurnCalories(minCalories, false);
            ChatBaseExtended.CBInfo(string.Format(Localizer.DoStr("Warped to {0}"),pointName), user);
            WarpManager.SaveData();
        }

        [ChatSubCommand("Warp","List all available warps.", "warp-info", ChatAuthorizationLevel.User)]
        public static void WarpList(User user)
        {
            var warps = WarpManager.Data.ListPoints();
            var text = string.Empty;

            if (warps.Count == 0)
                text = Localizer.DoStr("There are no community warp points set yet.");
            else
            {
                text += string.Format(Localizer.DoStr("There are set {0} community warp points set.\n"), warps.Count);
                text += $"\n";
                text += Localizer.DoStr("Warp Points:\n");

                foreach (var warp in warps)
                    text += $"{warp.Location} - {warp.PointName}\n";
            }

            user.Player.OpenInfoPanel($"Warp Points", Defaults.appName + text, "");
        }

        [ChatSubCommand("Warp", "Reloads the Warp Config if you edit the files directly (Only Works with Default Config!)", "warp-reload", ChatAuthorizationLevel.Admin)]
        public static void warpReload(User user)
        {
            WarpManager.Config = WarpManager.LoadConfig();
            ChatBaseExtended.CBInfo(Defaults.appName + Localizer.DoStr("Warp Config Reloaded, use /warp-settings to see if the reload worked."), user);
        }

        [ChatSubCommand("Warp", "Check The Current Settings of your warp points configuration", "warp-settings", ChatAuthorizationLevel.Admin)]
        public static void warpSettings(User user)
        {
            string _message = "";
            var group = GroupsManager.API.AllGroups();
            _message += Localizer.DoStr("Default Server Values \n");
            _message += Localizer.DoStr("Calorie Cost: ") + WarpManager.Config.CalorieCost + Localizer.DoStr("\n");
            _message += Localizer.DoStr("Max Teleports: ") + WarpManager.Config.MaxTeleports + Localizer.DoStr("\n");
            _message += Localizer.DoStr("Cooldown: ") + WarpManager.Config.CooldownSeconds + Localizer.DoStr("\n");

            if (group != null)
            {
                _message += Localizer.DoStr("\n<color=green>Group Settings</color> \n\n");
                group.ForEach(grp =>
                {
                    var warpPermission = grp.Permissions.Find(p => p.Identifier == WarpManager.ID);
                    if (warpPermission != null)
                    {
                        var config = (WarpConfig)warpPermission;
                        _message += Localizer.DoStr("Group Name: ") + $"<color=green>{grp.GroupName}</color>" + Localizer.DoStr("\n");
                        _message += Localizer.DoStr("Calorie Cost: ") + config.CalorieCost + Localizer.DoStr("\n");
                        _message += Localizer.DoStr("Max Teleports: ") + config.MaxTeleports + Localizer.DoStr("\n");
                        _message += Localizer.DoStr("Cooldown: ") + config.CooldownSeconds + Localizer.DoStr("\n");
                        _message += Localizer.DoStr("\n");
                    }
                });
            }

            ChatBaseExtended.CBInfoPane("Warp Configuration Settings", _message, "Warp", user);
        }

        [ChatSubCommand("Warp", "Deletes a warp point and model if it exists", "warp-delete", ChatAuthorizationLevel.Admin)]
        public static void warpDelete(User user, string warpName)
        {
            var point = WarpManager.Data.GetPoint(warpName);
            if (point == null) { ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("Warp point not found, check name and try again."), user); return; }

            WorldObject warpObject = null;

            if (World.GetBlock((Vector3i)point.Location) is WorldObjectBlock warpObjectBlock) { warpObject = warpObjectBlock.WorldObjectHandle.Object; }

            if (WarpManager.Data.RemovePoint(point.PointName))
            {
                if (warpObject != null) warpObject.Destroy();
                ChatBaseExtended.CBInfo(Defaults.appName + string.Format(Localizer.DoStr("{0} removed."), point.PointName), user);
                return;
            }

            ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} was unable to be removed."), point.PointName), user);
        }
    }
}
