namespace Eco.EM
{
    using Eco.Core.Plugins;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;

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
        public PluginConfig<VoteLogs> VoteLogs;
        public IPluginConfig PluginConfig => VoteConfig;

        public VoteMechanics()
        {
            LoadConfig( );
            LoadLogs( );

            if (!string.IsNullOrWhiteSpace( VoteConfig.Config.ServerAPIKey ))
            {
                VoteTicker = new Timer( Tick, null, 0, 15000 );

                _ServerURL = GetServerURL( VoteConfig.Config.ServerAPIKey );
            }
        }

        private Timer VoteTicker;
        private string _ServerURL;
        public string ServerURL {
            get {
                if (string.IsNullOrWhiteSpace( _ServerURL ))
                    _ServerURL = GetServerURL( VoteConfig.Config.ServerAPIKey );

                return _ServerURL;
            }
        }

        public object GetEditObject() => VoteConfig.Config;
        public void OnEditObjectChanged( object o, string param ) => SaveConfig( );
        public void Initialize( TimedTask timer )
        {

        }

        public string status = "Initialized";
        public override string ToString() => "Vote Rewards";
        public string GetStatus() => status;

        #region Methods
        private string GetServerURL( string ServerApiKey ) => Eco.EM.VoteRewards.EcoServers.GetServerURL( ServerApiKey );
        private bool AddVote( VoteItem vote ) => AddVote( vote.nickname, vote.date, vote.steamid, vote.timestamp, ( vote.claimed == "1" ) ? true : false );
        private bool AddVote( string Nickname, string Date, string SteamID, string Timestamp, bool IsClaimed )
        {
            try
            {
                VoteLogs.Config.Votes.Add( new VoteItem( )
                {
                    claimed     = ( IsClaimed ) ? "1" : "0",
                    nickname    = Nickname,
                    date        = Date,
                    steamid     = SteamID,
                    timestamp   = Timestamp
                } );
                SaveLogs( );
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool VoteExists( VoteItem vote ) => VoteLogs.Config.Votes.Any( vl => vl.timestamp == vote.timestamp && vl.nickname == vote.nickname && vl.steamid == vote.steamid );
        public bool HasRewardsToCollect( User user ) => RewardsToCollect( user ) > 0;
        public int  RewardsToCollect( User user )    => VoteLogs.Config.Votes.Count( vl => vl.nickname == user.Name || (user.SteamId != string.Empty && vl.steamid == user.SteamId) );
        public void ClaimFor(User user)
        {

        }

        public void Tick( object state ) 
        {
            status = "Ticking...";

            if (string.IsNullOrWhiteSpace(VoteConfig.Config.ServerAPIKey))
                return;

            new Thread( () =>
            {
                try
                {
                    var votesresponse = Base.GetRequest( EndPoints.GetVotersURL( VoteConfig.Config.ServerAPIKey ) );
                    if (votesresponse.StartsWith( "Error" ))
                    {
                        Console.WriteLine( Localizer.DoStr( "Invalid apikey for Vote Rewards" ) );
                        status = "Invalid API Key";
                        return;
                    }
                    var GetVotes = Core.Serialization.SerializationUtils.DeserializeJson<VoteResponse>( votesresponse );
                    var NotifiedUsers = new List<string>( );

                    GetVotes.votes
                        .Where( v => v.claimed == "0" && ( !string.IsNullOrWhiteSpace( v.nickname ) || !string.IsNullOrWhiteSpace( v.steamid ) ) )
                        .ForEach( vote =>
                        {
                            if (!VoteExists( vote ))
                            {
                                AddVote( vote );

                                if (!NotifiedUsers.Contains( vote.nickname ) && !NotifiedUsers.Contains( vote.steamid ))
                                {
                                    var user = Base.GetUser( ( !string.IsNullOrWhiteSpace( vote.nickname ) ) ? vote.nickname : vote.steamid );

                                    if (user == null)
                                        return;

                                    ChatBase.Send( new ChatBase.Message( "Thank you for voting. Use /reward to claim your reward.", user ) );
                                    NotifiedUsers.Add( vote.nickname ?? vote.steamid );
                                }
                            }
                        } );
                
                    Save();

                    status = "Ready";
                }
                catch (WebException)
                {
                    Console.WriteLine( $"EcoServers.io is unavailable at this time." );
                    status = "Unable to establish connection with ecoservers.io";
                }
                catch (Exception e)
                {
                    status = "An error occured during the tick process.";
                    Console.WriteLine( Localizer.DoStr( $"An issue has occured during the Vote Rewards Tick." ) );
                    Console.WriteLine( e.Message );
                    Console.WriteLine( e.StackTrace );
                    Console.WriteLine( e.Source );
                }
            } ).Start( );
        }

        public static string TimeLeftToday()
        {
            var ResetTime = DateTime.Today.AddDays( 1 );
            var TimeLeft = ResetTime.Subtract( DateTime.Now );

            return TimeFormatter.FormatSpan( TimeLeft );
        }
        public static string TimeUntilCanClaim( User user, int MinTimeInSeconds )
        {
            var LoginTime = user.LoginTime;
            var SessionDuration = DateTime.Now.Subtract( DateTime.MinValue ).TotalSeconds - user.LoginTime;

            if (SessionDuration > MinTimeInSeconds)
                return "Ready";

            var TimeLeft = MinTimeInSeconds - user.LoginTime;
            return TimeFormatter.FormatSpan( TimeLeft );
        }
        #endregion

        #region Load / Save
        public void LoadConfig() => VoteConfig = new PluginConfig<VoteConfig>( "EMVoteConfig" );
        public void LoadLogs()   => VoteLogs   = new PluginConfig<VoteLogs>( "EMVoteLogs" );
        public void Load()
        {
            try {
                LoadConfig();
                LoadLogs();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while loading vote rewards data.");
                Console.WriteLine(e.Message);
            }
        }

        public void SaveConfig() => VoteConfig.Save( );
        public void SaveLogs()   => VoteLogs.Save( );
        public void Save()
        {
            try {
                SaveConfig( );
                SaveLogs( );
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
