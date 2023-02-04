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
    public partial class BigShovelItem : ToolItem
    {
        private static SkillModifiedValue           caloriesBurn                    = CreateCalorieValue(20, typeof(SelfImprovementSkill), typeof(BigShovelItem));
        private static IDynamicValue                skilledRepairCost               = new ConstantValue(1);
        private static IDynamicValue                tier                            = new ConstantValue(0);

        public override GameActionDescription       DescribeBlockAction             => new(Localizer.DoStr("dig up"), Localizer.DoStr("digging up"));
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
            // Doesn't let you use the tool if the tool is broken
            if (Durability == 0) return InteractResult.FailureLoc($"Your Tool is Broken, You Need to Repair It First");

            // Fallback if not enough room in carrying stack
            if (context.Player.User.Carrying.Quantity >= this.MaxTake) return InteractResult.FailureLoc($"There is not enough room to pick this up.");

            // Try interact with a block.
            if (context.HasBlock && context.Block.Is<Diggable>())
            {
                // Is it a diggable plant? Treat it like a plant then.
                if (context.Block is PlantBlock) 
                    return (InteractResult)AtomicActions.DestroyPlantNow(this.CreateMultiblockContext(context), harvestTo: context.Player?.User.Inventory);

                return (InteractResult)AtomicActions.DeleteBlockNow(
                    context: this.CreateMultiblockContext(context),
                    harvestPlantsAbove: World.World.GetBlock(context.BlockPosition.Value + Vector3i.Up).Is<Diggable>(),
                    addTo: context.Player?.User.Inventory);
            }

            // Try interact with a world object.
            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            // Fallback.
            return base.OnActLeft(context);
        }
    }
}