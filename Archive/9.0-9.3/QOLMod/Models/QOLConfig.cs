using Eco.EM.Framework.Groups;
using System;

namespace Eco.EM.QOL
{
    public class QOLConfig: IGroupAuthorizable
    {
        public int MaxTalents { get; private set; } = 1;
        public int MaxSkills { get; private set; } = 1;


        public string Identifier => QOLManager.ID;

        public bool Permit(SimpleGroupUser user)
        {
            return true;
        }

        public bool UpdateConfig(string setting, int value)
        {
            switch (setting)
            {
                case "max-talents":
                    MaxTalents = value;
                    break;
                case "max-skills":
                    MaxSkills = value;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public bool UpdateConfigBool(bool value)
        {
            return true;
        }

        public QOLConfig DeepCopy()
        {
            QOLConfig newConfig = new QOLConfig();
            newConfig.MaxTalents = MaxTalents;
            newConfig.MaxSkills = MaxSkills;

            return newConfig;
        }
    }
}
