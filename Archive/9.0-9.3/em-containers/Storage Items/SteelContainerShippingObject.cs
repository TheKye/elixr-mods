// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.EM.Storage
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Gameplay.Components.Auth;

    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class SteelShippingContainerObject : WorldObject
    {
        protected override void PostInitialize()
        {
            base.PostInitialize();

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(128);
            this.GetComponent<LinkComponent>().Initialize(7);
        }
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(LinkComponent))]
    public class ASteelShippingContainerObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("FunnyMContainerSteelShipping"); } }

        protected override void Initialize()
        {
            base.Initialize();

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(128, 8000000);
            this.GetComponent<LinkComponent>().Initialize(7);
        }
    }
}
