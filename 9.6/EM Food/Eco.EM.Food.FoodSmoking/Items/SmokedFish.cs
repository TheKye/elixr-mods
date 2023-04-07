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
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Smoked Fish")]
    public partial class SmokedFishItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayNamePlural    => Localizer.DoStr("Smoked Fish");
        public override LocString DisplayDescription   => Localizer.DoStr("Smoke me a kipper, I'll be back for breakfast.");

        private static readonly FoodItemModel defaults = new(typeof(SmokedFishItem), "Smoked Fish", shelflife: 24, calories: 400, carbs: 0, fat: 8, protein: 12, vitamins: 0);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static SmokedFishItem()                        => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class SmokedFishRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SmokedFishRecipe).Name,
            Assembly = typeof(SmokedFishRecipe).AssemblyQualifiedName,
            HiddenName = "Smoked Fish",
            LocalizableName = Localizer.DoStr("Smoked Fish"),
            IngredientList = new()
            {
                new EMIngredient("RawFishItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("SmokedFishItem"),
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

        static SmokedFishRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SmokedFishRecipe()
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