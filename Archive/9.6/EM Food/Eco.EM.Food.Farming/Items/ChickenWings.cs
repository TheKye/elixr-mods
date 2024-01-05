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

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Chicken Wings")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class ChickenWingsItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Chicken Wings, Cooked in Fat for a Crispy Delicious Treat");

        private static readonly FoodItemModel defaults  = new(typeof(ChickenWingsItem), "Chicken Wings", shelflife: 12, calories: 700, carbs: 0, fat: 3, protein: 6, vitamins: 0);

        public override float Calories                  => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override int BaseShelfLife => throw new NotImplementedException();

        static ChickenWingsItem()                       => EMFoodItemResolver.AddDefaults(defaults);

    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class ChickenWingsRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType               = typeof(ChickenWingsRecipe).Name,
            Assembly                = typeof(ChickenWingsRecipe).AssemblyQualifiedName,
            HiddenName              = "Chicken Wings",
            LocalizableName         = Localizer.DoStr("Chicken Wings"),
            IngredientList          = new()
            {
                new EMIngredient("RawChickenWingsItem", false, 2, true),
                new EMIngredient("Fat", true, 1, true),
            },
            ProductList             = new()
            {
                new EMCraftable("ChickenWingsItem", 2),
            },
            BaseExperienceOnCraft   = 6,
            BaseLabor               = 20,
            LaborIsStatic           = false,
            BaseCraftTime           = 1,
            CraftTimeIsStatic       = false,
            CraftingStation         = "KitchenItem",
            RequiredSkillType       = typeof(CookingSkill),
            RequiredSkillLevel      = 2,
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static ChickenWingsRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ChickenWingsRecipe()
        {
            this.Recipes            = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories    = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes       = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft  = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltChickenWingsRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType                    = typeof(AltChickenWingsRecipe).Name,
            Assembly                     = typeof(AltChickenWingsRecipe).AssemblyQualifiedName,
            HiddenName                   = "Chicken Wings",
            LocalizableName              = Localizer.DoStr("Chicken Wings"),
            IngredientList               = new()
            {
                new EMIngredient("RawChickenWingsItem", false, 4),
            },
            ProductList                  = new()
            {
                new EMCraftable("ChickenWingsItem", 2),
            },
            BaseExperienceOnCraft        = 6,
            BaseLabor                    = 20,
            LaborIsStatic                = false,
            BaseCraftTime                = 1,
            CraftTimeIsStatic            = false,
            CraftingStation              = "CastIronStoveItem",
            RequiredSkillType            = typeof(CookingSkill),
            RequiredSkillLevel           = 2,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents      = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static AltChickenWingsRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltChickenWingsRecipe()
        {
            this.Recipes                 = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories         = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes            = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft       = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}