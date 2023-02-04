using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Economy;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Items.PersistentData;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eco.EM.APS.Commands
{
    class Commands
    {
        #region Main Commands / Info
        [ChatCommand("Money Management Commands for players", ChatAuthorizationLevel.Admin)]
        public static void MoneyManager() { }
        [ChatCommand("Player Settings Commands", ChatAuthorizationLevel.Admin)]
        public static void PlayerSettings() { }
        [ChatCommand("Player Bonus Settings", ChatAuthorizationLevel.Admin)]
        public static void PlayerBonus() { }
        #endregion
        #region Money Management
        [ChatSubCommand("MoneyManager", "Generate a Mintless Currency","mmoney", ChatAuthorizationLevel.Admin)]
        public static void MintlessMoney(User user, string name, float amount)
        {
            char[] whitespace = { ' ' };
            name = name.TrimStart(whitespace);

            Currency currencyDollar = CurrencyManager.AddCurrency(user, new LocString(name), CurrencyType.Backed);
            BankAccountManager.Obj.SpawnMoney(currencyDollar, user, amount);
            ChatBaseExtended.CBInfo($"You New Currency {name} Has been made with a total of {amount} In Circulation", user);
        }
        [ChatSubCommand("MoneyManager", "", ChatAuthorizationLevel.Admin)]
        public static void RemovePlayerCurrencies(User user, bool value)
        {
            if (value) 
            {
                foreach( var pl in Base.OnlineUsers)
                {
                    var plCurrency = CurrencyManager.GetPlayerCurrency(pl);
                }
                
            }
        }
        #endregion
        #region Player Settings

        #endregion
        #region PlayerBonus

        #endregion

    }
}
