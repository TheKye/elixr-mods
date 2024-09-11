using Eco.EM.Framework.Components;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Housing.Doors.Modules
{
    [Serialized]
    [LocDisplayName("Automatic Door Operator - Ceiling")]
    [LocDescription("A Door Operator for Operating Doors Automatically, Sits on the Ceiling")]
    public partial class AutomaticDoorOperatorCeilingItem : WorldObjectItem<AutomaticDoorOperatorCeilingObject>
    {
        
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(AutoDoorComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public partial class AutomaticDoorOperatorCeilingObject : WorldObject, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AutomaticDoorOperatorCeilingItem);

        static AutomaticDoorOperatorCeilingObject()
        {
            AddOccupancy<AutomaticDoorOperatorCeilingObject>(new List<BlockOccupancy>(0));
        }

        protected override void Initialize()
        {
            GetComponent<AutoDoorComponent>().Initialize(this);
        }


    }

    [Serialized]
    [LocDisplayName("Automatic Door Operator - Floor")]
    [LocDescription("A Door Operator for Operating Doors Automatically - Sits on the floor")]
    public partial class AutomaticDoorOperatorFloorItem : WorldObjectItem<AutomaticDoorOperatorFloorObject>
    {
        
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(AutoDoorComponent))]
    [RequireComponent(typeof(StatusComponent))]
    public partial class AutomaticDoorOperatorFloorObject : WorldObject, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AutomaticDoorOperatorFloorItem);

        static AutomaticDoorOperatorFloorObject()
        {
            AddOccupancy<AutomaticDoorOperatorFloorObject>(new List<BlockOccupancy>(0));
        }

        protected override void Initialize()
        {
            GetComponent<AutoDoorComponent>().Initialize(this);
        }


    }
}