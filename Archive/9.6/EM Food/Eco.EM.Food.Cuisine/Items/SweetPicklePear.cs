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

namespace Eco.EM.Food.Cuisine
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Sweet Pickle Pear")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class SweetPicklePearItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Pickle Pear With Bitter Beats.");

        private static readonly FoodItemModel defaults = new(typeof(SweetPicklePearItem), "Sweet Pickle Pear", shelflife: 96, calories: 750, carbs: 6, fat: 4, protein: 7, vitamins: 7);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override int BaseShelfLife => throw new NotImplementedException();

        static SweetPicklePearItem()                   => EMFoodItemResolver.AddDefaults(defaults);
    }
        public partial class SweetPicklePearRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SweetPicklePearRecipe).Name,
            Assembly = typeof(SweetPicklePearRecipe).AssemblyQualifiedName,
            HiddenName = "Sweet Pickle Pear",
            LocalizableName = Localizer.DoStr("Sweet Pickle Pear"),
            IngredientList = new()
            {
                new EMIngredient("BeetItem", false, 2),
                new EMIngredient("PricklyPearFruitItem", false, 2)
            },
            ProductList = new()
            {
                new EMCraftable("SweetPicklePearItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "FermentingBarrelItem",
        };

        static SweetPicklePearRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SweetPicklePearRecipe()
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