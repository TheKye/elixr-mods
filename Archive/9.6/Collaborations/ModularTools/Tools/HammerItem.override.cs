// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Blocks;

[Serialized]
[LocDisplayName("Hammer")]
[Category("Hidden")]
[CanMakeBlockForm, Tag("Construction")]
public class HammerItem : ToolItem
{
    static IDynamicValue tier = new ConstantValue(0);
    static IDynamicValue caloriesBurn = new ConstantValue(1);
    private static IDynamicValue skilledRepairCost = new ConstantValue(1);

    public override ToolCategory ToolCategory { get { return ToolCategory.Hammer; } }

    public override LocString DisplayDescription { get { return Localizer.DoStr("Used to construct buildings and pickup manmade objects."); } }

    public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.PickupBlock; } }
    public override LocString LeftActionDescription { get { return Localizer.DoStr("Pick Up"); } }

    public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }
    [SyncToView] public override IDynamicValue Tier => base.Tier; // tool tier, overriden to have SyncToView only for hammer
    public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

    public override bool IsValidFor(Item item)
    {
        var blockItem = item as BlockItem;
        return !(item is LogItem) && blockItem != null && Block.Is<Constructed>(blockItem.OriginType);
    }

    public override InteractResult OnActRight(InteractionContext context)
    {
        // if we are trying to place the block in the air or on inside of another solid block then dont allow that.
        if (!context.HasBlock || context.Block.Is<Solid>())
            return InteractResult.NoOp;

        Contract.Assume(context.BlockPosition != null);
        var blockPosition = context.BlockPosition.Value;
        return this.PlaceBlockFill(context, blockPosition);
    }

    public override InteractResult OnActLeft(InteractionContext context)
    {
        if (Durability == 0) return InteractResult.FailureLoc($"Your Tool is Broken, You Need to Repair It First");
        
        if (context.HasBlock)
        {
            var block = context.Block;

            //If the block is a ramp don't create a new ConstructOrDeconstruct GameAction, because that GameAction will be created inside RampItem.RampPickupOverride (special case because the item have multiple blocks) and we don't want a duplicate.
            //TO DO : After refactoring ramps, this specific check will need to be removed so that when removing ramps using a hammer item, it will just use the same logic as other blocks.
            if (block.Is<Ramp>()) return (InteractResult)AtomicActions.DeleteBlockNow(context: this.CreateMultiblockContext(context, true), addTo: context.Player?.User.Inventory);
            else if (block.Is<Constructed>())
                return (InteractResult)AtomicActions.DeleteBlockNow(context: this.CreateMultiblockContext(context, true, () => new ConstructOrDeconstruct() { ConstructedOrDeconstructed = ConstructedOrDeconstructed.Deconstructed }),
                                                                     addTo: context.Player?.User.Inventory);
            else if (block is WorldObjectBlock worldBlock)
                return this.TryPickUp(worldBlock.WorldObjectHandle.Object, context);
            else if (block is PickupableBlock pickupableBlock)
                return pickupableBlock.OnActInteract(context);//using hammer left click on clickable 
            else
                return InteractResult.NoOp;
        }
        else if (context.Target is WorldObject worldObject)
            return this.TryPickUp(worldObject, context);

        return base.OnActLeft(context);
    }

    public override bool ShouldHighlight(Type block)
    {
        return Block.Is<Constructed>(block) || block.IsSubclassOf(typeof(PickupableBlock)) || Block.Is<Empty>(block);
    }

    //Law todo
    private InteractResult TryPickUp(WorldObject obj, InteractionContext context)
    {
        var basicResult = this.BasicToolOnWorldObjectCheck(context);
        if (context.Modifier == InteractionModifier.Ctrl ? basicResult.IsFailure : !basicResult.IsNoOp) return basicResult;

        var player = context.Player;
        if (player == null)
            return InteractResult.NoOp;

        return AsyncInteractResult.MakeResultFromTask(this.PickupDialog(obj, player));
    }

    private async Task<InteractResult> PickupDialog(WorldObject obj, Player player)
    {
        try
        {
            if (await obj.CheckForPickUpAsync(player)) return (InteractResult)obj.TryPickUpNow(player, null, this.NeededCalories(player));
            return InteractResult.NoOp;
        }
        catch (Exception e)
        {
            Log.WriteException(e);
            return InteractResult.Fail;
        }
    }

    public override LocString GetNoSuitablePickupTargetFailureMessage(Inventory inventory)
    {
        if (!inventory.IsEmpty) return Localizer.DoStr("Object storage must be empty to pick up.");
        return base.GetNoSuitablePickupTargetFailureMessage(inventory);
    }

    InteractResult PlaceBlockFill(InteractionContext context, Vector3i blockPosition)
    {
        int rotation = 0;
        BlockLayout layout = null;
        if (context.Parameters != null)
        {
            if (context.Parameters.TryGetValue("formRotation", out var val))
                rotation = val.Int32Value;

            if (context.Parameters.TryGetValue("blocks", out val))
                layout = BsonManipulator.FromBson<BlockLayout>(val);
        }

        if (context.CarriedItem is not BlockItem creatingItem)
            return InteractResult.NoOp;

        var form = context.Player?.User.Inventory.Carried.SelectedForm?.FormType.Name;
        var blockType = BlockFormManager.GetBlockTypeToCreate(context.Player, context.SelectedItem, creatingItem, form, rotation);

        // Let's give up! (Let the carried type handle it)
        if (form == null || blockType == null || layout == null)
            return InteractResult.NoOp;

        // Create game action pack, fill it and try to perform.
        using (var pack = new GameActionPack())
        {
            // Fill the pack.
            pack.PlaceBlock(
                context: this.CreateMultiblockContext(context.Player, true, layout.Blocks.Select(x => x.Key + blockPosition),
                                        layout.Blocks.Select(x => BlockManager.FromId(x.Value))),
                blockType: blockType,
                createBlockAction: true,
                removeFromInv: context.Player?.User.Inventory,
                itemToRemove: creatingItem.GetType());

            // Try to perform created actions.
            return (InteractResult)pack.TryPerform(false);
        }
    }
}
