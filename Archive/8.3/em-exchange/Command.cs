namespace Eco.EM
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Gameplay;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Mods;
    using Eco.Mods.TechTree;
    using Eco.Shared.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    class Exchange : IChatCommandHandler
    {
        static int SkillPointsRatio;

        [ChatCommand("exchange", "Exchange from skillpoints into tokens")]
        public static void DoExchange(User user, int Amount)
        {
            if (Amount <= 0)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error("Error: You must input a number greater than 0"), user));
                return;
            }

            if (user.XP < (Amount * SkillPointsRatio))
            {
                ChatBase.Send(new ChatBase.Message("Error: You do not have enough skill points", user));
                return;
            }

            /*if (user.Inventory.TryAddItems<Eco.EM.Items.TokenItem>(Amount, user))
            {
                user.UseXP(Amount * SkillPointsRatio);
                ChatBase.Send(new ChatBase.Message("Exchange complete", user));
            }
            else
            {
                ChatBase.Send(new ChatBase.Message(Text.Error("Error: Unable to issue tokens, perhaps inventory is full?"), user));
            }*/
        }
    }
}