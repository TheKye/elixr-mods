using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Greenhousing
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HeatLampComponent))]
    public partial class SmallHeatLampObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Small Heat Lamp Object"); } }

        public virtual Type RepresentedItemType { get { return typeof(SmallHeatLampItem); } }

        static SmallHeatLampObject() { AddOccupancy<SmallHeatLampObject>(new List<BlockOccupancy>() 
        { 
            new BlockOccupancy(new Vector3i(0, 0, 0)) }); 
        }

        protected override void Initialize()
        {
            this.GetComponent<HeatLampComponent>().Initialize(5);
        }
    }

    [Serialized, LocDisplayName("Small Heat lamp Item")]
    public class SmallHeatLampItem : WorldObjectItem<SmallHeatLampObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Small Heat lamp Item"); } }
    }

}
