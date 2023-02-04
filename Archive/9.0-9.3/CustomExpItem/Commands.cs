namespace CustomExpItem
{
    using Eco.Core.IoC;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using System;
    using Eco.Mods.TechTree;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class EXPCommands : IChatCommandHandler
    {
        [ChatCommand("Create A Token that is filled with EXP!", "tokens", ChatAuthorizationLevel.Admin)]
        public static void CreateToken(User user, int amount)
        {
            string tokens = "Token";
            int count = 0;
            try
            {
                if (amount > 1)
                    tokens = "Tokens";

                while (count < amount)
                {
                    user.Inventory.AddItem<MagicTokenItem>();
                    count++;
                }
                ExpExchanger.Log($"{DateTime.Now}: {user.Name} Created {amount} {tokens}");
                return;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr(e.ToString());
            }
        }

        [ChatCommand("Create A Token that is filled with EXP! ( beware you will lose xp though! )", "convert-xp", ChatAuthorizationLevel.Admin)]
        public static void CreateTokens(User user, int amount)
        {
            string tokens = "Token";
            int count = 0;
            try
            {
                if (amount > 1)
                    tokens = "Tokens";
                if (user.XP < 55)
                {
                    user.Player.ErrorLocStr("You do not have enough experience points to make this transaction..");
                    return;
                }
                while (count < amount)
                {
                    if (user.XP < 55)
                    {
                        user.Player.ErrorLocStr($"You do not have enough experience points to finish this transaction.. but you did get {count} {tokens}");
                        ExpExchanger.Log($"{DateTime.Now}: {user.Name} Created {count} {tokens}");
                        return;
                    }
                    user.Inventory.AddItem<MagicTokenItem>();
                    user.AddExperience(-55);
                    count++;
                }
                ExpExchanger.Log($"{DateTime.Now}: {user.Name} Created {amount} {tokens}");
                return;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr(e.ToString());
            }
        }
    }
}