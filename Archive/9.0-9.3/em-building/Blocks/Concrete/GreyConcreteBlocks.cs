using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Core.Items;

namespace Eco.EM.Building
{
    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(3)]
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GreyReinforcedConcreteBlock :
           Block
           , IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }

    [Serialized]
    [LocDisplayName("Grey Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class GreyReinforcedConcreteItem :
    BlockItem<GreyReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Grey Reinforced Concrete"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar. And It's GREY!"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
        typeof(GreyReinforcedConcreteStacked1Block),
        typeof(GreyReinforcedConcreteStacked2Block),
        typeof(GreyReinforcedConcreteStacked3Block),
            typeof(GreyReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class GreyReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreyReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreyReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreyReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GreyReinforcedConcrete


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcretePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyReinforcedConcreteItem); } }
    }



    [RotatedVariants(typeof(GreyReinforcedConcreteLadderBlock), typeof(GreyReinforcedConcreteLadder90Block), typeof(GreyReinforcedConcreteLadder180Block), typeof(GreyReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteLadder270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteStairsBlock), typeof(GreyReinforcedConcreteStairs90Block), typeof(GreyReinforcedConcreteStairs180Block), typeof(GreyReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteStairs270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteUnderStairsBlock), typeof(GreyReinforcedConcreteUnderStairs90Block), typeof(GreyReinforcedConcreteUnderStairs180Block), typeof(GreyReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteBasicSlopeSideBlock), typeof(GreyReinforcedConcreteBasicSlopeSide90Block), typeof(GreyReinforcedConcreteBasicSlopeSide180Block), typeof(GreyReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteBasicSlopeCornerBlock), typeof(GreyReinforcedConcreteBasicSlopeCorner90Block), typeof(GreyReinforcedConcreteBasicSlopeCorner180Block), typeof(GreyReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteBasicSlopeTurnBlock), typeof(GreyReinforcedConcreteBasicSlopeTurn90Block), typeof(GreyReinforcedConcreteBasicSlopeTurn180Block), typeof(GreyReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteBasicSlopePointBlock), typeof(GreyReinforcedConcreteBasicSlopePoint90Block), typeof(GreyReinforcedConcreteBasicSlopePoint180Block), typeof(GreyReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteStairsCornerBlock), typeof(GreyReinforcedConcreteStairsCorner90Block), typeof(GreyReinforcedConcreteStairsCorner180Block), typeof(GreyReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteStairsTurnBlock), typeof(GreyReinforcedConcreteStairsTurn90Block), typeof(GreyReinforcedConcreteStairsTurn180Block), typeof(GreyReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteUnderSlopeSideBlock), typeof(GreyReinforcedConcreteUnderSlopeSide90Block), typeof(GreyReinforcedConcreteUnderSlopeSide180Block), typeof(GreyReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteUnderSlopeCornerBlock), typeof(GreyReinforcedConcreteUnderSlopeCorner90Block), typeof(GreyReinforcedConcreteUnderSlopeCorner180Block), typeof(GreyReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteUnderSlopeTurnBlock), typeof(GreyReinforcedConcreteUnderSlopeTurn90Block), typeof(GreyReinforcedConcreteUnderSlopeTurn180Block), typeof(GreyReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteUnderSlopePeakBlock), typeof(GreyReinforcedConcreteUnderSlopePeak90Block), typeof(GreyReinforcedConcreteUnderSlopePeak180Block), typeof(GreyReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteRoofSideBlock), typeof(GreyReinforcedConcreteRoofSide90Block), typeof(GreyReinforcedConcreteRoofSide180Block), typeof(GreyReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteRoofTurnBlock), typeof(GreyReinforcedConcreteRoofTurn90Block), typeof(GreyReinforcedConcreteRoofTurn180Block), typeof(GreyReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteRoofCornerBlock), typeof(GreyReinforcedConcreteRoofCorner90Block), typeof(GreyReinforcedConcreteRoofCorner180Block), typeof(GreyReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteRoofPeakBlock), typeof(GreyReinforcedConcreteRoofPeak90Block), typeof(GreyReinforcedConcreteRoofPeak180Block), typeof(GreyReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteUnderInnerPeakBlock), typeof(GreyReinforcedConcreteUnderInnerPeak90Block), typeof(GreyReinforcedConcreteUnderInnerPeak180Block), typeof(GreyReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteHalfSlopeABlock), typeof(GreyReinforcedConcreteHalfSlopeA90Block), typeof(GreyReinforcedConcreteHalfSlopeA180Block), typeof(GreyReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(GreyReinforcedConcreteHalfSlopeBBlock), typeof(GreyReinforcedConcreteHalfSlopeB90Block), typeof(GreyReinforcedConcreteHalfSlopeB180Block), typeof(GreyReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(GreyReinforcedConcreteItem))]
    public partial class GreyReinforcedConcreteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyReinforcedConcreteHalfSlopeB270Block : Block
    { }

}
