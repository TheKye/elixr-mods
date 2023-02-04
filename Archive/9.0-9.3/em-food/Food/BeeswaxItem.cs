using Eco.Core.Items;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Food
{
    [Serialized]
    [LocDisplayName("Beeswax")]
    [Weight(20)]
    [Fuel(2000)][Tag("Fuel")]
    [Tag("Fat", 1)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeeswaxItem: FoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Bees wax gathered from a bee box.");

        public override float Calories => 200;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 0, Fat = 8, Protein = 0, Vitamins = 0 };
    }
}