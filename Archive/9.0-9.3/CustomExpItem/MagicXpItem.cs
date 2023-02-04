using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.ComponentModel;
using static Eco.Shared.Utils.Text;

namespace Eco.Mods.TechTree
{
    [Serialized, LocDisplayName("Magic Coins"), NotSpawnable, Currency]
    public class MagicTokenItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A token that can be exchanged into experience points."); } }

        [Tooltip(500, typeof(Controls))]
        public string ControlsTooltip => Style(Styles.Controls, Localizer.Do($"[Right-click to consume]"));

        public bool Consume(Player player)
        {
            player.User.UseXP(55 * -1);
            return true;
        }

        public override void OnUsed(Player player, ItemStack itemStack) => itemStack.TryModifyStack(player.User, -1, () => Consume(player));
    }
}