// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
#nullable enable
using System;
using System.ComponentModel;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.World;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Gameplay.GameActions;
using Eco.Shared.Items;
using Eco.Simulation;
using Eco.Gameplay.Objects;
using Eco.Core.Items;

[Serialized]
[LocDisplayName("Hoe")]
[Category("Hidden")]
[Hoer, Tag("Plow")]
public class HoeItem : ToolItem
{
    private static IDynamicValue skilledRepairCost = new ConstantValue(1);
    private static IDynamicValue caloriesBurn      = new ConstantValue(1);
    private static IDynamicValue tier              = new ConstantValue(0);

    public override LocString                  DisplayDescription    => Localizer.DoStr("Used to till soil and prepare it for planting."); 
    public override GameActionDescription      DescribeBlockAction   => GameActionDescription.DoStr("plow a block", "plowing a block");
    public override LocString                  LeftActionDescription => Localizer.DoStr("Hoe ground"); 
    public override ClientPredictedBlockAction LeftAction            => ClientPredictedBlockAction.None;
    public override int                        FullRepairAmount      => 1;
    public override Item                       RepairItem            => Item.Get<StoneItem>(); 
    public override IDynamicValue              SkilledRepairCost     => skilledRepairCost; 
    public override IDynamicValue              CaloriesBurn          => caloriesBurn; 
    public override IDynamicValue              Tier                  => tier; 
    public override Type                       ExperienceSkill       => typeof(FarmingSkill);

    public override bool ShouldHighlight(Type block) => Block.Is<Tillable>(block) && !Block.Is<Road>(block);

    public override InteractResult OnActLeft(InteractionContext context)
    {
        if (Durability == 0) return InteractResult.FailureLoc($"Your Tool is Broken, You Need to Repair It First");

        // Try plow the block (and maybe its surroundings).
        if (context.HasBlock && context.Block!.Is<Tillable>()) return (InteractResult)AtomicActions.ChangeBlockNow(this.CreateMultiblockContext(context, true, () => new PlowField()), typeof(TilledDirtBlock));

        // Try interact with a world object.
        if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

        // Fallback.
        return base.OnActLeft(context);
    }

}
