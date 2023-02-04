

namespace Eco.EM.Homes
{
    using Eco.EM.Framework;
    using Eco.EM.Framework.ChatBase;
    using Eco.EM.Framework.Groups;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class HomeCommands : IChatCommandHandler
    {
        [ChatCommand("Elixr Mods Home's Plugin.")]
        public static void Home() { }

        [ChatCommand("Lets you know how many Homes you have left for the day")]
        public static void Homes(User user)
        {
            var userData = HomeManager.Data.GetHomeUserData(user.Name);
            var total = HomeManager.Data.GetMaxTeleports(user) - userData.Teleports;

            if (HomeManager.Data.GetMaxTeleports(user) == int.MaxValue)
                ChatBaseExtended.CBInfoBox($"You Can Return home as much as you like, no limit.", user);
            else if (HomeManager.Data.GetMaxTeleports(user) <= userData.Teleports)
                ChatBaseExtended.CBInfoBox($"You Can't return home anymore today, you can return home a total amount of: {HomeManager.Data.GetMaxTeleports(user)} times Per Day", user);
            else
                ChatBaseExtended.CBInfoBox($"You have {total} Homes left today, you can return home a total amount of: {HomeManager.Data.GetMaxTeleports(user)} times Per Day", user);
        }

        [ChatSubCommand("Home", "Configures asetting for the server homes config.", "home-config", ChatAuthorizationLevel.Admin)]
        public static void ConfigureHomes(User user, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            if (!HomeManager.Config.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Base.appName + $"{setting} is not a valid configuration option.", user);
                return;
            }

            switch (setting)
            {
                case "max":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Home Max Teleports</color> has been changed to <color=green>{value}</color>", user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Home Teleport Calorie Cost</color> has been changed to <color=green>{value}</color>", user);
                    break;
                case "count":
                    ChatBaseExtended.CBInfoBox(Localizer.DoStr(Base.appName + $"<color=yellow>Max Home Count</color> has been changed to <color=green>{value}</color>"), user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Localizer.DoStr(Base.appName + $"<color=yellow>Home Cooldown Seconds</color> has been changed to <color=green>{value}</color>"), user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Localizer.DoStr(Base.appName + $"Homes {setting} has been set to {value}"), user);
                    break;
            }

            HomeManager.SaveConfig();          
        }

        [ChatSubCommand("Home", "Configures a setting for a groups home config. Settings: max,count,cost.", "home-grpconfig", ChatAuthorizationLevel.Admin)]
        public static void GroupConfigureHomes(User user, string groupName, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{groupName} could not be found.", user);
                return;
            }

            var groupConfig = group.Permissions.Find(p => p.Identifier == HomeManager.ID) as HomeConfig;

            if (groupConfig == null)
            {
                groupConfig = HomeManager.Config.DeepCopy();
                group.AddPermission(groupConfig);
            }

            if (setting == "max" && value < HomeManager.Config.MaxTeleports && value != -1 && value != 0)
            {
                ChatBaseExtended.CBError(Base.appName + $"Groups cannot have a smaller maximum value than the serverwide maximum {HomeManager.Config.MaxTeleports}. Reduce the serverwide maximum first.", user);
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
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Home Max Teleports</color> for {group.GroupName} has been changed to <color=green>{value}</color>", user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Home Teleport Calorie Cost</color> for {group.GroupName} has been changed to <color=green>{value}</color>", user);
                    break;
                case "count":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Max Home Count</color> for {group.GroupName} has been changed to <color=green>{value}</color>", user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>Home Cooldown Seconds</color> for {group.GroupName} has been changed to <color=green>{value}</color>", user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Base.appName + $"Homes {setting} for {group.GroupName} has been set to {value}", user);
                    break;
            }

            GroupsManager.API.SaveData();
        }
       
        [ChatSubCommand("Home", "Go to one of your saved homes.", "gohome", ChatAuthorizationLevel.User)]
        public static void GoHome(User user, string homeName)
        {
            DateTime check = DateTime.Now;
            HomeManager.Data.ResetTeleports(check);
            HomeManager.Data.ClearCoolDown(check, user);

            if (string.IsNullOrEmpty(homeName))
            {
                ChatBaseExtended.CBError(Base.appName + "Please specify a Home name.", user);
                return;
            }

            var userData = HomeManager.Data.GetHomeUserData(user.Name);

            if (userData.Teleports > HomeManager.Data.GetMaxTeleports(user))
            {
                ChatBaseExtended.CBError(Base.appName + $"You have exhausted all your Home Teleports today. ({HomeManager.Data.GetMaxTeleports(user) - userData.Teleports} out of {HomeManager.Data.GetMaxTeleports(user)})", user);
                return;
            }

            if (user.Stomach.Calories < HomeManager.Data.GetMinCalorieCost(user))
            {
                ChatBaseExtended.CBError(Localizer.DoStr(Base.appName + "You're too hungry to teleport."), user);
                return;
            }

            if (userData.OnCoolDown)
            {
                ChatBaseExtended.CBError(Base.appName + $"Your ability to teleport is on cool down. It will reset in {Math.Ceiling(HomeManager.Data.GetMinCoolDownTime(user) - check.Subtract(userData.CoolDownSetTime).TotalSeconds)} seconds.", user);
                return;
            }

            var home = HomeManager.Data.GetHome(homeName, user);

            if (home == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"Your home: {homeName} was not found.", user);
                return;
            }

            if (home.Location.WorldPosition3i == user.Position.WorldPosition3i)
            {
                ChatBaseExtended.CBInfoBox(Base.appName + $"You arrived before you left. No calories burnt.", user);
                return;
            }

            userData.Teleport();
            user.Player.SetPosition(home.Location);
            user.Stomach.BurnCalories(HomeManager.Data.GetMinCalorieCost(user));
            userData.SetCoolDown();

            var total = HomeManager.Data.GetMaxTeleports(user) - userData.Teleports;
            if (HomeManager.Data.GetMaxTeleports(user) == int.MaxValue)
                ChatBaseExtended.CBInfoBox(Base.appName + $"You teleported to {home.HomeName}. You have an unlimited amount of Home Teleports left today", user);
            else
                ChatBaseExtended.CBInfoBox(Base.appName + $"You teleported to {home.HomeName}. You have {total} Home Teleports left today", user);

            HomeManager.Log($"{user.Name} teleported to their home {home.HomeName} at {home.Location.ToStringLabelled("location: ")}");
            HomeManager.SaveData();
        }

        [ChatSubCommand("Home", "List all saved homes, name and location", "home-myinfo", ChatAuthorizationLevel.User)]
        public static void HomeInfo(User user)
        {
            var homes = HomeManager.Data.ListHomes(user);
            var text = string.Empty;

            if (homes.Count == 0)
                text = "You have not set any homes yet.";
            else
            {
                text += $"You have set {homes.Count} of {HomeManager.Data.GetMaxHomes(user)} maximum homes.\n";
                text += $"\n";
                text += $"Homes:\n";

                foreach (var home in homes)
                    text += $"{home.Location} - {home.HomeName}\n";
            }

            ChatBaseExtended.CBInfoPane($"{user.Name}'s Homes", Base.appName + text, "Homes", user);
        }

        [ChatSubCommand("Home", "Add current position to your homes list.", "home-add", ChatAuthorizationLevel.User)]
        public static void AddHome(User user, string homeName)
        {
            var plot = PropertyManager.GetPlot(user.Player.Position.XZi);
            if (plot == null || !plot.IsAuthorized(user).Success)
            {
                ChatBaseExtended.CBError(Base.appName + "You cannot set home on land you have no rights on.", user);
                return;
            }

            homeName = Base.Sanitize(homeName);

            var userData = HomeManager.Data.GetHomeUserData(user.Name);
            var userMax = HomeManager.Data.GetMaxHomes(user);

            if (userData.Homes.Count >= userMax)
            {
                ChatBaseExtended.CBError(Base.appName + $"You've already set your maximum allowed number of homes ({userMax}).", user);
                return;
            }

            if (!userData.AddHome(homeName, user.Position))
            {
                ChatBaseExtended.CBError(Base.appName + "You already have a home with that name.", user);
                return;
            }

            ChatBaseExtended.CBInfoBox(Base.appName + $"You added <color=green>{homeName}</color> to your homes. You have set {userData.Homes.Count} of {userMax} allowed homes.", user);
            HomeManager.SaveData();
        }

        [ChatSubCommand("Home", "Remove a home from your saved list of homes", "home-del", ChatAuthorizationLevel.User)]
        public static void RemoveHome(User user, string homeName)
        {
            var userData = HomeManager.Data.GetHomeUserData(user.Name);

            if (!userData.RemoveHome(homeName))
            {
                ChatBaseExtended.CBError(Base.appName + $"Unable to find home {homeName}", user);
                return;
            }

            ChatBaseExtended.CBInfo(Base.appName + $"You removed {homeName} from your homes. You now have {userData.Homes.Count} homes.", user);
            HomeManager.SaveData();
        }

        [ChatSubCommand("Home", "This will clear your list of homes completely", "home-clear", ChatAuthorizationLevel.User)]
        public static void ClearHomes(User user)
        {
            var userData = HomeManager.Data.GetHomeUserData(user.Name);

            userData.ClearHomes();
            ChatBaseExtended.CBInfoBox(Base.appName + $"You have removed all of your homes. You now have {userData.Homes.Count} homes.", user);
            HomeManager.SaveData();
        }

        [ChatSubCommand("Home", "Reloads the Homes Config if you edit the files directly", "home-reload", ChatAuthorizationLevel.Admin)]
        public static void homeReload(User user)
        {
            HomeManager.Config = HomeManager.LoadConfig();
            ChatBaseExtended.CBInfoBox(Base.appName + "Home Config Reloaded, use /home-settings to see if the reload worked.", user);
        }

        [ChatSubCommand("Home", "Check The Current Settings of your homes configuration", "home-settings", ChatAuthorizationLevel.Admin)]
        public static void HomeSettings(User user)
        {
            string _message = "";
            var group = GroupsManager.API.AllGroups();
            _message += "Default Server Values \n";
            _message += "Calorie Cost: " + HomeManager.Config.CalorieCost + "\n";
            _message += "Max Home Teleports: " + HomeManager.Config.MaxTeleports + "\n";
            _message += "Max Home Count: " + HomeManager.Config.MaxHomeCount + "\n";
            _message += "Cooldown Timer:" + HomeManager.Config.CoolDown + "\n";

            if(group != null)
            {
                _message += "\n<color=green>Group Settings</color> \n\n";
                group.ForEach(grp =>
                {
                    var homePermission = grp.Permissions.Find(p => p.Identifier == HomeManager.ID);
                    if (homePermission != null)
                    {
                        var config = (HomeConfig)homePermission;
                        _message += "Group Name: " + $"<color=green>{grp.GroupName}</color>" + "\n";
                        _message += "Calorie Cost: " + config.CalorieCost + "\n";
                        _message += "Max Home Teleports: " + config.MaxHomeCount + "\n";
                        _message += "Max Home Count: " + config.MaxTeleports + "\n";
                        _message += "Cooldown Timer:" + config.CoolDown + "\n";
                        _message += "\n";
                    }
                });
            }

            ChatBaseExtended.CBInfoPane("Home Configuration Settings", _message, "Homes", user);
        }
    }
}

