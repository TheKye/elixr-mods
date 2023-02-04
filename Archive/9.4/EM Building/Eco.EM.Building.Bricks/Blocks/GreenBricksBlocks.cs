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
    public partial class GreenBrickBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [LocDisplayName("Green Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class GreenBrickItem :
    BlockItem<GreenBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Green Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Green!");

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
    [IsForm(typeof(FloorFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }




    [RotatedVariants(typeof(GreenBrickStairsBlock), typeof(GreenBrickStairs90Block), typeof(GreenBrickStairs180Block), typeof(GreenBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(GreenBrickRoofSideBlock), typeof(GreenBrickRoofSide90Block), typeof(GreenBrickRoofSide180Block), typeof(GreenBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(GreenBrickRoofTurnBlock), typeof(GreenBrickRoofTurn90Block), typeof(GreenBrickRoofTurn180Block), typeof(GreenBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(GreenBrickRoofCornerBlock), typeof(GreenBrickRoofCorner90Block), typeof(GreenBrickRoofCorner180Block), typeof(GreenBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(GreenBrickRoofPeakBlock), typeof(GreenBrickRoofPeak90Block), typeof(GreenBrickRoofPeak180Block), typeof(GreenBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(GreenBrickBasicSlopeSideBlock), typeof(GreenBrickBasicSlopeSide90Block), typeof(GreenBrickBasicSlopeSide180Block), typeof(GreenBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(GreenBrickBasicSlopePointBlock), typeof(GreenBrickBasicSlopePoint90Block), typeof(GreenBrickBasicSlopePoint180Block), typeof(GreenBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(GreenBrickUnderSlopeSideBlock), typeof(GreenBrickUnderSlopeSide90Block), typeof(GreenBrickUnderSlopeSide180Block), typeof(GreenBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(GreenBrickUnderSlopePeakBlock), typeof(GreenBrickUnderSlopePeak90Block), typeof(GreenBrickUnderSlopePeak180Block), typeof(GreenBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickUnderSlopePeak270Block : Block
    { }

}
