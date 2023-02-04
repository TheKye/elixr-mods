using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.Groups;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Shared.Localization;
using Eco.Simulation.Time;
using System;

namespace Eco.EM.Daily
{
    
    [ChatCommandHandler]
    public class DailyCommands 
    {
        [ChatCommand("Elixr Mods Community Daily Plugin", ChatAuthorizationLevel.Admin)]
        public static void Daily() { }

        [ChatSubCommand("Daily", "Configures a setting in the daily config. Settings: xp, startTier, time.", "daily-config", ChatAuthorizationLevel.Admin)]
        public static void ConfigureDaily(User user, string setting, int value)
        {
            setting = StringUtils.Sanitize(setting);

            if (!DailyManager.Config.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is not a valid configuration option."), setting), user);
                return;
            }

            switch (setting)
            {
                case "xp":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Daily Reward Experience</color> has been changed to <color=green>{0}</color>."), value), user);
                    break;
                case "starttier":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Daily Start Tier</color> has been changed to <color=green>{0}</color>."), value), user);
                    break;
                case "time":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Daily Minimum Logged-in Time</color> has been changed to <color=green>{0}</color>."), value), user);
                    break;
                case "timer":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Daily Claim Timer</color> has been changed to <color=green>{0}</color>."), value), user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("Daily Config {0} has been set to {1}."), setting, value), user);
                    break;
            }

            DailyManager.SaveConfig();
        }

        [ChatSubCommand("Daily", "Configures a setting a groups daily config. Settings: xp, startTier, time.", "dy-grpconfig", ChatAuthorizationLevel.Admin)]
        public static void GroupConfigureDaily(User user, string groupName, string setting, int value)
        {
            setting = StringUtils.Sanitize(setting);

            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} could not be found."), groupName), user);
                return;
            }

            var groupConfig = group.Permissions.Find(p => p.Identifier == DailyManager.ID) as DailyConfig;

            if (groupConfig == null)
            {
                groupConfig = DailyManager.Config.DeepCopy();
                group.AddPermission(groupConfig);
            }

            value = Math.Clamp(value, 0, int.MaxValue);

            if (!groupConfig.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is not a valid configuration option."),setting), user);
                return;
            }

            switch (setting)
            {
                case "xp":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Daily Reward Experience</color> for {0} has been changed to <color=green>{1}</color>."),group.GroupName ,value), user);
                    break;
                case "starttier":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Daily Start Tier</color> for {0} has been changed to <color=green>{1}</color>."), group.GroupName, value), user);
                    break;
                case "time":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Daily Minimum Logged-in Time</color> for {0} has been changed to <color=green>{1}</color>."), group.GroupName, value), user);
                    break;
                case "timer":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Daily Claim Timer</color> has been changed to <color=green>{0}</color>."), value), user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("Daily Config {0} for {1} has been set to {2}."), group.GroupName, value), user);
                    break;
            }

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("Daily", "Get a daily gift box reward", "get-daily",ChatAuthorizationLevel.User)]
        public static void GetDaily(User user)
        {
            var sgu = DailyManager.Data.GetDailyUserData(user.Name);
            DateTime check = DateTime.Now;

            // Check user can claim
            if (!sgu.CanClaim(check))
            {
                ChatBaseExtended.CBInfoBox(Defaults.appName + "You already collected a Daily Reward within the last 24 hours.", user);
                return;
            }

            // Check for playtime
            if (WorldTime.Seconds - user.LoginTime < TimeSpan.FromMinutes(DailyManager.Data.GetMinimumLoggedInTime(user)).TotalSeconds)
            {
                ChatBaseExtended.CBInfoBox
                    (Defaults.appName + 
                    string.Format(Localizer.DoStr("You have not been logged in for long enough this session to claim your reward, Please wait another {0} minutes."), 
                    Math.Ceiling(TimeSpan.FromMinutes(DailyManager.Data.GetMinimumLoggedInTime(user)).TotalMinutes - TimeSpan.FromSeconds(WorldTime.Seconds - user.LoginTime).TotalMinutes)),
                    user);
                return;
            }

            var result = user.Inventory.TryAddItem(new DailyRewardItem());

            // Check for ability to add to inventory
            if (result.Failed)
            {
                ChatBaseExtended.CBError(Defaults.appName + "You have too many items in your inventory, clear it and try again.", user);
                return;
            }

            // Update claim time and feedback to user 
            sgu.Claim(check);
            DailyManager.Log($"{check} : {user.Name} claimed their daily gift!");
            ChatBaseExtended.CBInfoBox(Defaults.appName + "Thank you for playing on the server!", user);

            DailyManager.SaveData();            
        }

        [ChatSubCommand("Daily", "", "config-daily",ChatAuthorizationLevel.Admin)]
        public static void Open(User user)
        {
            RewardPackTableObject rw = new();
            rw.OpenUI(user.Player);
        }
    }
}
