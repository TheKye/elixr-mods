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
    [MaxStackSize(100)]
    [LocDisplayName("Fish Oil")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Cooking Oils")]
    public partial class FishOilItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Fishiest Fish Oil");

        private static readonly FoodItemModel defaults = new(typeof(FishOilItem), "Fish Oil", calories: 65, carbs: 3, fat: 7, protein: 4, vitamins: 3);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static FishOilItem()                           => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(ZymologySkill), 1)]   
    public partial class FishOilRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(FishOilRecipe).Name,
            Assembly = typeof(FishOilRecipe).AssemblyQualifiedName,
            HiddenName = "Fish Oil",
            LocalizableName = Localizer.DoStr("Fish Oil"),
            IngredientList = new()
            {
                new EMIngredient("Fish", true, 5),
            },
            ProductList = new()
            {
                new EMCraftable("OilItem", 2),
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

        static FishOilRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public FishOilRecipe()
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