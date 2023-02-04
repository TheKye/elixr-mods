namespace Eco.EM.Commands
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Chat;
    using Shared.Utils;
    using Simulation.Time;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Economy;
    using System;
    using Eco.EM.Framework;
    using Eco.EM.Framework.ChatBase;

    class Commands : IChatCommandHandler
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        private struct PopulationStat
        {
            public string Key;
            public string Current;
            public float Change;
        }

        [ChatCommand("See when players were last online", "last-online")]
        public static void LastOnline(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBaseExtended.CBError($"{string.Format(appName + $"Unable to find user {0}", target)}", user);
                return;
            }

            string message = string.Empty;
            if (targetUser.LoggedIn)
            {
                var positionLink = new Vector3Tooltip(targetUser.Position).UILink();
                message = appName + "{0} is currently {1} and is located at {2}";
                message = string.Format(Localizer.DoStr($"{message}"), targetUser.Name, Text.Positive(Localizer.DoStr($"Online")), positionLink);
            }
            else
            {
                var time = TimeFormatter.FormatSpan(WorldTime.Seconds - targetUser.LogoutTime);
                message = appName + "{0} has been {1} for {2}";
                message = string.Format(Localizer.DoStr($"{message}"), targetUser.Name, Text.Negative(Localizer.DoStr($"Offline")), time);
            }

            ChatBaseExtended.CBChat(message, user.Player);
        }

        [ChatCommand("Display stats of players.")]
        public static void Stats(User user, string target)
        {
            User targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                var message = string.Format(Localizer.DoStr(appName + $"Unable to find user {0}"), target);
                ChatBaseExtended.CBError(message, user);
                return;
            }

            // Build Stats Information
            string Title = string.Format(Localizer.DoStr("Stats for {0}"), targetUser.Name);
            string PlayerStats = string.Empty;

            if (targetUser.IsAdminOrDev && !targetUser.IsAdmin)
                Title += " " + Localizer.DoStr("[DEV]");
            else if (targetUser.IsAdmin)
                Title += " " + Localizer.DoStr("[ADMIN]");

            if (targetUser.Player != null)
                PlayerStats += Text.Positive(Localizer.DoStr("Online")) + "\n";

            string gender = Localizer.DoStr($"Character Gender: {targetUser.Avatar.Sex}");
            gender = gender[0].ToString().ToUpper() + gender.Remove(0, 1);

            string skilltitle = Localizer.DoStr($"Skill Title: {targetUser.Skillset.Title}");
            skilltitle = skilltitle[0].ToString().ToUpper() + skilltitle.Remove(0, 1);

            PlayerStats += $"{gender} {targetUser.Skillset.Title}\n";
            PlayerStats += string.Format(Localizer.DoStr("Online Time (Total): {0}"), Eco.Shared.Utils.TimeFormatter.FormatSpan(targetUser.TotalPlayTime)) + "\n";
            if (user.LoggedIn)
                PlayerStats += string.Format(Localizer.DoStr("Online Time (Session): {0}"), Eco.Shared.Utils.TimeFormatter.FormatSpan(WorldTime.Seconds - targetUser.LoginTime)) + "\n";
            else
                PlayerStats += string.Format(Localizer.DoStr("Online Time (Session): {0}"), Localizer.DoStr($"Offline")) + "\n";
            PlayerStats += string.Format(Localizer.DoStr("Food Skill Rate: {0}"), (targetUser.SkillRate - targetUser.CachedHouseValue.HousingSkillRate)) + "\n";
            PlayerStats += string.Format(Localizer.DoStr("House Skill Rate: {0}"), (targetUser.CachedHouseValue.HousingSkillRate)) + "\n";
            PlayerStats += string.Format(Localizer.DoStr("Total Skill Rate: {0}"), targetUser.SkillRate) + "\n";
            PlayerStats += string.Format(Localizer.DoStr("SP: {0}"), String.Format("{0:0}", targetUser.XP)) + "\n";

            ChatBaseExtended.CBInfoPane(Title, PlayerStats, "Stats", user);
        }

        [ChatCommand("Displays a list of online citizens (doesn't auto update)")]
        public static void Online(User user)
        {
            int OnlineCount = Base.OnlineUsers.Count;
            string OnlineList = ListToString(Base.OnlineUsers);

            ChatBaseExtended.CBInfoPane("Citizens Online", string.Format("Total Citizens Online: {0}\n", OnlineCount.ToString()) + OnlineList, "PlayerList");
        }

        [ChatCommand("Displays a list of all admins on this server")]
        public static void Admins(User user)
        {
            ChatBaseExtended.CBInfoPane(Localizer.DoStr("Admins"), ListToString(Base.Admins), "Admins", user);
        }

        [ChatCommand("Displays a list of admins that are currently online.", "admins-online")]
        public static void AdminsOnline(User user)
        {
            ChatBaseExtended.CBInfoPane(Localizer.DoStr("Admins Online"), ListToString(Base.OnlineAdmins), "Admins", user);
        }

        [ChatCommand("Display Top 10 of players according to Activeness or Richness")]
        public static void Top(User user, string type)
        {
            var listType = Enum.Parse(typeof(ListType), type, true);

            switch (listType)
            {
                case ListType.Active:
                    TopActive(user.Player);
                    return;
                case ListType.Richest:
                    TopRichest(user.Player);
                    return;
                default:
                    ChatBaseExtended.CBError("You can only use, Active or Richest for this command.", user);
                    return;
            }
        }

        public static void TopActive(Player player)
        {
            string Title = Localizer.DoStr($"Top Active");
            string Content = string.Empty;

            int myrank = 0;
            int counter = 0;
            int limit = 10;
            Base.Users
                .OrderByDescending(u => u.TotalPlayTime)
                .Take(limit)
                .ForEach(u =>
                {
                    counter++;

                    if (counter <= limit)
                        Content += $"{counter}    {u.Name}    {Eco.Shared.Utils.TimeFormatter.FormatSpan(u.TotalPlayTime)}\n";

                    if (u.Player != null && u.Player == player)
                        myrank = counter;
                });

            if (myrank > limit)
                Content += $"{myrank}\t{player.DisplayName}\tTotal Play Time: {Eco.Shared.Utils.TimeFormatter.FormatSpan(player.User.TotalPlayTime)}\n";

            ChatBaseExtended.CBInfoPane(Title, Content, "Top",player, false, true);
        }

        public static void TopRichest(Player player)
        {
            var currencies = CurrencyManager.Currencies.Where(c => c.CurrencyType == Shared.Items.CurrencyType.Backed).ToList();

            if (currencies.Count == 0) {
                ChatBaseExtended.CBError("We couldn't find a non player currency, please try again later..?", player);
                return;
            }

            var Title = Localizer.DoStr($"Richest");
            var Content = string.Empty;

            currencies
                .OrderBy(c => c.Circulation)
                .Where(c => c != null && c.Circulation > 0)
                .ForEach(currency =>
                {
                    Content += "Rank \t Username \t Currency Name: Balance\n";
                    Content += $"\nby {currency.CurrencyType}\n";
                int myrank = 0, counter = 0, limit = 10;
                var accounts = BankAccountManager.Obj.Accounts;
                Base.Users
                    .OrderByDescending(u => accounts.Sum(a => a.GetCurrencyHoldingVal(currency, u)))
                    .Take(limit)
                    .ForEach(u =>
                        {
                            counter++;
                            var TotalBalance = accounts.Sum(a => a.GetCurrencyHoldingVal(currency, u));

                            if (counter <= limit)
                                Content += counter + $"\t{u.Name}\t\t{currency.Name}: {TotalBalance}\n";

                            if (u.Player == player)
                                myrank = counter;
                    });
                });

            if (string.IsNullOrWhiteSpace(Content))
                ChatBaseExtended.CBError(appName + $"Error: No Currency Found");
            else
                ChatBaseExtended.CBInfoPane(Title, Content, "Top", player, false, true);
        }

        public static string ListToString(List<User> Users)
        {
            var userlines = new List<string>();

            Users.ForEach(user =>
            {
                userlines.Add($"{user.Name} - {user.Reputation} - {user.Player.SkillTitle}");
            });

            return string.Join("\n", userlines);
        }
    }
}