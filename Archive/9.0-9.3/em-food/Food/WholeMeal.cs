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
    [Weight(200)]                                          
    [LocDisplayName("Wholemeal")]
    [MaxStackSize(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class WholeMealItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("WholeMeal Made From Wheat.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 2, Protein = 4, Vitamins = 1};
        public override float Calories                          => 60;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(MillingSkill), 3)]    
    public partial class WholeMealRecipe : RecipeFamily
    {
        public WholeMealRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Wholemeal",
                    Localizer.DoStr("Wholemeal"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WheatItem), 5, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),
                    },
                    new CraftingElement<WholeMealItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WholeMealRecipe), 5, typeof(MillingSkill), typeof(MillingParallelSpeedTalent), typeof(MillingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("WholeMeal"), typeof(WholeMealRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}