using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Butter")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ButterItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Turning Butter.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 7, Protein = 1, Vitamins = 4};
        public override float Calories                          => 65; 
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(ZymologySkill), 2)]   
    public partial class ButterRecipe : RecipeFamily
    {
        public ButterRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Butter",
                    Localizer.DoStr("Butter"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CreamItem), 4, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                    },
                    new CraftingElement<ButterItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ZymologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ButterRecipe), 20, typeof(ZymologySkill), typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Butter"), typeof(ButterRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}