namespace Eco.Mods.TechTree
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.World;

    [Serialized]
    [Weight(30000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(BucketItem))]
    [MakesRoads]
    public class WatersItem : BlockItem<WaterBlock>, ICanExitFromPipe
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Water"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Water"); } }
        public override bool CanStickToWalls { get { return true; } }

        public string FlowTooltip(float flowrate) { return null; }

        public float OnPipeExit(Ray posDir, float amount)
        {
            var existingBlock = World.GetBlock(posDir.FirstPos) as EmptyBlock;
            if (existingBlock != null)
            {
                var target = World.FindPyramidPos(posDir.FirstPos);
                World.SetBlock(this.OriginType, target);
                return 1;
            }
            return 0;
        }

        public static explicit operator WatersItem(Block WaterItem)
        {
            throw new NotImplementedException();
        }

        internal object TryPickUp(Player player)
        {
            throw new NotImplementedException();
        }
    }

    public class WaterItem : Block
    {
        public object WorldObjectHandle { get; internal set; }
        public object Object { get; internal set; }

        internal object TryPickUp(Player player)
        {
            throw new NotImplementedException();
        }
    }
}