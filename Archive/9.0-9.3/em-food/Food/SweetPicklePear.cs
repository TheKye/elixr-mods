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
    [MaxStackSize(100)]
    [LocDisplayName("Sweet Pickle Pear")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SweetPicklePearItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Pickle Pear With Bitter Beats.");  

        private static Nutrients nutrition = new Nutrients() { Carbs = 6, Fat = 4, Protein = 7, Vitamins = 7 };
        public override float Calories                          => 750;  
        public override Nutrients Nutrition                     => nutrition;  
    }

    [RequiresSkill(typeof(ZymologySkill), 1)]   
    public partial class SweetPicklePearRecipe : RecipeFamily
    {
        public SweetPicklePearRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Sweet Pickle Pear",
                    Localizer.DoStr("Sweet Pickle Pear"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BeetItem), 2, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                        new IngredientElement(typeof(PricklyPearFruitItem), 2, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent))
                    },
                    new CraftingElement<SweetPicklePearItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ZymologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SweetPicklePearRecipe), 15, typeof(ZymologySkill), typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Sweet Pickle Pear"), typeof(SweetPicklePearRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}