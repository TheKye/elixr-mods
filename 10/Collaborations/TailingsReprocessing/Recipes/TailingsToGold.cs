using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class RecycleForGoldRecipe : RecipeFamily
    {
        public RecycleForGoldRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycled Tailings: Gold",
                    Localizer.DoStr("Recycled Tailings: Gold"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(TailingsItem), 10, true)
                    },
                    new CraftingElement<GoldConcentrateItem>(1),
                    new CraftingElement<WetTailingsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleForGoldRecipe), 40, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Recycled Tailings: Gold"), typeof(RecycleForGoldRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}