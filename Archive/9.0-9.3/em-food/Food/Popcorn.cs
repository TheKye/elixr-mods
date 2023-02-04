using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food
{
    [Weight(100)]
    [MaxStackSize(100)]
    [LocDisplayName("Popcorn")]
    public partial class PopcornItem : FoodItem            
    {
		public override LocString DisplayNamePlural             => Localizer.DoStr("Popcorn");
        public override LocString DisplayDescription            => Localizer.DoStr("Everybody loves popcorn.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 8, Protein = 0, Vitamins = 3};
        public override float Calories                          => 600;
        public override Nutrients Nutrition                     => nutrition;
    }

	[Serialized]
	[Weight(100)]
    [MaxStackSize(100)]
    [LocDisplayName("Caramel Popcorn")]
    public partial class CaramelPopcornItem : FoodItem            
    {
		public override LocString DisplayNamePlural             => Localizer.DoStr("Caramel Popcorn");
        public override LocString DisplayDescription            => Localizer.DoStr("Sweet, Sweet Popcorn.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 9, Protein = 0, Vitamins = 3};
        public override float Calories                          => 700;
        public override Nutrients Nutrition                     => nutrition;
    }
	
    [RequiresSkill(typeof(CampfireCookingSkill), 1)]    
    public partial class PopcornRecipe : RecipeFamily
    {
        public PopcornRecipe()
        {
            var product = new Recipe(
                "Popcorn",
                Localizer.DoStr("Popcorn"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CornSeedItem), 10, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),
                },
                 new CraftingElement<PopcornItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(10f, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PopcornRecipe), .5f, typeof(CampfireCookingSkill), typeof(CampfireCookingParallelSpeedTalent), typeof(CampfireCookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Popcorn"), typeof(PopcornRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);            
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 4)]
    public partial class CaramelPopcornRecipe : RecipeFamily
    {
        public CaramelPopcornRecipe()
        {
            var product = new Recipe(
                "Caramel Popcorn",
                Localizer.DoStr("Caramel Popcorn"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(PopcornItem), 5, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(SugarItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),
                },
                 new CraftingElement<CaramelPopcornItem>(5f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(10f, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CaramelPopcornRecipe), .5f, typeof(CampfireCookingSkill), typeof(CampfireCookingParallelSpeedTalent), typeof(CampfireCookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Caramel Popcorn"), typeof(CaramelPopcornRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}