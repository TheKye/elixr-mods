using Eco.Core.Utils;
using Eco.EM.Daily;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using static Eco.Shared.Utils.Text;

namespace Eco.EM.Mods.TechTree
{
    [Serialized]
    [Weight(1)]
    [LocDisplayName("Token")]
    [MaxStackSize(100)]
    [Priority(PriorityAttribute.High)]
    [LocDescription("A token that can be exchanged into experience points")]
    public class TokenItem : Item
    {

        public string ControlsTooltip => Style(Styles.Controls, Localizer.Do($"[Right-click to consume]"));

        public bool Consume(Player player)
        {
            player.User.UserXP.UseXP(DailyManager.Data.GetMaxRewardExperience(player.User) * -1);
            DailyManager.Log($"[{DateTime.Now: dd/MM/yyyy HH:mm:ss}] {player.DisplayName} Used a Token");
            return true;
        }

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.TryModifyStack(player.User, -1, () => Consume(player));
            return "";
        }
    }
}