using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.Groups;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Simulation.Time;
using System;

namespace Eco.EM.Daily
{
    public class DailyCommands : IChatCommandHandler
    {
        [ChatCommand("Elixr Mods Community Daily Plugin", ChatAuthorizationLevel.Admin)]
        public static void Daily() { }

        [ChatSubCommand("Daily", "Configures a setting in the daily config. Settings: xp, startTier, time.", "daily-config", ChatAuthorizationLevel.Admin)]
        public static void ConfigureDaily(User user, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            if (!DailyManager.Config.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Base.appName + $"{setting} is not a valid configuration option.", user);
                return;
            }

            switch (setting)
            {
                case "xp":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Daily Reward Experience</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                case "starttier":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Daily Start Tier</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                case "time":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Daily Minimum Logged-in Time</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                case "timer":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Daily Claim Timer</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Base.appName + $"Daily Config {setting} has been set to {value}.", user);
                    break;
            }

            DailyManager.SaveConfig();
        }

        [ChatSubCommand("Daily", "Configures a setting a groups daily config. Settings: xp, startTier, time.", "dy-grpconfig", ChatAuthorizationLevel.Admin)]
        public static void GroupConfigureDaily(User user, string groupName, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{groupName} could not be found.", user);
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
                ChatBaseExtended.CBError(Base.appName + $"{setting} is not a valid configuration option.", user);
                return;
            }

            switch (setting)
            {
                case "xp":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Daily Reward Experience</color> for {group.GroupName} has been changed to <color=green>{value}</color>.", user);
                    break;
                case "starttier":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Daily Start Tier</color> for {group.GroupName} has been changed to <color=green>{value}</color>.", user);
                    break;
                case "time":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Daily Minimum Logged-in Time</color> for {group.GroupName} has been changed to <color=green>{value}</color>.", user);
                    break;
                case "timer":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Daily Claim Timer</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Base.appName + $"Daily Config {setting} for {group.GroupName} has been set to {value}.", user);
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
                ChatBaseExtended.CBInfoBox(Base.appName + "You already collected a Daily Reward within the last 24 hours.", user);
                return;
            }

            // Check for playtime
            if (WorldTime.Seconds - user.LoginTime < TimeSpan.FromMinutes(DailyManager.Data.GetMinimumLoggedInTime(user)).TotalSeconds)
            {

                Base.Debug(
                        $"User: {user.Name}, " +
                        $"Logged in: {user.LoginTime}, " +
                        $"Min Time: {DailyManager.Data.GetMinimumLoggedInTime(user)}, " +
                        $"WorldTime: {WorldTime.Seconds}, " +
                        $"Time until next claim: {TimeSpan.FromMinutes(DailyManager.Data.GetMinimumLoggedInTime(user)).TotalMinutes - TimeSpan.FromSeconds(WorldTime.Seconds - user.LoginTime).TotalMinutes} ");

                ChatBaseExtended.CBInfoBox
                    (Base.appName + 
                    $"You have not been logged in for long enough this session to claim your reward, " +
                    $"Please wait another {Math.Ceiling(TimeSpan.FromMinutes(DailyManager.Data.GetMinimumLoggedInTime(user)).TotalMinutes - TimeSpan.FromSeconds(WorldTime.Seconds - user.LoginTime).TotalMinutes)} minutes."
                    , user);
                return;
            }

            var result = user.Inventory.TryAddItem(new DailyRewardItem());

            // Check for ability to add to inventory
            if (result.Failed)
            {
                ChatBaseExtended.CBError(Base.appName + "You have too many items in your inventory, clear it and try again.", user);
                return;
            }

            // Update claim time and feedback to user 
            sgu.Claim(check);
            DailyManager.Log($"{check} : {user.Name} claimed their daily gift!");
            ChatBaseExtended.CBInfoBox(Base.appName + "Thank you for playing on the server.", user);

            DailyManager.SaveData();            
        }
    }
}
