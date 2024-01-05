

namespace Eco.EM.Homes
{
    using Eco.EM.Framework.Groups;
    public class HomeConfig: IGroupAuthorizable
    {
        public int CalorieCost { get; set; } = 500;
        public int MaxTeleports { get; set; } = 10;
        public int MaxHomeCount { get; set; } = 2;
        public int CoolDown { get; set; } = 320;

        public string Identifier => HomeManager.ID;

        public bool BlackListed { get; set; }

        public bool Permit(SimpleGroupUser user) => true;

        public bool UpdateConfig(string setting, int value)
        {
            switch (setting)
            {
                case "max":
                    MaxTeleports = value;
                    break;
                case "cost":
                    CalorieCost = value;
                    break;
                case "count":
                    MaxHomeCount = value;
                    break;
                case "cooldown":
                    CoolDown = value;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public HomeConfig DeepCopy()
        {
            HomeConfig newConfig = new HomeConfig();
            newConfig.MaxTeleports = MaxTeleports;
            newConfig.MaxHomeCount = MaxHomeCount;
            newConfig.CalorieCost = CalorieCost;
            newConfig.CoolDown = CoolDown;

            return newConfig;
        }
    }
}