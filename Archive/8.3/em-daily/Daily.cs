namespace Eco.EM
{
    using Eco.Core.Plugins;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.EM.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using System;
    using System.Linq;

    public sealed class Daily : IModKitPlugin, IInitializablePlugin, IConfigurablePlugin, IChatCommandHandler
    {
        private static bool loaded = false;
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        static readonly Daily _instance = new Daily();
        public static Daily Instance
        {
            get {
                return _instance;
            }
        }
        public PluginConfig<DailyReward> DailyConfig;
        public PluginConfig<DailyLogs>   DailyLogs;
        public IPluginConfig PluginConfig => DailyConfig;

        public ThreadSafeAction<object, string> ParamChanged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Daily()
        {
            LoadConfig ( );
            LoadLogs ( );
            loaded = true;
        }

        public object GetEditObject() => DailyConfig.Config;

        public void OnEditObjectChanged( object o, string param ) => SaveConfig ( );

        public void Initialize ( TimedTask timer ) { }

        public override string ToString() => "Daily Rewards";
        public string GetStatus() => $"{ClaimsToday()} claims today";

        #region Methods
        private bool AddLog( User user )
        {
            try
            {
                DailyLogs.Config.Logs.Add ( new DailyLog ( )
                {
                    User        = Base.WhoAmI ( user ),
                    Timestamp   = DateTime.Now
                } );
                SaveLogs ( );
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       // public bool GiveTokensTo( User user, int Amount ) => GiveRewardTo( user );
       /* public bool GiveRewardTo( User user )
       // {
           // try
           // 
{          //
           //     var rand = RandomUtil.Range(1, 100);
           //     var RewardType = typeof(EMGift000Item);
           //
           //     if (rand <= 35)
           //         RewardType = typeof(EMGift000Item);
           //     else if (rand <= 47)
           //         RewardType = typeof(EMGift001Item);
           //     else if (rand <= 74)
           //         RewardType = typeof(EMGift002Item);
           //     else if (rand <= 79)
           //         RewardType = typeof(EMGift003Item);
           //     else if (rand <= 82)
           //         RewardType = typeof(EMGift004Item);
           //     else if (rand <= 92)
           //         RewardType = typeof(EMGift005Item);
           //     else if (rand <= 100)
           //         RewardType = typeof(EMGift006Item);
           //
           //     if (!user.Inventory.TryAddItems(RewardType, 1, user ))
           //     {
           //         ChatBase.Send ( new ChatBase.Message ( "Error: Unable to give you the daily reward, perhaps your inventory is full?" ) );
           //         return false;
           //     }
           //
             //   AddLog ( user );

               // if (!string.IsNullOrEmpty ( DailyConfig.Config.CurrencyName ))
               // {
               //     var currency = user.Currency.GetCurrency ( DailyConfig.Config.CurrencyName );
               //     if (currency != null)
               //     {
               //         var userpocket = currency.GetAccount ( user.Name );
               //         userpocket.SetVal ( userpocket.Val + DailyConfig.Config.CurrencyReward );
               //     }
               // }
                ChatBase.Send ( new ChatBase.Message ( Text.Positive ( "Your daily reward has been claimed." ), user ) );
                AddCredits(user);
                return true;
            
           // catch (Exception)
            
                return false;
            }
        }*/
        public bool ClaimedToday( User user )
        {
            var userid = Base.WhoAmI ( user );
            return DailyLogs.Config.Logs.Count ( l => l.Timestamp > DateTime.Today && l.User == userid ) > 0;
        }
        public int  ClaimsToday () => DailyLogs.Config.Logs.Count ( l => l.Timestamp > DateTime.Today );
        public bool CanClaim( User user ) => ( TimeUntilCanClaim ( user, DailyConfig.Config.MinLoggedInTime * 60 ) == "Ready" && !ClaimedToday ( user ) );
        public void AddCredits( User user )
        {
            string EMapi = $"https://claystk.info/claimed/daily?whoami={Base.WhoAmI(user)}";
            Base.GetRequest(EMapi);
        }

        public static string TimeLeftToday()
        {
            var ResetTime = DateTime.Today.AddDays ( 1 );
            var TimeLeft = ResetTime.Subtract ( DateTime.Now );

            return TimeFormatter.FormatSpan ( TimeLeft );
        }
        public static string TimeUntilCanClaim( User user, int MinTimeInSeconds )
        {
            var LoginTime = user.LoginTime;
            var SessionDuration = DateTime.Now.Subtract ( DateTime.MinValue ).TotalSeconds - user.LoginTime;

            if (SessionDuration > MinTimeInSeconds)
                return "Ready";

            var TimeLeft = MinTimeInSeconds - user.LoginTime;
            return TimeFormatter.FormatSpan ( TimeLeft );
        }
        #endregion

       #region Load / Save
        public void LoadConfig() => DailyConfig = new PluginConfig<DailyReward> ( "EMDailyRewards" );
        public void LoadLogs() => DailyLogs = new PluginConfig<DailyLogs> ( "EMDailyLogs" );

        public void SaveConfig() => DailyConfig.SaveAsync ( );
        public void SaveLogs() => DailyLogs.SaveAsync ( );
        public void Save()
        {
            SaveConfig ( );
            SaveLogs ( );
        }
        #endregion

    }
}