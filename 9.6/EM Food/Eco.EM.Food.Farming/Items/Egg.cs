using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Farming
{
	[Serialized]
	[Weight(200)]
	[MaxStackSize(100)]
	[LocDisplayName("Egg")]
	[Tag("Egg")]
	[Ecopedia("Food", "Ingredients", createAsSubPage: true)]
	public partial class EggItem : FoodItem, IConfigurableFoodItem
	{
		public override LocString DisplayNamePlural             => Localizer.DoStr("Eggs");
		public override LocString DisplayDescription            => Localizer.DoStr("Eggs Gathered From The Coop.");

		private static readonly FoodItemModel defaults          = new(typeof(EggItem), "Eggs", shelflife: 24, calories: 60, carbs: 4, fat: 5, protein: 7, vitamins: 1);

		public override float Calories                          => EMFoodItemResolver.Obj.ResolveCalories(this);
		public override Nutrients Nutrition                     => EMFoodItemResolver.Obj.ResolveNutrients(this);

		protected override int BaseShelfLife => throw new System.NotImplementedException();

		static EggItem()                                        => EMFoodItemResolver.AddDefaults(defaults);
	}
}