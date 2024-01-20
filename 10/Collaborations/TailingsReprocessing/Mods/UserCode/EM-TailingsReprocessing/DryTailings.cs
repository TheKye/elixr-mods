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
    public partial class DryTailingsRecipe : RecipeFamily
    {
        public DryTailingsRecipe()
        {
            Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dry Out Tailings",
                    Localizer.DoStr("Dry Out Tailings"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WetTailingsItem), 10, true),
                        new IngredientElement(typeof(DirtItem), 10, true)
                    },
                    new CraftingElement<TailingsItem>(20)
                    )
            };
            ExperienceOnCraft = 2;
            LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(DryTailingsRecipe), 12.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            ModsPreInitialize();
            Initialize(Localizer.DoStr("Dry Out Tailings"), typeof(DryTailingsRecipe));
            ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
