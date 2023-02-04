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
    [LocDisplayName("Egg")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class EggItem :
        FoodItem            
    {
		public override LocString DisplayNamePlural             => Localizer.DoStr("Egg's");
        public override LocString DisplayDescription            => Localizer.DoStr("Egg's Gathered From The Chicken Coop.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 5, Protein = 7, Vitamins = 1};
        public override float Calories                          => 60;
        public override Nutrients Nutrition                     => nutrition;
    }
}