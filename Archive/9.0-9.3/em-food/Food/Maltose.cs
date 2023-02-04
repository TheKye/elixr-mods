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
    [LocDisplayName("Maltose")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class MaltoseItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Also known as maltobiose or malt sugar.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 4, Protein = 5, Vitamins = 2};
        public override float Calories                          => 55;
        public override Nutrients Nutrition                     => nutrition;
    }

	
	[RequiresSkill(typeof(ZymologySkill), 3)]   
    public partial class MaltoseRecipe : RecipeFamily
    {
        public MaltoseRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Maltose",
                    Localizer.DoStr("Maltose"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WheatItem), 4, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                        new IngredientElement(typeof(SugarItem), 4, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent))
                    },
                    new CraftingElement<MaltoseItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ZymologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MaltoseRecipe), 8, typeof(ZymologySkill), typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Maltose"), typeof(MaltoseRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}