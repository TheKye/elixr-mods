using System;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Warp
{
    [Serialized]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WarpSignObject : WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Warp Sign"); } }
        public virtual Type RepresentedItemType { get { return typeof(WarpSignItem); } }

        protected override void Initialize()
        {
            GetComponent<CustomTextComponent>().Initialize(700);
        }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (!context.Player.User.IsAdmin)
            {
                context.Player.ErrorLocStr("Only an admin may remove this object");
                return InteractResult.Fail;
            }
            return base.OnActLeft(context);
        }

        public override InteractResult OnActInteract(InteractionContext context)
        {
            if (!context.Player.User.IsAdmin)
            {
                context.Player.ErrorLocStr("Only an admin may change the content on this object.");
                return InteractResult.Fail;
            }
            return base.OnActInteract(context);
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            var text = GetComponent<CustomTextComponent>().TextData.Text;

            if (!string.IsNullOrWhiteSpace(text) && text.ToLower().Contains("warp to "))
            {

                var ltrimd = text.Remove(0, text.IndexOf("warp to ") + 8);

                if (string.IsNullOrWhiteSpace(ltrimd))
                    return base.OnActRight(context);

                var rtrimd = text.Remove(text.IndexOf(" "));

                if (string.IsNullOrWhiteSpace(rtrimd))
                    return base.OnActRight(context);
                if (ltrimd.EndsWith(",") || ltrimd.EndsWith("."))
                    ltrimd.Remove(ltrimd.Length - 1);

                WarpCommands.SignWarpto(context.Player.User, ltrimd);
            }
            return base.OnActRight(context);

        }
    }

    [Serialized]
    [LocDisplayName("Warp Sign")]
    [MaxStackSize(100)]
    public partial class WarpSignItem :
    WorldObjectItem<WarpSignObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A large sign For Warp Points!"); } }

        static WarpSignItem()
        {

        }


    }
}


// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Plants;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Simulation;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.GameActions;
    using Eco.Shared.Serialization;
    using Eco.Core.Items;

    [Serialized]
    [LocDisplayName("Shovel")]
    [Weight(0)]
    [Category("Hidden"), Tag("Excavation"), Tag("Harvester")]
    [CanAirInteraction]
    public abstract partial class ShovelItem : ToolItem
    {
        private static SkillModifiedValue caloriesBurn = CreateCalorieValue(20, typeof(SelfImprovementSkill), typeof(ShovelItem));
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        private static IDynamicValue tier = new ConstantValue(0);

        public override GameActionDescription DescribeBlockAction => GameActionDescription.DoStr("dig up", "digging up");
        public override IDynamicValue CaloriesBurn => caloriesBurn;
        public override ClientPredictedBlockAction LeftAction => ClientPredictedBlockAction.PickupBlock;
        public override LocString LeftActionDescription => Localizer.DoStr("Dig");
        public override IDynamicValue Tier => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override int FullRepairAmount => 1;
        public override int MaxTake => 1;
        public override bool ShouldHighlight(Type block) => Block.Is<Diggable>(block);
        public override ToolCategory ToolCategory => ToolCategory.Shovel;

        public override InteractResult OnActLeft(InteractionContext context)
        {
            // Fallback if not enough room in carrying stack
            var carry = context.Player.User.Carrying;
            if (this.MaxTake > 0 && carry.Quantity >= this.MaxTake)
            {
                context.Player.ErrorLoc($"Can't dig while carrying {carry.UILink()}.");
                return base.OnActLeft(context);
            }

            // Try interact with a block.
            if (context.HasBlock && context.Block.Is<Diggable>())
            {
                // Is it a diggable plant? Treat it like a plant then.
                if (context.Block is PlantBlock) return (InteractResult)AtomicActions.DestroyPlantNow(this.CreateMultiblockContext(context), harvestTo: context.Player?.User.Inventory);

                // Delete diggable block and add it to inventory.
                return (InteractResult)AtomicActions.DeleteBlockNow(
                    context: this.CreateMultiblockContext(context),                                     // Get context with area of effect, calories, XP, etc.
                    harvestPlantsAbove: World.GetBlock(context.BlockPosition.Value + Vector3i.Up).Is<Diggable>(),  // Also try harvest plants above if they are diggable.
                    addTo: context.Player?.User.Inventory);                                           // Deleted block (and maybe plants above) will be added to this inventory.
            }

            // Try interact with a world object.
            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            // Fallback.
            return base.OnActLeft(context);
        }

        public override InteractResult OnActInteract(InteractionContext context)
        {
            var carry = context.Player.User.Carrying;
            if (carry.Quantity >= carry.Item.MaxStackSize)
            {
                context.Player.ErrorLoc($"Can't dig while carrying {carry.UILink()}.");
                return base.OnActLeft(context);
            }

            // Try interact with a block.
            if (context.HasBlock && context.Block.Is<Diggable>())
            {
                // Is it a diggable plant? Treat it like a plant then.
                if (context.Block is PlantBlock) return (InteractResult)AtomicActions.DestroyPlantNow(this.CreateMultiblockContext(context), harvestTo: context.Player?.User.Inventory);

                // Delete diggable block and add it to inventory.
                return (InteractResult)AtomicActions.DeleteBlockNow(
                    context: this.CreateMultiblockContext(context),                                     // Get context with area of effect, calories, XP, etc.
                    harvestPlantsAbove: World.GetBlock(context.BlockPosition.Value + Vector3i.Up).Is<Diggable>(),  // Also try harvest plants above if they are diggable.
                    addTo: context.Player?.User.Inventory);                                           // Deleted block (and maybe plants above) will be added to this inventory.
            }

            // Try interact with a world object.
            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            // Fallback.
            return base.OnActInteract(context);
        }
    }
}
