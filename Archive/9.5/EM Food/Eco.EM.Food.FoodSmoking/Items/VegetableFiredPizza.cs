using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Food.FoodSmoking
{
    [Serialized]
    [Weight(1000)]
    [MaxStackSize(100)]
    [LocDisplayName("Vegetable Pizza")]
    public partial class VegetableFiredPizzaItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("A pizza, say no more.");

        private static readonly FoodItemModel defaults = new(typeof(VegetableFiredPizzaItem), "Vegetable Pizza", calories: 800, carbs: 10, fat: 5, protein: 5, vitamins: 10);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static VegetableFiredPizzaItem()               => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class VegetableFiredPizzaRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(VegetableFiredPizzaRecipe).Name,
            Assembly = typeof(VegetableFiredPizzaRecipe).AssemblyQualifiedName,
            HiddenName = "Vegetable Pizza",
            LocalizableName = Localizer.DoStr("Vegetable Pizza"),
            IngredientList = new()
            {
                new EMIngredient("FlatbreadItem", false, 5),
                new EMIngredient("VegetableMedleyItem", false, 4),
                new EMIngredient("FriedTomatoesItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("VegetableFiredPizzaItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "SmokehouseItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static VegetableFiredPizzaRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public VegetableFiredPizzaRecipe()
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
