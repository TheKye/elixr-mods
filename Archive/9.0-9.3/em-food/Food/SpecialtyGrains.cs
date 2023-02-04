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
    [LocDisplayName("Specialty Grains")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SpecialtyGrainsItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Specialty grains, Ground With love.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 6, Protein = 6, Vitamins = 9};
        public override float Calories                          => 250;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(MillingSkill), 3)]
    public partial class SpecialtyGrainsRecipe : RecipeFamily
    {
        public SpecialtyGrainsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Specialty Grains",
                    Localizer.DoStr("Specialty Grains"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CornItem), 4, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),
                        new IngredientElement(typeof(WheatItem), 4, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),
                    },
                    new CraftingElement<SpecialtyGrainsItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SpecialtyGrainsRecipe), 5, typeof(MillingSkill), typeof(MillingParallelSpeedTalent), typeof(MillingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Specialty Grains"), typeof(SpecialtyGrainsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}