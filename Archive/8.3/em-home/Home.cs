/* Programmer: ClayC
 * Description: Home (Part of Clays ToolKit [EM])
 */

namespace Eco.EM
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Shared.Math;
    using Gameplay.Property;
    using Eco.Shared.Utils;

    public class Home : IChatCommandHandler
    {
        public Home()
        {
            Load();
        }

        #region Commands
        [ChatCommand( "Set the cost of home in calories.", "home-cost", ChatAuthorizationLevel.Admin)]
        public static void HomeCostCalorie(User user, int Amount)
        {
            try
            {
                Load();

                if (Amount < 0)
                {
                    ChatBase.Send(new ChatBase.Message(Text.Error("Error: Amount must be greater than or equal to 0."), user));
                    return;
                }

                homes.CaloriesCost = Amount;

                Save();

                ChatBase.Send(new ChatBase.Message($"Home cost is now {Amount} calories.", user));
            }
            catch (Exception e)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error($"Error: {e.Message}")));
            }
        }

        [ChatCommand("Set the limit of how many times this feature can be used every day.", "home-limit", ChatAuthorizationLevel.Admin)]
        public static void HomeLimit(User user, int Amount)
        {
            try
            {
                Load();

                if (Amount < 0)
                {
                    ChatBase.Send(new ChatBase.Message(Text.Error("Error: Amount must be greater than or equal to 0."), user));
                    return;
                }

                homes.LimitPerDay = Amount;

                Save();

                var message = (Amount > 0) ? $"Home can be used {Amount} times every day." : $"Home can be used unlimited times every day.";

                ChatBase.Send(new ChatBase.Message(message, user));
            }
            catch (Exception e)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error($"Error: {e.Message}")));
            }
        }

        [ChatCommand("Set the maximum number of homes a player can have.", "home-maxhomes", ChatAuthorizationLevel.Admin)]
        public static void HomeMaxHomes(User user, int Amount)
        {
            try
            {
                Load();

                if (Amount == 0)
                {
                    ChatBase.Send(new ChatBase.Message(Text.Error("Error: Amount must be greater than or equal to 0."), user));
                    return;
                }

                homes.MaxHomeCount = Amount;

                Save();

                var message = (Amount > 0) ? $"Players can now have, up to {Amount} homes." :  $"Players can now have unlimited homes.";

                ChatBase.Send(new ChatBase.Message(message, user));
            }
            catch (Exception e)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error($"Error: {e.Message}")));
            }
        }

        [ChatCommand("Backup and wipe all homes (useful after server wipe)", "wipe-homes", ChatAuthorizationLevel.Admin)]
        public static void WipeHomes(User user)
        {
            Load();

            Backup();
            ChatBase.Send(new ChatBase.Message("Homes have been backed up.", user));

            homes.List.Clear();
            Save();
            ChatBase.Send(new ChatBase.Message("Homes have been wiped", user));
        }

        [ChatCommand("Backup and wipe all homes and logs (useful after server wipe)", "wipe-homelogs", ChatAuthorizationLevel.Admin)]
        public static void WipeHomeLogs(User user)
        {
            Load();

            Backup();
            ChatBase.Send(new ChatBase.Message("Home Logs have been backed up.", user));

            homes.Logs.Clear();
            Save();
            ChatBase.Send(new ChatBase.Message("Home Logs have been wiped", user));
        }

        [ChatCommand("Go to the saved home.", "home")]
        public static void GoHome(User user, string HomeName)
        {
            Load();

            if (string.IsNullOrEmpty(HomeName))
            {
                ChatBase.Send(new ChatBase.Message("Please specify a Home Name", user));
                return;
            }

            if (GetHomes(user).Count == 0)
            {
                ChatBase.Send(new ChatBase.Message("You haven't set a home yet", user));
                return;
            }

            var UsesToday = GetDayUses(user).Count;
            if (homes.LimitPerDay > 0 && UsesToday >= homes.LimitPerDay)
            {
                var ResetTime = DateTime.Today.AddDays(1);
                var TimeLeft  = ResetTime.Subtract(DateTime.Now);

                var timeleft = string.Format("{0:00}:{1:00}:{2:00}", TimeLeft.Hours, TimeLeft.Minutes, TimeLeft.Seconds);

                ChatBase.Send(new ChatBase.Message($"You have reached the limit of daily usage. This will reset in {timeleft}", user));
                return;
            }

            if (user.Stomach.Calories < homes.CaloriesCost)
            {
                ChatBase.Send(new ChatBase.Message("You are too hungry", user));
                return;
            }

            if (!HomeExist(HomeName, user))
            {
                ChatBase.Send(new ChatBase.Message($"You do not have a home with name {HomeName}", user));
                return;
            }

            var home = GetHome(HomeName, user);
            string[] cords = home.Location.Split(home.Location.Contains("|") ? '|' : ',');

            if (cords.Length > 3)
            {
                home.Location = $"{cords[0]}|{cords[2]}|{cords[4]}";
            }

            var homeLocation = new Vector3(float.Parse(cords[0].Trim()), float.Parse(cords[1].Trim()), float.Parse(cords[2].Trim()));
            if (!PropertyManager.GetPlot(new Vector2i((int)homeLocation.x, (int)homeLocation.z)).IsAuthorized(user).Success)
            {
                ChatBase.Send(new ChatBase.Message("Cannot teleport to this home location, action is unauthorized.", user));
                return;
            }

            if (homes.CaloriesCost > 0)
                user.Stomach.BurnCalories(homes.CaloriesCost);

            user.Player.SetPosition(homeLocation);
            homes.Logs.Add(new LogItem()
            {
                UserId = (!string.IsNullOrWhiteSpace(user.SteamId)) ? user.SteamId : user.SlgId,
                Date = DateTime.Now.ToString("yyyy-MM-dd")
            });

            var message = $"You have been teleported to {HomeName}";
            if (homes.LimitPerDay > 0)
            {
                UsesToday++;
                var left = homes.LimitPerDay - UsesToday;

                message += $" ({left} uses left today)";
            }

            ChatBase.Send(new ChatBase.Message(message, user));
            Save();
        }

        [ChatCommand("List all saved homes, name and location", "home-list")]
        public static void ListHomes(User user)
        {
            Load();

            var myhomes = GetHomes(user);
            var text = string.Empty;

            if (myhomes.Count == 0)
                text = "You have not set any homes yet.";
            else {
                var uses = GetDayUses(user).Count;

                if (homes.MaxHomeCount > 0)
                    text += $"You have already set {GetHomes(user).Count} of {homes.MaxHomeCount} maximum homes.\n";
                else
                    text += $"You have already set {GetHomes(user).Count} homes.\n";

                if (homes.LimitPerDay > 0) {
                    var left = homes.LimitPerDay - uses;
                    text += $"Out of the limit of {homes.LimitPerDay}, you have {left} home usage left.\n\n";
                } else
                    text += $"You have already used home {GetDayUses(user).Count} times today.\n\n";

                foreach (var home in myhomes)
                    text += $"{home.Location}    {home.Name}\n";
            }

            user.Player.OpenInfoPanel("My Homes", text);
        }

        [ChatCommand("Add current position to your homes list", "home-add")]
        public static void AddHome(User user, string HomeName)
        {
            Load();
            var plot = PropertyManager.GetPlot(user.Player.Position.XZi);
            if (plot == null || !plot.IsAuthorized(user).Success)
            {
                ChatBase.Send(new ChatBase.Message("You cannot set home on land you do not own.", user));
                return;
            }

            if (HomeExist(HomeName, user))
            {
                ChatBase.Send(new ChatBase.Message("You already have a home with that name.", user));
                return;
            }

            if (GetHomes(user).Count >= homes.MaxHomeCount)
            {
                ChatBase.Send(new ChatBase.Message($"You've already set the maximum number of homes ({homes.MaxHomeCount}).", user));
                return;
            }

            homes.List.Add(new HomeItem()
            {
                Name = HomeName,
                Location = $"{user.Position.x}|{user.Position.y}|{user.Position.z}",
                UserId = (!string.IsNullOrWhiteSpace(user.SteamId)) ? user.SteamId : user.SlgId,
            });

            ChatBase.Send(new ChatBase.Message($"Home was added to list. ({GetHomes(user).Count} of {homes.MaxHomeCount})", user));
            Save();
        }

        [ChatCommand("Remove a home from your saved list of homes", "home-remove")]
        public static void RemoveHome(User user, string HomeName)
        {
            Load();

            if (!HomeExist(HomeName, user))
            {
                ChatBase.Send(new ChatBase.Message($"Unable to find home {HomeName}", user));
                return;
            }

            var Home = GetHome(HomeName, user);
            ChatBase.Send(new ChatBase.Message($"Home \"{Home.Name}\" has been removed from your list of homes.", user));
            homes.List.Remove(Home);

            Save();
        }
        #endregion

        #region Methods
        public static void Load()
        {
            if (!loaded)
            {
                homes = FileManager<Homes>.ReadFromFile(Base.SaveLocation, "Homes");

                if (homes == null)
                    homes = new Homes();

                loaded = true;
            }
        }

        public static void Backup()
        {
            var date = DateTime.Now.ToString("yyyyMMDDHHmm");

            FileManager<Homes>.WriteToFile(homes, Base.SaveLocation, $"Home-{date}");

            homes.List.Clear();
            homes.Logs.Clear();
        }

        public static void Save()
        {
            FileManager<Homes>.WriteToFile(homes, Base.SaveLocation, "Homes");
        }

        private static List<HomeItem> GetHomes(User user)
        {
            var result = homes.List.Where(home => home.UserId == user.SteamId || home.UserId == user.SlgId).ToList();

            return result;
        }

        private static HomeItem GetHome(string HomeName, User user)
        {
            var home = homes.List.Where(item => (
                                    item.UserId == user.SteamId ||
                                    item.UserId == user.SlgId
                                ) && 
                                Compare.IsLike(item.Name, HomeName)).FirstOrDefault();

            return home;
        }

        private static bool HomeExist(string HomeName, User user)
        {
            int HomeCount = GetHomes(user).Where(item => Compare.IsLike(item.Name, HomeName)).Count();

            return (HomeCount > 0);
        }
        
        private static List<LogItem> GetDayUses(User user)
        {
            var result = homes.Logs.Where(log => (
                            log.UserId == user.SteamId ||
                            log.UserId == user.SlgId
                        ) &&
                        log.Date == DateTime.Now.ToString("yyyy-MM-dd")).ToList();

            return result;
        }
        #endregion

        #region Properties
        private static bool loaded = false;
        static Homes homes = new Homes();
        #endregion
    }
}
