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
    [LocDisplayName("Wort")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class WortItem :
        FoodItem            
    {
        public override LocString DisplayDescription                     => Localizer.DoStr("Boot Runners Wort.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 7, Protein = 9, Vitamins = 2};
        public override float Calories                          => 400;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class WortRecipe : RecipeFamily
    {
        public WortRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Wort",
                    Localizer.DoStr("Wort"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(SpecialtyGrainsItem), 5, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(MaltoseItem), 5, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<WortItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WortRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wort"), typeof(WortRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}