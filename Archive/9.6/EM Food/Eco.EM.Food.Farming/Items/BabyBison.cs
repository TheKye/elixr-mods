using Eco.Core.Items;
using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Simulation.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Food.Farming
{
    [Serialized, Weight(5000), MaxStackSize(1)]
    [LocDisplayName("Baby Bison")]
    [Ecopedia("Natural Resources", "Animal", createAsSubPage: true)]
    public partial class BabyBisonItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Baby Bison, Maybe this could be used for something");
    }
}
