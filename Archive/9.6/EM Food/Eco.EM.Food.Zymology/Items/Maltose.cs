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

namespace Eco.EM.Food.Zymology
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Maltose")]
    [Tag("Sugar")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class MaltoseItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Also known as maltobiose or malt sugar.");

        private static readonly FoodItemModel defaults = new(typeof(MaltoseItem), "Maltose", shelflife: 24, calories: 55, carbs: 4, fat: 4, protein: 5, vitamins: 2);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override int BaseShelfLife => throw new NotImplementedException();

        static MaltoseItem()                           => EMFoodItemResolver.AddDefaults(defaults);
    }

	
	[RequiresSkill(typeof(ZymologySkill), 1)]   
    public partial class MaltoseRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(MaltoseRecipe).Name,
            Assembly = typeof(MaltoseRecipe).AssemblyQualifiedName,
            HiddenName = "Maltose",
            LocalizableName = Localizer.DoStr("Maltose"),
            IngredientList = new()
            {
                new EMIngredient("WheatItem", false, 4),
                new EMIngredient("SugarItem", false, 4)
            },
            ProductList = new()
            {
                new EMCraftable("MaltoseItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "FermentingBarrelItem",
            RequiredSkillType = typeof(ZymologySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(ZymologyLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent) },
        };

        static MaltoseRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public MaltoseRecipe()
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