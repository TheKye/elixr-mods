namespace Eco.EM
{
    using Eco.Gameplay.Systems.Chat;
}

namespace Eco.EM
{

    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using System;

    public class DailyCommands : IChatCommandHandler
    {
        public static void Reload()
        {

        }

        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        [ChatCommand ("daily", "Get a daily reward of tokens", ChatAuthorizationLevel.User )]
        public static void Daily( User user )
        {
            try
            {
                var bClaimedToday   = EM.Daily.Instance.ClaimedToday ( user );
                var bCanClaim       = EM.Daily.Instance.CanClaim ( user );
                if (bClaimedToday)
                {
                    ChatBase.Send ( new ChatBase.Message (appName + "You already collected your Daily Reward", user ) );
                    return;
                }

                if (!bCanClaim)
                {
                    var message = string.Format ( Localizer.DoStr (appName + "You must play at least {0} minutes before claiming your daily. ({1})" ), EM.Daily.Instance.DailyConfig.Config.MinLoggedInTime, EM.Daily.TimeUntilCanClaim ( user, EM.Daily.Instance.DailyConfig.Config.MinLoggedInTime * 60 ) );
                    ChatBase.Send ( new ChatBase.Message ( message, user ) );
                    return;
                }


               // EM.Daily.Instance.GiveRewardTo ( user ); //, Daily.Instance.DailyConfig.Config.TokenReward
            }
            catch (Exception e)
            {
                ChatBase.Send ( new ChatBase.Message (appName + "Error: " + e.Message, user ) );
            }
        }
        [ChatCommand("daily-reload", "Reload Daily Settings", ChatAuthorizationLevel.Admin)]
        public static void reload(User user)
        {
            Reload();
            ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + "Daily Configs Reloaded"), user));
        }
    }
}
