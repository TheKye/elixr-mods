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
    public partial class PinkBrickBlock :
        NBlock
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickBlock);
    }

    [Serialized]
    [LocDisplayName("Pink Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks")]
    [Tag("Constructable")]
    [LocDescription("Durable building material made from fired blocks and mortar. And Its Pink!")]
    [Tier(2)]
    public partial class PinkBrickItem :
    BlockItem<PinkBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Pink Bricks");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(PinkBrickStacked1Block),
        typeof(PinkBrickStacked2Block),
        typeof(PinkBrickStacked3Block),
            typeof(PinkBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class PinkBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class PinkBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class PinkBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class PinkBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 PinkBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FloorFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickFloorBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickFloorBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WallFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickWallBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickWallBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(CubeFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickCubeBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickRoofBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ColumnFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickColumnBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(AqueductFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickAqueductBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickAqueductBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofPeakSetFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofPeakSetBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickRoofPeakSetBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofCubeFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofCubeBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickRoofCubeBlock);
    }

    [RotatedVariants(typeof(PinkBrickStairsBlock), typeof(PinkBrickStairs90Block), typeof(PinkBrickStairs180Block), typeof(PinkBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(StairsFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickStairsBlock : NBlock
    { public override Type BaseType => typeof(BrickStairsBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickStairs90Block : NBlock
    { public override Type BaseType => typeof(BrickStairs90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickStairs180Block : NBlock
    { public override Type BaseType => typeof(BrickStairs180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickStairs270Block : NBlock
    { public override Type BaseType => typeof(BrickStairs270Block); }

    [RotatedVariants(typeof(PinkBrickRoofSideBlock), typeof(PinkBrickRoofSide90Block), typeof(PinkBrickRoofSide180Block), typeof(PinkBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofSideFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofSideBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofSideBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofSide90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofSide180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofSide270Block : NBlock
    { public override Type BaseType => typeof(BrickRoofSide270Block); }
    [RotatedVariants(typeof(PinkBrickRoofTurnBlock), typeof(PinkBrickRoofTurn90Block), typeof(PinkBrickRoofTurn180Block), typeof(PinkBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofTurnFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofTurnBlock : NBlock
    { public override Type BaseType => typeof(BrickRoofTurnBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofTurn90Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn90Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofTurn180Block : NBlock
    { public override Type BaseType => typeof(BrickRoofTurn180Block); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofTurn270Block);
    }
    [RotatedVariants(typeof(PinkBrickRoofCornerBlock), typeof(PinkBrickRoofCorner90Block), typeof(PinkBrickRoofCorner180Block), typeof(PinkBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofCornerFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofCorner270Block);
    }
    [RotatedVariants(typeof(PinkBrickRoofPeakBlock), typeof(PinkBrickRoofPeak90Block), typeof(PinkBrickRoofPeak180Block), typeof(PinkBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofPeakFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickRoofPeak270Block);
    }
    [RotatedVariants(typeof(PinkBrickBasicSlopeSideBlock), typeof(PinkBrickBasicSlopeSide90Block), typeof(PinkBrickBasicSlopeSide180Block), typeof(PinkBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopeSide270Block);
    }
    [RotatedVariants(typeof(PinkBrickBasicSlopePointBlock), typeof(PinkBrickBasicSlopePoint90Block), typeof(PinkBrickBasicSlopePoint180Block), typeof(PinkBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BasicSlopePointFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBasicSlopePoint270Block);
    }
    [RotatedVariants(typeof(PinkBrickUnderSlopeSideBlock), typeof(PinkBrickUnderSlopeSide90Block), typeof(PinkBrickUnderSlopeSide180Block), typeof(PinkBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopeSide270Block);
    }
    [RotatedVariants(typeof(PinkBrickUnderSlopePeakBlock), typeof(PinkBrickUnderSlopePeak90Block), typeof(PinkBrickUnderSlopePeak180Block), typeof(PinkBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderSlopePeak270Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorBottomFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickThinFloorBottomBlock :
    NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickThinFloorBottomBlock);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorTopFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickThinFloorTopBlock :
        NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
        public override Type BaseType => typeof(BrickThinFloorTopBlock);
    }

    [RotatedVariants(typeof(PinkBrickBraceBlock), typeof(PinkBrickBrace90Block), typeof(PinkBrickBrace180Block), typeof(PinkBrickBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BraceFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickBraceBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBrace270Block);
    }
    [RotatedVariants(typeof(PinkBrickBraceCornerBlock), typeof(PinkBrickBraceCorner90Block), typeof(PinkBrickBraceCorner180Block), typeof(PinkBrickBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BraceCornerFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickBraceCornerBlock : NBlock
    { public override Type BaseType => typeof(BrickBraceCornerBlock); }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceCorner270Block);
    }
    [RotatedVariants(typeof(PinkBrickBraceTurnBlock), typeof(PinkBrickBraceTurn90Block), typeof(PinkBrickBraceTurn180Block), typeof(PinkBrickBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BraceTurnFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickBraceTurn270Block);
    }
    [RotatedVariants(typeof(PinkBrickSideBraceBlock), typeof(PinkBrickSideBrace90Block), typeof(PinkBrickSideBrace180Block), typeof(PinkBrickSideBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SideBraceFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickSideBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSideBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickSideBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickSideBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickSideBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSideBrace270Block);
    }
    [RotatedVariants(typeof(PinkBrickSmallCornerBraceBlock), typeof(PinkBrickSmallCornerBrace90Block), typeof(PinkBrickSmallCornerBrace180Block), typeof(PinkBrickSmallCornerBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SmallCornerBraceFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickSmallCornerBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickSmallCornerBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickSmallCornerBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickSmallCornerBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickSmallCornerBrace270Block);
    }
    [RotatedVariants(typeof(PinkBrickThinWallEdgeBlock), typeof(PinkBrickThinWallEdge90Block), typeof(PinkBrickThinWallEdge180Block), typeof(PinkBrickThinWallEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinWallEdgeFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickThinWallEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickThinWallEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickThinWallEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickThinWallEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickThinWallEdge270Block);
    }
    [RotatedVariants(typeof(PinkBrickUnderBraceBlock), typeof(PinkBrickUnderBrace90Block), typeof(PinkBrickUnderBrace180Block), typeof(PinkBrickUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderBraceFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickUnderBraceBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderBrace90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderBrace180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderBrace270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBrace270Block);
    }
    [RotatedVariants(typeof(PinkBrickUnderBraceCornerBlock), typeof(PinkBrickUnderBraceCorner90Block), typeof(PinkBrickUnderBraceCorner180Block), typeof(PinkBrickUnderBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderBraceCornerFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickUnderBraceCornerBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderBraceCorner90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderBraceCorner180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderBraceCorner270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceCorner270Block);
    }
    [RotatedVariants(typeof(PinkBrickUnderBraceTurnBlock), typeof(PinkBrickUnderBraceTurn90Block), typeof(PinkBrickUnderBraceTurn180Block), typeof(PinkBrickUnderBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderBraceTurnFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickUnderBraceTurnBlock : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderBraceTurn90Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderBraceTurn180Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickUnderBraceTurn270Block : NBlock
    {
        public override Type BaseType => typeof(BrickUnderBraceTurn270Block);
    }
    [RotatedVariants(typeof(PinkBrickWindowBlock), typeof(PinkBrickWindow90Block), typeof(PinkBrickWindow180Block), typeof(PinkBrickWindow270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickWindowBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindow90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindow180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindow270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindow270Block);
    }
    [RotatedVariants(typeof(PinkBrickWindowEdgeBlock), typeof(PinkBrickWindowEdge90Block), typeof(PinkBrickWindowEdge180Block), typeof(PinkBrickWindowEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowEdgeFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickWindowEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindowEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindowEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindowEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowEdge270Block);
    }
    [RotatedVariants(typeof(PinkBrickWindowGrillesBlock), typeof(PinkBrickWindowGrilles90Block), typeof(PinkBrickWindowGrilles180Block), typeof(PinkBrickWindowGrilles270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowGrillesFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickWindowGrillesBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindowGrilles90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindowGrilles180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindowGrilles270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrilles270Block);
    }
    [RotatedVariants(typeof(PinkBrickWindowGrillesEdgeBlock), typeof(PinkBrickWindowGrillesEdge90Block), typeof(PinkBrickWindowGrillesEdge180Block), typeof(PinkBrickWindowGrillesEdge270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowGrillesEdgeFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickWindowGrillesEdgeBlock : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdgeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindowGrillesEdge90Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindowGrillesEdge180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class PinkBrickWindowGrillesEdge270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWindowGrillesEdge270Block);
    }
}
