using Eco.EM.Framework.Groups;

namespace Eco.EM.Warp
{
    public class WarpConfig : IGroupAuthorizable
    {
        public int MaxTeleports { get; private set; } = 5;
        public int CalorieCost { get; private set; } = 500;
        public int CooldownSeconds { get; private set; } = 900;

        public bool CostCurrency { get; private set; } = false;
        public string Currency { get; private set; }
        public int CurrencyCost { get; private set; }

        public bool BlackListed { get; set; }
        public string Identifier => WarpManager.ID;

        public bool Permit(SimpleGroupUser user)
        {
            return true;
        }

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
                case "cooldown":
                    CooldownSeconds = value;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public WarpConfig DeepCopy()
        {
            WarpConfig newConfig = new WarpConfig();
            newConfig.MaxTeleports = MaxTeleports;
            newConfig.CooldownSeconds = CooldownSeconds;
            newConfig.CalorieCost = CalorieCost;
            newConfig.CostCurrency = CostCurrency;
            newConfig.Currency = Currency;

            return newConfig;
        }
    }
}
