using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Farming
{
    [Serialized, Weight(2000), MaxStackSize(1)]
    [LocDisplayName("Baby Mountain Goat")]
    public partial class BabyMountainGoatItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("description");
    }
}