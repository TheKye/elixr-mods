namespace Eco.EM.Votes
{
    using Eco.Core.Plugins;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.EM.Framework.Networking;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Players;
    using Eco.Plugins.Networking;
    using Eco.Shared.Utils;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VoteMod.Helpers;

    public sealed class VoteMechanics : IModKitPlugin, IInitializablePlugin
    {
        static readonly VoteMechanics _instance = new();
        public static VoteMechanics Instance => _instance;

        public PluginConfig<VoteConfig> VoteConfig;
        public IPluginConfig PluginConfig => VoteConfig;
        public Dictionary<int, string> ErrorDict = new()
        {
            { 304, "You have already voted today. Please vote again tomorrow." },
            { 401, "It seems like the api key used for this server is no longer valid. please notify the admin." },
            { 403, "It seems like the api key used for this server is no longer valid. please notify the admin." },
            { 404, "It seems like the api key used for this server is no longer valid. please notify the admin." },
            { 408, "We are having trouble connecting to tso, please try again later." },
            { 500, "We are having trouble connecting to tso, please try again later." },
            { 502, "We are having trouble connecting to tso, please try again later." },
            { 503, "We are having trouble connecting to tso, please try again later." },
            { 504, "We are having trouble connecting to tso, please try again later." },
            { 0, "Unable to cast your vote at this time, please try again later." }
        };

        public VoteMechanics() => Load();

        public object GetEditObject() => VoteConfig.GetConfig();
        public void OnEditObjectChanged(object o, string param)
        {
            SaveConfig();
        }
        public void Initialize(TimedTask timer)
        {
            UserManager.OnUserLoggedIn.Add(CheckVotes);
            Load();
            status = "Initialized";
        }

        public string status = "Loading...";
        public override string ToString() => "TSO Voter Mod";
        public string GetStatus() => status;

        Currency currency = null;

        public void CheckVotes(User user)
        {
            var claimedCount = Instance.UnclaimedVotes(user);
            if (claimedCount > 0)
            {
                ChatHelper.SendMessageToPlayer(PhraseDictionary.CheckVotes_VotesUnclaimed, user);
            }
            else
            {
                ChatHelper.SendMessageToPlayer("No Votes To Claim", user);
            }
        }

        public string CastVote(User user)
        {
            try
            {
                var webport = NetworkManager.Config.WebServerPort;
                if (string.IsNullOrEmpty(user.SteamId))
                {
                    Console.WriteLine(string.Format("{0} failed to vote.", user.Name));
                    return "Unable to cast vote, please try running Eco via Steam.";
                }

                var endpoint = EndPoints.CastVoteTSOURL(VoteConfig.Config.TsoServerAPIKey, user.SteamId);
                var responseString = Network.GetRequest(endpoint);
                dynamic response = JsonConvert.DeserializeObject(responseString);

                int statusCode = response.StatusCode;

                if (statusCode == 200)
                {
                    user.UserXP.AddExperience(VoteConfig.Config.RewardExperience * -1);

                    if (VoteConfig.Config.RewardCurrency > 0 && !string.IsNullOrWhiteSpace(VoteConfig.Config.RewardCurrencyName))
                    {
                        var currencyName = VoteConfig.Config.RewardCurrencyName.ToLower();
                        if (currency == null && CurrencyManager.Currencies.Any(c => c.Name.ToLower() == currencyName))
                        {
                            currency = CurrencyManager.Currencies.First(c => c.Name.ToLower() == currencyName);
                        }

                        if (currency == null)
                        {
                            Console.WriteLine(string.Format("Unable to issue {0} {1}. Unable to find currency with that name", VoteConfig.Config.RewardCurrency, VoteConfig.Config.RewardCurrencyName));

                            return string.Empty;
                        }

                        user.BankAccount.AddCurrency(currency, VoteConfig.Config.RewardCurrency * 1);
                    }

                    Console.WriteLine(string.Format("{0} has voted for the server", user.Name));
                    return response.Message;
                }
                else
                {
                    return ErrorDict.ContainsKey(statusCode) ? ErrorDict[statusCode] : ErrorDict[0];

                }
            }
            catch (Exception)
            {
                return ErrorDict.ContainsKey(0) ? ErrorDict[0] : ErrorDict[0];
            }
        }

        public string CheckTopVoters()
        {
            var endpoint = EndPoints.TopVotersTSOURL(VoteConfig.Config.TsoServerAPIKey);
            var responseString = Network.GetRequest(endpoint);
            var response = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (response.StatusCode != null)
            {
                int statusCode = response.StatusCode;
                switch (statusCode)
                {
                    case 200:
                        string voters = "";
                        foreach (var u in response.Message.TopVoter)
                        {
                            voters += $"\n{u.Username} with <color=orange>{u.Votes}</color> votes.";
                        }
                        return $"Total Votes For This Month: <color=orange>{response.Message.TotalVotes}</color>\nTop Voters: \n{voters}";
                    case 403:
                        return "Top Voter Checks are not enabled on this server, please talk to your admin.";
                    default:
                        return ErrorDict.ContainsKey(statusCode) ? ErrorDict[statusCode] : ErrorDict[0];
                }
            }
            else
            {
                return "Unable to fetch the Top Voters at this time, please try again later";
            }

        }

        public int UnclaimedVotes(User user)
        {
            try
            {
                var webport = NetworkManager.Config.WebServerPort;
                if (string.IsNullOrEmpty(user.SteamId))
                    return 0;
                if (!string.IsNullOrEmpty(VoteConfig.Config.TsoServerAPIKey))
                {
                    var endpoint = EndPoints.UnclaimedVotesTSOURL(VoteConfig.Config.TsoServerAPIKey, user.SteamId);
                    var responseString = Network.GetRequest(endpoint);
                    var response = JsonConvert.DeserializeObject<UnclaimedVotesResponse>(responseString);
                    if (response.StatusCode == 200 && response.Result.Claimed > 0)
                    {
                        user.UserXP.AddExperience(VoteConfig.Config.RewardExperience * -1);
                        if (VoteConfig.Config.RewardCurrency > 0 &&
                            !string.IsNullOrEmpty(VoteConfig.Config.RewardCurrencyName))
                        {
                            var currencyName = VoteConfig.Config.RewardCurrencyName.ToLower();
                            if (currency == null && CurrencyManager.Currencies.Any(c => c.Name.ToLower() == currencyName))
                                currency = CurrencyManager.Currencies.First(c => c.Name.ToLower() == currencyName);

                            if (currency != null)
                                user.BankAccount.AddCurrency(currency, VoteConfig.Config.RewardCurrency * 1);
                        }
                        return response.Result.Claimed;
                    }
                    else
                        return 0;
                }
                else if (!string.IsNullOrEmpty(VoteConfig.Config.EcoServerAPIKey))
                {
                    var endpoint = EndPoints.UnclaimedVotesESURL(VoteConfig.Config.EcoServerAPIKey, user.SteamId);
                    var responseString = Network.GetRequest(endpoint);
                    var response = JsonConvert.DeserializeObject<UnclaimedVotesResponse>(responseString);
                    if (response.StatusCode == 200 && response.Result.Claimed == 1)
                    {
                        user.UserXP.AddExperience(VoteConfig.Config.RewardExperience * -1);
                        if (VoteConfig.Config.RewardCurrency > 0 &&
                            !string.IsNullOrEmpty(VoteConfig.Config.RewardCurrencyName))
                        {
                            var currencyName = VoteConfig.Config.RewardCurrencyName.ToLower();
                            if (currency == null && CurrencyManager.Currencies.Any(c => c.Name.ToLower() == currencyName))
                                currency = CurrencyManager.Currencies.First(c => c.Name.ToLower() == currencyName);

                            if (currency != null)
                                user.BankAccount.AddCurrency(currency, VoteConfig.Config.RewardCurrency * 1);
                        }
                        return response.Result.Claimed;
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #region Load / Save
        public void LoadConfig() => VoteConfig = new PluginConfig<VoteConfig>("TSOConfig");
        public void Load()
        {
            try
            {
                LoadConfig();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while loading vote rewards data.");
                Console.WriteLine(e.Message);
            }
        }

        public void SaveConfig() => VoteConfig.SaveAsync();
        public void Save()
        {
            try
            {
                SaveConfig();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while saving vote rewards data.");
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
