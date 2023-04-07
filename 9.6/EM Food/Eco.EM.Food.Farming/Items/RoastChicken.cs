using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Roast Chicken")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class RoastChickenItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Roasted Chicken with delicious Roasted Vegetables");

        private static readonly FoodItemModel defaults = new(typeof(RoastChickenItem), "Roasted Chicken", shelflife: 24, calories: 1200, carbs: 0, fat: 14, protein: 27, vitamins: 0);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static RoastChickenItem()                      => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class RoastChickenRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType                      = typeof(RoastChickenRecipe).Name,
            Assembly                       = typeof(RoastChickenRecipe).AssemblyQualifiedName,
            HiddenName                     = "Roast Chicken",
            LocalizableName                = Localizer.DoStr("Roast Chicken"),
            IngredientList                 = new()
            {
                new EMIngredient("RawChickenItem", false, 1, true),
                new EMIngredient("Fat", true, 1, true),
                new EMIngredient("Vegetable", true, 5, true),

            },
            ProductList                    = new()
            {
                new EMCraftable("RoastChickenItem", 1),
            },
            BaseExperienceOnCraft          = 6,
            BaseLabor                      = 20,
            LaborIsStatic                  = false,
            BaseCraftTime                  = 1,
            CraftTimeIsStatic              = false,
            CraftingStation                = "KitchenItem",
            RequiredSkillType              = typeof(CookingSkill),
            RequiredSkillLevel             = 2,
            SpeedImprovementTalents        = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static RoastChickenRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RoastChickenRecipe()
        {
            this.Recipes                   = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories           = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes              = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft         = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltRoastChickenRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType                      = typeof(AltRoastChickenRecipe).Name,
            Assembly                       = typeof(AltRoastChickenRecipe).AssemblyQualifiedName,
            HiddenName                     = "Roast Chicken",
            LocalizableName                = Localizer.DoStr("Roast Chicken"),
            IngredientList                 = new()
            {
                new EMIngredient("RawChickenItem", false, 1, true),
            },
            ProductList                    = new()
            {
                new EMCraftable("RoastChickenItem", 1),
            },
            BaseExperienceOnCraft          = 6,
            BaseLabor                      = 20,
            LaborIsStatic                  = false,
            BaseCraftTime                  = 1,
            CraftTimeIsStatic              = false,
            CraftingStation                = "CastIronStoveItem",
            RequiredSkillType              = typeof(CookingSkill),
            RequiredSkillLevel             = 2,
            IngredientImprovementTalents   = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents        = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static AltRoastChickenRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltRoastChickenRecipe()
        {
            this.Recipes                   = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories           = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes              = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft         = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
