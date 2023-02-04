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
    [Weight(1000)]
    [MaxStackSize(100)]
    [LocDisplayName("Smoked Hare Surprise")]
    public partial class SmokedHareSurpriseItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("A smokin' hot bunny with twist.");

        private static readonly FoodItemModel defaults = new(typeof(SmokedHareSurpriseItem), "Smoked Hare Surprise", calories: 600, carbs: 5, fat: 7, protein: 7, vitamins: 5);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static SmokedHareSurpriseItem()                => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class SmokedHareSurpriseRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SmokedHareSurpriseRecipe).Name,
            Assembly = typeof(SmokedHareSurpriseRecipe).AssemblyQualifiedName,
            HiddenName = "Smoked Hare Surprise",
            LocalizableName = Localizer.DoStr("Smoked Hare Surprise"),
            IngredientList = new()
            {
                new EMIngredient("PrimeCutItem", false, 2),
                new EMIngredient("VegetableJerkyItem", false, 4),
                new EMIngredient("HareCarcassItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("SmokedHareSurpriseItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "SmokehouseItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static SmokedHareSurpriseRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SmokedHareSurpriseRecipe()
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
