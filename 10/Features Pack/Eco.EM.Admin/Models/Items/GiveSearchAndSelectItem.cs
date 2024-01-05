using System.Collections.Generic;
using System.Linq;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.UI;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.View;
using Eco.EM.Admin;
using System.ComponentModel;

namespace Eco.EM.Admin
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(1)]
    [LocDisplayName("Search And Select")]
    [Category("Hidden")]
    [LocDescription("This tool.. is super powerful.. you have been warned.")]
    public partial class GiveSearchAndSelectItem :
            Item
    {
        public override string OnUsed(Player player, ItemStack itemStack)
        {
            string message = "";
            Admin.GiveSearchAndSelect(player.User);
            player.User.Inventory.ToolbarBackpack.TryRemoveItem(typeof(GiveSearchAndSelectItem));
            return message;
        }
    }
}
