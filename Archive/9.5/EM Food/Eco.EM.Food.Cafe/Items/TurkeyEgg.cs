using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Turkey Egg")]
    [Tag("Egg")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class TurkeyEggItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Turkey Eggs");
        public override LocString DisplayDescription => Localizer.DoStr("Eggs Gathered From The Chicken Coop.");

        private static readonly FoodItemModel defaults = new(typeof(TurkeyEggItem), "Turkey Eggs", calories: 60, carbs: 4, fat: 5, protein: 7, vitamins: 1);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static TurkeyEggItem() => EMFoodItemResolver.AddDefaults(defaults);
    }
}