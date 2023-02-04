// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
using System.ComponentModel;
using Eco.Core.Controller;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;

namespace Eco.EM.Energy.Electronics.Components
{
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
