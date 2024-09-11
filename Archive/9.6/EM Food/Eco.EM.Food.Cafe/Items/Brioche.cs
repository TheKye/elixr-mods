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

namespace Eco.EM.Food.Cuisine
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Brioche")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class BriocheItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayNamePlural    => Localizer.DoStr("Brioche"); 
        public override LocString DisplayDescription   => Localizer.DoStr("A Delicious, Honey Soft Roll.");

        private static readonly FoodItemModel defaults = new(typeof(BriocheItem), "Brioche", calories: 750, carbs: 14, fat: 6, protein: 4, vitamins: 4, shelflife: 72);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override int BaseShelfLife => throw new NotImplementedException();

        static BriocheItem()                           => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(BakingSkill), 3)]    
    public partial class BriocheRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BriocheRecipe).Name,
            Assembly = typeof(BriocheRecipe).AssemblyQualifiedName,
            HiddenName = "Brioche",
            LocalizableName = Localizer.DoStr("Brioche"),
            IngredientList = new()
            {
                new EMIngredient("FlourItem", false, 1, true),
                new EMIngredient("YeastItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("BriocheItem", 6),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "BakeryOvenItem",
            RequiredSkillType = typeof(BakingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(BakingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(BakingParallelSpeedTalent), typeof(BakingFocusedSpeedTalent) },
        };

        static BriocheRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BriocheRecipe()
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