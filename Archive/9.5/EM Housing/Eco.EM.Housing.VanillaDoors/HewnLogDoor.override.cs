using Eco.Gameplay.Items;
using System;
using Eco.Mods.TechTree;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Items;
using Eco.EM.Framework.AutoDoor;
using Eco.Gameplay.Modules;
using Eco.EM.Housing.Doors;
using System.Linq;
using Eco.Shared.Utils;

namespace Eco.EM.Housing.VanillaDoors
{
    public partial class VanillaDoors
    {
        public static void ReplaceVanillaDoors()
        {
            var newElement = new CraftingElementq(typeof(AHewnDoorItem));

            RecipeFamily hRecipe = RecipeFamily.Get(typeof(HewnLogDoorRecipe));
            hRecipe.Product.Replace(hRecipe.Product.First(), newElement);

        }
    }

    public partial class CraftingElementq : CraftingElement
    {
        new Item Item { get; set; }
        new int Quantity { get; set; }

        public CraftingElementq(Type item, int quantity = 1) {
            Item = Item.Get(typeof(AHewnDoorItem));
            Quantity = quantity;
        }
    }

    [Serialized]
    public partial class AHewnDoorItem : Item
    {

    }
}
