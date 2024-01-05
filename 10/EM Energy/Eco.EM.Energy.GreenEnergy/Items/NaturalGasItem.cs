using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Core.Items;
using Eco.Mods.TechTree;

namespace Eco.EM.Energy.GreenEnergy
{
    //Definition for Natural Gas
    [Serialized]
    [NotSpawnable]
    [LocDisplayName("Natural Gas")]
    public partial class NaturalGasItem : Item
    { 
        public override LocString DisplayNamePlural => Localizer.DoStr("Natural Gas");
        public override LocString DisplayDescription => Localizer.DoStr("Natural Gas which is pumped from deep within our planet to use as a cleaner fuel.");
    }
}