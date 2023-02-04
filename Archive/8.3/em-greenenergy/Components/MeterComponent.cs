// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Gameplay.Components
{
    using System.Linq;
    using Eco.Core.Controller;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Objects;
    using Shared.Serialization;

    [Serialized]
    public class MeterComponent : WorldObjectComponent
    {
        // how much energy we desire
        [SyncToView]
        public int PipsCount { get; private set; }

        [SyncToView]
        public int Percentage { get; set; }

        public MeterComponent() { }
        public MeterComponent(int pipsCount)
        {
            this.Initialize(pipsCount);
        }

        public void Initialize(int pipsCount) => this.PipsCount = pipsCount;
    }
}
