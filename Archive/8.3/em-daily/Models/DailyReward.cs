namespace Eco.EM
{
    public class DailyReward
    {
        public int RewardExperience { get; set; } = 2;
        public int RewardCurrency { get; set; } = 0;
        public string RewardCurrencyName { get; set; } = string.Empty;
        public bool Loyalty { get; set; } = true;
        public int MinLoggedInTime { get; set; } = 20;
    }
}
