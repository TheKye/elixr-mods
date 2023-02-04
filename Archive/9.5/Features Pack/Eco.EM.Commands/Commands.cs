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
    using Eco.Gameplay.Systems.Messaging.Chat.Commands;
    using Eco.EM.Framework.Utils;
    using System.Text;

    class Commands : IChatCommandHandler
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";

        [ChatCommand("See when players were last online", "last-online")]
        public static void LastOnline(User user, string target)
        {
            var targetUser = PlayerUtils.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBaseExtended.CBError($"{string.Format(appName + $"Unable to find user {0}", target)}", user);
                return;
            }

            string message;
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
        public static void Stats(User user, User target = null)
        {
            if (target == null)
                target = user;
            // Build Stats Information
            string Title = string.Format(Localizer.DoStr("Stats for {0}"), target.Name);
            StringBuilder PlayerStats = new();

            if (target.IsAdminOrDev && !target.IsAdmin)
                Title += " " + Localizer.DoStr("[DEV]");
            else if (target.IsAdmin)
                Title += " " + Localizer.DoStr("[ADMIN]");

            if (target.IsOnline)
                PlayerStats.Append(Text.Positive(Localizer.DoStr("Online")) + "\n");

            string gender = string.Format(Localizer.DoStr("Character Gender: {0}"), target.Avatar.Sex);
            gender = gender[0].ToString().ToUpper() + gender.Remove(0, 1);

            string skilltitle = string.Format(Localizer.DoStr("Skill Title: {0}"), target.Skillset.Title);
            _ = skilltitle[0].ToString().ToUpper() + skilltitle.Remove(0, 1);

            PlayerStats.Append($"{gender} {target.Skillset.Title}\n");
            PlayerStats.Append(string.Format(Localizer.DoStr("Online Time (Total): {0}"), TimeFormatter.FormatSpan(target.TotalPlayTime)) + "\n");

            if (user.LoggedIn)
                PlayerStats.Append(string.Format(Localizer.DoStr("Online Time (Session): {0}"), TimeFormatter.FormatSpan(WorldTime.Seconds - user.LoginTime)) + "\n");
            else
                PlayerStats.Append(string.Format(Localizer.DoStr("Online Time (Session): {0}"), Localizer.DoStr($"Offline")) + "\n");

            PlayerStats.Append(string.Format(Localizer.DoStr("Food Skill Rate: {0}"), target.Stomach.NutrientSkillRate()) + "\n");
            PlayerStats.Append(string.Format(Localizer.DoStr("House Skill Rate: {0}"), target.HomePropertyValue?.TotalSkillPoints ?? 0) + "\n");
            PlayerStats.Append(string.Format(Localizer.DoStr("Total Skill Rate: {0}"), target.UserXP.SkillRate) + "\n");
            PlayerStats.Append(string.Format(Localizer.DoStr("SP: {0}"), (int)target.UserXP.XP) + "\n");

            ChatBaseExtended.CBInfoPane(Title, PlayerStats.ToString(), "PlayerStats", user);
        }

        [ChatCommand("Displays a list of online citizens (doesn't auto update)")]
        public static void Online(User user)
        {
            int OnlineCount = PlayerUtils.OnlineUsers.Count;
            string OnlineList = ListToString(PlayerUtils.OnlineUsers);

            ChatBaseExtended.CBInfoPane("Citizens Online", string.Format("Total Citizens Online: {0}\n", OnlineCount.ToString()) + OnlineList, "PlayerStats", user);
        }

        [ChatCommand("Displays a list of all admins on this server")]
        public static void Admins(User user)
        {
            ChatBaseExtended.CBInfoPane(Localizer.DoStr("Admins"), ListToString(PlayerUtils.Admins), "PlayerStats", user);
        }

        [ChatCommand("Displays a list of admins that are currently online.", "admins-online")]
        public static void AdminsOnline(User user)
        {
            ChatBaseExtended.CBInfoPane(Localizer.DoStr("Admins Online"), ListToString(PlayerUtils.OnlineAdmins), "PlayerStats", user);
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
            PlayerUtils.Users
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
                Content += string.Format(Localizer.DoStr("{0}\t{1}\tTotal Play Time: {2}\n"), myrank, player.DisplayName, Eco.Shared.Utils.TimeFormatter.FormatSpan(player.User.TotalPlayTime));

            ChatBaseExtended.CBInfoPane(Title, Content, "PlayerStats", player, ChatBase.PanelType.InfoPanel, true);
        }

        public static void TopRichest(Player player)
        {
            var currencies = CurrencyManager.Currencies.Where(c => c.CurrencyType == Shared.Items.CurrencyType.Backed).ToList();

            if (currencies.Count == 0)
            {
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
                    Content += string.Format(Localizer.DoStr("\nby {0}\n"), currency.CurrencyType);
                    int myrank = 0, counter = 0, limit = 10;
                    var accounts = BankAccountManager.Obj.Accounts;
                    PlayerUtils.Users
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
                ChatBaseExtended.CBInfoPane(Title, Content, "PlayerStats", player, ChatBase.PanelType.InfoPanel, true);
        }

        public static string ListToString(List<User> Users)
        {
            var userlines = new List<string>();

            Users.ForEach(user =>
            {
                userlines.Add($"{user.Name} - Reputation: {user.Reputation} - Skill Title: {user.Player.SkillTitle}");
            });

            return string.Join("\n", userlines);
        }
    }
}