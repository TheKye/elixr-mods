﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System.ComponentModel;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Gameplay.GameActions;
    using Eco.Shared.Serialization;
    using Eco.Core.Items;
    using Eco.Gameplay.Interactions.Interactors;
    using Eco.Gameplay.Players;
    using Eco.Shared.SharedTypes;
    using Eco.Shared.Utils;
    using Eco.Shared.Math;
    using World = Eco.World.World;
    using Eco.World;
    using Eco.Gameplay.Placement;
    using Eco.World.Blocks;
    using Eco.Mods.TechTree;
    using Eco.Gameplay.Components.Storage;
    using Eco.Shared.Services;

    [Serialized]
    [LocDisplayName("Shovel")]
    [Weight(0)]
    [Category("Hidden"), Tag("Excavation"), Tag("Harvester")]
    [CanAirInteraction]
    public abstract partial class ShovelItem : ToolItem, IInteractor
    {

        /// <summary>
        /// Enable This option if you wish to have the Stack Size Multiplier affect the max take, 
        /// If you set the stack size multiplier to 2, the max take will automatically be times by 2
        /// the value can only be true or false
        /// </summary>
        public static bool StackMultiplierAffectsMaxTake = false;

        /// <summary>
        /// This is the Max Take for the Shovel, this has been moved to its own variable due to the addition of the <see cref="StackMultiplierAffectsMaxTake"/> Value to have the stack size multiplier adjust the max take as well
        /// Adjust this value to the desired amount. The StackMultiplierAffectsMaxTake will only affect this in code below so you don't need to worry about code below
        /// </summary>
        public static int maxTake = 10;


        private static SkillModifiedValue caloriesBurn = CreateCalorieValue(20, typeof(SelfImprovementSkill), typeof(ShovelItem));
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        private static IDynamicValue tier = new ConstantValue(0);

        
        public override GameActionDescription DescribeBlockAction => GameActionDescription.DoStr("dig up", "digging up");
        public override IDynamicValue CaloriesBurn => caloriesBurn;
        public override IDynamicValue Tier => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override int FullRepairAmount => 1;
        public override int MaxTake => StackMultiplierAffectsMaxTake ? maxTake * (int)DifficultySettings.Obj.Config.DifficultyModifiers.UstackSizeModifier : maxTake;
        public override bool IsValidForInteraction(Item item) => base.IsValidForInteraction(item) && (item?.GetType().HasTag(TagManager.GetTagOrFail("Diggable")) ?? false);
        public override ItemCategory ItemCategory => ItemCategory.Shovel;


        [Interaction(InteractionTrigger.RightClick, canHoldToTrigger: TriBool.True, animationDriven: true, Priority = -1,
            RequiredEnvVars = new[] { ClientSideEnvVars.Carried }, Flags = InteractionFlags.MustNotHaveTarget)]
        public bool Drop(Player player, InteractionTriggerInfo triggerInfo, InteractionTarget target)
            => BlockPlacementUtils.DropCarriedBlock(player);

        [Interaction(InteractionTrigger.LeftClick, tags: BlockTags.Diggable, canHoldToTrigger: TriBool.True, animationDriven: true)]
        public bool Dig(Player player, InteractionTriggerInfo triggerInfo, InteractionTarget target)
        {
            // Fallback if not enough room in carrying stack
            var carry = player.User.Carrying;
            if (MaxTake > 0 && carry.Quantity >= MaxTake)
            {
                player.ErrorLoc($"Can't dig while carrying {player.User.Carrying.UILink()}.");
                return false;
            }

            //Find all plants we can harvest and all blocks we can dig within area of effect of this tool
            var anyPlants = this.TryCreateMultiblockContext(out var plantContext, target, player, tagsTargetable: BlockTags.Diggable, mustNotHaveTags: BlockTags.NonPlant.SingleItemAsEnumerable(), applyXPSkill: true);
            var anyOtherBlocks = this.TryCreateMultiblockContext(out var otherContext, target, player, tagsTargetable: BlockTags.Diggable, mustHaveTags: BlockTags.NonPlant.SingleItemAsEnumerable(), applyXPSkill: false);

            if (anyPlants || anyOtherBlocks)
            {
                using var pack = new GameActionPack();

                //Harvest all targeted plants
                if (anyPlants) pack.DestroyPlant(plantContext, harvestTo: player?.User.Inventory);
                //Destroy all targeted blocks that are not plants and harvest plants above them if those plants can be harvested by this tool
                if (anyOtherBlocks) pack.DeleteBlock(otherContext, player?.User.Inventory);

                return pack.TryPerform(player.User).Success;
            }

            return false;
        }
    }
}
