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
    [LocDisplayName("Brioche")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BriocheItem :
        FoodItem            
    {
        public override LocString DisplayNamePlural               => Localizer.DoStr("Brioche"); 
        public override LocString DisplayDescription              => Localizer.DoStr("A Delicious, Honey Soft Roll.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 14, Fat = 8, Protein = 4, Vitamins = 4};
        public override float Calories                          => 750;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(BakingSkill), 3)]    
    public partial class BriocheRecipe : RecipeFamily
    {
        public BriocheRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Brioche",
                    Localizer.DoStr("Brioche"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(HoneyItem), 6, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),
                        new IngredientElement(typeof(FlourItem), 6, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),
                        new IngredientElement(typeof(YeastItem), 3, typeof(BakingSkill), typeof(BakingLavishResourcesTalent))
                    },
                    new CraftingElement<BriocheItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(BakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BriocheRecipe), 8, typeof(BakingSkill), typeof(BakingParallelSpeedTalent), typeof(BakingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Brioche"), typeof(BriocheRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}