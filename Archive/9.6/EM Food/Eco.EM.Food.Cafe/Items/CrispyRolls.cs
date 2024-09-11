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
    [LocDisplayName("Crispy Rolls")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class CrispyRollsItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayNamePlural    => Localizer.DoStr("Crispy Rolls");
        public override LocString DisplayDescription   => Localizer.DoStr("Crispy Rolls Baked With Heat.");

        private static readonly FoodItemModel defaults = new(typeof(CrispyRollsItem), "Crispy Rolls", calories: 680, carbs: 11, fat: 6, protein: 7, vitamins: 4, shelflife: 72);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override int BaseShelfLife => throw new NotImplementedException();

        static CrispyRollsItem()                       => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(BakingSkill), 2)]    
    public partial class CrispyRollsRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CrispyRollsRecipe).Name,
            Assembly = typeof(CrispyRollsRecipe).AssemblyQualifiedName,
            HiddenName = "Crispy Rolls",
            LocalizableName = Localizer.DoStr("Crispy Rolls"),
            IngredientList = new()
            {
                new EMIngredient("FlourItem", false, 5),
                new EMIngredient("YeastItem", false, 2)
            },
            ProductList = new()
            {
                new EMCraftable("CrispyRollsItem", 3),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "BakeryOvenItem",
            RequiredSkillType = typeof(BakingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(BakingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(BakingParallelSpeedTalent), typeof(BakingFocusedSpeedTalent) },
        };

        static CrispyRollsRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CrispyRollsRecipe()
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