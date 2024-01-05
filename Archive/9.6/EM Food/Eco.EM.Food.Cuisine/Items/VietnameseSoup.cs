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
    [LocDisplayName("Vietnamese Soup")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class VietnameseSoupItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Vietnamese Soup, It's a trade secret");

        private static readonly FoodItemModel defaults = new(typeof(VietnameseSoupItem), "Vietnamese Soup", shelflife: 12, calories: 750, carbs: 7, fat: 3, protein: 7, vitamins: 6);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override int BaseShelfLife => throw new NotImplementedException();

        static VietnameseSoupItem()                    => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 2)]   
    public partial class VietnameseSoupRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(VietnameseSoupRecipe).Name,
            Assembly = typeof(VietnameseSoupRecipe).AssemblyQualifiedName,
            HiddenName = "Vietnamese Soup",
            LocalizableName = Localizer.DoStr("Vietnamese Soup"),
            IngredientList = new()
            {
                new EMIngredient("UrchinOilItem", false, 2),
                new EMIngredient("BeansItem", false, 4),
                new EMIngredient("CornItem", false, 4)
            },
            ProductList = new()
            {
                new EMCraftable("VietnameseSoupItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 13,
            CraftTimeIsStatic = false,
            CraftingStation = "KitchenItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static VietnameseSoupRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public VietnameseSoupRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltVietnameseSoupRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AltVietnameseSoupRecipe).Name,
            Assembly = typeof(AltVietnameseSoupRecipe).AssemblyQualifiedName,
            HiddenName = "Vietnamese Soup",
            LocalizableName = Localizer.DoStr("Vietnamese Soup"),
            IngredientList = new()
            {
                new EMIngredient("UrchinOilItem", false, 2),
                new EMIngredient("BeansItem", false, 4),
                new EMIngredient("CornItem", false, 4)
            },
            ProductList = new()
            {
                new EMCraftable("VietnameseSoupItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 20,
            CraftTimeIsStatic = false,
            CraftingStation = "CastIronStoveItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static AltVietnameseSoupRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltVietnameseSoupRecipe()
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