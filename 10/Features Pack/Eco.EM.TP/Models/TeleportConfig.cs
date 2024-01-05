using Eco.EM.Framework.Groups;
using System;

namespace Eco.EM.TP
{
    public class TeleportConfig: IGroupAuthorizable
    {
        public int MaxTeleports { get; private set; } = 5;
        public int CalorieCost { get; private set; } = 500;
        public int CooldownSeconds { get; private set; } = 900;
        public int Expiry { get; private set; } = 15;
        public bool postMessge { get; private set; } = true;

        public bool BlackListed { get; set; }

        public string Identifier => TeleportManager.ID;

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
                case "expiry":
                    Expiry = value;
                    break;
                case "cooldown":
                    CooldownSeconds = value;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public bool UpdateConfigBool(bool value)
        {
            postMessge = value;
            return true;
        }

        public TeleportConfig DeepCopy()
        {
            TeleportConfig newConfig = new();
            newConfig.MaxTeleports = MaxTeleports;
            newConfig.Expiry = Expiry;
            newConfig.CalorieCost = CalorieCost;

            return newConfig;
        }
    }
}
