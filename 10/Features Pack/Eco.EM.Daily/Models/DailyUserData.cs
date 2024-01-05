using System;

namespace Eco.EM.Daily
{
    public class DailyUserData
    {
        public string LastClaim { get; private set; }

        public bool CanClaim(DateTime check) => check > DailyManager.StringtoDT(LastClaim) + TimeSpan.FromHours(DailyManager.Config.DailyTimer);

        public void Claim(DateTime update)
        {
            LastClaim = DailyManager.DTtoString(update);
        }
    }
}
