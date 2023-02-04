using System;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Farming
{
    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class AnimalTroughObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Animal Trough");

        public virtual Type RepresentedItemType => typeof(AnimalTroughItem);

        static AnimalTroughObject()
        {

        }

        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(4);
            storage.Storage.AddInvRestriction(new TagRestriction("Feed")); // can't store anything other then items with the feed tag
            this.GetComponent<LinkComponent>().Initialize(12);

            base.PostInitialize();
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
            UpdateAnimation();
        }

        public override void Tick()
        {
            UpdateAnimation();
        }

        public void UpdateAnimation()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            SetAnimatedState("HasInventory", storage.Inventory.IsEmpty);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [Weight(600)]
    [MaxStackSize(10)]
    [LocDisplayName("Animal Trough")]
    public partial class AnimalTroughItem : WorldObjectItem<AnimalTroughObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Trough for holding Animal Feed.");
    }

    //to do: add recipe for animal trough
}
