using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Items;
using Eco.Mods.TechTree;

namespace Eco.EM.SciFi
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class MTSmallHouseObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("MT Small House");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public virtual Type RepresentedItemType => typeof(MTSmallHouseItem);
        protected override void Initialize() { }
        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("MT Small House")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class MTSmallHouseItem : WorldObjectItem<MTSmallHouseObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Housing for 4 in your Micro Town.");
        static MTSmallHouseItem() { }
    }

    public partial class MTSmallHouseRecipe : RecipeFamily
    {
        private const string itemName = "MT Small House";

        public MTSmallHouseRecipe()
        {
            var product = new Recipe
            (
                "MTSmallHouse",
                Localizer.DoStr(itemName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20),
                },
               new CraftingElement<MTSmallHouseItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(25); 
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.Initialize(Localizer.DoStr(itemName), typeof(MTSmallHouseRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
