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
    [LocDisplayName("Ground Bean")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class GroundBeanItem :
        FoodItem            
    {
        public override LocString DisplayNamePlural             => Localizer.DoStr("Ground Beans");
        public override LocString DisplayDescription            => Localizer.DoStr("Ground beans To Perfection For the Perfect Cup");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 6, Protein = 5, Vitamins = 0};
        public override float Calories                          => 40;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(MillingSkill), 3)]    
    public partial class GroundBeanRecipe : RecipeFamily
    {
        public GroundBeanRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Ground Bean",
                    Localizer.DoStr("Ground Bean"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BeansItem), 15, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),
                    },
                    new CraftingElement<GroundBeanItem>(6)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(GroundBeanRecipe), 5, typeof(MillingSkill), typeof(MillingParallelSpeedTalent), typeof(MillingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Ground Bean"), typeof(GroundBeanRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}