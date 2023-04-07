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
    [LocDisplayName("Ice-Cream")]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class IceCreamItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Olden Day Ice-Cream");

        private static readonly FoodItemModel defaults = new(typeof(IceCreamItem), "Ice-Cream", calories: 1250, carbs: 6, fat: 9, protein: 9, shelflife:12, vitamins: 5);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        static IceCreamItem()                          => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class IceCreamRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(IceCreamRecipe).Name,
            Assembly = typeof(IceCreamRecipe).AssemblyQualifiedName,
            HiddenName = "Ice-Cream",
            LocalizableName = Localizer.DoStr("Ice-Cream"),
            IngredientList = new()
            {
                new EMIngredient("CreamItem", false, 8),
                new EMIngredient("Milk", true, 8),
                new EMIngredient("SimpleSyrupItem", false, 8),
                new EMIngredient("Sugar", true, 8)
            },
            ProductList = new()
            {
                new EMCraftable("IceCreamItem", 4),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "CastIronStoveItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static IceCreamRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public IceCreamRecipe()
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