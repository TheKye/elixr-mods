using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.Groups;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Property;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using System;

namespace Eco.EM.Homes
{
    [ChatCommandHandler]
    public class HomeCommands
    {
        [ChatCommand("Elixr Mods Home's Plugin.")]
        public static void EMHomes() { }

        [ChatCommand("Lets you know how many Homes you have left for the day")]
        public static void Homes(User user)
        {
            var userData = HomeManager.Data.GetHomeUserData(user.Name);
            var total = HomeManager.Data.GetMaxTeleports(user) - userData.Teleports;

            if (HomeManager.Data.GetMaxTeleports(user) == int.MaxValue)
                ChatBaseExtended.CBInfoBox($"You Can Return home as much as you like, no limit.", user);
            else if (HomeManager.Data.GetMaxTeleports(user) <= userData.Teleports)
                ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("You Can't return home anymore today, you can return home a total amount of: {0} times Per Day"), HomeManager.Data.GetMaxTeleports(user)), user);
            else
                ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("You have {0} Homes left today, you can return home a total amount of: {1} times Per Day"), total, HomeManager.Data.GetMaxTeleports(user)), user);
        }

        [ChatSubCommand("EMHomes", "Configures the setting for the server homes config.", "home-config", ChatAuthorizationLevel.Admin)]
        public static void ConfigureHomes(User user, string setting, int value)
        {
            setting = StringUtils.Sanitize(setting);

            if (!HomeManager.Config.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} is not a valid configuration option."), setting), user);
                return;
            }

            switch (setting)
            {
                case "max":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Home Max Teleports</color> has been changed to <color=green>{0}</color>"), value), user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Home Teleport Calorie Cost</color> has been changed to <color=green>{0}</color>"), value), user);
                    break;
                case "count":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Max Home Count</color> has been changed to <color=green>{0}</color>"), value), user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Home Cooldown Seconds</color> has been changed to <color=green>{0}</color>"), value), user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("Homes {0} has been set to {1}"), setting, value), user);
                    break;
            }

            HomeManager.SaveConfig();
        }

        [ChatSubCommand("EMHomes", "Configures a setting for a groups home config. Settings: max, count, cost, cooldown.", "home-grpconfig", ChatAuthorizationLevel.Admin)]
        public static void GroupConfigureHomes(User user, string groupName, string setting, int value)
        {
            setting = StringUtils.Sanitize(setting);

            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("{0} could not be found."), groupName), user);
                return;
            }

            if (group.Permissions.Find(p => p.Identifier == HomeManager.ID) is not HomeConfig groupConfig)
            {
                groupConfig = HomeManager.Config.DeepCopy();
                group.AddPermission(groupConfig);
            }

            if (setting == "max" && value < HomeManager.Config.MaxTeleports && value != -1 && value != 0)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("Groups cannot have a smaller maximum value than the serverwide maximum {0}. Reduce the serverwide maximum first."), HomeManager.Config.MaxTeleports), user);
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
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Home Max Teleports</color> for {0} has been changed to <color=green>{1}</color>"), group.GroupName, value), user);
                    break;
                case "cost":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Home Teleport Calorie Cost</color> for {0} has been changed to <color=green>{1}</color>"), group.GroupName, value), user);
                    break;
                case "count":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Max Home Count</color> for {0} has been changed to <color=green>{1}</color>"), group.GroupName, value), user);
                    break;
                case "cooldown":
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("<color=yellow>Home Cooldown Seconds</color> for {0} has been changed to <color=green>{1}</color>"), group.GroupName, value), user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("Homes {0} for {1} has been set to {2}"), setting, group.GroupName, value), user);
                    break;
            }

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("EMHomes", "Go to one of your saved homes.", "gohome", ChatAuthorizationLevel.User)]
        public static void GoHome(User user, string homeName)
        {
            DateTime check = DateTime.Now;
            HomeManager.Data.ResetTeleports(check);
            HomeManager.Data.ClearCoolDown(check, user);

            if (string.IsNullOrEmpty(homeName))
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("Please specify a Home name."), user);
                return;
            }

            var userData = HomeManager.Data.GetHomeUserData(user.Name);

            if (userData.Teleports > HomeManager.Data.GetMaxTeleports(user))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("You have exhausted all your Home Teleports today. ({0} out of {1})"), HomeManager.Data.GetMaxTeleports(user) - userData.Teleports, HomeManager.Data.GetMaxTeleports(user)), user);
                return;
            }

            if (user.Stomach.Calories < HomeManager.Data.GetMinCalorieCost(user))
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You're too hungry to teleport."), user);
                return;
            }

            if (userData.OnCoolDown)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("Your ability to teleport is on cool down. It will reset in {0} seconds."), Math.Ceiling(HomeManager.Data.GetMinCoolDownTime(user) - check.Subtract(userData.CoolDownSetTime).TotalSeconds)), user);
                return;
            }

            var home = HomeManager.Data.GetHome(homeName, user);

            if (home == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("Your home: {0} was not found."), homeName), user);
                return;
            }

            if (home.Location.WorldPosition3i() == user.Position.WorldPosition3i())
            {
                ChatBaseExtended.CBInfoBox(Defaults.appName + Localizer.DoStr("You arrived before you left. No calories burnt."), user);
                return;
            }

            userData.Teleport();
            user.Player.SetPosition(home.Location);
            user.Stomach.BurnCalories(HomeManager.Data.GetMinCalorieCost(user), false);
            userData.SetCoolDown();

            var total = HomeManager.Data.GetMaxTeleports(user) - userData.Teleports;
            if (HomeManager.Data.GetMaxTeleports(user) == int.MaxValue)
                ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("You teleported to {0}. You have an unlimited amount of Home Teleports left today"), home.HomeName), user);
            else
                ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("You teleported to {0}. You have {1} Home Teleports left today"), home.HomeName, total), user);

            HomeManager.Log($"{user.Name} teleported to their home {home.HomeName} at {home.Location.ToStringLabelled("location: ")}");
            HomeManager.SaveData();
        }

        [ChatSubCommand("EMHomes", "List all saved homes, name and location", "home-myinfo", ChatAuthorizationLevel.User)]
        public static void HomeInfo(User user)
        {
            var homes = HomeManager.Data.ListHomes(user);
            var text = string.Empty;

            if (homes.Count == 0)
                text = Localizer.DoStr("You have not set any homes yet.");
            else
            {
                text += string.Format(Localizer.DoStr("You have set {0} of {1} maximum homes.\n"), homes.Count, HomeManager.Data.GetMaxHomes(user));
                text += $"\n";
                text += string.Format(Localizer.DoStr("Homes:\n"));

                foreach (var home in homes)
                    text += $"{home.Location} - {home.HomeName}\n";
            }

            ChatBaseExtended.CBInfoPane($"{user.Name}'s Homes", Defaults.appName + text, "EMHomes", user);
        }

        [ChatSubCommand("EMHomes", "Add current position to your homes list.", "home-add", ChatAuthorizationLevel.User)]
        public static void AddHome(User user, string homeName)
        {
            var plot = PropertyManager.GetPlotFromWorldPos(user.Position.XZi());
            if (plot == null || !plot.IsAuthorized(user))
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You cannot set home on land you have no rights on."), user);
                return;
            }

            homeName = StringUtils.Sanitize(homeName);

            var userData = HomeManager.Data.GetHomeUserData(user.Name);
            var userMax = HomeManager.Data.GetMaxHomes(user);

            if (userData.Homes.Count >= userMax)
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("You've already set your maximum allowed number of homes ({0})."), userMax), user);
                return;
            }

            if (!userData.AddHome(homeName, user.Position))
            {
                ChatBaseExtended.CBError(Defaults.appName + Localizer.DoStr("You already have a home with that name."), user);
                return;
            }

            ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("You added <color=green>{0}</color> to your homes. You have set {1} of {2} allowed homes."), homeName, userData.Homes.Count, userMax), user);
            HomeManager.SaveData();
        }

        [ChatSubCommand("EMHomes", "Remove a home from your saved list of homes", "home-del", ChatAuthorizationLevel.User)]
        public static void RemoveHome(User user, string homeName)
        {
            var userData = HomeManager.Data.GetHomeUserData(user.Name);

            if (!userData.RemoveHome(homeName))
            {
                ChatBaseExtended.CBError(Defaults.appName + string.Format(Localizer.DoStr("Unable to find home {0}"), homeName), user);
                return;
            }

            ChatBaseExtended.CBInfo(Defaults.appName + string.Format(Localizer.DoStr("You removed {0} from your homes. You now have {1} homes."), homeName, userData.Homes.Count), user);
            HomeManager.SaveData();
        }

        [ChatSubCommand("EMHomes", "This will clear your list of homes completely", "home-clear", ChatAuthorizationLevel.User)]
        public static void ClearHomes(User user)
        {
            var userData = HomeManager.Data.GetHomeUserData(user.Name);

            userData.ClearHomes();
            ChatBaseExtended.CBInfoBox(Defaults.appName + string.Format(Localizer.DoStr("You have removed all of your homes. You now have {0} homes."), userData.Homes.Count), user);
            HomeManager.SaveData();
        }

        [ChatSubCommand("EMHomes", "Reloads the Homes Config if you edit the files directly", "home-reload", ChatAuthorizationLevel.Admin)]
        public static void homeReload(User user)
        {
            HomeManager.Config = HomeManager.LoadConfig();
            ChatBaseExtended.CBInfoBox(Defaults.appName + Localizer.DoStr("Home Config Reloaded, use /home-settings to see if the reload worked."), user);
        }

        [ChatSubCommand("EMHomes", "Check The Current Settings of your homes configuration", "home-settings", ChatAuthorizationLevel.Admin)]
        public static void HomeSettings(User user)
        {
            string _message = "";
            var group = GroupsManager.API.AllGroups();
            _message += Localizer.DoStr("Default Server Values \n");
            _message += Localizer.DoStr("Calorie Cost: ") + HomeManager.Config.CalorieCost + "\n";
            _message += Localizer.DoStr("Max Home Teleports: ") + HomeManager.Config.MaxTeleports + "\n";
            _message += Localizer.DoStr("Max Home Count: ") + HomeManager.Config.MaxHomeCount + "\n";
            _message += Localizer.DoStr("Cooldown Timer:") + HomeManager.Config.CoolDown + "\n";

            if (group != null)
            {
                _message += Localizer.DoStr("\n<color=green>Group Settings</color> \n\n");
                group.ForEach(grp =>
                {
                    var homePermission = grp.Permissions.Find(p => p.Identifier == HomeManager.ID);
                    if (homePermission != null)
                    {
                        var config = (HomeConfig)homePermission;
                        _message += Localizer.DoStr("Group Name: ") + string.Format(Localizer.DoStr("<color=green>{0}</color>"), grp.GroupName) + "\n";
                        _message += Localizer.DoStr("Calorie Cost: ") + config.CalorieCost + "\n";
                        _message += Localizer.DoStr("Max Home Teleports: ") + config.MaxTeleports + "\n";
                        _message += Localizer.DoStr("Max Home Count: ") + config.MaxHomeCount + "\n";
                        _message += Localizer.DoStr("Cooldown Timer:") + config.CoolDown + "\n";
                        _message += "\n";
                    }
                });
            }

            ChatBaseExtended.CBInfoPane("Home Configuration Settings", _message, "EMHomes", user);
        }
    }
}

