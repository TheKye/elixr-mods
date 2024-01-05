using Eco.EM.Framework.Groups;

namespace Eco.EM.Admin.ReportsSystem
{
    public class WarningConfig: IGroupAuthorizable
    {
        public bool UseBanSystem { get; set; } = false;
        public bool ActivePermaBans { get; set; } = false;
        public int MaxWarningsUntilTempBan { get; set; } = 5;
        public int MaxTempBansUntilPermaBan { get; set; } = 1;
        public int DefaultBanTimeHours { get; set; } = 24;

        public string Identifier => WarningManager.ID;

        public bool BlackListed { get; set; }

        public bool Permit(SimpleGroupUser user) => true;

        public bool UpdateConfig(string setting, int value)
        {
            switch (setting)
            {
                case "usebans":
                    UseBanSystem = value > 0;
                    break;
                case "pbans":
                    ActivePermaBans = value > 0;
                    break;
                case "warningmax":
                    MaxWarningsUntilTempBan = value;
                    break;
                case "tempmax":
                    MaxTempBansUntilPermaBan = value;
                    break;
                case "time":
                    DefaultBanTimeHours = value;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public WarningConfig DeepCopy()
        {
            WarningConfig newConfig = new();
            newConfig.MaxWarningsUntilTempBan = MaxWarningsUntilTempBan;
            newConfig.DefaultBanTimeHours = DefaultBanTimeHours;

            return newConfig;
        }
    }
}
