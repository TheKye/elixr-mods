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
	[LocDisplayName("Corn Syrup")]
	[Tag("Syrup", 1)]
	[Tag("Sugar")]
	[Ecopedia("Food", "Ingredients", createAsSubPage: true)]
	public partial class CornSyrupItem : FoodItem, IConfigurableFoodItem
	{
		public override LocString DisplayDescription   => Localizer.DoStr("Corn syrup, also known as glucose syrup to confectioners");

		private static readonly FoodItemModel defaults = new(typeof(CornSyrupItem), "Corn Syrup", shelflife: 24, calories: 55, carbs: 4, fat: 4, protein: 5, vitamins: 2);

		public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
		public override Nutrients Nutrition            => n;
		private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

		protected override float BaseShelfLife => throw new NotImplementedException();

		static CornSyrupItem()                         => EMFoodItemResolver.AddDefaults(defaults);
	}

	[RequiresSkill(typeof(ZymologySkill), 1)]   
	public partial class CornSyrupRecipe : RecipeFamily, IConfigurableRecipe
	{
		static RecipeDefaultModel Defaults => new()
		{
			ModelType = typeof(CornSyrupRecipe).Name,
			Assembly = typeof(CornSyrupRecipe).AssemblyQualifiedName,
			HiddenName = "Corn Syrup",
			LocalizableName = Localizer.DoStr("Corn Syrup"),
			IngredientList = new()
			{
				new EMIngredient("CornItem", false, 4),
				new EMIngredient("MaltoseItem", false, 2),
			},
			ProductList = new()
			{
				new EMCraftable("CornSyrupItem", 2),
			},
			BaseExperienceOnCraft = 1,
			BaseLabor = 50,
			LaborIsStatic = false,
			BaseCraftTime = 12,
			CraftTimeIsStatic = false,
			CraftingStation = "FermentingBarrelItem",
			RequiredSkillType = typeof(ZymologySkill),
			RequiredSkillLevel = 1,
			IngredientImprovementTalents = typeof(ZymologyLavishResourcesTalent),
			SpeedImprovementTalents = new Type[] { typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent) },
		};

		static CornSyrupRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

		public CornSyrupRecipe()
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