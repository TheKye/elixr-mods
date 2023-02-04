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
    public partial class GreyBrickBlock :
           Block
           , IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }

    [Serialized]
    [LocDisplayName("Grey Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class GreyBrickItem :
    BlockItem<GreyBrickBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Grey Bricks"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar. And It's GREY!"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
        typeof(GreyBrickStacked1Block),
        typeof(GreyBrickStacked2Block),
        typeof(GreyBrickStacked3Block),
            typeof(GreyBrickStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class GreyBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreyBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreyBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreyBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GreyBrick


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreyBrickItem); } }
    }



    [RotatedVariants(typeof(GreyBrickLadderBlock), typeof(GreyBrickLadder90Block), typeof(GreyBrickLadder180Block), typeof(GreyBrickLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickLadder270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickStairsBlock), typeof(GreyBrickStairs90Block), typeof(GreyBrickStairs180Block), typeof(GreyBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickStairs270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickUnderStairsBlock), typeof(GreyBrickUnderStairs90Block), typeof(GreyBrickUnderStairs180Block), typeof(GreyBrickUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickBasicSlopeSideBlock), typeof(GreyBrickBasicSlopeSide90Block), typeof(GreyBrickBasicSlopeSide180Block), typeof(GreyBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickBasicSlopeCornerBlock), typeof(GreyBrickBasicSlopeCorner90Block), typeof(GreyBrickBasicSlopeCorner180Block), typeof(GreyBrickBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickBasicSlopeTurnBlock), typeof(GreyBrickBasicSlopeTurn90Block), typeof(GreyBrickBasicSlopeTurn180Block), typeof(GreyBrickBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickBasicSlopePointBlock), typeof(GreyBrickBasicSlopePoint90Block), typeof(GreyBrickBasicSlopePoint180Block), typeof(GreyBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickStairsCornerBlock), typeof(GreyBrickStairsCorner90Block), typeof(GreyBrickStairsCorner180Block), typeof(GreyBrickStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickStairsTurnBlock), typeof(GreyBrickStairsTurn90Block), typeof(GreyBrickStairsTurn180Block), typeof(GreyBrickStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickUnderSlopeSideBlock), typeof(GreyBrickUnderSlopeSide90Block), typeof(GreyBrickUnderSlopeSide180Block), typeof(GreyBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickUnderSlopeCornerBlock), typeof(GreyBrickUnderSlopeCorner90Block), typeof(GreyBrickUnderSlopeCorner180Block), typeof(GreyBrickUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickUnderSlopeTurnBlock), typeof(GreyBrickUnderSlopeTurn90Block), typeof(GreyBrickUnderSlopeTurn180Block), typeof(GreyBrickUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickUnderSlopePeakBlock), typeof(GreyBrickUnderSlopePeak90Block), typeof(GreyBrickUnderSlopePeak180Block), typeof(GreyBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickRoofSideBlock), typeof(GreyBrickRoofSide90Block), typeof(GreyBrickRoofSide180Block), typeof(GreyBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickRoofTurnBlock), typeof(GreyBrickRoofTurn90Block), typeof(GreyBrickRoofTurn180Block), typeof(GreyBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickRoofCornerBlock), typeof(GreyBrickRoofCorner90Block), typeof(GreyBrickRoofCorner180Block), typeof(GreyBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickRoofPeakBlock), typeof(GreyBrickRoofPeak90Block), typeof(GreyBrickRoofPeak180Block), typeof(GreyBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickUnderInnerPeakBlock), typeof(GreyBrickUnderInnerPeak90Block), typeof(GreyBrickUnderInnerPeak180Block), typeof(GreyBrickUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickHalfSlopeABlock), typeof(GreyBrickHalfSlopeA90Block), typeof(GreyBrickHalfSlopeA180Block), typeof(GreyBrickHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(GreyBrickHalfSlopeBBlock), typeof(GreyBrickHalfSlopeB90Block), typeof(GreyBrickHalfSlopeB180Block), typeof(GreyBrickHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreyBrickHalfSlopeB270Block : Block
    { }

}
