using System;
using System.Collections.Generic;
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
	[Weight(100)]
	[MaxStackSize(100)]
	[LocDisplayName("Caramel Popcorn")]
	public partial class CaramelPopcornItem : FoodItem, IConfigurableFoodItem
	{
		public override LocString DisplayNamePlural    => Localizer.DoStr("Caramel Popcorn");
		public override LocString DisplayDescription   => Localizer.DoStr("Sweet, Sweet Popcorn.");

		private static readonly FoodItemModel defaults = new(typeof(CaramelPopcornItem), "Caramel Popcorn", shelflife: 24, calories: 800, carbs: 12, fat: 9, protein: 0, vitamins: 3);

		public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
		public override Nutrients Nutrition            => n;
		private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

		protected override float BaseShelfLife => throw new NotImplementedException();

		static CaramelPopcornItem()                    => EMFoodItemResolver.AddDefaults(defaults);
	}
	
	[RequiresSkill(typeof(CampfireCookingSkill), 4)]
	public partial class CaramelPopcornRecipe : RecipeFamily, IConfigurableRecipe
	{
		static RecipeDefaultModel Defaults => new()
		{
			ModelType = typeof(CaramelPopcornRecipe).Name,
			Assembly = typeof(CaramelPopcornRecipe).AssemblyQualifiedName,
			HiddenName = "Caramel Popcorn",
			LocalizableName = Localizer.DoStr("Caramel Popcorn"),
			IngredientList = new()
			{
				new EMIngredient("PopcornItem", false, 5, true),
				new EMIngredient("Sugar", true, 1, true)
			},
			ProductList = new()
			{
				new EMCraftable("CaramelPopcornItem", 3),
			},
			BaseExperienceOnCraft = 1,
			BaseLabor = 10,
			LaborIsStatic = false,
			BaseCraftTime = .5f,
			CraftTimeIsStatic = false,
			CraftingStation = "CampfireItem",
			RequiredSkillType = typeof(CampfireCookingSkill),
			RequiredSkillLevel = 4,
			IngredientImprovementTalents = typeof(CampfireCookingLavishResourcesTalent),
			SpeedImprovementTalents = new Type[] { typeof(CampfireCookingParallelSpeedTalent), typeof(CampfireCookingFocusedSpeedTalent) },
		};

		static CaramelPopcornRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

		public CaramelPopcornRecipe()
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