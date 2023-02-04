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
    [LocDisplayName("Soy Coffee")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SoyCoffeeItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Soy Coffee... ummm.. okay..");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 2, Protein = 6, Vitamins = 3};
        public override float Calories                          => 880;
        public override Nutrients Nutrition                     => nutrition;
    }

	
	[RequiresSkill(typeof(CookingSkill), 2)]   
    public partial class SoyCoffeeRecipe : RecipeFamily
    {
        public SoyCoffeeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Soy Coffee",
                    Localizer.DoStr("Soy Coffee"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GroundBeanItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(MaltoseItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(SoyMilkItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<SoyCoffeeItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SoyCoffeeRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Soy Coffee"), typeof(SoyCoffeeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltSoyCoffeeRecipe : RecipeFamily
    {
        public AltSoyCoffeeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Soy Coffee",
                    Localizer.DoStr("Soy Coffee"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GroundBeanItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(MaltoseItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(SoyMilkItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<SoyCoffeeItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltSoyCoffeeRecipe), 12, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Soy Coffee"), typeof(AltSoyCoffeeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}