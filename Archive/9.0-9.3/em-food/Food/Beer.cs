using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Beer")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeerItem :
        FoodItem            
    {
        public override LocString DisplayDescription                     => Localizer.DoStr("Organic Eco Friendly Fuel");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 9, Fat = 10, Protein = 13, Vitamins = 6};
        public override float Calories                          => 1350;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(ZymologySkill), 4)]
    public partial class BeerRecipe : RecipeFamily
    {
        public BeerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Beer",
                    Localizer.DoStr("Beer"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WortItem), 10, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                        new IngredientElement(typeof(YeastItem), 5, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                    },
                    new CraftingElement<BeerItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ZymologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeerRecipe), 8, typeof(ZymologySkill), typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Beer"), typeof(BeerRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}