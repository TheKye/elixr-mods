using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class ReplacedIronAxeRecipe : RecipeFamily
    {
        static private RecipeFamily vanillaData = new IronAxeRecipe();

        public ReplacedIronAxeRecipe()
        {
            this.Recipes = vanillaData.Recipes;
            this.ExperienceOnCraft = vanillaData.ExperienceOnCraft;
            this.LaborInCalories = CreateLaborInCaloriesValue(vanillaData.LaborInCalories.GetBaseValue, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ReplacedIronAxeRecipe), vanillaData.CraftMinutes.GetBaseValue, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Iron Axe"), typeof(ReplacedIronAxeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);

            RecipeKiller.recipeTypesToKill.Add((typeof(IronAxeRecipe), typeof(IronAxeItem), typeof(AnvilObject)));
        }

        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}
