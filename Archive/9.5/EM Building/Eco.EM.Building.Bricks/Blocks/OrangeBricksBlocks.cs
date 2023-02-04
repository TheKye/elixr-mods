using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Core.Items;
using Eco.EM.Framework.Extentsions;

namespace Eco.EM.Building.Bricks
{
    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class OrangeBrickBlock :
        NBlock
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickBlock);
    }

    [Serialized]
    [LocDisplayName("Orange Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class OrangeBrickItem :
    BlockItem<OrangeBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Orange Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Orange!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(OrangeBrickStacked1Block),
        typeof(OrangeBrickStacked2Block),
        typeof(OrangeBrickStacked3Block),
            typeof(OrangeBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class OrangeBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class OrangeBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 OrangeBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickFloorBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickFloorBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickWallBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickWallBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickCubeBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickRoofBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickColumnBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickAqueductBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickAqueductBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofPeakSetBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickRoofPeakSetBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickRoofCubeBlock);
    }

    [RotatedVariants(typeof(OrangeBrickStairsBlock), typeof(OrangeBrickStairs90Block), typeof(OrangeBrickStairs180Block), typeof(OrangeBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickStairsBlock : NBlock
    { public override Type BaseType => typeof(BrickStairsBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickStairs90Block : NBlock
    { public override Type BaseType => typeof(BrickStairs90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickStairs180Block : NBlock
    { public override Type BaseType => typeof(BrickStairs180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickStairs270Block : NBlock
    { public override Type BaseType => typeof(BrickStairs270Block); }

    [RotatedVariants(typeof(OrangeBrickRoofSideBlock), typeof(OrangeBrickRoofSide90Block), typeof(OrangeBrickRoofSide180Block), typeof(OrangeBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofSideBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofSideBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofSide90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofSide180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofSide270Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide270Block); }
    [RotatedVariants(typeof(OrangeBrickRoofTurnBlock), typeof(OrangeBrickRoofTurn90Block), typeof(OrangeBrickRoofTurn180Block), typeof(OrangeBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofTurnBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofTurnBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofTurn90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofTurn180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofTurn270Block);
    }
    [RotatedVariants(typeof(OrangeBrickRoofCornerBlock), typeof(OrangeBrickRoofCorner90Block), typeof(OrangeBrickRoofCorner180Block), typeof(OrangeBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner270Block);
    }
    [RotatedVariants(typeof(OrangeBrickRoofPeakBlock), typeof(OrangeBrickRoofPeak90Block), typeof(OrangeBrickRoofPeak180Block), typeof(OrangeBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak270Block);
    }
    [RotatedVariants(typeof(OrangeBrickBasicSlopeSideBlock), typeof(OrangeBrickBasicSlopeSide90Block), typeof(OrangeBrickBasicSlopeSide180Block), typeof(OrangeBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide270Block);
    }
    [RotatedVariants(typeof(OrangeBrickBasicSlopePointBlock), typeof(OrangeBrickBasicSlopePoint90Block), typeof(OrangeBrickBasicSlopePoint180Block), typeof(OrangeBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint270Block);
    }
    [RotatedVariants(typeof(OrangeBrickUnderSlopeSideBlock), typeof(OrangeBrickUnderSlopeSide90Block), typeof(OrangeBrickUnderSlopeSide180Block), typeof(OrangeBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide270Block);
    }
    [RotatedVariants(typeof(OrangeBrickUnderSlopePeakBlock), typeof(OrangeBrickUnderSlopePeak90Block), typeof(OrangeBrickUnderSlopePeak180Block), typeof(OrangeBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak270Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinFloorBottomFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickThinFloorBottomBlock :
    NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickThinFloorBottomBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinFloorTopFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickThinFloorTopBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
        public override Type BaseType => typeof(BrickThinFloorTopBlock);
    }

    [RotatedVariants(typeof(OrangeBrickBraceBlock), typeof(OrangeBrickBrace90Block), typeof(OrangeBrickBrace180Block), typeof(OrangeBrickBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BraceFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickBraceBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace270Block);
    }
    [RotatedVariants(typeof(OrangeBrickBraceCornerBlock), typeof(OrangeBrickBraceCorner90Block), typeof(OrangeBrickBraceCorner180Block), typeof(OrangeBrickBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BraceCornerFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickBraceCornerBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceCornerBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner270Block);
    }
    [RotatedVariants(typeof(OrangeBrickBraceTurnBlock), typeof(OrangeBrickBraceTurn90Block), typeof(OrangeBrickBraceTurn180Block), typeof(OrangeBrickBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BraceTurnFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn270Block);
    }
    [RotatedVariants(typeof(OrangeBrickSideBraceBlock), typeof(OrangeBrickSideBrace90Block), typeof(OrangeBrickSideBrace180Block), typeof(OrangeBrickSideBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SideBraceFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickSideBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSideBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickSideBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickSideBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickSideBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace270Block);
    }
    [RotatedVariants(typeof(OrangeBrickSmallCornerBraceBlock), typeof(OrangeBrickSmallCornerBrace90Block), typeof(OrangeBrickSmallCornerBrace180Block), typeof(OrangeBrickSmallCornerBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SmallCornerBraceFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickSmallCornerBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickSmallCornerBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickSmallCornerBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickSmallCornerBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace270Block);
    }
    [RotatedVariants(typeof(OrangeBrickThinWallEdgeBlock), typeof(OrangeBrickThinWallEdge90Block), typeof(OrangeBrickThinWallEdge180Block), typeof(OrangeBrickThinWallEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinWallEdgeFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickThinWallEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickThinWallEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickThinWallEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickThinWallEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge270Block);
    }
    [RotatedVariants(typeof(OrangeBrickUnderBraceBlock), typeof(OrangeBrickUnderBrace90Block), typeof(OrangeBrickUnderBrace180Block), typeof(OrangeBrickUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderBraceFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickUnderBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace270Block);
    }
    [RotatedVariants(typeof(OrangeBrickUnderBraceCornerBlock), typeof(OrangeBrickUnderBraceCorner90Block), typeof(OrangeBrickUnderBraceCorner180Block), typeof(OrangeBrickUnderBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderBraceCornerFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickUnderBraceCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner270Block);
    }
    [RotatedVariants(typeof(OrangeBrickUnderBraceTurnBlock), typeof(OrangeBrickUnderBraceTurn90Block), typeof(OrangeBrickUnderBraceTurn180Block), typeof(OrangeBrickUnderBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderBraceTurnFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickUnderBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn270Block);
    }
    [RotatedVariants(typeof(OrangeBrickWindowBlock), typeof(OrangeBrickWindow90Block), typeof(OrangeBrickWindow180Block), typeof(OrangeBrickWindow270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickWindowBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindow90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindow180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindow270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow270Block);
    }
    [RotatedVariants(typeof(OrangeBrickWindowEdgeBlock), typeof(OrangeBrickWindowEdge90Block), typeof(OrangeBrickWindowEdge180Block), typeof(OrangeBrickWindowEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowEdgeFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickWindowEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindowEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindowEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindowEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge270Block);
    }
    [RotatedVariants(typeof(OrangeBrickWindowGrillesBlock), typeof(OrangeBrickWindowGrilles90Block), typeof(OrangeBrickWindowGrilles180Block), typeof(OrangeBrickWindowGrilles270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowGrillesFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickWindowGrillesBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindowGrilles90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindowGrilles180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindowGrilles270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles270Block);
    }
    [RotatedVariants(typeof(OrangeBrickWindowGrillesEdgeBlock), typeof(OrangeBrickWindowGrillesEdge90Block), typeof(OrangeBrickWindowGrillesEdge180Block), typeof(OrangeBrickWindowGrillesEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowGrillesEdgeFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickWindowGrillesEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindowGrillesEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindowGrillesEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickWindowGrillesEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge270Block);
    }
}
