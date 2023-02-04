namespace Eco.TSO
{
    using Eco.Core.Plugins;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Players;
    using Eco.Plugins.Networking;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public sealed class VoteMechanics : IModKitPlugin, IInitializablePlugin, IConfigurablePlugin
    {
        static readonly VoteMechanics _instance = new VoteMechanics( );
        public static VoteMechanics Instance
        {
            get {
                return _instance;
            }
        }

        public PluginConfig<VoteConfig> VoteConfig;
        public IPluginConfig PluginConfig => VoteConfig;

        public VoteMechanics() => Load();

        public object GetEditObject() => VoteConfig.GetConfig();
        public void OnEditObjectChanged( object o, string param ) {
            if ( !string.IsNullOrEmpty(VoteConfig.Config.ServerAPIKey) )
                status = "Initialized - " + VoteConfig.Config.ServerAPIKey;

             SaveConfig( );
        }
        public void Initialize( TimedTask timer )
        {
            Load();
            status = "Initialized";
        }

        public string status = "Loading...";
        public override string ToString() => "TSO Voter Mod";
        public string GetStatus() => status;

        Currency currency = null;

        public string CastVote( User user )
        {
            var webport = NetworkManager.Config.WebServerPort;
            if ( string.IsNullOrEmpty(user.SteamId) )
            {
                Console.WriteLine( string.Format( "{0} failed to vote.", user.Name ) );
                return "Unable to cast vote, please try running Eco via Steam.";
            }

            var endpoint = EndPoints.CastVoteURL( VoteConfig.Config.ServerAPIKey, user.SteamId );
            var responseString = NetworkHelper.GET( endpoint );
            dynamic response = JsonConvert.DeserializeObject( responseString );

            if (response.StatusCode == 200)
            {
                user.UseXP( VoteConfig.Config.RewardExperience * -1 );
                if ( VoteConfig.Config.RewardCurrency > 0 &&
                    !string.IsNullOrEmpty( VoteConfig.Config.RewardCurrencyName ))
                {
                    var currencyName = VoteConfig.Config.RewardCurrencyName.ToLower();
                    if (currency == null && CurrencyManager.Obj.Currencies.Any( c => c.CurrencyName.ToLower() == currencyName ))
                        currency = CurrencyManager.Obj.Currencies.First( c => c.CurrencyName.ToLower() == currencyName );

                    if (currency != null)
                        user.BankAccount.AddCurrency(currency, VoteConfig.Config.RewardCurrency);
                    else
                        Console.WriteLine( string.Format( "Unable to issue {0} {1}. Unable to find currency with that name", VoteConfig.Config.RewardCurrency, VoteConfig.Config.RewardCurrencyName ));
                }

                Console.WriteLine( string.Format( "{0} has voted for the server", user.Name ) );
                return response.Message;
            } else
                return response.Message??"Unable to cast your vote at this time, please try again later.";
        }
        public int UnclaimedVotes( User user )
        {
            var webport = NetworkManager.Config.WebServerPort;
            if ( string.IsNullOrEmpty(user.SteamId) )
                return 0;

            var endpoint = EndPoints.UnclaimedVotesURL( VoteConfig.Config.ServerAPIKey, user.SteamId );
            var responseString = NetworkHelper.GET( endpoint );
            var response = JsonConvert.DeserializeObject<UnclaimedVotesResponse>( responseString );

            if (response.StatusCode == 200)
            {
                user.UseXP( (VoteConfig.Config.RewardExperience * response.Result.Claimed) * -1 );
                if ( VoteConfig.Config.RewardCurrency > 0 &&
                    !string.IsNullOrEmpty( VoteConfig.Config.RewardCurrencyName ))
                {
                    var currencyName = VoteConfig.Config.RewardCurrencyName.ToLower();
                    if (currency == null && CurrencyManager.Obj.Currencies.Any( c => c.CurrencyName.ToLower() == currencyName ))
                        currency = CurrencyManager.Obj.Currencies.First( c => c.CurrencyName.ToLower() == currencyName );

                    if (currency != null)
                        user.BankAccount.AddCurrency(currency, VoteConfig.Config.RewardCurrency * response.Result.Claimed);
                }
                return response.Result.Claimed;
            } else
                return 0;
        }

        #region Load / Save
        public void LoadConfig() => VoteConfig = new PluginConfig<VoteConfig>( "TSOConfig" );
        public void Load()
        {
            try {
                LoadConfig();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while loading vote rewards data.");
                Console.WriteLine(e.Message);
            }
        }

        public void SaveConfig() => VoteConfig.Save( );
        public void Save()
        {
            try {
                SaveConfig( );
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while loading vote rewards data.");
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
