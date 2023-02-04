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
    [LocDisplayName("Meat Pizza")]
    public partial class MeatFiredPizzaItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Heart attack on a round base");

        private static readonly FoodItemModel defaults = new(typeof(MeatFiredPizzaItem), "Meat Pizza", calories: 1250, carbs: 10, fat: 7, protein: 9, vitamins: 3);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static MeatFiredPizzaItem()                    => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class MeatFiredPizzaRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(MeatFiredPizzaRecipe).Name,
            Assembly = typeof(MeatFiredPizzaRecipe).AssemblyQualifiedName,
            HiddenName = "Meat Pizza",
            LocalizableName = Localizer.DoStr("Meat Pizza"),
            IngredientList = new()
            {
                new EMIngredient("FlatbreadItem", false, 5),
                new EMIngredient("SmokedBaconItem", false, 4),
                new EMIngredient("FriedTomatoesItem", false, 4),

            },
            ProductList = new()
            {
                new EMCraftable("MeatFiredPizzaItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "SmokehouseItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static MeatFiredPizzaRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public MeatFiredPizzaRecipe()
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
