using System;
using System.Collections.Generic;
using System.Linq;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Zymology
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Vegetable Oil")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Cooking Oils")]
    public partial class VegetableOilItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Vegetable Oil for cooking");

        private static readonly FoodItemModel defaults = new(typeof(VegetableOilItem), "Vegetable Oil", calories: 65, carbs: 3, fat: 7, protein: 4, vitamins: 3);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static VegetableOilItem()                      => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(ZymologySkill), 1)]   
    public partial class VegetableOilRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(VegetableOilRecipe).Name,
            Assembly = typeof(VegetableOilRecipe).AssemblyQualifiedName,
            HiddenName = "Vegetable Oil",
            LocalizableName = Localizer.DoStr("Vegetable Oil"),
            IngredientList = new()
            {
                new EMIngredient("CornItem", false, 5),
            },
            ProductList = new()
            {
                new EMCraftable("VegetableOilItem", 2),
            },
            BaseExperienceOnCraft = 1.5f,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "FermentingBarrelItem",
            RequiredSkillType = typeof(ZymologySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(ZymologyLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent) },
        };

        static VegetableOilRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public VegetableOilRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(ZymologySkill), 1)]
    public partial class altVegetableOilRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(altVegetableOilRecipe).Name,
            Assembly = typeof(altVegetableOilRecipe).AssemblyQualifiedName,
            HiddenName = "Vegetable Oil",
            LocalizableName = Localizer.DoStr("Vegetable Oil"),
            IngredientList = new()
            {
                new EMIngredient("SunflowerItem", false, 5),
            },
            ProductList = new()
            {
                new EMCraftable("VegetableOilItem", 2),
            },
            CraftingStation = "FermentingBarrelItem",
        };

        static altVegetableOilRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public altVegetableOilRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(VegetableOilRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}