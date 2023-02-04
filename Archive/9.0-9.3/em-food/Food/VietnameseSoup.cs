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
    [LocDisplayName("Vietnamese Soup")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class VietnameseSoupItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Vietnamese Soup");  

        private static Nutrients nutrition = new Nutrients() { Carbs = 7, Fat = 3, Protein = 7, Vitamins = 6 };
        public override float Calories                          => 750;  
        public override Nutrients Nutrition                     => nutrition;  
    }

    [RequiresSkill(typeof(CookingSkill), 2)]   
    public partial class VietnameseSoupRecipe : RecipeFamily
    {
        public VietnameseSoupRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Vietnamese Soup",
                    Localizer.DoStr("Vietnamese Soup"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(UrchinOilItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(BeansItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(CornItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<VietnameseSoupItem>()
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(VietnameseSoupRecipe), 13, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Vietnamese Soup"), typeof(VietnameseSoupRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltVietnameseSoupRecipe : RecipeFamily
    {
        public AltVietnameseSoupRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Vietnamese Soup",
                    Localizer.DoStr("Vietnamese Soup"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(UrchinOilItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(BeansItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(CornItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<VietnameseSoupItem>()
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltVietnameseSoupRecipe), 20, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Vietnamese Soup"), typeof(AltVietnameseSoupRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}