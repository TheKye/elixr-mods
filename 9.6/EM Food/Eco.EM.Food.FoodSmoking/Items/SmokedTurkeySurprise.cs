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
    [LocDisplayName("Smoked Turkey Surprise")]
    public partial class SmokedTurkeySurpriseItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("A smokin' hot bird with twist.");

        private static readonly FoodItemModel defaults = new(typeof(SmokedTurkeySurpriseItem), "Smoked Turkey Surprise", shelflife: 24, calories: 600, carbs: 5, fat: 7, protein: 7, vitamins: 5);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static SmokedTurkeySurpriseItem()              => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class SmokedTurkeySurpriseRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SmokedTurkeySurpriseRecipe).Name,
            Assembly = typeof(SmokedTurkeySurpriseRecipe).AssemblyQualifiedName,
            HiddenName = "Smoked Turkey Surprise",
            LocalizableName = Localizer.DoStr("Smoked Turkey Surprise"),
            IngredientList = new()
            {
                new EMIngredient("TurkeyCarcassItem", false, 1),
                new EMIngredient("VegetableJerkyItem", false, 4),
                new EMIngredient("PrimeCutItem", false, 8),
            },
            ProductList = new()
            {
                new EMCraftable("SmokedTurkeySurpriseItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "SmokehouseItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static SmokedTurkeySurpriseRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SmokedTurkeySurpriseRecipe()
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
