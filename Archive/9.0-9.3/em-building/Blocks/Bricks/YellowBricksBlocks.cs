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
    public partial class YellowBrickBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }

    [Serialized]
    [LocDisplayName("Yellow Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class YellowBrickItem :
    BlockItem<YellowBrickBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Yellow Bricks"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Yellow!"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
        typeof(YellowBrickStacked1Block),
        typeof(YellowBrickStacked2Block),
        typeof(YellowBrickStacked3Block),
            typeof(YellowBrickStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class YellowBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class YellowBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class YellowBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class YellowBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 YellowBrick


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(YellowBrickItem); } }
    }



    [RotatedVariants(typeof(YellowBrickLadderBlock), typeof(YellowBrickLadder90Block), typeof(YellowBrickLadder180Block), typeof(YellowBrickLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickLadder270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickStairsBlock), typeof(YellowBrickStairs90Block), typeof(YellowBrickStairs180Block), typeof(YellowBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickStairs270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickUnderStairsBlock), typeof(YellowBrickUnderStairs90Block), typeof(YellowBrickUnderStairs180Block), typeof(YellowBrickUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickBasicSlopeSideBlock), typeof(YellowBrickBasicSlopeSide90Block), typeof(YellowBrickBasicSlopeSide180Block), typeof(YellowBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickBasicSlopeCornerBlock), typeof(YellowBrickBasicSlopeCorner90Block), typeof(YellowBrickBasicSlopeCorner180Block), typeof(YellowBrickBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickBasicSlopeTurnBlock), typeof(YellowBrickBasicSlopeTurn90Block), typeof(YellowBrickBasicSlopeTurn180Block), typeof(YellowBrickBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickBasicSlopePointBlock), typeof(YellowBrickBasicSlopePoint90Block), typeof(YellowBrickBasicSlopePoint180Block), typeof(YellowBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickStairsCornerBlock), typeof(YellowBrickStairsCorner90Block), typeof(YellowBrickStairsCorner180Block), typeof(YellowBrickStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickStairsTurnBlock), typeof(YellowBrickStairsTurn90Block), typeof(YellowBrickStairsTurn180Block), typeof(YellowBrickStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickUnderSlopeSideBlock), typeof(YellowBrickUnderSlopeSide90Block), typeof(YellowBrickUnderSlopeSide180Block), typeof(YellowBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickUnderSlopeCornerBlock), typeof(YellowBrickUnderSlopeCorner90Block), typeof(YellowBrickUnderSlopeCorner180Block), typeof(YellowBrickUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickUnderSlopeTurnBlock), typeof(YellowBrickUnderSlopeTurn90Block), typeof(YellowBrickUnderSlopeTurn180Block), typeof(YellowBrickUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickUnderSlopePeakBlock), typeof(YellowBrickUnderSlopePeak90Block), typeof(YellowBrickUnderSlopePeak180Block), typeof(YellowBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickRoofSideBlock), typeof(YellowBrickRoofSide90Block), typeof(YellowBrickRoofSide180Block), typeof(YellowBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickRoofTurnBlock), typeof(YellowBrickRoofTurn90Block), typeof(YellowBrickRoofTurn180Block), typeof(YellowBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickRoofCornerBlock), typeof(YellowBrickRoofCorner90Block), typeof(YellowBrickRoofCorner180Block), typeof(YellowBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickRoofPeakBlock), typeof(YellowBrickRoofPeak90Block), typeof(YellowBrickRoofPeak180Block), typeof(YellowBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickUnderInnerPeakBlock), typeof(YellowBrickUnderInnerPeak90Block), typeof(YellowBrickUnderInnerPeak180Block), typeof(YellowBrickUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickHalfSlopeABlock), typeof(YellowBrickHalfSlopeA90Block), typeof(YellowBrickHalfSlopeA180Block), typeof(YellowBrickHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(YellowBrickHalfSlopeBBlock), typeof(YellowBrickHalfSlopeB90Block), typeof(YellowBrickHalfSlopeB180Block), typeof(YellowBrickHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowBrickHalfSlopeB270Block : Block
    { }

}
