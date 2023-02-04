using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [LocDisplayName("Mac And Cheese")]
    [Weight(300)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class MacAndCheeseFoodItem : FoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Mac And Cheese");
        public override LocString DisplayDescription => Localizer.DoStr("Electronic computer baked in cheese.");

        public override float Calories => 350;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 55, Fat = 10, Protein = 15, Vitamins = 0 };
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class MacAndCheeseFoodRecipe : RecipeFamily
    {
        public MacAndCheeseFoodRecipe()
        {
            var product = new Recipe(
                "Mac And Cheese",
                Localizer.DoStr("Mac And Cheese"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(FlourItem), 1, typeof(CookingSkill)),
                    new IngredientElement(typeof(CheeseItem), 1, typeof(CookingSkill)),
                },
                new CraftingElement<MacAndCheeseFoodItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(30, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MacAndCheeseFoodRecipe), 1, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Mac And Cheese"), typeof(MacAndCheeseFoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
