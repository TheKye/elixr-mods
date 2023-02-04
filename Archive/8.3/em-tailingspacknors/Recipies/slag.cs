namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Gameplay.Items.SearchAndSelect;

    [Serialized, Weight(30), StartsDiscovered]
    [MaxStackSize(10)]
    [RequiresTool(typeof(ShovelItem))]
    public partial class SlagsItem : BlockItem<TailingsBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Slag"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Slag"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Leftover Waste From Smelting Tailings."); } }
        public override bool CanStickToWalls { get { return false; } }
    }
}
