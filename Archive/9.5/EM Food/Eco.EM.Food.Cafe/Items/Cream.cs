using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Cream")]
    [Tag("Cream")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CreamItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Fluffy Cream a byproduct of making milk");

        private static readonly FoodItemModel defaults = new(typeof(CreamItem), "Cream", calories: 400, carbs: 1, fat: 6, protein: 1, vitamins: 4);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static CreamItem() => EMFoodItemResolver.AddDefaults(defaults);
    }
}