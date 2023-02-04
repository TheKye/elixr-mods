using Eco.Core.Items;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Cream")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CreamItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Fluffy Cream a byproduct of making milk");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 4, Protein = 2, Vitamins = 4};
        public override float Calories                          => 650;
        public override Nutrients Nutrition                     => nutrition;
    }

}