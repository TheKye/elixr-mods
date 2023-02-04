using Eco.Core.Items;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Honey")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class HoneyItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Eco Fresh, Reserve Honey.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 4, Protein = 5, Vitamins = 2};
        public override float Calories                          => 55;
        public override Nutrients Nutrition                     => nutrition;
    }
}