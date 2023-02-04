using Eco.EM.Framework.Components;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Housing.Doors.Modules
{
    [Serialized]
    [LocDisplayName("Automatic Door Operator - Ceiling")]
    public partial class AutomaticDoorOperatorCeilingItem : WorldObjectItem<AutomaticDoorOperatorCeilingObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Door Operator for Operating Doors Automatically, Sits on the Ceiling");
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

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Automatic Door Operator - Floor")]
    public partial class AutomaticDoorOperatorFloorItem : WorldObjectItem<AutomaticDoorOperatorFloorObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Door Operator for Operating Doors Automatically - Sits on the floor");
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

        public override void Destroy() => base.Destroy();
    }
}