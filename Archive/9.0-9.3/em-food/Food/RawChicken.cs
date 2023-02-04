using System.Collections.Generic;
using System.Linq;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.View;

namespace Eco.EM.Food
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [LocDisplayName("Chicken Carcass")]
    public partial class RawChickenItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("A Chicken Carcass");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 6, Protein = 9, Vitamins = 3};
        public override float Calories                          => -500;
        public override Nutrients Nutrition                     => nutrition;
    }

    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Roast Chicken")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class RoastChickenItem :
    FoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Roasted Chicken");

        private static Nutrients nutrition = new Nutrients() { Carbs = 3, Fat = 12, Protein = 12, Vitamins = 3 };
        public override float Calories      => 800;
        public override Nutrients Nutrition => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class RoastChickenRecipe : RecipeFamily
    {
        public RoastChickenRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Roast Chicken",
                    Localizer.DoStr("Roast Chicken"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RawChickenItem), 1),
                    },
                    new CraftingElement<RoastChickenItem>(1)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RoastChickenRecipe), 30, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Roast Chicken"), typeof(RoastChickenRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltRoastChickenRecipe : RecipeFamily
    {
        public AltRoastChickenRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Roast Chicken",
                    Localizer.DoStr("Roast Chicken"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RawChickenItem), 1),
                    },
                    new CraftingElement<RoastChickenItem>(1)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltRoastChickenRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Roast Chicken"), typeof(AltRoastChickenRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}