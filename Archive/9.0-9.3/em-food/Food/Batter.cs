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
    [LocDisplayName("Batter")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BatterItem : FoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Batter");

        private static Nutrients nutrition = new Nutrients() { Carbs = 4, Fat = 6, Protein = 9, Vitamins = 3 };
        public override float Calories { get { return 450; } }
        public override Nutrients Nutrition => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class BatterRecipe : RecipeFamily
    {
        public BatterRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Batter",
                    Localizer.DoStr("Batter"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(FlourItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(WholeMealItem), 1, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<BatterItem>()
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BatterRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Batter"), typeof(BatterRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltBatterRecipe : RecipeFamily
    {
        public AltBatterRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Batter",
                    Localizer.DoStr("Batter"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(FlourItem), 4, typeof(CookingSkill)),
                        new IngredientElement(typeof(WholeMealItem), 2, typeof(CookingSkill))
                    },
                    new CraftingElement<BatterItem>()
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltBatterRecipe), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Batter"), typeof(AltBatterRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}