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
    public partial class PurpleBrickBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }

    [Serialized]
    [LocDisplayName("Purple Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class PurpleBrickItem :
    BlockItem<PurpleBrickBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Purple Bricks"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Purple!"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
        typeof(PurpleBrickStacked1Block),
        typeof(PurpleBrickStacked2Block),
        typeof(PurpleBrickStacked3Block),
            typeof(PurpleBrickStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class PurpleBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class PurpleBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 PurpleBrick


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleBrickItem); } }
    }



    [RotatedVariants(typeof(PurpleBrickLadderBlock), typeof(PurpleBrickLadder90Block), typeof(PurpleBrickLadder180Block), typeof(PurpleBrickLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickLadder270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickStairsBlock), typeof(PurpleBrickStairs90Block), typeof(PurpleBrickStairs180Block), typeof(PurpleBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickStairs270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickUnderStairsBlock), typeof(PurpleBrickUnderStairs90Block), typeof(PurpleBrickUnderStairs180Block), typeof(PurpleBrickUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickBasicSlopeSideBlock), typeof(PurpleBrickBasicSlopeSide90Block), typeof(PurpleBrickBasicSlopeSide180Block), typeof(PurpleBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickBasicSlopeCornerBlock), typeof(PurpleBrickBasicSlopeCorner90Block), typeof(PurpleBrickBasicSlopeCorner180Block), typeof(PurpleBrickBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickBasicSlopeTurnBlock), typeof(PurpleBrickBasicSlopeTurn90Block), typeof(PurpleBrickBasicSlopeTurn180Block), typeof(PurpleBrickBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickBasicSlopePointBlock), typeof(PurpleBrickBasicSlopePoint90Block), typeof(PurpleBrickBasicSlopePoint180Block), typeof(PurpleBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickStairsCornerBlock), typeof(PurpleBrickStairsCorner90Block), typeof(PurpleBrickStairsCorner180Block), typeof(PurpleBrickStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickStairsTurnBlock), typeof(PurpleBrickStairsTurn90Block), typeof(PurpleBrickStairsTurn180Block), typeof(PurpleBrickStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickUnderSlopeSideBlock), typeof(PurpleBrickUnderSlopeSide90Block), typeof(PurpleBrickUnderSlopeSide180Block), typeof(PurpleBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickUnderSlopeCornerBlock), typeof(PurpleBrickUnderSlopeCorner90Block), typeof(PurpleBrickUnderSlopeCorner180Block), typeof(PurpleBrickUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickUnderSlopeTurnBlock), typeof(PurpleBrickUnderSlopeTurn90Block), typeof(PurpleBrickUnderSlopeTurn180Block), typeof(PurpleBrickUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickUnderSlopePeakBlock), typeof(PurpleBrickUnderSlopePeak90Block), typeof(PurpleBrickUnderSlopePeak180Block), typeof(PurpleBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickRoofSideBlock), typeof(PurpleBrickRoofSide90Block), typeof(PurpleBrickRoofSide180Block), typeof(PurpleBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickRoofTurnBlock), typeof(PurpleBrickRoofTurn90Block), typeof(PurpleBrickRoofTurn180Block), typeof(PurpleBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickRoofCornerBlock), typeof(PurpleBrickRoofCorner90Block), typeof(PurpleBrickRoofCorner180Block), typeof(PurpleBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickRoofPeakBlock), typeof(PurpleBrickRoofPeak90Block), typeof(PurpleBrickRoofPeak180Block), typeof(PurpleBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickUnderInnerPeakBlock), typeof(PurpleBrickUnderInnerPeak90Block), typeof(PurpleBrickUnderInnerPeak180Block), typeof(PurpleBrickUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickHalfSlopeABlock), typeof(PurpleBrickHalfSlopeA90Block), typeof(PurpleBrickHalfSlopeA180Block), typeof(PurpleBrickHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(PurpleBrickHalfSlopeBBlock), typeof(PurpleBrickHalfSlopeB90Block), typeof(PurpleBrickHalfSlopeB180Block), typeof(PurpleBrickHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleBrickHalfSlopeB270Block : Block
    { }

}
