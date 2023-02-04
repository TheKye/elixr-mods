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
    public partial class GreyBrickBlock :
           Block
           , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [LocDisplayName("Grey Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class GreyBrickItem :
    BlockItem<GreyBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Grey Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And It's GREY!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(GreyBrickStacked1Block),
        typeof(GreyBrickStacked2Block),
        typeof(GreyBrickStacked3Block),
            typeof(GreyBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class GreyBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreyBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreyBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreyBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GreyBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }




    [RotatedVariants(typeof(GreyBrickStairsBlock), typeof(GreyBrickStairs90Block), typeof(GreyBrickStairs180Block), typeof(GreyBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(GreyBrickRoofSideBlock), typeof(GreyBrickRoofSide90Block), typeof(GreyBrickRoofSide180Block), typeof(GreyBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(GreyBrickRoofTurnBlock), typeof(GreyBrickRoofTurn90Block), typeof(GreyBrickRoofTurn180Block), typeof(GreyBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(GreyBrickRoofCornerBlock), typeof(GreyBrickRoofCorner90Block), typeof(GreyBrickRoofCorner180Block), typeof(GreyBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(GreyBrickRoofPeakBlock), typeof(GreyBrickRoofPeak90Block), typeof(GreyBrickRoofPeak180Block), typeof(GreyBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(GreyBrickBasicSlopeSideBlock), typeof(GreyBrickBasicSlopeSide90Block), typeof(GreyBrickBasicSlopeSide180Block), typeof(GreyBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(GreyBrickBasicSlopePointBlock), typeof(GreyBrickBasicSlopePoint90Block), typeof(GreyBrickBasicSlopePoint180Block), typeof(GreyBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(GreyBrickUnderSlopeSideBlock), typeof(GreyBrickUnderSlopeSide90Block), typeof(GreyBrickUnderSlopeSide180Block), typeof(GreyBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(GreyBrickUnderSlopePeakBlock), typeof(GreyBrickUnderSlopePeak90Block), typeof(GreyBrickUnderSlopePeak180Block), typeof(GreyBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreyBrickUnderSlopePeak270Block : Block
    { }

}
