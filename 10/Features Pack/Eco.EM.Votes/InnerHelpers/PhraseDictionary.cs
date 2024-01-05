using Eco.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoteMod.Helpers
{
    public static class PhraseDictionary
    {
        public static string Vote_VoteAttempt => "Attempting To Vote now, Please wait. . .";
        public static string Vote_NotEnabled => "I'm sorry, the server owner has not enabled voting on the server yet, maybe give them a little nudge?";
        public static string ApiKey_Set => "ApiKey has been set to {0}";
        public static string ApiKey_Current => "Current ApiKey is {0}";
        public static string ApiKey_Missing => "Api Key is not configured. please enter your api key.";
        public static string RewardExp_Set => "Exp Reward has been set to {0} Exp";
        public static string RewardExp_Current => "Exp Reward is currently set to {0} Exp";
        public static string RewardExp_Disabled => "Exp Reward has been disabled";
        public static string RewardCurrency_Set => "Currency Reward has been set to {0} {1}";
        public static string RewardCurrency_Current => "Currency Reward is currently set to {0} {1}";
        public static string RewardCurrency_CurrencyDoesNotExist => "Currency Reward is currently set to {0} {1}";
        public static string VoteReard_Disabled => "The server owner has not set any rewards for this server.";
        public static string VoteReard_CurrentCurrency => "Currency Reward is currently set to {0} {1}";
        public static string VoteReard_CurrentExp => "Exp Reward is currently set to {0} Exp";
        public static string CheckVotes_Attempt => "Checking For Votes";
        public static string CheckTopVoters => "Fetching Top Voters List. . .";
        public static string TSOVersion => "TSO Voting Mod Version: {0}";
        public static string CheckVotes_VotesUnclaimed => "Thank you for voting on Top Servers Online, you have received your reward.";
    }
}
