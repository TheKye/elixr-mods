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

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Steak Burger")]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SteakBurgerItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Premium Steak Burger");

        private static readonly FoodItemModel defaults = new(typeof(SteakBurgerItem), "Steak Burker", calories: 2000, carbs: 8, fat: 9, protein: 11, vitamins: 10);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static SteakBurgerItem()                       => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 4)]    
    public partial class SteakBurgerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SteakBurgerRecipe).Name,
            Assembly = typeof(SteakBurgerRecipe).AssemblyQualifiedName,
            HiddenName = "Steak Burger",
            LocalizableName = Localizer.DoStr("Steak Burger"),
            IngredientList = new()
            {
                new EMIngredient("WildMixItem", false, 4),
                new EMIngredient("BriocheItem", false, 4),
                new EMIngredient("PrimeCutItem", false, 4),
                new EMIngredient("Cooking Oils", true, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("SteakBurgerItem", 4),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "KitchenItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static SteakBurgerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SteakBurgerRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}