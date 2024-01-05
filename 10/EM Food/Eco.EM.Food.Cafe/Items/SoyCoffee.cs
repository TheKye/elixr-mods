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
    [LocDisplayName("Soy Coffee")]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class SoyCoffeeItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Soy Coffee, Made with 100% Soy Milk");

        private static readonly FoodItemModel defaults = new(typeof(SoyCoffeeItem), "Soy Coffee", calories: 800, carbs: 6, fat: 2, protein: 6, vitamins: 3, shelflife: 12);

        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static SoyCoffeeItem()                         => EMFoodItemResolver.AddDefaults(defaults);
    }


    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class SoyCoffeeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SoyCoffeeRecipe).Name,
            Assembly = typeof(SoyCoffeeRecipe).AssemblyQualifiedName,
            HiddenName = "Soy Coffee",
            LocalizableName = Localizer.DoStr("Soy Coffee"),
            IngredientList = new()
            {
                new EMIngredient("CoffeeBeanItem", false, 5),
                new EMIngredient("Sugar", true, 2),
                new EMIngredient("SoyMilkItem", false, 1)
            },
            ProductList = new()
            {
                new EMCraftable("SoyCoffeeItem", 2),
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

        static SoyCoffeeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SoyCoffeeRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}