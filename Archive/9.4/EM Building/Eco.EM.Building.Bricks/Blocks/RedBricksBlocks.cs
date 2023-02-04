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
    public partial class RedBrickBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }

    [Serialized]
    [LocDisplayName("Red Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class RedBrickItem :
    BlockItem<RedBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Red Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Red!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(RedBrickStacked1Block),
        typeof(RedBrickStacked2Block),
        typeof(RedBrickStacked3Block),
            typeof(RedBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class RedBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class RedBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class RedBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class RedBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 RedBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(RedBrickItem))]
    public partial class RedBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(RedBrickItem))]
    public partial class RedBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(RedBrickItem))]
    public partial class RedBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(RedBrickItem))]
    public partial class RedBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(RedBrickItem))]
    public partial class RedBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(RedBrickItem))]
    public partial class RedBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(RedBrickItem))]
    public partial class RedBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(RedBrickItem))]
    public partial class RedBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(RedBrickItem))]
    public partial class RedBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);
    }

    [RotatedVariants(typeof(RedBrickStairsBlock), typeof(RedBrickStairs90Block), typeof(RedBrickStairs180Block), typeof(RedBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(RedBrickItem))]
    public partial class RedBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(RedBrickRoofSideBlock), typeof(RedBrickRoofSide90Block), typeof(RedBrickRoofSide180Block), typeof(RedBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(RedBrickItem))]
    public partial class RedBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(RedBrickRoofTurnBlock), typeof(RedBrickRoofTurn90Block), typeof(RedBrickRoofTurn180Block), typeof(RedBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(RedBrickItem))]
    public partial class RedBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(RedBrickRoofCornerBlock), typeof(RedBrickRoofCorner90Block), typeof(RedBrickRoofCorner180Block), typeof(RedBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(RedBrickItem))]
    public partial class RedBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(RedBrickRoofPeakBlock), typeof(RedBrickRoofPeak90Block), typeof(RedBrickRoofPeak180Block), typeof(RedBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(RedBrickItem))]
    public partial class RedBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(RedBrickBasicSlopeSideBlock), typeof(RedBrickBasicSlopeSide90Block), typeof(RedBrickBasicSlopeSide180Block), typeof(RedBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(RedBrickItem))]
    public partial class RedBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(RedBrickBasicSlopePointBlock), typeof(RedBrickBasicSlopePoint90Block), typeof(RedBrickBasicSlopePoint180Block), typeof(RedBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(RedBrickItem))]
    public partial class RedBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(RedBrickUnderSlopeSideBlock), typeof(RedBrickUnderSlopeSide90Block), typeof(RedBrickUnderSlopeSide180Block), typeof(RedBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(RedBrickItem))]
    public partial class RedBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(RedBrickUnderSlopePeakBlock), typeof(RedBrickUnderSlopePeak90Block), typeof(RedBrickUnderSlopePeak180Block), typeof(RedBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(RedBrickItem))]
    public partial class RedBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickUnderSlopePeak270Block : Block
    { }

}
