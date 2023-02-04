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

namespace Eco.EM.Building.Bricks
{

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [RequiresSkill(typeof(PotterySkill), 1)]
    public partial class BrownBrickBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }

    [Serialized]
    [LocDisplayName("Brown Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class BrownBrickItem :
    BlockItem<BrownBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Brown Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Brown!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(BrownBrickStacked1Block),
        typeof(BrownBrickStacked2Block),
        typeof(BrownBrickStacked3Block),
            typeof(BrownBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class BrownBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BrownBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BrownBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BrownBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 BrownBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownBrickItem);
    }

    [RotatedVariants(typeof(BrownBrickStairsBlock), typeof(BrownBrickStairs90Block), typeof(BrownBrickStairs180Block), typeof(BrownBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(BrownBrickRoofSideBlock), typeof(BrownBrickRoofSide90Block), typeof(BrownBrickRoofSide180Block), typeof(BrownBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(BrownBrickRoofTurnBlock), typeof(BrownBrickRoofTurn90Block), typeof(BrownBrickRoofTurn180Block), typeof(BrownBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(BrownBrickRoofCornerBlock), typeof(BrownBrickRoofCorner90Block), typeof(BrownBrickRoofCorner180Block), typeof(BrownBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(BrownBrickRoofPeakBlock), typeof(BrownBrickRoofPeak90Block), typeof(BrownBrickRoofPeak180Block), typeof(BrownBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(BrownBrickBasicSlopeSideBlock), typeof(BrownBrickBasicSlopeSide90Block), typeof(BrownBrickBasicSlopeSide180Block), typeof(BrownBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(BrownBrickBasicSlopePointBlock), typeof(BrownBrickBasicSlopePoint90Block), typeof(BrownBrickBasicSlopePoint180Block), typeof(BrownBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(BrownBrickUnderSlopeSideBlock), typeof(BrownBrickUnderSlopeSide90Block), typeof(BrownBrickUnderSlopeSide180Block), typeof(BrownBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(BrownBrickUnderSlopePeakBlock), typeof(BrownBrickUnderSlopePeak90Block), typeof(BrownBrickUnderSlopePeak180Block), typeof(BrownBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(BrownBrickItem))]
    public partial class BrownBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownBrickUnderSlopePeak270Block : Block
    { }

}
