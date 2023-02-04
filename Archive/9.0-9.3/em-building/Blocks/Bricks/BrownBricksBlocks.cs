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
    public partial class BrownBrickBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }

    [Serialized]
    [LocDisplayName("Brown Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class BrownBrickItem :
    BlockItem<BrownBrickBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Brown Bricks"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Brown!"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
        typeof(BrownBrickStacked1Block),
        typeof(BrownBrickStacked2Block),
        typeof(BrownBrickStacked3Block),
            typeof(BrownBrickStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class BrownBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BrownBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BrownBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BrownBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 BrownBrick


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BrownBrickItem); } }
    }



    [RotatedVariants(typeof(BrownBrickLadderBlock), typeof(BrownBrickLadder90Block), typeof(BrownBrickLadder180Block), typeof(BrownBrickLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickLadder270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickStairsBlock), typeof(BrownBrickStairs90Block), typeof(BrownBrickStairs180Block), typeof(BrownBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickStairs270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickUnderStairsBlock), typeof(BrownBrickUnderStairs90Block), typeof(BrownBrickUnderStairs180Block), typeof(BrownBrickUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickBasicSlopeSideBlock), typeof(BrownBrickBasicSlopeSide90Block), typeof(BrownBrickBasicSlopeSide180Block), typeof(BrownBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickBasicSlopeCornerBlock), typeof(BrownBrickBasicSlopeCorner90Block), typeof(BrownBrickBasicSlopeCorner180Block), typeof(BrownBrickBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickBasicSlopeTurnBlock), typeof(BrownBrickBasicSlopeTurn90Block), typeof(BrownBrickBasicSlopeTurn180Block), typeof(BrownBrickBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickBasicSlopePointBlock), typeof(BrownBrickBasicSlopePoint90Block), typeof(BrownBrickBasicSlopePoint180Block), typeof(BrownBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickStairsCornerBlock), typeof(BrownBrickStairsCorner90Block), typeof(BrownBrickStairsCorner180Block), typeof(BrownBrickStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickStairsTurnBlock), typeof(BrownBrickStairsTurn90Block), typeof(BrownBrickStairsTurn180Block), typeof(BrownBrickStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickUnderSlopeSideBlock), typeof(BrownBrickUnderSlopeSide90Block), typeof(BrownBrickUnderSlopeSide180Block), typeof(BrownBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickUnderSlopeCornerBlock), typeof(BrownBrickUnderSlopeCorner90Block), typeof(BrownBrickUnderSlopeCorner180Block), typeof(BrownBrickUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickUnderSlopeTurnBlock), typeof(BrownBrickUnderSlopeTurn90Block), typeof(BrownBrickUnderSlopeTurn180Block), typeof(BrownBrickUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickUnderSlopePeakBlock), typeof(BrownBrickUnderSlopePeak90Block), typeof(BrownBrickUnderSlopePeak180Block), typeof(BrownBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickRoofSideBlock), typeof(BrownBrickRoofSide90Block), typeof(BrownBrickRoofSide180Block), typeof(BrownBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickRoofTurnBlock), typeof(BrownBrickRoofTurn90Block), typeof(BrownBrickRoofTurn180Block), typeof(BrownBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickRoofCornerBlock), typeof(BrownBrickRoofCorner90Block), typeof(BrownBrickRoofCorner180Block), typeof(BrownBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickRoofPeakBlock), typeof(BrownBrickRoofPeak90Block), typeof(BrownBrickRoofPeak180Block), typeof(BrownBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickUnderInnerPeakBlock), typeof(BrownBrickUnderInnerPeak90Block), typeof(BrownBrickUnderInnerPeak180Block), typeof(BrownBrickUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickHalfSlopeABlock), typeof(BrownBrickHalfSlopeA90Block), typeof(BrownBrickHalfSlopeA180Block), typeof(BrownBrickHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(BrownBrickHalfSlopeBBlock), typeof(BrownBrickHalfSlopeB90Block), typeof(BrownBrickHalfSlopeB180Block), typeof(BrownBrickHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownBrickHalfSlopeB270Block : Block
    { }

}
