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
    [LocDisplayName("Sake")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SakeItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Body And Mind Original Sake");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 2, Protein = 7, Vitamins = 6};
        public override float Calories                          => 850;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(ZymologySkill), 2)]   
    public partial class SakeRecipe : RecipeFamily
    {
        public SakeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Sake",
                    Localizer.DoStr("Sake"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RiceItem), 4, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                        new IngredientElement(typeof(CornItem), 4, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent))
                    },
                    new CraftingElement<SakeItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ZymologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SakeRecipe), 26, typeof(ZymologySkill), typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Sake"), typeof(SakeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}