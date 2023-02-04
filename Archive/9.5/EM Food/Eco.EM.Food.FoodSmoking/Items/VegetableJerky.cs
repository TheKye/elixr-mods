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
    [Weight(300)]
    [MaxStackSize(100)]
    [LocDisplayName("Vegetable Jerky")]
    public partial class VegetableJerkyItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Vegetarian, salty and dry.");

        private static readonly FoodItemModel defaults = new(typeof(VegetableJerkyItem), "Vegetable Jerky", calories: 400, carbs: 12, fat: 0, protein: 0, vitamins: 12);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static VegetableJerkyItem()                    => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class VegetableJerkyRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(VegetableJerkyRecipe).Name,
            Assembly = typeof(VegetableJerkyRecipe).AssemblyQualifiedName,
            HiddenName = "Vegetable Jerky",
            LocalizableName = Localizer.DoStr("Vegetable Jerky"),
            IngredientList = new()
            {
                new EMIngredient("BeanPasteItem", false, 5),
                new EMIngredient("CriminiMushroomsItem", false, 5),
                new EMIngredient("CamasPasteItem", false, 5),
            },
            ProductList = new()
            {
                new EMCraftable("VegetableJerkyItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "SmokehouseItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static VegetableJerkyRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public VegetableJerkyRecipe()
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
