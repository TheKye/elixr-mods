using Eco.Core.Items;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Wishbone")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class WishBoneItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("An Old Tradition is to break the Wishbone with someone!");

        public override InteractResult OnActRight(InteractionContext context)
        {
            context.Player.Msg(Localizer.DoStr("Make a Wish as you break the wishbone!"));
            context.Player.User.Inventory.RemoveItem(typeof(WishBoneItem));
            return base.OnActRight(context);
        }
    }
}
