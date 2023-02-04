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
    [LocDisplayName("Battered Fish")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BatteredFishItem :
        FoodItem
    {
        public override LocString DisplayDescription =>Localizer.DoStr("Fresh Battered Fish");

        private static Nutrients nutrition = new Nutrients() { Carbs = 6, Fat = 6, Protein = 9, Vitamins = 8 };
        public override float Calories => 1100;
        public override Nutrients Nutrition => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class BatteredFishRecipe : RecipeFamily
    {
        public BatteredFishRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Battered Fish",
                    Localizer.DoStr("Battered Fish"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RawFishItem), 5, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(BatterItem), 5, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<BatteredFishItem>(3)
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BatteredFishRecipe), 2f, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Battered Fish"), typeof(BatteredFishRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public class AltBatteredFishRecipe : RecipeFamily
    {
        public AltBatteredFishRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Battered Fish",
                    Localizer.DoStr("Battered Fish"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BatterItem), 8, typeof(CookingSkill)),
                        new IngredientElement(typeof(RawFishItem), 8, typeof(CookingSkill))
                    },
                    new CraftingElement<BatteredFishItem>(3)
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltBatteredFishRecipe), 2, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Battered Fish"), typeof(AltBatteredFishRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}