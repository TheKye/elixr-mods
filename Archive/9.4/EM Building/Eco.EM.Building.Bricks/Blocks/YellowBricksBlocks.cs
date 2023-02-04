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
    public partial class YellowBrickBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [LocDisplayName("Yellow Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class YellowBrickItem :
    BlockItem<YellowBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Yellow Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Yellow!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(YellowBrickStacked1Block),
        typeof(YellowBrickStacked2Block),
        typeof(YellowBrickStacked3Block),
            typeof(YellowBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class YellowBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class YellowBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class YellowBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class YellowBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 YellowBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }




    [RotatedVariants(typeof(YellowBrickStairsBlock), typeof(YellowBrickStairs90Block), typeof(YellowBrickStairs180Block), typeof(YellowBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(YellowBrickRoofSideBlock), typeof(YellowBrickRoofSide90Block), typeof(YellowBrickRoofSide180Block), typeof(YellowBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(YellowBrickRoofTurnBlock), typeof(YellowBrickRoofTurn90Block), typeof(YellowBrickRoofTurn180Block), typeof(YellowBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(YellowBrickRoofCornerBlock), typeof(YellowBrickRoofCorner90Block), typeof(YellowBrickRoofCorner180Block), typeof(YellowBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(YellowBrickRoofPeakBlock), typeof(YellowBrickRoofPeak90Block), typeof(YellowBrickRoofPeak180Block), typeof(YellowBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(YellowBrickBasicSlopeSideBlock), typeof(YellowBrickBasicSlopeSide90Block), typeof(YellowBrickBasicSlopeSide180Block), typeof(YellowBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(YellowBrickBasicSlopePointBlock), typeof(YellowBrickBasicSlopePoint90Block), typeof(YellowBrickBasicSlopePoint180Block), typeof(YellowBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(YellowBrickUnderSlopeSideBlock), typeof(YellowBrickUnderSlopeSide90Block), typeof(YellowBrickUnderSlopeSide180Block), typeof(YellowBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(YellowBrickUnderSlopePeakBlock), typeof(YellowBrickUnderSlopePeak90Block), typeof(YellowBrickUnderSlopePeak180Block), typeof(YellowBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(YellowBrickItem))]
    public partial class YellowBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class YellowBrickUnderSlopePeak270Block : Block
    { }

}
