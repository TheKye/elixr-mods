using Eco.EM.Framework.Extentsions;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.UI;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Artistry
{
    [Serialized]
    [Category("Hidden")]
    public abstract class SprayGunToolItem : ToolItem
    {
        private static readonly IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(SprayGunToolItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(8, typeof(SelfImprovementSkill), typeof(SprayGunToolItem)));

        public override IDynamicValue CaloriesBurn => caloriesBurn;
        public override float DurabilityRate => DurabilityMax / 2500f;
        public override Item RepairItem => Item.Get<FurPeltItem>();
        public override int FullRepairAmount => 1;
        public override LocString LeftActionDescription => Localizer.DoStr("Paint");
        public virtual string Color { get; set; }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (this.Durability == 0)
                return InteractResult.Failure(Localizer.DoStr("The Paint Brush is broken and needs repairs, it can not be used until it has been repaired"));

            #region predefined
            var targetBlock = context.Target;
#nullable enable
            Type? BaseType = null;
#nullable disable
            Type newBlock = null;

            Item newBlockItem;
            Item woItem;
            Item requiredPaint;
            Item paint = null;

            string blockName;
            #endregion
            var inventory = context.Player.User.Inventory;

            // If they aren't looking at anything, don't do anything
            if (targetBlock == null)
                return base.OnActLeft(context);

            // Check for color or solvent, everything else will need to use a Color
            switch (string.IsNullOrWhiteSpace(Color))
            {
                case true:
                    requiredPaint = ItemUtil.TryGet($"SolventPaintBucketItem");
                    try
                    {
                        foreach (var i in inventory.AllInventories.SelectMany(i => i.Stacks.Where(itm => itm.Item.DisplayName.ToLower() == requiredPaint.DisplayName.ToLower())))
                        {
                            paint = i.Item;
                            break;
                        }
                    }
                    catch { paint = null; }
                    break;
                case false:
                    requiredPaint = ItemUtil.TryGet($"{Color}PaintBucketItem");
                    try
                    {
                        foreach (var i in inventory.AllInventories.SelectMany(i => i.Stacks.Where(itm => itm.Item.DisplayName.ToLower() == requiredPaint.DisplayName.ToLower())))
                        {
                            paint = i.Item;
                            break;
                        }
                    }
                    catch { paint = null; }
                    break;
            }
            if (paint == null)
                return InteractResult.Failure(Localizer.DoStr(string.Format("You Require {0} in your toolbar to be able to paint this block..", string.IsNullOrWhiteSpace(Color) ? "Solvent" : Color + " Paint")));

            // Safe Guard incase of vanilla blocks
            try
            {
                BaseType = (targetBlock as NBlock).BaseType;
            }
            catch (Exception) { }

            // Make the switch based on null
            switch (BaseType)
            {
                case null:
                    // safe check for other blocks that would cause errors, like Dirt
                    try
                    {
                        blockName = Color + targetBlock.GetType().Name;
                        woItem = ItemUtil.TryGet(blockName);
                    }
                    catch (Exception)
                    {
                        return InteractResult.NoOp;
                    }
                    break;
                case not null:
                    blockName = Color + BaseType.Name;
                    woItem = BlockItem.CreatingItem(BaseType);
                    //check against trying to paint the same block
                    if (targetBlock.GetType().Name == blockName)
                        return base.OnActLeft(context);
                    break;
            }

            // Try and get our item, Safeguard incase of null
            try
            {
                newBlockItem = Get(Color + woItem.Name);
                newBlock = BlockUtils.GetBlockType(blockName);
            }
            catch (Exception)
            {
                return InteractResult.Failure(Localizer.DoStr("Unable to Paint This Block"));
            }
            if (newBlockItem == null || newBlock == null)
            {
                return InteractResult.Failure(Localizer.DoStr("Unable to Paint This Block"));
            }

            //After everything is good, Finish the action
            var blockPosition = context.BlockPosition.Value;
            World.World.DeleteBlock(blockPosition);
            PlaceBlockFill(context, context.TargetPosition, newBlockItem, newBlock);

            this.BurnCaloriesNow(context.Player);
            this.UseDurability(DurabilityRate, context.Player);

            var paintBucket = paint as RepairableItem;
            // Remove durability from the paint bucket
            paintBucket.Durability -= 1;
            if (paintBucket.Durability == 0)
            {
                inventory.RemoveItem(paint.GetType());
                inventory.AddItem(typeof(EmptyPaintBucketItem));
            }
            return InteractResult.Success;
        }

        public InteractResult PlaceBlockFill(InteractionContext context, Vector3i blockPosition, Item blockitem, Type form)
        {

            // TODO SJS: Verify all the blocks are created from the same type

            // Create game action pack, fill it and try to perform.
            using GameActionPack pack = new();
            // Fill the pack.
            pack.PlaceBlock(
                context: this.CreateMultiblockContext(context.Player, true, blockPosition.SingleItemAsEnumerable()),
                blockType: form,
                createBlockAction: true
                );

            // Try to perform created actions.
            return (InteractResult)pack.TryPerform(false);
        }

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            string message = "";
            player.PopupTypePicker(Localizer.DoStr("Pick A Color!"), typeof(PaintBrushToolItem), material => SetMaterial(material, player, this));

            return message;
        }

        private void SetMaterial(List<Type> result, Player player, Item heldPaintbrush)
        {
            var tool = Get(result[0]) as RepairableItem;

            player.User.Inventory.ToolbarBackpack.AddItem(tool);
            tool.Durability = this.Durability;
            player.User.Inventory.ToolbarBackpack.TryRemoveItem(heldPaintbrush.GetType());

            player.MsgLocStr($"{Get(result[0]).DisplayName} Selected");
        }
    }
}
