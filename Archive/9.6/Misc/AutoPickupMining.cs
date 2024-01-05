// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Controller;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using Eco.World.Blocks;
    using Eco.Gameplay.Objects;
    using Eco.Core.Items;

    [Category("Hidden"), Tag("Excavation")]
    public partial class PickaxeItem : ToolItem
    {
        /// <summary>
        /// We have a few values here, 
        /// AutoPickupLevel is what mining level is needed to enable auto pickup - Only Works if enableAutoPickupForAll is false!
        /// LuckyBreakLevel is what mining level is needed to enable LuckyBreak - Only Works if enableLuckyBreakForAll is false!
        /// Only edit the values here and not below the don't edit below line, this takes care of the rest for you
        /// New settings where added for ease of use
        /// </summary>

        public bool enableAutoPickupForAll = false;
        public bool enableLuckyBreakForAll = false;

        public int AutoPickupLevel = 7;
        public int LuckyBreakLevel = 5;

        // Don't Edit Below Here
        // -------------------------------------------------------------------------------------------------------------------------

        private readonly static SkillModifiedValue caloriesBurn = CreateCalorieValue(20, typeof(MiningSkill), typeof(PickaxeItem));
        static PickaxeItem() { }

        public override IDynamicValue CaloriesBurn => caloriesBurn;

        public override ClientPredictedBlockAction LeftAction => ClientPredictedBlockAction.Mine;
        public override LocString LeftActionDescription => Localizer.DoStr("Mine");

        public override Item RepairItem => Item.Get<StoneItem>();
        [SyncToView] public virtual float Damage => 1.0f;      // damage per tier level
        [SyncToView] public override IDynamicValue Tier => base.Tier; // tool tier, overriden to have SyncToView only for pickaxe
        public override int FullRepairAmount => 1;

        [Tooltip(200)]
        public TooltipSection MinablesTooltip(TooltipContext context)
        {
            var myHardness = this.Tier.GetCurrentValue(context.Player.User);
            var minableBlockTypes = Block.BlockTypesWithAttribute(typeof(Minable)).Select(x => new KeyValuePair<Type, float>(x, Block.Get<Minable>(x).Hardness)).ToList();

            if (!minableBlockTypes.Any()) return null;

            var allBlocks = AllItems.OfType<BlockItem>();

            var resList = new List<LocString>();
            minableBlockTypes.OrderBy(item => item.Value).ForEach(x =>
            {
                var targetItem = allBlocks.FirstOrDefault(item => item.OriginType == x.Key);
                var hitCount = (int)Math.Ceiling(x.Value / myHardness);
                if (targetItem != null) resList.Add(Localizer.NotLocalized($"{targetItem.UILink()}: {Localizer.Plural("hit", hitCount)}"));
            });

            return new TooltipSection(Localizer.DoStr("Can mine"), resList.FoldoutListLoc("item", context.Origin));
        }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock && context.Block.Is<Minable>())
            {
                var user = context.Player.User;
                var item = context.Block is IRepresentsItem item1 ? Item.Get(item1) : null;

                var totalDamageToTarget = user.BlockHitCache.MemorizeHit(context.Block.GetType(), context.BlockPosition.Value, this.Tier.GetCurrentValue(context.Player.User) * this.Damage);
                if (context.Block.Get<Minable>().Hardness <= totalDamageToTarget)
                {
                    var result = AtomicActions.DeleteBlockNow(this.CreateMultiblockContext(context, false), spawnRubble: false);    // Use the tool, but do not trigger an AddExperience call for destroying blocks.
                    var miningSkill = context.Player.User.Skillset.GetSkill(typeof(MiningSkill));
                    if (result.Success)
                    {
                        bool pickupItems = false;
                        if (miningSkill.Level >= AutoPickupLevel || enableLuckyBreakForAll)
                        {
                            var addItems = context.Player.User.Inventory.Carried.TryAddItems(item.GetType(), 4);
                            pickupItems = addItems.Success;
                            if (pickupItems)
                                return (InteractResult)result;
                        }

                        if (!pickupItems)
                        {
                            var forced = 0;
                            if (enableLuckyBreakForAll)
                                forced = -1;
                            else
                                forced = miningSkill.Level >= LuckyBreakLevel ? 4 : -1;
                            if (RubbleObject.TrySpawnFromBlock(context.Player, context.Block.GetType(), context.BlockPosition.Value, forced))
                            {
                                var addition = item != null ? " " + item.UILink() : string.Empty;
                                this.AddExperience(user, 1f, new LocString(Localizer.Format("mining") + addition));                     // Add experience based on the tool's experience rate (altered in the EcoTechTree.csv).
                                user.UserUI.OnCreateRubble.Invoke(item.DisplayName.NotTranslated);
                                user.BlockHitCache.ForgetHit(context.BlockPosition.Value);
                            }
                        }
                    }

                    return (InteractResult)result;
                }
                else return (InteractResult)AtomicActions.UseToolNow(this.CreateMultiblockContext(context, false));                // Use the tool, but do not trigger an AddExperience call for damaging blocks.
            }
            else if (context.Target is RubbleObject rubble)
            {
                if (rubble.IsBreakable)
                {
                    using var pack = new GameActionPack();
                    pack.UseTool(this.CreateMultiblockContext(context, false));                                                     // Break the rubble, but do not trigger an AddExperience call.
                    pack.AddPostEffect(() => rubble.Breakup(context.Player));
                    return (InteractResult)pack.TryPerform(false);
                }

                return InteractResult.NoOp;
            }

            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            return base.OnActLeft(context);
        }

        public override bool ShouldHighlight(Type block)
        {
            return Block.Is<Minable>(block);
        }

        public override bool CanPickUpItemStack(ItemStack stack)
        {
            return stack.Item.IsCarried && stack.Item is BlockItem blockitem && Block.Get<Minable>(blockitem.OriginType) != null;
        }
    }
}
