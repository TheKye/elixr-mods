using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Energy.Sensors
{
    [Serialized]
    [MaxStackSize(10)]
    [Weight(100)]
    [LocDisplayName("Broken Fuse")]
    public partial class BrokenFuseItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Broken Fuses");
        public override LocString DisplayDescription => Localizer.DoStr("A Blown Fuse from the Power Switch or Power Breaker. Considered Rubbish.");
    }

    //Broken Fuses Cannot be crafted

}
