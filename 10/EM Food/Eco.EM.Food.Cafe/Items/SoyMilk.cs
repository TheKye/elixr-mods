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
    [LocDisplayName("Soy Milk")]
    [Tag("Milk")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class SoyMilkItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Soy Milk Made From Beans.");

        private static readonly FoodItemModel defaults = new(typeof(SoyMilkItem), "Soy Milk", calories: 55, carbs: 4, fat: 4, protein: 5, vitamins: 2, shelflife: 72);

        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static SoyMilkItem()                           => EMFoodItemResolver.AddDefaults(defaults);
    }
    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class SoyMilkRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SoyMilkRecipe).Name,
            Assembly = typeof(SoyMilkRecipe).AssemblyQualifiedName,
            HiddenName = "Soy Milk",
            LocalizableName = Localizer.DoStr("Soy Milk"),
            IngredientList = new()
            {
                new EMIngredient("BeansItem", false, 5),
                new EMIngredient("Fat", true, 1),
                new EMIngredient("FlourItem", false, 1)
            },
            ProductList = new()
            {
                new EMCraftable("SoyMilkItem", 3)
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 20,
            CraftTimeIsStatic = false,
            CraftingStation = "CastIronStoveItem",
            RequiredSkillLevel = 1,
        };

        static SoyMilkRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SoyMilkRecipe()
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