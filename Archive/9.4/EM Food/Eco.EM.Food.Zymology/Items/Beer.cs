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

namespace Eco.EM.Food.Zymology
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Beer")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeerItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Organic Eco Friendly Fuel");

        private static readonly FoodItemModel defaults = new(typeof(BeerItem), "Beer", calories: 1350, carbs: 9, fat: 10, protein: 13, vitamins: 6);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static BeerItem()                              => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(ZymologySkill), 4)]
    public partial class BeerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BeerRecipe).Name,
            Assembly = typeof(BeerRecipe).AssemblyQualifiedName,
            HiddenName = "Beer",
            LocalizableName = Localizer.DoStr("Beer"),
            IngredientList = new()
            {
                new EMIngredient("WortItem", false, 10),
                new EMIngredient("YeastItem", false, 5),
            },
            ProductList = new()
            {
                new EMCraftable("BeerItem", 2),
            },
            BaseExperienceOnCraft = 1.5f,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "FermentingBarrelItem",
            RequiredSkillType = typeof(ZymologySkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(ZymologyLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent) },
        };

        static BeerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BeerRecipe()
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