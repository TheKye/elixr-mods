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
    [LocDisplayName("Full Cream Milk")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FullCreamMilkItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Full Cream Milk");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 1, Protein = 4, Vitamins = 2};
        public override float Calories                          => 55;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(ZymologySkill), 2)]   
    public partial class FullCreamMilkRecipe : RecipeFamily
    {
        public FullCreamMilkRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Full Cream Milk",
                    Localizer.DoStr("Full Cream Milk"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WholeMealItem), 5, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                        new IngredientElement(typeof(CornSyrupItem), 5, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent))
                    },
                    new CraftingElement<FullCreamMilkItem>(3),
                    new CraftingElement<CreamItem>(3)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ZymologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FullCreamMilkRecipe), 30, typeof(ZymologySkill), typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Full Cream Milk"), typeof(FullCreamMilkRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}