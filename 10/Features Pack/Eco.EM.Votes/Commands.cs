using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Votes
{
    using Eco.EM.Framework.ChatBase;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using VoteMod.Helpers;

    public class VoteCommands : IChatCommandHandler
    {
        #region Properties
        private static VoteConfig Config => VoteMechanics.Instance.VoteConfig.Config;
        public const string version = "1.5.0";
        #endregion

        #region Commands
        [ChatCommand("Vote for this server on TopServers.Online", "vote")]
        public static void DoVote(User user)
        {
            if (string.IsNullOrWhiteSpace(Config.TsoServerAPIKey))
            {
                ChatHelper.SendMessageToPlayer(PhraseDictionary.Vote_NotEnabled, user);

                return;
            }

            ChatHelper.SendMessageToPlayer(PhraseDictionary.Vote_VoteAttempt, user);
            ChatHelper.SendMessageToPlayer(VoteMechanics.Instance.CastVote(user), user);
        }

        [ChatCommand("Add or view your Server API Key to the config file", "api-key", ChatAuthorizationLevel.Admin)]
        public static void ApiKey(User user, string platform, string ApiKey = "")
        {
            bool useEs = false;
            switch (platform)
            {
                case "tso":
                    useEs = false;
                    break;
                case "es":
                    useEs = true;
                    break;
                default:
                    ChatBaseExtended.CBError("You need to specify tso or es as the platform to set the api key for each particular service");
                    return;
            }

            switch (useEs)
            {
                case false:
                    if (string.IsNullOrWhiteSpace(ApiKey))
                    {
                        if (Config.TsoServerAPIKey != null)
                        {
                            ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.ApiKey_Current), Config.TsoServerAPIKey), user);
                        }
                        else
                        {
                            ChatHelper.SendMessageToPlayer(PhraseDictionary.ApiKey_Missing, user);
                        }

                        return;
                    }
                    Config.TsoServerAPIKey = ApiKey;
                    ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.ApiKey_Set), Config.TsoServerAPIKey), user, true);
                    break;
                case true:
                    if (string.IsNullOrWhiteSpace(ApiKey))
                    {
                        if (Config.EcoServerAPIKey != null)
                        {
                            ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.ApiKey_Current), Config.EcoServerAPIKey), user);
                        }
                        else
                        {
                            ChatHelper.SendMessageToPlayer(PhraseDictionary.ApiKey_Missing, user);
                        }

                        return;
                    }
                    Config.EcoServerAPIKey = ApiKey;
                    ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.ApiKey_Set), Config.EcoServerAPIKey), user, true);
                    break;
            }
            VoteMechanics.Instance.SaveConfig();
        }

        [ChatCommand("Set the amount of EXP to be rewarded to players who vote.", "reward-exp", ChatAuthorizationLevel.Admin)]
        public static void ExpReward(User user, int Amount)
        {
            if (Amount < 0)
            {
                ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.RewardExp_Current), Config.RewardExperience), user);
                return;
            }

            Config.RewardExperience = Amount;
            if (Amount == 0)
            {
                ChatHelper.SendMessageToPlayer(PhraseDictionary.RewardExp_Disabled, user);
            }
            else
            {
                ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.RewardExp_Set), Config.RewardExperience), user);
            }

            VoteMechanics.Instance.SaveConfig();
        }

        [ChatCommand("Set the amount of currency to be rewarded to players who vote.", "reward-money", ChatAuthorizationLevel.Admin)]
        public static void CurrencyReward(User user, int Amount, string CurrencyName)
        {
            if (Amount <= 0)
            {
                ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.RewardCurrency_Current), Config.RewardCurrency, Config.RewardCurrencyName), user);
                return;
            }

            CurrencyName = CurrencyName.Trim();
            var currency = CurrencyManager.GetClosestCurrency(CurrencyName);
                
            if (currency.Id.ToString() == Guid.NewGuid().ToString("N"))
            {
                ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.RewardCurrency_CurrencyDoesNotExist), CurrencyName), user);
                return;
            }

            Config.RewardCurrency = Amount;
            Config.RewardCurrencyName = CurrencyName;
            VoteMechanics.Instance.SaveConfig();
            ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.RewardCurrency_Set), Config.RewardCurrency, Config.RewardCurrencyName), user);
        }

        [ChatCommand("See what the current rewards are for voting", "vote-rewards")]
        public static void VoteRewards(User user)
        {
            if (Config.RewardCurrency == 0 && Config.RewardExperience == 0)
            {
                ChatHelper.SendMessageToPlayer(PhraseDictionary.VoteReard_Disabled, user);
                return;
            }
            if (Config.RewardExperience > 0)
            {
                ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.VoteReard_CurrentExp), Config.RewardExperience), user);
            }
            if (Config.RewardCurrency > 0)
            {
                ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.VoteReard_CurrentCurrency), Config.RewardCurrency, Config.RewardCurrencyName), user);
            }
        }

        [ChatCommand("Check For Votes", "check-votes")]
        public static void CheckVotes(User user)
        {
            ChatHelper.SendMessageToPlayer(PhraseDictionary.CheckVotes_Attempt, user);
            VoteMechanics.Instance.CheckVotes(user);
        }

        [ChatCommand("Get a list of the top voters!")]
        public static void TopVoters(User user)
        {
            ChatHelper.SendMessageToPlayer(PhraseDictionary.CheckTopVoters, user);
            user.Player.OpenInfoPanel("Top Voters", VoteMechanics.Instance.CheckTopVoters(), "");
        }

        [ChatCommand("tso-version")]
        public static void TsoVersion(User user)
        {
            ChatHelper.SendMessageToPlayer(string.Format(Localizer.DoStr(PhraseDictionary.TSOVersion), version), user);
        }
        #endregion
    }
}

