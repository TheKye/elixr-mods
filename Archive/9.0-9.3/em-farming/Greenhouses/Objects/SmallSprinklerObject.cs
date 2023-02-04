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
    [RequireComponent(typeof(SprinklerComponent))]
    public partial class SmallSprinklerObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Small Sprinkler Object"); } }

        public virtual Type RepresentedItemType { get { return typeof(SmallSprinklerItem); } }

        static SmallSprinklerObject()
        {
            AddOccupancy<SmallSprinklerObject>(new List<BlockOccupancy>()
        {
            new BlockOccupancy(new Vector3i(0, 0, 0)) });
        }

        protected override void Initialize()
        {
            this.GetComponent<SprinklerComponent>().Initialize(5);
        }
    }

    [Serialized, LocDisplayName("Small Sprinkler Item")]
    public class SmallSprinklerItem : WorldObjectItem<SmallSprinklerObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Small Sprinkler Item"); } }
    }
}
