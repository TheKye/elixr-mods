namespace Eco.EM
{
    using Eco.EM.Enums;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Chat;
    using Gameplay;
    using Shared.Utils;
    using Simulation.Time;
    using Stats;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Economy;

    class Commands : IChatCommandHandler
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        private struct PopulationStat
        {
            public string Key;
            public string Current;
            public float Change;
        }

        [ChatCommand("lastonline", "See when players were last online")]
        public static void LastOnline(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error($"{string.Format(Localizer.DoStr(appName + $"Unable to find user {0}"), target)}"), user));
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

            ChatBase.Send(new ChatBase.Message(message, user.Player));
        }

        [ChatCommand("stats", "Display stats of players.")]
        public static void Stats(User user, string target)
        {
            User targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                var message = string.Format(Localizer.DoStr(appName + $"Unable to find user {0}"), target);
                ChatBase.Send(new ChatBase.Message(Text.Error(message), user));
                return;
            }

            // Build Stats Information
            string Title = string.Format(Localizer.DoStr(appName + "Stats for {0}"), targetUser.Name);
            string PlayerStats = string.Empty;

            if (targetUser.IsAdminOrDev && !targetUser.IsAdmin)
                Title += " " + Localizer.DoStr("[DEV]");
            else if (targetUser.IsAdmin)
                Title += " " + Localizer.DoStr("[ADMIN]");

            if (targetUser.Player != null)
                PlayerStats += Text.Positive(Localizer.DoStr("Online")) + "\n";

            string gender = Localizer.DoStr($"{targetUser.Avatar.Sex}");
            gender = gender[0].ToString().ToUpper() + gender.Remove(0, 1);

            string skilltitle = Localizer.DoStr($"{targetUser.Skillset.Title}");
            skilltitle = skilltitle[0].ToString().ToUpper() + skilltitle.Remove(0, 1);

            PlayerStats += $"{gender} {targetUser.Skillset.Title}\n";
            PlayerStats += string.Format(Localizer.DoStr(appName + "Online Time (Total): {0}"), Eco.Shared.Utils.TimeFormatter.FormatSpan(targetUser.TotalPlayTime)) + "\n";
            if (user.LoggedIn)
                PlayerStats += string.Format(Localizer.DoStr(appName + "Online Time (Session): {0}"), Eco.Shared.Utils.TimeFormatter.FormatSpan(WorldTime.Seconds - targetUser.LoginTime)) + "\n";
            else
                PlayerStats += string.Format(Localizer.DoStr(appName + "Online Time (Session): {0}"), Localizer.DoStr($"Offline")) + "\n";
            PlayerStats += string.Format(Localizer.DoStr(appName + "Food Skill Rate: {0}"), (targetUser.SkillRate - targetUser.CachedHouseValue.HousingSkillRate)) + "\n";
            PlayerStats += string.Format(Localizer.DoStr(appName + "House Skill Rate: {0}"), (targetUser.CachedHouseValue.HousingSkillRate)) + "\n";
            PlayerStats += string.Format(Localizer.DoStr(appName + "Total Skill Rate: {0}"), targetUser.SkillRate) + "\n";
            PlayerStats += string.Format(Localizer.DoStr(appName + "SP: {0}"), String.Format("{0:0}", targetUser.XP)) + "\n";

            user.Player.OpenInfoPanel(
                Title,
                PlayerStats
            );
        }

        [ChatCommand("version", "Display the current installed version of EM")]
        public static void Version(User user)
        {
            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "EM Version: {0}"), Base.version), user));
        }

        [ChatCommand("online", "Displays a list of online citizens (doesn't auto update)")]
        public static void Online(User user)
        {
            int OnlineCount = Base.OnlineUsers.Count;
            string OnlineList = ListToString(Base.OnlineUsers);

            user.Player.OpenInfoPanel(
                Localizer.DoStr(appName + "Citizens Online"),
                string.Format(Localizer.DoStr(appName + "Total Citizens Online: {0}\n"), OnlineCount.ToString()) + OnlineList);
        }

        [ChatCommand("admins", "Displays a list of all admins on this server")]
        public static void Admins(User user)
        {
            user.Player.OpenInfoPanel(Localizer.DoStr("Admins"), ListToString(Base.Admins));
        }

        [ChatCommand("admins-online", "Displays a list of admins that are currently online.")]
        public static void AdminsOnline(User user)
        {
            user.Player.OpenInfoPanel(Localizer.DoStr("Admins Online"), ListToString(Base.OnlineAdmins));
        }

        [ChatCommand("top", "Display Top 10 of players according to Activeness or Richness")]
        public static void Top(User user, string type)
        {
            var listType = Enum.Parse(typeof(ListType), type, true);

            switch (listType)
            {
                case ListType.Active:
                    TopActive(user.Player);
                    return;
                    /*                case ListType.Richest:
                                        TopRichest(user.Player);
                                    return;*/
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
                Content += $"{myrank}\t{player.DisplayName}\t{Eco.Shared.Utils.TimeFormatter.FormatSpan(player.User.TotalPlayTime)}\n";

            player.OpenInfoPanel(
                Title,
                Content
            );
        }

        /* public static void TopRichest(Player player)
         {
             var currencies = CurrencyManager.Currencies.Where( c => c.CurrencyType == Shared.Items.CurrencyType.Backed ).ToList( );

             if (currencies.Count == 0)
                 return;

             var Title = Localizer.DoStr($"Richest");
             var Content = string.Empty;

             currencies
                 .OrderBy( c => c.Circulation )
                 .Where( c => c != null && c.Circulation > 0 )
                 .ForEach(currency =>
             {
                 Content += $"\nby {currency.CurrencyType}\n";
                 int myrank = 0, counter = 0, limit = 10;
                 var accounts = BankAccountManager.Obj.GetAccountsForCurrency( currency.Id );
                 Base.Users
                     .OrderByDescending( u => accounts.Sum(a => a.account.GetCurrencyHoldingVal( currency ) ) )
                     .Take( limit )
                     .ForEach( u =>
                         {
                             counter++;
                             var TotalBalance = accounts.Sum(a => a.account.GetCurrencyHoldingVal( currency ) );

                             if (counter <= limit)
                                 Content += counter + $"\t{u.Name}\t{TotalBalance}\n";

                             if (u.Player == player)
                                 myrank = counter;
                         } );
             } );

             if (string.IsNullOrWhiteSpace(Content))
                 ChatBase.Send(new ChatBase.Message(Text.Error(Localizer.DoStr(appName + $"Error: No Currency Found"))));
             else
                 player.OpenInfoPanel( Title, Content );
         }*/

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