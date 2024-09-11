// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

#nullable enable
namespace Eco.Mods.TechTree
{
    using System.Linq;
    using Eco.Gameplay.Plants;
    using Eco.Shared.Math;
    using Eco.Simulation;
    using System;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.World;
    using Eco.World.Blocks;

    [Tag("Harvester")]
    [Category("Hidden")]
    [Mower]
    public abstract partial class MacheteItem : ToolItem
    {
        static readonly LocString ClearString = Localizer.DoStr("Clear");

        public override ClientPredictedBlockAction LeftAction => ClientPredictedBlockAction.DestroyBlock;
        public override LocString LeftActionDescription => ClearString;

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (Durability == 0) return InteractResult.FailureLoc($"Your Tool is Broken, You Need to Repair It First");

            var interactionResult = InteractResult.NoOp;
            // Destroy highlighted plants
            if (context.HasBlock && context.Block!.Is<Clearable>())
                interactionResult = (InteractResult)AtomicActions.DestroyPlantNow(this.CreateMultiblockContext(context), notify: false);

            if (context.Player != null)
            {
                // Take player's position to cut plants below player and in front of him
                var playerPosition    = context.Player.User.Position.XYZi();
                context.Block         = World.GetBlock(playerPosition);
                context.BlockPosition = playerPosition;
                // Create plant destroying action for area in player's position and it's facing direction (multiblock context will take blocks in facing dir)
                // Take only tall plants, grass could be set at 0 height and will be ignored
                AtomicActions.DestroyPlantNow(this.CreateMultiblockContext(context, highlightCenter: false), notify: false, plantSpeciesChecked: plantSpecies => plantSpecies.Height >= 1);
            }

            if (interactionResult != InteractResult.NoOp) return interactionResult;
            
            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            return base.OnActLeft(context);
        }

        public override bool ShouldHighlight(Type block)
        {
            return Block.Is<Clearable>(block);
        }
    }
}
