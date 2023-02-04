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
    public partial class DarkRedBrickBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [LocDisplayName("Dark Red Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class DarkRedBrickItem :
    BlockItem<DarkRedBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Dark Red Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Dark Red!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(DarkRedBrickStacked1Block),
        typeof(DarkRedBrickStacked2Block),
        typeof(DarkRedBrickStacked3Block),
            typeof(DarkRedBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class DarkRedBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class DarkRedBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class DarkRedBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class DarkRedBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 DarkRedBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [RotatedVariants(typeof(DarkRedBrickStairsBlock), typeof(DarkRedBrickStairs90Block), typeof(DarkRedBrickStairs180Block), typeof(DarkRedBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(DarkRedBrickRoofSideBlock), typeof(DarkRedBrickRoofSide90Block), typeof(DarkRedBrickRoofSide180Block), typeof(DarkRedBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(DarkRedBrickRoofTurnBlock), typeof(DarkRedBrickRoofTurn90Block), typeof(DarkRedBrickRoofTurn180Block), typeof(DarkRedBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(DarkRedBrickRoofCornerBlock), typeof(DarkRedBrickRoofCorner90Block), typeof(DarkRedBrickRoofCorner180Block), typeof(DarkRedBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(DarkRedBrickRoofPeakBlock), typeof(DarkRedBrickRoofPeak90Block), typeof(DarkRedBrickRoofPeak180Block), typeof(DarkRedBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(DarkRedBrickBasicSlopeSideBlock), typeof(DarkRedBrickBasicSlopeSide90Block), typeof(DarkRedBrickBasicSlopeSide180Block), typeof(DarkRedBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(DarkRedBrickBasicSlopePointBlock), typeof(DarkRedBrickBasicSlopePoint90Block), typeof(DarkRedBrickBasicSlopePoint180Block), typeof(DarkRedBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(DarkRedBrickUnderSlopeSideBlock), typeof(DarkRedBrickUnderSlopeSide90Block), typeof(DarkRedBrickUnderSlopeSide180Block), typeof(DarkRedBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(DarkRedBrickUnderSlopePeakBlock), typeof(DarkRedBrickUnderSlopePeak90Block), typeof(DarkRedBrickUnderSlopePeak180Block), typeof(DarkRedBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(DarkRedBrickItem))]
    public partial class DarkRedBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class DarkRedBrickUnderSlopePeak270Block : Block
    { }

}
