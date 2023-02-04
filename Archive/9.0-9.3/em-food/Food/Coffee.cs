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
    [LocDisplayName("Coffee")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CoffeeItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("100% Real Coffee");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 7, Fat = 6, Protein = 5, Vitamins = 4};
        public override float Calories                          => 850;
        public override Nutrients Nutrition                     => nutrition;
    }

	
	[RequiresSkill(typeof(CookingSkill), 2)]   
    public partial class CoffeeRecipe : RecipeFamily
    {
        public CoffeeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Coffee",
                    Localizer.DoStr("Coffee"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GroundBeanItem), 5, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(SugarItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(FullCreamMilkItem), 1, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<CoffeeItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CoffeeRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Coffee"), typeof(CoffeeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltCoffeeRecipe : RecipeFamily
    {
        public AltCoffeeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Coffee",
                    Localizer.DoStr("Coffee"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GroundBeanItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(SugarItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(FullCreamMilkItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<CoffeeItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltCoffeeRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Coffee"), typeof(AltCoffeeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}