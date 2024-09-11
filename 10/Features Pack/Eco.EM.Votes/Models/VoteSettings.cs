using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Votes
{
    public class VoteConfig
    {
        public string   TsoServerAPIKey { get; set; } = string.Empty;
        public string   EcoServerAPIKey { get; set; } = string.Empty;
        public int      RewardExperience { get; set; } = 2;
        public int      RewardCurrency { get; set; } = 0;
        public string   RewardCurrencyName { get; set; } = string.Empty;
    }
}