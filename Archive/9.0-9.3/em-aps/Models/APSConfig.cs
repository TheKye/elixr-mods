using Eco.EM.Framework.Groups;
using System;
using System.Collections.Generic;

namespace Eco.EM.APS
{
    public class APSConfig: IGroupAuthorizable
    {
        #region Bools
        public bool DisableMint { get; private set; } = false; // When a mint is placed prevent action
        public bool LimitCurrencies { get; private set; } = false; // When attempting to make a new currency prevent the action
        public bool DisableProgression { get; private set; } = false; // when a player gains experience, deduct that amount of experience
        public bool LimitProfessions { get; private set; } = false; // Limits players too a max set profession
        public bool NewPlayerBonus { get; private set; } = false; // give new players bonus items
        public bool LongTermBonus { get; private set; } = false; // give long term players bonus items
        #endregion
        #region Ints
        public int MaxProfessions { get; private set; } = 3; // total amount of professions a player can have
        public int NewMinPlayTime { get; private set; } = 10; // This is Minutes
        public int LTMinPlayTime { get; private set; } = 7; // This is Days
        public int MaxTotalCurrencies { get; private set; } = 3; // total amount of player made currencies allowed
        #endregion
        #region Lists
        public List<NewPlayerBonusItems> npList;
        public List<LongTermBonusItens> ltList;
        #endregion

        public string Identifier => APSManager.ID;

        public bool Permit(SimpleGroupUser user)
        {
            return true;
        }

        public bool UpdateConfig(string setting, int value)
        {
            switch (setting)
            {
                case "max":
                    break;
                case "cost":
                    break;
                case "expiry":
                    break;
                case "cooldown":
                    break;
                default:
                    return false;
            }

            return true;
        }

        public bool UpdateConfigTF(string setting, bool value)
        {
            switch (setting)
            {
                case "max":
                    break;
                case "cost":
                    break;
                case "expiry":
                    break;
                case "cooldown":
                    break;
                default:
                    return false;
            }
            return true;
        }

        public APSConfig DeepCopy()
        {
            APSConfig newConfig = new APSConfig();

            return newConfig;
        }
    }
}
