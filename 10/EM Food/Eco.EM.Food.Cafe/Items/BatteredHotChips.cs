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
    [LocDisplayName("Hot Chips")]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class BatteredHotChipsItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Hot Chips, A nice tasty treat to help fill the gap");
                                                       
        private static readonly FoodItemModel defaults = new(typeof(BatteredHotChipsItem), "Hot Chips", calories: 1100, carbs: 10, fat: 6, protein: 0, shelflife: 12, vitamins: 2);
                                                       
        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        static BatteredHotChipsItem()                  => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 3)]    
    public partial class BatteredHotChipsRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BatteredHotChipsRecipe).Name,
            Assembly = typeof(BatteredHotChipsRecipe).AssemblyQualifiedName,
            HiddenName = "Hot Chips",
            LocalizableName = Localizer.DoStr("Hot Chips"),
            IngredientList = new()
            {
                new EMIngredient("StraightCutChipsItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("BatteredHotChipsItem", 4),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "DeepFryerItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static BatteredHotChipsRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BatteredHotChipsRecipe()
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