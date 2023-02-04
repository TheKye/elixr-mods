using Eco.Core.Items;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Plants;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.World;
using Eco.World.Blocks;
using System;
using System.ComponentModel;

namespace Eco.Mods.TechTree
{
    [Category("Hidden"), Tag("Excavation"), Tag("Harvester")]
    [CarryTypesLimited]
    public partial class BigShovelItem : ToolItem
    {
        private static SkillModifiedValue           caloriesBurn                    = CreateCalorieValue(20, typeof(SelfImprovementSkill), typeof(BigShovelItem), new BigShovelItem().UILink());
        private static IDynamicValue                skilledRepairCost               = new ConstantValue(1);
        private static IDynamicValue                tier                            = new ConstantValue(0);

        public override GameActionDescription       DescribeBlockAction             => new GameActionDescription("dig up", "digging up");
        public override IDynamicValue               CaloriesBurn                    => caloriesBurn;
        public override ClientPredictedBlockAction  LeftAction                      => ClientPredictedBlockAction.PickupBlock;
        public override LocString                   LeftActionDescription           => Localizer.DoStr("Dig");
        public override IDynamicValue               Tier                            => tier;
        public override IDynamicValue               SkilledRepairCost               => skilledRepairCost;
        public override int                         FullRepairAmount                => 1;
        public override bool                        ShouldHighlight(Type block)     => Block.Is<Diggable>(block);
        
        //This is the default the big shovel will pickup Don't adjust this value, adjust the value in the Shovel Files instead
        public override int                         MaxTake                         => 10;

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.Player.User.Carrying.Quantity >= this.MaxTake) return base.OnActLeft(context);

            if (context.HasBlock && context.Block.Is<Diggable>())
            {
                if (context.Block is PlantBlock) return (InteractResult)AtomicActions.DestroyPlantNow(this.CreateMultiblockContext(context), harvestTo: context.Player?.User.Inventory);

                return (InteractResult)AtomicActions.DeleteBlockNow(
                    context: this.CreateMultiblockContext(context),
                    harvestPlantsAbove: World.World.GetBlock(context.BlockPosition.Value + Vector3i.Up).Is<Diggable>(),
                    addTo: context.Player?.User.Inventory);
            }

            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            return base.OnActLeft(context);
        }
    }
}