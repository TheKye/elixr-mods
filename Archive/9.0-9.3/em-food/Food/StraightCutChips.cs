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
    [LocDisplayName("Straight Cut Chips")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class StraightCutChipsItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Straight Cut Chips, Ready Cut for Cooking");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 4, Protein = 2, Vitamins = 2};
        public override float Calories                          => 420;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class StraightCutChipsRecipe : RecipeFamily
    {
        public StraightCutChipsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Straight Cut Chips",
                    Localizer.DoStr("Straight Cut Chips"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CamasBulbItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    },
                    new CraftingElement<StraightCutChipsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StraightCutChipsRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Straight Cut Chips"), typeof(StraightCutChipsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltStraightCutChipsRecipe : RecipeFamily
    {
        public AltStraightCutChipsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Straight Cut Chips",
                    Localizer.DoStr("Straight Cut Chips"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CamasBulbItem), 10, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                    },
                    new CraftingElement<StraightCutChipsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltStraightCutChipsRecipe), 8, typeof(CookingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Straight Cut Chips"), typeof(AltStraightCutChipsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}