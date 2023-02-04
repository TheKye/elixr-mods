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
    [LocDisplayName("Chicken Drumsticks")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ChickenDrumsticksItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Chicken Drumsticks");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 12, Protein = 9, Vitamins = 3};
        public override float Calories                          => 700;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class ChickenDrumsticksRecipe : RecipeFamily
    {
        public ChickenDrumsticksRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Chicken Drumsticks",
                    Localizer.DoStr("Chicken Drumsticks"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RawChickenDrumsticksItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    },
                    new CraftingElement<ChickenDrumsticksItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenDrumsticksRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Chicken Drumsticks"), typeof(ChickenDrumsticksRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltChickenDrumsticksRecipe : RecipeFamily
    {
        public AltChickenDrumsticksRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Chicken Drumsticks",
                    Localizer.DoStr("Chicken Drumsticks"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RawChickenDrumsticksItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    },
                    new CraftingElement<ChickenDrumsticksItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltChickenDrumsticksRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Chicken Drumsticks"), typeof(AltChickenDrumsticksRecipe));
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
    [LocDisplayName("Raw Chicken Drumsticks")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class RawChickenDrumsticksItem :
       FoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Raw Chicken Drumsticks");

        private static Nutrients nutrition = new Nutrients() { Carbs = 4, Fat = 12, Protein = 9, Vitamins = 3 };
        public override float Calories      => -50;
        public override Nutrients Nutrition => nutrition;
    }

    [RequiresSkill(typeof(ButcherySkill), 2)]
    public partial class ProcessChickenRecipe : RecipeFamily
    {
        public ProcessChickenRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Process Chicken",
                    Localizer.DoStr("Process Chicken"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RawChickenItem), 1, typeof(ButcherySkill)),
                    },
                    new CraftingElement<RawChickenDrumsticksItem>(2),
                    new CraftingElement<RawChickenWingsItem>(2),
                    new CraftingElement<ScrapMeatItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ButcherySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenDrumsticksRecipe), 8, typeof(ButcherySkill), typeof(ButcheryParallelSpeedTalent), typeof(ButcheryFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Process Chicken"), typeof(ProcessChickenRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}