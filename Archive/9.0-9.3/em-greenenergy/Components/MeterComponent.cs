// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Gameplay.Components
{
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Controller;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Utils;
    using Objects;
    using Shared.Serialization;

    [Serialized, AutogenClass]
    public partial class MeterComponent : WorldObjectComponent
    {
        // how much energy we desire
        public float PipsCount { get; private set; }

        [Serialized, SyncToView, Autogen, ReadOnly(true)]
        public float Percentage { get; set; }

        public MeterComponent() { }
        public MeterComponent(float pipsCount)
        {
            this.Initialize(pipsCount);
        }

        public void Initialize(float pipsCount) => this.PipsCount = pipsCount;
    }
}
