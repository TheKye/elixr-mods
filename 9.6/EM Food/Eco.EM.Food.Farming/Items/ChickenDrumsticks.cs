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
    [LocDisplayName("Chicken Drumsticks")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class ChickenDrumsticksItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Chicken Drumsticks, Cooked in Fat for a Crispy Delicious Treat");

        private static readonly FoodItemModel defaults          = new(typeof(ChickenDrumsticksItem), "Chicken Drumsticks", shelflife: 12, calories: 700, carbs: 0, fat: 10, protein: 12, vitamins: 0);

        public override float Calories                          => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition                     => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static ChickenDrumsticksItem()                          => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class ChickenDrumsticksRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType               = typeof(ChickenDrumsticksRecipe).Name,
            Assembly                = typeof(ChickenDrumsticksRecipe).AssemblyQualifiedName,
            HiddenName              = "Chicken Drumsticks",
            LocalizableName         = Localizer.DoStr("Chicken Drumsticks"),
            IngredientList          = new()
            {
                new EMIngredient("RawChickenDrumsticksItem", false, 2, true),
                new EMIngredient("Fat", true, 1, true),
            },
            ProductList             = new()
            {
                new EMCraftable("ChickenDrumsticksItem", 2),
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

        static ChickenDrumsticksRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ChickenDrumsticksRecipe()
        {
            this.Recipes           = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories   = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes      = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltChickenDrumsticksRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType                    = typeof(AltChickenDrumsticksRecipe).Name,
            Assembly                     = typeof(AltChickenDrumsticksRecipe).AssemblyQualifiedName,
            HiddenName                   = "Chicken Drumsticks",
            LocalizableName              = Localizer.DoStr("Chicken Drumsticks"),
            IngredientList               = new()
            {
                new EMIngredient("RawChickenDrumsticksItem", false, 4),
                new EMIngredient("Fat", true, 1, true),
            },
            ProductList                  = new()
            {
                new EMCraftable("ChickenDrumsticksItem", 2),
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

        static AltChickenDrumsticksRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltChickenDrumsticksRecipe()
        {
            this.Recipes           = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories   = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes      = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}