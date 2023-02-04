using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Zymology
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Double Cream")]
    [Tag("Cream")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class DoubleCreamItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("A Double Dose of Fluffy Cream, a byproduct of making low fat milk");

        private static readonly FoodItemModel defaults = new(typeof(DoubleCreamItem), "Double Cream", calories: 300, carbs: 1, fat: 10, protein: 1, vitamins: 2);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static DoubleCreamItem()                       => EMFoodItemResolver.AddDefaults(defaults);
    }
}