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
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Smoked Bacon")]
    public partial class SmokedBaconItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayNamePlural    => Localizer.DoStr("Smoked Bacon");
        public override LocString DisplayDescription   => Localizer.DoStr("Bacon! Bacon! Bacon!");

        private static readonly FoodItemModel defaults = new(typeof(SmokedBaconItem), "Smoked Bacon", shelflife: 24, calories: 500, carbs: 0, fat: 15, protein: 17, vitamins: 0);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static SmokedBaconItem()                       => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 3)]
    public partial class SmokedBaconRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SmokedBaconRecipe).Name,
            Assembly = typeof(SmokedBaconRecipe).AssemblyQualifiedName,
            HiddenName = "Smoked Bacon",
            LocalizableName = Localizer.DoStr("Smoked Bacon"),
            IngredientList = new()
            {
                new EMIngredient("RawBaconItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("SmokedBaconItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "SmokehouseItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static SmokedBaconRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SmokedBaconRecipe()
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
