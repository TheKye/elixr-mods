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
    [Tag("Constructable")]
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class GreenBrickBlock :
        NBlock
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickBlock);
    }

    [Serialized]
    [LocDisplayName("Green Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks")]
    [Tag("Constructable")]
    [LocDescription("Durable building material made from fired blocks and mortar. And Its Green!")]
    [Tier(2)]
    public partial class GreenBrickItem :
    BlockItem<GreenBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Green Bricks");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(GreenBrickStacked1Block),
        typeof(GreenBrickStacked2Block),
        typeof(GreenBrickStacked3Block),
            typeof(GreenBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class GreenBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreenBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreenBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreenBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GreenBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FloorFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickFloorBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickFloorBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WallFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickWallBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickWallBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(CubeFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickCubeBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickRoofBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ColumnFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickColumnBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(AqueductFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickAqueductBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickAqueductBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofPeakSetFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofPeakSetBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickRoofPeakSetBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofCubeFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickRoofCubeBlock);
    }

    [RotatedVariants(typeof(GreenBrickStairsBlock), typeof(GreenBrickStairs90Block), typeof(GreenBrickStairs180Block), typeof(GreenBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(StairsFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickStairsBlock : NBlock
    { public override Type BaseType => typeof(BrickStairsBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickStairs90Block : NBlock
    { public override Type BaseType => typeof(BrickStairs90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickStairs180Block : NBlock
    { public override Type BaseType => typeof(BrickStairs180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickStairs270Block : NBlock
    { public override Type BaseType => typeof(BrickStairs270Block); }

    [RotatedVariants(typeof(GreenBrickRoofSideBlock), typeof(GreenBrickRoofSide90Block), typeof(GreenBrickRoofSide180Block), typeof(GreenBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofSideFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofSideBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofSideBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofSide90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofSide180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofSide270Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide270Block); }
    [RotatedVariants(typeof(GreenBrickRoofTurnBlock), typeof(GreenBrickRoofTurn90Block), typeof(GreenBrickRoofTurn180Block), typeof(GreenBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofTurnFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofTurnBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofTurnBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofTurn90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofTurn180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofTurn270Block);
    }
    [RotatedVariants(typeof(GreenBrickRoofCornerBlock), typeof(GreenBrickRoofCorner90Block), typeof(GreenBrickRoofCorner180Block), typeof(GreenBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofCornerFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner270Block);
    }
    [RotatedVariants(typeof(GreenBrickRoofPeakBlock), typeof(GreenBrickRoofPeak90Block), typeof(GreenBrickRoofPeak180Block), typeof(GreenBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofPeakFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak270Block);
    }
    [RotatedVariants(typeof(GreenBrickBasicSlopeSideBlock), typeof(GreenBrickBasicSlopeSide90Block), typeof(GreenBrickBasicSlopeSide180Block), typeof(GreenBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide270Block);
    }
    [RotatedVariants(typeof(GreenBrickBasicSlopePointBlock), typeof(GreenBrickBasicSlopePoint90Block), typeof(GreenBrickBasicSlopePoint180Block), typeof(GreenBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BasicSlopePointFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint270Block);
    }
    [RotatedVariants(typeof(GreenBrickUnderSlopeSideBlock), typeof(GreenBrickUnderSlopeSide90Block), typeof(GreenBrickUnderSlopeSide180Block), typeof(GreenBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide270Block);
    }
    [RotatedVariants(typeof(GreenBrickUnderSlopePeakBlock), typeof(GreenBrickUnderSlopePeak90Block), typeof(GreenBrickUnderSlopePeak180Block), typeof(GreenBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak270Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorBottomFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickThinFloorBottomBlock :
    NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickThinFloorBottomBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorTopFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickThinFloorTopBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
        public override Type BaseType => typeof(BrickThinFloorTopBlock);
    }

    [RotatedVariants(typeof(GreenBrickBraceBlock), typeof(GreenBrickBrace90Block), typeof(GreenBrickBrace180Block), typeof(GreenBrickBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BraceFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickBraceBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace270Block);
    }
    [RotatedVariants(typeof(GreenBrickBraceCornerBlock), typeof(GreenBrickBraceCorner90Block), typeof(GreenBrickBraceCorner180Block), typeof(GreenBrickBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BraceCornerFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickBraceCornerBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceCornerBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner270Block);
    }
    [RotatedVariants(typeof(GreenBrickBraceTurnBlock), typeof(GreenBrickBraceTurn90Block), typeof(GreenBrickBraceTurn180Block), typeof(GreenBrickBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BraceTurnFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn270Block);
    }
    [RotatedVariants(typeof(GreenBrickSideBraceBlock), typeof(GreenBrickSideBrace90Block), typeof(GreenBrickSideBrace180Block), typeof(GreenBrickSideBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SideBraceFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickSideBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSideBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickSideBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickSideBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickSideBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace270Block);
    }
    [RotatedVariants(typeof(GreenBrickSmallCornerBraceBlock), typeof(GreenBrickSmallCornerBrace90Block), typeof(GreenBrickSmallCornerBrace180Block), typeof(GreenBrickSmallCornerBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SmallCornerBraceFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickSmallCornerBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickSmallCornerBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickSmallCornerBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickSmallCornerBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace270Block);
    }
    [RotatedVariants(typeof(GreenBrickThinWallEdgeBlock), typeof(GreenBrickThinWallEdge90Block), typeof(GreenBrickThinWallEdge180Block), typeof(GreenBrickThinWallEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinWallEdgeFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickThinWallEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickThinWallEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickThinWallEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickThinWallEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge270Block);
    }
    [RotatedVariants(typeof(GreenBrickUnderBraceBlock), typeof(GreenBrickUnderBrace90Block), typeof(GreenBrickUnderBrace180Block), typeof(GreenBrickUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderBraceFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickUnderBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace270Block);
    }
    [RotatedVariants(typeof(GreenBrickUnderBraceCornerBlock), typeof(GreenBrickUnderBraceCorner90Block), typeof(GreenBrickUnderBraceCorner180Block), typeof(GreenBrickUnderBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderBraceCornerFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickUnderBraceCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner270Block);
    }
    [RotatedVariants(typeof(GreenBrickUnderBraceTurnBlock), typeof(GreenBrickUnderBraceTurn90Block), typeof(GreenBrickUnderBraceTurn180Block), typeof(GreenBrickUnderBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderBraceTurnFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickUnderBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickUnderBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn270Block);
    }
    [RotatedVariants(typeof(GreenBrickWindowBlock), typeof(GreenBrickWindow90Block), typeof(GreenBrickWindow180Block), typeof(GreenBrickWindow270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickWindowBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindow90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindow180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindow270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow270Block);
    }
    [RotatedVariants(typeof(GreenBrickWindowEdgeBlock), typeof(GreenBrickWindowEdge90Block), typeof(GreenBrickWindowEdge180Block), typeof(GreenBrickWindowEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowEdgeFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickWindowEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindowEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindowEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindowEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge270Block);
    }
    [RotatedVariants(typeof(GreenBrickWindowGrillesBlock), typeof(GreenBrickWindowGrilles90Block), typeof(GreenBrickWindowGrilles180Block), typeof(GreenBrickWindowGrilles270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowGrillesFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickWindowGrillesBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindowGrilles90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindowGrilles180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindowGrilles270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles270Block);
    }
    [RotatedVariants(typeof(GreenBrickWindowGrillesEdgeBlock), typeof(GreenBrickWindowGrillesEdge90Block), typeof(GreenBrickWindowGrillesEdge180Block), typeof(GreenBrickWindowGrillesEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowGrillesEdgeFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickWindowGrillesEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindowGrillesEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindowGrillesEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenBrickWindowGrillesEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge270Block);
    }
}
