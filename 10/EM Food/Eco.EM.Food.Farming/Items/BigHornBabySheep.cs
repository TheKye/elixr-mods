using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Farming
{
    [Serialized, Weight(2000), MaxStackSize(1)]
    [LocDisplayName("Baby Bighorn Sheep")]
    public partial class BabyBighornSheepItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Baby Bighorn Sheep, Maybe this could be used for something");
    }
}