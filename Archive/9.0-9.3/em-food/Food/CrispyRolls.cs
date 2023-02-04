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
    [LocDisplayName("Crispy Rolls")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CrispyRollsItem :
        FoodItem            
    {
        public override LocString DisplayNamePlural             => Localizer.DoStr("Crispy Rolls");
        public override LocString DisplayDescription            => Localizer.DoStr("Crispy Rolls Baked With Heat.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 11, Fat = 6, Protein = 7, Vitamins = 4};
        public override float Calories                          => 680;
        public override Nutrients Nutrition                     => nutrition; 
    }

    [RequiresSkill(typeof(BakingSkill), 2)]    
    public partial class CrispyRollsRecipe : RecipeFamily
    {
        public CrispyRollsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Crispy Rolls",
                    Localizer.DoStr("Crispy Rolls"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(FlourItem), 5, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),
                        new IngredientElement(typeof(YeastItem), 2, typeof(BakingSkill), typeof(BakingLavishResourcesTalent))
                    },
                    new CraftingElement<CrispyRollsItem>(3)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(BakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrispyRollsRecipe), 8, typeof(BakingSkill), typeof(BakingParallelSpeedTalent), typeof(BakingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("CrispyRolls"), typeof(CrispyRollsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}