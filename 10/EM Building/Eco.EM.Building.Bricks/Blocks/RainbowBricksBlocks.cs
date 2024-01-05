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
    public partial class RainbowBrickBlock :
        NBlock
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickBlock);
    }

    [Serialized]
    [LocDisplayName("Rainbow Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks")]
    [Tag("Constructable")]
    [LocDescription("Durable building material made from fired blocks and mortar. And Its Rainbow!")]
    [Tier(2)]
    public partial class RainbowBrickItem :
    BlockItem<RainbowBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Rainbow Bricks");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(RainbowBrickStacked1Block),
        typeof(RainbowBrickStacked2Block),
        typeof(RainbowBrickStacked3Block),
            typeof(RainbowBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class RainbowBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class RainbowBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class RainbowBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class RainbowBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 RainbowBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickFloorBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickFloorBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickWallBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickWallBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickCubeBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickRoofBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickRoofBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickColumnBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickAqueductBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickAqueductBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickRoofPeakSetBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickRoofPeakSetBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickRoofCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickRoofCubeBlock);
    }

    [RotatedVariants(typeof(RainbowBrickStairsBlock), typeof(RainbowBrickStairs90Block), typeof(RainbowBrickStairs180Block), typeof(RainbowBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickStairsBlock : NBlock
    { public override Type BaseType => typeof(BrickStairsBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickStairs90Block : NBlock
    { public override Type BaseType => typeof(BrickStairs90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickStairs180Block : NBlock
    { public override Type BaseType => typeof(BrickStairs180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickStairs270Block : NBlock
    { public override Type BaseType => typeof(BrickStairs270Block); }

    [RotatedVariants(typeof(RainbowBrickRoofSideBlock), typeof(RainbowBrickRoofSide90Block), typeof(RainbowBrickRoofSide180Block), typeof(RainbowBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickRoofSideBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofSideBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofSide90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofSide180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofSide270Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide270Block); }
    [RotatedVariants(typeof(RainbowBrickRoofTurnBlock), typeof(RainbowBrickRoofTurn90Block), typeof(RainbowBrickRoofTurn180Block), typeof(RainbowBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickRoofTurnBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofTurnBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofTurn90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofTurn180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofTurn270Block);
    }
    [RotatedVariants(typeof(RainbowBrickRoofCornerBlock), typeof(RainbowBrickRoofCorner90Block), typeof(RainbowBrickRoofCorner180Block), typeof(RainbowBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner270Block);
    }
    [RotatedVariants(typeof(RainbowBrickRoofPeakBlock), typeof(RainbowBrickRoofPeak90Block), typeof(RainbowBrickRoofPeak180Block), typeof(RainbowBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak270Block);
    }
    [RotatedVariants(typeof(RainbowBrickBasicSlopeSideBlock), typeof(RainbowBrickBasicSlopeSide90Block), typeof(RainbowBrickBasicSlopeSide180Block), typeof(RainbowBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide270Block);
    }
    [RotatedVariants(typeof(RainbowBrickBasicSlopePointBlock), typeof(RainbowBrickBasicSlopePoint90Block), typeof(RainbowBrickBasicSlopePoint180Block), typeof(RainbowBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint270Block);
    }
    [RotatedVariants(typeof(RainbowBrickUnderSlopeSideBlock), typeof(RainbowBrickUnderSlopeSide90Block), typeof(RainbowBrickUnderSlopeSide180Block), typeof(RainbowBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide270Block);
    }
    [RotatedVariants(typeof(RainbowBrickUnderSlopePeakBlock), typeof(RainbowBrickUnderSlopePeak90Block), typeof(RainbowBrickUnderSlopePeak180Block), typeof(RainbowBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak270Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinFloorBottomFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickThinFloorBottomBlock :
    NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickThinFloorBottomBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinFloorTopFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickThinFloorTopBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RainbowBrickItem);
        public override Type BaseType => typeof(BrickThinFloorTopBlock);
    }

    [RotatedVariants(typeof(RainbowBrickBraceBlock), typeof(RainbowBrickBrace90Block), typeof(RainbowBrickBrace180Block), typeof(RainbowBrickBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BraceFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickBraceBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace270Block);
    }
    [RotatedVariants(typeof(RainbowBrickBraceCornerBlock), typeof(RainbowBrickBraceCorner90Block), typeof(RainbowBrickBraceCorner180Block), typeof(RainbowBrickBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BraceCornerFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickBraceCornerBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceCornerBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner270Block);
    }
    [RotatedVariants(typeof(RainbowBrickBraceTurnBlock), typeof(RainbowBrickBraceTurn90Block), typeof(RainbowBrickBraceTurn180Block), typeof(RainbowBrickBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BraceTurnFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn270Block);
    }
    [RotatedVariants(typeof(RainbowBrickSideBraceBlock), typeof(RainbowBrickSideBrace90Block), typeof(RainbowBrickSideBrace180Block), typeof(RainbowBrickSideBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SideBraceFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickSideBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSideBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickSideBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickSideBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickSideBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace270Block);
    }
    [RotatedVariants(typeof(RainbowBrickSmallCornerBraceBlock), typeof(RainbowBrickSmallCornerBrace90Block), typeof(RainbowBrickSmallCornerBrace180Block), typeof(RainbowBrickSmallCornerBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SmallCornerBraceFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickSmallCornerBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickSmallCornerBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickSmallCornerBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickSmallCornerBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace270Block);
    }
    [RotatedVariants(typeof(RainbowBrickThinWallEdgeBlock), typeof(RainbowBrickThinWallEdge90Block), typeof(RainbowBrickThinWallEdge180Block), typeof(RainbowBrickThinWallEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinWallEdgeFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickThinWallEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickThinWallEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickThinWallEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickThinWallEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge270Block);
    }
    [RotatedVariants(typeof(RainbowBrickUnderBraceBlock), typeof(RainbowBrickUnderBrace90Block), typeof(RainbowBrickUnderBrace180Block), typeof(RainbowBrickUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderBraceFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickUnderBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace270Block);
    }
    [RotatedVariants(typeof(RainbowBrickUnderBraceCornerBlock), typeof(RainbowBrickUnderBraceCorner90Block), typeof(RainbowBrickUnderBraceCorner180Block), typeof(RainbowBrickUnderBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderBraceCornerFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickUnderBraceCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner270Block);
    }
    [RotatedVariants(typeof(RainbowBrickUnderBraceTurnBlock), typeof(RainbowBrickUnderBraceTurn90Block), typeof(RainbowBrickUnderBraceTurn180Block), typeof(RainbowBrickUnderBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderBraceTurnFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickUnderBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickUnderBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn270Block);
    }
    [RotatedVariants(typeof(RainbowBrickWindowBlock), typeof(RainbowBrickWindow90Block), typeof(RainbowBrickWindow180Block), typeof(RainbowBrickWindow270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickWindowBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindow90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindow180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindow270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow270Block);
    }
    [RotatedVariants(typeof(RainbowBrickWindowEdgeBlock), typeof(RainbowBrickWindowEdge90Block), typeof(RainbowBrickWindowEdge180Block), typeof(RainbowBrickWindowEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowEdgeFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickWindowEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindowEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindowEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindowEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge270Block);
    }
    [RotatedVariants(typeof(RainbowBrickWindowGrillesBlock), typeof(RainbowBrickWindowGrilles90Block), typeof(RainbowBrickWindowGrilles180Block), typeof(RainbowBrickWindowGrilles270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowGrillesFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickWindowGrillesBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindowGrilles90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindowGrilles180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindowGrilles270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles270Block);
    }
    [RotatedVariants(typeof(RainbowBrickWindowGrillesEdgeBlock), typeof(RainbowBrickWindowGrillesEdge90Block), typeof(RainbowBrickWindowGrillesEdge180Block), typeof(RainbowBrickWindowGrillesEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowGrillesEdgeFormType), typeof(RainbowBrickItem))]
    public partial class RainbowBrickWindowGrillesEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindowGrillesEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindowGrillesEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RainbowBrickWindowGrillesEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge270Block);
    }
}
