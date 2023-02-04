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
    public partial class ColorBrickBlock :
        NBlock
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem);
        public override Type BaseType => typeof(BrickBlock);
    }

    [Serialized]
    [LocDisplayName("Color Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class ColorBrickItem :
    BlockItem<ColorBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Color Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Color!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(ColorBrickStacked1Block),
        typeof(ColorBrickStacked2Block),
        typeof(ColorBrickStacked3Block),
            typeof(ColorBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class ColorBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class ColorBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class ColorBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class ColorBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 ColorBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickFloorBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem);
        public override Type BaseType => typeof(BrickFloorBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickWallBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem);
        public override Type BaseType => typeof(BrickWallBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem);
        public override Type BaseType => typeof(BrickCubeBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickRoofBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem); 
        public override Type BaseType => typeof(BrickRoofBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickColumnBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem); 
        public override Type BaseType => typeof(BrickColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickAqueductBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem); 
        public override Type BaseType => typeof(BrickAqueductBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickRoofPeakSetBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem); 
        public override Type BaseType => typeof(BrickRoofPeakSetBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickRoofCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem);
        public override Type BaseType => typeof(BrickRoofCubeBlock);
    }

    [RotatedVariants(typeof(ColorBrickStairsBlock), typeof(ColorBrickStairs90Block), typeof(ColorBrickStairs180Block), typeof(ColorBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickStairsBlock : NBlock
    { public override Type BaseType => typeof(BrickStairsBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickStairs90Block : NBlock
    { public override Type BaseType => typeof(BrickStairs90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickStairs180Block : NBlock
    { public override Type BaseType => typeof(BrickStairs180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickStairs270Block : NBlock
    { public override Type BaseType => typeof(BrickStairs270Block); }

    [RotatedVariants(typeof(ColorBrickRoofSideBlock), typeof(ColorBrickRoofSide90Block), typeof(ColorBrickRoofSide180Block), typeof(ColorBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickRoofSideBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofSideBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofSide90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofSide180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofSide270Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide270Block); }
    [RotatedVariants(typeof(ColorBrickRoofTurnBlock), typeof(ColorBrickRoofTurn90Block), typeof(ColorBrickRoofTurn180Block), typeof(ColorBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickRoofTurnBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofTurnBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofTurn90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofTurn180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofTurn270Block);
    }
    [RotatedVariants(typeof(ColorBrickRoofCornerBlock), typeof(ColorBrickRoofCorner90Block), typeof(ColorBrickRoofCorner180Block), typeof(ColorBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner270Block);
    }
    [RotatedVariants(typeof(ColorBrickRoofPeakBlock), typeof(ColorBrickRoofPeak90Block), typeof(ColorBrickRoofPeak180Block), typeof(ColorBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak270Block);
    }
    [RotatedVariants(typeof(ColorBrickBasicSlopeSideBlock), typeof(ColorBrickBasicSlopeSide90Block), typeof(ColorBrickBasicSlopeSide180Block), typeof(ColorBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide270Block);
    }
    [RotatedVariants(typeof(ColorBrickBasicSlopePointBlock), typeof(ColorBrickBasicSlopePoint90Block), typeof(ColorBrickBasicSlopePoint180Block), typeof(ColorBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint270Block);
    }
    [RotatedVariants(typeof(ColorBrickUnderSlopeSideBlock), typeof(ColorBrickUnderSlopeSide90Block), typeof(ColorBrickUnderSlopeSide180Block), typeof(ColorBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide270Block);
    }
    [RotatedVariants(typeof(ColorBrickUnderSlopePeakBlock), typeof(ColorBrickUnderSlopePeak90Block), typeof(ColorBrickUnderSlopePeak180Block), typeof(ColorBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak270Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinFloorBottomFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickThinFloorBottomBlock :
    NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem);
        public override Type BaseType => typeof(BrickThinFloorBottomBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinFloorTopFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickThinFloorTopBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorBrickItem);
        public override Type BaseType => typeof(BrickThinFloorTopBlock);
    }

    [RotatedVariants(typeof(ColorBrickBraceBlock), typeof(ColorBrickBrace90Block), typeof(ColorBrickBrace180Block), typeof(ColorBrickBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BraceFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickBraceBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace270Block);
    }
    [RotatedVariants(typeof(ColorBrickBraceCornerBlock), typeof(ColorBrickBraceCorner90Block), typeof(ColorBrickBraceCorner180Block), typeof(ColorBrickBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BraceCornerFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickBraceCornerBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceCornerBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner270Block);
    }
    [RotatedVariants(typeof(ColorBrickBraceTurnBlock), typeof(ColorBrickBraceTurn90Block), typeof(ColorBrickBraceTurn180Block), typeof(ColorBrickBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BraceTurnFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn270Block);
    }
    [RotatedVariants(typeof(ColorBrickSideBraceBlock), typeof(ColorBrickSideBrace90Block), typeof(ColorBrickSideBrace180Block), typeof(ColorBrickSideBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SideBraceFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickSideBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSideBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickSideBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickSideBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickSideBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace270Block);
    }
    [RotatedVariants(typeof(ColorBrickSmallCornerBraceBlock), typeof(ColorBrickSmallCornerBrace90Block), typeof(ColorBrickSmallCornerBrace180Block), typeof(ColorBrickSmallCornerBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SmallCornerBraceFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickSmallCornerBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickSmallCornerBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickSmallCornerBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickSmallCornerBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace270Block);
    }
    [RotatedVariants(typeof(ColorBrickThinWallEdgeBlock), typeof(ColorBrickThinWallEdge90Block), typeof(ColorBrickThinWallEdge180Block), typeof(ColorBrickThinWallEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinWallEdgeFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickThinWallEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickThinWallEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickThinWallEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickThinWallEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge270Block);
    }
    [RotatedVariants(typeof(ColorBrickUnderBraceBlock), typeof(ColorBrickUnderBrace90Block), typeof(ColorBrickUnderBrace180Block), typeof(ColorBrickUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderBraceFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickUnderBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace270Block);
    }
    [RotatedVariants(typeof(ColorBrickUnderBraceCornerBlock), typeof(ColorBrickUnderBraceCorner90Block), typeof(ColorBrickUnderBraceCorner180Block), typeof(ColorBrickUnderBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderBraceCornerFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickUnderBraceCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner270Block);
    }
    [RotatedVariants(typeof(ColorBrickUnderBraceTurnBlock), typeof(ColorBrickUnderBraceTurn90Block), typeof(ColorBrickUnderBraceTurn180Block), typeof(ColorBrickUnderBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderBraceTurnFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickUnderBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickUnderBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn270Block);
    }
    [RotatedVariants(typeof(ColorBrickWindowBlock), typeof(ColorBrickWindow90Block), typeof(ColorBrickWindow180Block), typeof(ColorBrickWindow270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickWindowBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindow90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindow180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindow270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow270Block);
    }
    [RotatedVariants(typeof(ColorBrickWindowEdgeBlock), typeof(ColorBrickWindowEdge90Block), typeof(ColorBrickWindowEdge180Block), typeof(ColorBrickWindowEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowEdgeFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickWindowEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindowEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindowEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindowEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge270Block);
    }
    [RotatedVariants(typeof(ColorBrickWindowGrillesBlock), typeof(ColorBrickWindowGrilles90Block), typeof(ColorBrickWindowGrilles180Block), typeof(ColorBrickWindowGrilles270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowGrillesFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickWindowGrillesBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindowGrilles90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindowGrilles180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindowGrilles270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles270Block);
    }
    [RotatedVariants(typeof(ColorBrickWindowGrillesEdgeBlock), typeof(ColorBrickWindowGrillesEdge90Block), typeof(ColorBrickWindowGrillesEdge180Block), typeof(ColorBrickWindowGrillesEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowGrillesEdgeFormType), typeof(ColorBrickItem))]
    public partial class ColorBrickWindowGrillesEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindowGrillesEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindowGrillesEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ColorBrickWindowGrillesEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge270Block);
    }
}
