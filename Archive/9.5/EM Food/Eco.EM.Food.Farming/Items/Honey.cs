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
    [LocDisplayName("Honey")]
    [Tag("Sugar")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class HoneyItem : FoodItem, IConfigurableFoodItem            
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Eco Fresh, Reserve Honey.");

        private static readonly FoodItemModel defaults = new(typeof(HoneyItem), "Honey", calories: 55, carbs: 4, fat: 4, protein: 5, vitamins: 2);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static HoneyItem()                             => EMFoodItemResolver.AddDefaults(defaults);
    }
}