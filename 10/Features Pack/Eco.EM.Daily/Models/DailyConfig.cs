using Eco.EM.Framework.Groups;

namespace Eco.EM.Daily
{
    public class DailyConfig : IGroupAuthorizable
    {
        public int RewardExperience { get; set; } = 2;
        public int StartTier { get; set; } = 0;
        public int MinLoggedInTime { get; set; } = 20;
        public int DailyTimer { get; set; } = 24;

        public string Identifier => DailyManager.ID;

        public bool BlackListed { get; set; }

        public bool Permit(SimpleGroupUser user) => true;

        public bool UpdateConfig(string setting, int value)
        {
            switch (setting)
            {
                case "xp":
                    RewardExperience = value;
                    break;
                case "startTier":
                    StartTier = value;
                    break;
                case "time":
                    MinLoggedInTime = value;
                    break;
                case "timer":
                    DailyTimer = value;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public DailyConfig DeepCopy()
        {
            DailyConfig newConfig = new DailyConfig();
            newConfig.RewardExperience = RewardExperience;
            newConfig.StartTier = StartTier;
            newConfig.MinLoggedInTime = MinLoggedInTime;
            newConfig.DailyTimer = DailyTimer;

            return newConfig;
        }
    }
}
