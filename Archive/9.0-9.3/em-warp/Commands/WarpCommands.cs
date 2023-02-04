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
                ChatBaseExtended.CBInfo($"You have an unlimited amount of warps left today", user);
            else if(WarpManager.Data.GetMaxTeleports(user) <= userData.Teleports)
            {
                ChatBaseExtended.CBError($"You have no warps left today, you get a total amount of: {WarpManager.Data.GetMaxTeleports(user)} Warps Per Day", user);
            }
            else
                ChatBaseExtended.CBInfoBox($"You have {total} warps left today, you get a total amount of: {WarpManager.Data.GetMaxTeleports(user)} Warps Per Day", user);
        }

        [ChatSubCommand("Warp", "Configures a setting for the server warp config.", "warp-config", ChatAuthorizationLevel.Admin)]
        public static void ConfigureWarp(User user, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            if (!WarpManager.Config.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Base.appName + $"{setting} is not a valid configuration option.", user);
                return;
            }
            
            switch (setting)
            {
                case "max":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Warps Max Teleports</color> has been changed to <color=green>{value}</color>", user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Warp Teleport Calorie Cost</color> has been changed to <color=green>{value}</color>", user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Warp Cooldown Seconds</color> has been changed to <color=green>{value}</color>", user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Base.appName + $"Warps {setting} has been changed to {value}", user);
                    break;
            }

            WarpManager.SaveConfig();
        }

        [ChatSubCommand("Warp", "Configures a setting for a groups warp config. Settings: max, cooldown, cost.", "warp-grpconfig", ChatAuthorizationLevel.Admin)]
        public static void GroupConfigureWarp(User user, string groupName, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{groupName} could not be found.", user);
                return;
            }

            WarpConfig groupConfig = group.Permissions.Find(p => p.Identifier == WarpManager.ID) as WarpConfig;

            if (groupConfig == null)
            {
                groupConfig = WarpManager.Config.DeepCopy();
                group.AddPermission(groupConfig);
            }

            if (setting == "max" && value < WarpManager.Config.MaxTeleports && value != 0 && value != -1)
            {
                ChatBaseExtended.CBError(Base.appName + $"Groups cannot have a smaller maximum value than the serverwide maximum {WarpManager.Config.MaxTeleports}. Reduce the serverwide maximum first.", user);
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
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Warps Max Teleports</color> for {group.GroupName} has been changed to <color=green>{value}</color>", user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Warp Teleport Calorie Cost</color> for {group.GroupName} has been changed to <color=green>{value}</color>", user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Warp Cooldown Seconds</color> for {group.GroupName} has been changed to <color=green>{value}</color>", user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Base.appName + $"Warps {setting} for {group.GroupName} has been changed to {value}", user);
                    break;
            }

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("Warp", "Warp to specified named warp", "warpto", ChatAuthorizationLevel.User)]
        public static void Warpto(User user, string pointName)
        {
            if (string.IsNullOrWhiteSpace(pointName))
            {
                ChatBaseExtended.CBError(Base.appName + "You must specify where you want to warp to.", user);
                return;
            }

            DateTime check = DateTime.Now;
            WarpManager.Data.ClearCoolDown(check, user);
            WarpManager.Data.ResetTeleports(check);

            var userData = WarpManager.Data.GetWarpUserData(user.Name);

            // The Many conditions to check before we can teleport
            if (userData == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"Your data could not be found. Something has gone terribly wrong. Contact an admin.", user);
                return;
            }

            if (userData.Teleports >= WarpManager.Data.GetMaxTeleports(user))
            {
                ChatBaseExtended.CBError(Base.appName + $"You have exhausted all your teleports today. ({WarpManager.Data.GetMaxTeleports(user) - userData.Teleports} out of {WarpManager.Data.GetMaxTeleports(user)})", user); // Add the time remaining here??
                return;
            }

            if (userData.OnCoolDown)
            {
                ChatBaseExtended.CBError(Base.appName + $"Your ability to teleport is on cool down. It will reset in {Math.Ceiling(WarpManager.Data.GetMinCoolDownTime(user) - check.Subtract(userData.CoolDownSetTime).TotalSeconds)} seconds.", user);
                return;
            }

            pointName = Base.Sanitize(pointName);

            var warp = WarpManager.Data.GetPoint(pointName);

            if (warp == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{pointName} does not exist as a community warp location.", user);
                return;
            }

            var minCalories = WarpManager.Data.GetMinCalorieCost(user);
            if (user.Stomach.Calories < minCalories)
            {
                ChatBaseExtended.CBError(Base.appName + $"You are too hungry to warp.", user);
                return;
            }

            var total = WarpManager.Data.GetMaxTeleports(user) - userData.Teleports;
            if (WarpManager.Data.GetMaxTeleports(user) == int.MaxValue)
                ChatBaseExtended.CBInfoBox($"Warped to {pointName}, you have an unlimited amount of warps left today", user);
            else
                ChatBaseExtended.CBInfoBox($"Warped to {pointName}, you have {total} warps left today", user);

            userData.SetCoolDown();
            userData.Teleport();
            user.Player.SetPositionAndRotation((Vector3)warp.Location.WorldPosition3i + warp.Rotation.Forward, warp.Rotation);
            

            user.Stomach.BurnCalories(minCalories);

            WarpManager.SaveData();
        }

        public static void SignWarpto(User user, string pointName)
        {
            if (string.IsNullOrWhiteSpace(pointName))
            {
                ChatBaseExtended.CBError(Base.appName + "You must specify where you want to warp to.", user);
                return;
            }

            var userData = WarpManager.Data.GetWarpUserData(user.Name);

            if (userData == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"Your data could not be found. Something has gone terribly wrong. Contact an admin.", user);
                return;
            }

            pointName = Base.Sanitize(pointName);

            var warp = WarpManager.Data.GetPoint(pointName);

            if (warp == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{pointName} does not exist as a community warp location.", user);
                return;
            }

            var minCalories = WarpManager.Data.GetMinCalorieCost(user);
            if (user.Stomach.Calories < minCalories)
            {
                ChatBaseExtended.CBError(Base.appName + $"You are too hungry to warp.", user);
                return;
            }
            user.Player.SetPositionAndRotation((Vector3)warp.Location.WorldPosition3i + warp.Rotation.Forward, warp.Rotation);
            user.Stomach.BurnCalories(minCalories);
            ChatBaseExtended.CBInfo($"Warped to {pointName}", user);
            WarpManager.SaveData();
        }

        [ChatSubCommand("Warp","List all available warps.", "warp-info", ChatAuthorizationLevel.User)]
        public static void WarpList(User user)
        {
            var warps = WarpManager.Data.ListPoints();
            var text = string.Empty;

            if (warps.Count == 0)
                text = "There are no community warp points set yet.";
            else
            {
                text += $"There are set {warps.Count} community warp points set.\n";
                text += $"\n";
                text += $"Warp Points:\n";

                foreach (var warp in warps)
                    text += $"{warp.Location} - {warp.PointName}\n";
            }

            user.Player.OpenInfoPanel($"Warp Points", Base.appName + text, "");
        }

        [ChatSubCommand("Warp", "Reloads the Warp Config if you edit the files directly (Only Works with Default Config!)", "warp-reload", ChatAuthorizationLevel.Admin)]
        public static void warpReload(User user)
        {
            WarpManager.Config = WarpManager.LoadConfig();
            ChatBaseExtended.CBInfo(Base.appName + "Warp Config Reloaded, use /warp-settings to see if the reload worked.", user);
        }

        [ChatSubCommand("Warp", "Check The Current Settings of your warp points configuration", "warp-settings", ChatAuthorizationLevel.Admin)]
        public static void warpSettings(User user)
        {
            string _message = "";
            var group = GroupsManager.API.AllGroups();
            _message += "Default Server Values \n";
            _message += "Calorie Cost: " + WarpManager.Config.CalorieCost + "\n";
            _message += "Max Teleports: " + WarpManager.Config.MaxTeleports + "\n";
            _message += "Cooldown: " + WarpManager.Config.CooldownSeconds + "\n";

            if (group != null)
            {
                _message += "\n<color=green>Group Settings</color> \n\n";
                group.ForEach(grp =>
                {
                    var warpPermission = grp.Permissions.Find(p => p.Identifier == WarpManager.ID);
                    if (warpPermission != null)
                    {
                        var config = (WarpConfig)warpPermission;
                        _message += "Group Name: " + $"<color=green>{grp.GroupName}</color>" + "\n";
                        _message += "Calorie Cost: " + config.CalorieCost + "\n";
                        _message += "Max Teleports: " + config.MaxTeleports + "\n";
                        _message += "Cooldown: " + config.CooldownSeconds + "\n";
                        _message += "\n";
                    }
                });
            }

            ChatBaseExtended.CBInfoPane("Warp Configuration Settings", _message, "PM", user);
        }

        [ChatSubCommand("Warp", "Deletes a warp point and model if it exists", "warp-delete", ChatAuthorizationLevel.Admin)]
        public static void warpDelete(User user, string warpName)
        {
            var point = WarpManager.Data.GetPoint(warpName);
            if (point == null) { ChatBaseExtended.CBError(Base.appName + "Warp point not found, check name and try again.", user); return; }

            WorldObject warpObject = null;
            var warpObjectBlock = World.GetBlock((Vector3i)point.Location) as WorldObjectBlock;
            if (warpObjectBlock != null) { warpObject = warpObjectBlock.WorldObjectHandle.Object; }

            if (WarpManager.Data.RemovePoint(point.PointName))
            {
                if (warpObject != null) warpObject.Destroy();
                ChatBaseExtended.CBInfo(Base.appName + $"{point.PointName} removed.", user);
                return;
            }

            ChatBaseExtended.CBError(Base.appName + $"{point.PointName} was unable to be removed.", user);
        }
    }
}
