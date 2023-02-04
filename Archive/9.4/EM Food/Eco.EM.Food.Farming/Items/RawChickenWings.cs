using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [Tag("Chicken")]
    [LocDisplayName("Raw Chicken Wings")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class RawChickenWingsItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Raw Chicken Wings, Ready to be used in a quick easy meal!");

        private static readonly FoodItemModel defaults = new(typeof(RawChickenWingsItem), "Raw Chicken Wings", calories: -40, carbs: 4, fat: 6, protein: 9, vitamins: 3);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static RawChickenWingsItem()                   => EMFoodItemResolver.AddDefaults(defaults);
    }
}
