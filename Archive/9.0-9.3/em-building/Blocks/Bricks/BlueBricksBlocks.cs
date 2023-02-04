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
    public partial class BlueBrickBlock :
       Block
       , IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }

    [Serialized]
    [LocDisplayName("Blue Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class BlueBrickItem :
    BlockItem<BlueBrickBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Blue Bricks"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Blue!"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
        typeof(BlueBrickStacked1Block),
        typeof(BlueBrickStacked2Block),
        typeof(BlueBrickStacked3Block),
            typeof(BlueBrickStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class BlueBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlueBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlueBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlueBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 BlueBrick


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueBrickItem); } }
    }



    [RotatedVariants(typeof(BlueBrickLadderBlock), typeof(BlueBrickLadder90Block), typeof(BlueBrickLadder180Block), typeof(BlueBrickLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickLadder270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickStairsBlock), typeof(BlueBrickStairs90Block), typeof(BlueBrickStairs180Block), typeof(BlueBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickStairs270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickUnderStairsBlock), typeof(BlueBrickUnderStairs90Block), typeof(BlueBrickUnderStairs180Block), typeof(BlueBrickUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickBasicSlopeSideBlock), typeof(BlueBrickBasicSlopeSide90Block), typeof(BlueBrickBasicSlopeSide180Block), typeof(BlueBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickBasicSlopeCornerBlock), typeof(BlueBrickBasicSlopeCorner90Block), typeof(BlueBrickBasicSlopeCorner180Block), typeof(BlueBrickBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickBasicSlopeTurnBlock), typeof(BlueBrickBasicSlopeTurn90Block), typeof(BlueBrickBasicSlopeTurn180Block), typeof(BlueBrickBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickBasicSlopePointBlock), typeof(BlueBrickBasicSlopePoint90Block), typeof(BlueBrickBasicSlopePoint180Block), typeof(BlueBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickStairsCornerBlock), typeof(BlueBrickStairsCorner90Block), typeof(BlueBrickStairsCorner180Block), typeof(BlueBrickStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickStairsTurnBlock), typeof(BlueBrickStairsTurn90Block), typeof(BlueBrickStairsTurn180Block), typeof(BlueBrickStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickUnderSlopeSideBlock), typeof(BlueBrickUnderSlopeSide90Block), typeof(BlueBrickUnderSlopeSide180Block), typeof(BlueBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickUnderSlopeCornerBlock), typeof(BlueBrickUnderSlopeCorner90Block), typeof(BlueBrickUnderSlopeCorner180Block), typeof(BlueBrickUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickUnderSlopeTurnBlock), typeof(BlueBrickUnderSlopeTurn90Block), typeof(BlueBrickUnderSlopeTurn180Block), typeof(BlueBrickUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickUnderSlopePeakBlock), typeof(BlueBrickUnderSlopePeak90Block), typeof(BlueBrickUnderSlopePeak180Block), typeof(BlueBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickRoofSideBlock), typeof(BlueBrickRoofSide90Block), typeof(BlueBrickRoofSide180Block), typeof(BlueBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickRoofTurnBlock), typeof(BlueBrickRoofTurn90Block), typeof(BlueBrickRoofTurn180Block), typeof(BlueBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickRoofCornerBlock), typeof(BlueBrickRoofCorner90Block), typeof(BlueBrickRoofCorner180Block), typeof(BlueBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickRoofPeakBlock), typeof(BlueBrickRoofPeak90Block), typeof(BlueBrickRoofPeak180Block), typeof(BlueBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickUnderInnerPeakBlock), typeof(BlueBrickUnderInnerPeak90Block), typeof(BlueBrickUnderInnerPeak180Block), typeof(BlueBrickUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickHalfSlopeABlock), typeof(BlueBrickHalfSlopeA90Block), typeof(BlueBrickHalfSlopeA180Block), typeof(BlueBrickHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(BlueBrickHalfSlopeBBlock), typeof(BlueBrickHalfSlopeB90Block), typeof(BlueBrickHalfSlopeB180Block), typeof(BlueBrickHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueBrickHalfSlopeB270Block : Block
    { }

}
