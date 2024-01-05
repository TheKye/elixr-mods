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
    [LocDisplayName("Straight Cut Chips")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class StraightCutChipsItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Straight Cut Chips, Ready Cut for Cooking");

        private static readonly FoodItemModel defaults = new(typeof(StraightCutChipsItem), "Straight Cut Chips", calories: 420, carbs: 8, fat: 0, protein: 2, vitamins: 2, shelflife: 12);

        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static StraightCutChipsItem()                  => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class StraightCutChipsRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StraightCutChipsRecipe).Name,
            Assembly = typeof(StraightCutChipsRecipe).AssemblyQualifiedName,
            HiddenName = "Straight Cut Chips",
            LocalizableName = Localizer.DoStr("Straight Cut Chips"),
            IngredientList = new()
            {
                new EMIngredient("TaroRootItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("StraightCutChipsItem", 4),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "KitchenItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static StraightCutChipsRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StraightCutChipsRecipe()
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