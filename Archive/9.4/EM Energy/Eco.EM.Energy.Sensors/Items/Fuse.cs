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
    [LocDisplayName("Fuse")]
    public partial class FuseItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Fuses");
        public override LocString DisplayDescription => Localizer.DoStr("A Fuse for use in the Power Switch or Power Breaker.");
    }

    public partial class FuseRecipe : RecipeFamily
    {

    }
}
