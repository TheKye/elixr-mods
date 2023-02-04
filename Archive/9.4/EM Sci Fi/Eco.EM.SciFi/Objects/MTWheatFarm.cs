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
    public partial class MTWheatFarmObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("MT Wheat Farm");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public virtual Type RepresentedItemType => typeof(MTWheatFarmItem);
        protected override void Initialize() { }
        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("MT Wheat Farm")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class MTWheatFarmItem : WorldObjectItem<MTWheatFarmObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Wheat Farming for your Micro Town.");
        static MTWheatFarmItem() { }
    }

    public partial class MTWheatFarmRecipe : RecipeFamily
    {
        private const string itemName = "MT Wheat Farm";

        public MTWheatFarmRecipe()
        {
            var product = new Recipe
            (
                "MTWheatFarm",
                Localizer.DoStr(itemName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20),
                },
               new CraftingElement<MTWheatFarmItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(25); 
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.Initialize(Localizer.DoStr(itemName), typeof(MTWheatFarmRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
