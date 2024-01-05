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
    [Weight(150)]
    [MaxStackSize(100)]
    [LocDisplayName("Smoked Vegetable Kabob")]
    public partial class SmokedVegetableKabobItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Smoked Vegetable Kabob");

        private static readonly FoodItemModel defaults = new(typeof(SmokedVegetableKabobItem), "Smoked Vegetable Kabob", shelflife: 24, calories: 650, carbs: 5, fat: 5, protein: 5, vitamins: 5);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static SmokedVegetableKabobItem()              => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class SmokedVegetableKabobRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SmokedVegetableKabobRecipe).Name,
            Assembly = typeof(SmokedVegetableKabobRecipe).AssemblyQualifiedName,
            HiddenName = "Smoked Vegetable Kabob",
            LocalizableName = Localizer.DoStr("Smoked Vegetable Kabob"),
            IngredientList = new()
            {
                new EMIngredient("BeetItem", false, 3),
                new EMIngredient("CriminiMushroomsItem", false, 3),
                new EMIngredient("TomatoItem", false, 3),
            },
            ProductList = new()
            {
                new EMCraftable("SmokedVegetableKabobItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "SmokehouseItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static SmokedVegetableKabobRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SmokedVegetableKabobRecipe()
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
