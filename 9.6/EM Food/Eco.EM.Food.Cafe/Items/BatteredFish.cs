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

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Battered Fish")]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class BatteredFishItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   =>Localizer.DoStr("Fresh Battered Fish");

        private static readonly FoodItemModel defaults = new(typeof(BatteredFishItem), "Battered Fish", calories: 1100, carbs: 6, fat: 6, protein: 9, shelflife: 12, vitamins: 8);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        static BatteredFishItem()                      => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class BatteredFishRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BatteredFishRecipe).Name,
            Assembly = typeof(BatteredFishRecipe).AssemblyQualifiedName,
            HiddenName = "Battered Fish",
            LocalizableName = Localizer.DoStr("Battered Fish"),
            IngredientList = new()
            {
                new EMIngredient("RawFishItem", false, 5),
                new EMIngredient("BatterItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BatteredFishItem", 3),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "DeepFryerItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static BatteredFishRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BatteredFishRecipe()
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