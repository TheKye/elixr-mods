using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [LocDisplayName("Beeswax")]
    [Weight(20)]
    [Fuel(2000)][Tag("Fuel")]
    [Tag("Fat", 1)]
    [Tag("Wax")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeeswaxItem: FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Bees wax gathered from a bee box.");

        private static readonly FoodItemModel defaults = new(typeof(BeeswaxItem), "Beeswax", calories: 200, carbs: 0, fat: 8, protein: 0, vitamins: 0);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static BeeswaxItem()                           => EMFoodItemResolver.AddDefaults(defaults);
    }
}