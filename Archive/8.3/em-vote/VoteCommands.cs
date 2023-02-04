namespace Eco.EM
{
    using Eco.Gameplay.Systems.Chat;
}

namespace Eco.EM
{
    using System;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;

    public class VoteCommands : IChatCommandHandler
    {
        #region Properties
        private static VoteConfig Config => VoteMechanics.Instance.VoteConfig.Config;
        private static VoteLogs   Logs   => VoteMechanics.Instance.VoteLogs.Config;
        #endregion

        #region Commands
        [ChatCommand( "tick", "If rewards are stuck, or you cannot wait until the next tick, use this.", ChatAuthorizationLevel.Admin )]
        public static void Tick() => VoteMechanics.Instance.Tick(null);

        [ChatCommand( "vote", "Retrieve the voting url of this server" )]
        public static void DoVote( User user )
        {
            if (string.IsNullOrWhiteSpace(VoteMechanics.Instance.ServerURL))
                ChatBase.Send( new ChatBase.Message( Localizer.DoStr( "Vote Rewards has not yet been setup on this server." ), user ) );
            else
                ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "Cast your vote at {0} then use /reward to get your tokens" ), VoteMechanics.Instance.ServerURL ), user ) );
        }

        [ChatCommand( "reward", "Collect your vote rewards" )]
        public static void DoReward( User user )
        {
            VoteMechanics.Instance.Load();
            
            if (!VoteMechanics.Instance.HasRewardsToCollect( user ))
            {
                ChatBase.Send( new ChatBase.Message( Localizer.DoStr( "You don't have any unclaimed votes to collect" ), user ) );
                return;
            }

            var TimeUntilCanClaim = VoteMechanics.TimeUntilCanClaim( user, VoteMechanics.Instance.VoteConfig.Config.MinLoggedInTime * 60 );
            if (TimeUntilCanClaim != "Ready")
            {
                var LocalizedMessage = string.Format( Localizer.DoStr( "You must play at least {0} minutes before claiming your reward" ), Config.MinLoggedInTime );
                LocalizedMessage += $"({TimeUntilCanClaim})";

                ChatBase.Send( new ChatBase.Message( LocalizedMessage, user ) );
                return;
            }

            var TokensToCollect = VoteMechanics.Instance.RewardsToCollect( user ) * Config.RewardTokens;
           /* if (TokensToCollect > 0)
            {
                if (!user.Inventory.TryAddItems<Items.TokenItem>( ( TokensToCollect ), user ))
                {
                    ChatBase.Send( new ChatBase.Message( Localizer.DoStr( "Error: Unable to give you the reward, perhaps your inventory is full?" ), user ) );
                    return;
                }
            }*/

           //if (Config.RewardCurrency > 0)
           //{
           //    var currency = user.Currency.GetCurrency(Config.RewardCurrencyName);
           //    if (currency == null)
           //        ChatBase.Send( new ChatBase.Message( Localizer.DoStr( "Unable to reward the currency as currency no longer exist" ), user ) );
           //    else
           //        currency.GetAccount(user.Name).Val += Config.RewardCurrency * TokensToCollect;
           //}

            VoteMechanics.Instance.ClaimFor( user );
            
            ChatBase.Send( new ChatBase.Message( Localizer.DoStr( "Thank you for voting, you have received your reward" ), user ) );
        }
        
        [ChatCommand( "vote-minlogintime", "Set the minimum logged in time a player must spend before collecting reward", ChatAuthorizationLevel.Admin )]
        public static void SetMinLoginTime( User user, int Minutes = -1 )
        {
            if (Minutes < 0)
            {
                ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "A player must play for atleast {0} minutes before collecitng the rewards" ), Config.MinLoggedInTime ), user ) );
                return;
            }

            Config.MinLoggedInTime = Minutes;
            VoteMechanics.Instance.SaveConfig();

            ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "Minimum play time has ben set to {0} Minutes" ), Minutes ), user ) );
        }

        [ChatCommand( "apikey", "Set the server API Key from ecoservers.io", ChatAuthorizationLevel.Admin )]
        public static void SaveApiKey( User user, string ApiKey = "" )
        {
            if (string.IsNullOrWhiteSpace( ApiKey ))
            {
                ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "Current ApiKey is {0}" ), Config.ServerAPIKey ), user ) );
                return;
            }

            Config.ServerAPIKey = ApiKey;
            VoteMechanics.Instance.SaveConfig();

            ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "ApiKey has been set to {0}" ), Config.ServerAPIKey ), user ) );
        }

        //[ChatCommand( "top-voters", "Retrieve the list of the top voters" )]
        //public static void DoTopVoters( User user )
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace( ServerApiKey ))
        //        {
        //            ChatBase.Send( new ChatBase.Message( Localizer.DoStr( "Vote Rewards has not yet been setup on this server." ), user ) );
        //            return;
        //        }

        //        var Response = Base.GetRequest( EndPoints.TopVoters.Replace( "<apikey>", ServerApiKey ) );

        //        var topVotersResponse = Eco.Core.Serialization.SerializationUtils.DeserializeJson<TopVotersResponse>( Response );

        //        var text = string.Empty;
        //        var counter = 0;
        //        foreach (var voter in topVotersResponse.voters)
        //        {
        //            if (!string.IsNullOrWhiteSpace( voter.nickname ))
        //            {
        //                counter++;
        //                text += $"{counter}  {voter.nickname}     {voter.votes} \n";
        //            }
        //        }

        //        user.Player.OpenInfoPanel( Localizer.DoStr( "Top Voters" ), text );
        //    }
        //    catch (WebException)
        //    {
        //        ChatBase.Send( new ChatBase.Message( Localizer.DoStr( "EcoServers.io is unavailable at this time." ) ) );
        //    }
        //}

        [ChatCommand( "reward-token", "Set the amount of tokens to be rewarded to players who vote.", ChatAuthorizationLevel.Admin )]
        public static void TokenReward( User user, int Amount )
        {
            if (Amount < 0)
            {
                ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "Token Reward is currently set to {0} Tokens." ), Config.RewardTokens ), user ) );
                return;
            }

            Config.RewardTokens = Amount;
            if (Amount == 0)
                ChatBase.Send( new ChatBase.Message( Localizer.DoStr( "Token Reward has been disabled" ), user ) );
            else
                ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "Token Reward has been set to {0}" ), Amount.ToString( ) ), user ) );

            VoteMechanics.Instance.SaveConfig();
        }

        [ChatCommand( "reward-currency", "Set the amount of currency to be rewarded to players who vote.", ChatAuthorizationLevel.Admin )]
        public static void CurrencyReward( User user, int Amount, string CurrencyName )
        {
            if (Amount < 0)
            {
                ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "Currency Reward is currently set to {0} {1}." ), Config.RewardCurrency, Config.RewardCurrencyName ), user ) );
                return;
            }

            var currency = CurrencyManager.Obj.GetClosestCurrency( CurrencyName );
            if (currency.Id == System.Guid.NewGuid())
            {
                ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "Currency {0} does not exist." ), CurrencyName ), user ) );
                return;
            }

            Config.RewardCurrency = Amount;
            Config.RewardCurrencyName = CurrencyName;

            ChatBase.Send( new ChatBase.Message( string.Format( Localizer.DoStr( "Currency Reward has been set to {0} {1}." ), Config.RewardCurrency, Config.RewardCurrencyName ), user ) );
        }
        #endregion
    }
}
