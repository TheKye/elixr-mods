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
    [LocDisplayName("Raw Chicken Drumsticks")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class RawChickenDrumsticksItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Raw Chicken Drumsticks, My Second Favorite");

        private static readonly FoodItemModel defaults = new(typeof(RawChickenDrumsticksItem), "Raw Chicken Drumsticks", calories: -50, carbs: 4, fat: 12, protein: 9, vitamins: 3);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static RawChickenDrumsticksItem()              => EMFoodItemResolver.AddDefaults(defaults);
    }
}
