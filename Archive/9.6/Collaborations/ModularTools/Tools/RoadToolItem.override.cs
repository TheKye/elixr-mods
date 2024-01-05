// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Localization;
    using Eco.World;
    using Eco.World.Blocks;

    [Category("Hidden"), Tag("Tamper")]
    public abstract partial class RoadToolItem : ToolItem
    {
        public override LocString LeftActionDescription => Localizer.DoStr("Build road");
        public override GameActionDescription DescribeBlockAction => GameActionDescription.DoStr("make a road", "making a road");

        public override bool ShouldHighlight(Type block) =>  Block.Is<CanBeRoad>(block) && !Block.Is<Road>(block);

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (Durability == 0) return InteractResult.FailureLoc($"Your Tool is Broken, You Need to Repair It First");

            if (context.HasBlock && this.ShouldHighlight(context.Block!.GetType()))
                return (InteractResult)AtomicActions.ChangeBlockNow(this.CreateMultiblockContext(context, true, () => new TampRoad()), typeof(DirtRoadBlock));            

            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            return base.OnActLeft(context);
        }
    }
}
