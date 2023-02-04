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
    [Weight(200)]                                          
    [LocDisplayName("Wholemeal")]
    [MaxStackSize(100)]
    [Tag("Grain")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class WholeMealItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Wholemeal Made From Wheat.");

        private static readonly FoodItemModel defaults = new(typeof(WholeMealItem), "Wholemeal", calories: 60, carbs: 6, fat: 2, protein: 4, vitamins: 1);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static WholeMealItem()                         => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(MillingSkill), 3)]    
    public partial class WholeMealRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WholeMealRecipe).Name,
            Assembly = typeof(WholeMealRecipe).AssemblyQualifiedName,
            HiddenName = "Wholemeal",
            LocalizableName = Localizer.DoStr("Wholemeal"),
            IngredientList = new()
            {
                new EMIngredient("WheatItem", false, 5, true),
            },
            ProductList = new()
            {
                new EMCraftable("WholeMealItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "MillItem",
            RequiredSkillType = typeof(MillingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(MillingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MillingParallelSpeedTalent), typeof(MillingFocusedSpeedTalent) },
        };

        static WholeMealRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WholeMealRecipe()
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