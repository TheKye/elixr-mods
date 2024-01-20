using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;

namespace Eco.EM.TailingsReprocessing.Mods.UserCode.Recipes
{
    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class RecycleForCopperRecipe : RecipeFamily
    {
        public RecycleForCopperRecipe()
        {
            Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycled Tailings: Copper",
                    Localizer.DoStr("Recycled Tailings: Copper"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(TailingsItem), 10, true)
                    },
                    new CraftingElement<CopperConcentrateItem>(1),
                    new CraftingElement<WetTailingsItem>(4)
                    )
            };
            ExperienceOnCraft = 2;
            LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(RecycleForCopperRecipe), 40, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            ModsPreInitialize();
            Initialize(Localizer.DoStr("Recycled Tailings: Copper"), typeof(RecycleForCopperRecipe));
            ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}