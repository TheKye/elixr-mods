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
    [LocDisplayName("Chicken Wings")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ChickenWingsItem :
        FoodItem            
    {
        public override LocString DisplayDescription                     => Localizer.DoStr("Chicken Wings"); 

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 6, Protein = 9, Vitamins = 3};
        public override float Calories                          => 700;
        public override Nutrients Nutrition                     => nutrition; 
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class ChickenWingsRecipe : RecipeFamily
    {
        public ChickenWingsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Chicken Wings",
                    Localizer.DoStr("Chicken Wings"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RawChickenWingsItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    },
                    new CraftingElement<ChickenWingsItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenWingsRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Chicken Wings"), typeof(ChickenWingsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltChickenWingsRecipe : RecipeFamily
    {
        public AltChickenWingsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Chicken Wings",
                    Localizer.DoStr("Chicken Wings"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RawChickenWingsItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    },
                    new CraftingElement<ChickenWingsItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltChickenWingsRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Chicken Wings"), typeof(AltChickenWingsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Raw Chicken Wings")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class RawChickenWingsItem :
       FoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Raw Chicken Wings");

        private static Nutrients nutrition = new Nutrients() { Carbs = 4, Fat = 6, Protein = 9, Vitamins = 3 };
        public override float Calories      => -40;
        public override Nutrients Nutrition => nutrition;
    }
}