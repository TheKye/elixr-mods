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
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Coffee")]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class CoffeeItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("100% Real Coffee");

        private static readonly FoodItemModel defaults = new(typeof(CoffeeItem), "Coffee", calories: 850, carbs: 7, fat: 6, protein: 5, shelflife: 72, vitamins: 4);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        protected override int BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        static CoffeeItem()                            => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class CoffeeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CoffeeRecipe).Name,
            Assembly = typeof(CoffeeRecipe).AssemblyQualifiedName,
            HiddenName = "Brew Coffee",
            LocalizableName = Localizer.DoStr("Brew Coffee"),
            IngredientList = new()
            {
                new EMIngredient("CoffeeBeanItem", false, 8),
                new EMIngredient("Sugar", true, 4),
                new EMIngredient("Milk", true, 1)
            },
            ProductList = new()
            {
                new EMCraftable("CoffeeItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "CastIronStoveItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static CoffeeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CoffeeRecipe()
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