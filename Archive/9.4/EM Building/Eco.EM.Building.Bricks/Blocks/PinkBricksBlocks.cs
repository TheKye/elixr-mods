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
    public partial class PinkBrickBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }

    [Serialized]
    [LocDisplayName("Pink Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class PinkBrickItem :
    BlockItem<PinkBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Pink Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its PINK!");

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
    [IsForm(typeof(FloorFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkBrickItem);
    }




    [RotatedVariants(typeof(PinkBrickStairsBlock), typeof(PinkBrickStairs90Block), typeof(PinkBrickStairs180Block), typeof(PinkBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(PinkBrickRoofSideBlock), typeof(PinkBrickRoofSide90Block), typeof(PinkBrickRoofSide180Block), typeof(PinkBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(PinkBrickRoofTurnBlock), typeof(PinkBrickRoofTurn90Block), typeof(PinkBrickRoofTurn180Block), typeof(PinkBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(PinkBrickRoofCornerBlock), typeof(PinkBrickRoofCorner90Block), typeof(PinkBrickRoofCorner180Block), typeof(PinkBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(PinkBrickRoofPeakBlock), typeof(PinkBrickRoofPeak90Block), typeof(PinkBrickRoofPeak180Block), typeof(PinkBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(PinkBrickBasicSlopeSideBlock), typeof(PinkBrickBasicSlopeSide90Block), typeof(PinkBrickBasicSlopeSide180Block), typeof(PinkBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(PinkBrickBasicSlopePointBlock), typeof(PinkBrickBasicSlopePoint90Block), typeof(PinkBrickBasicSlopePoint180Block), typeof(PinkBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(PinkBrickUnderSlopeSideBlock), typeof(PinkBrickUnderSlopeSide90Block), typeof(PinkBrickUnderSlopeSide180Block), typeof(PinkBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(PinkBrickUnderSlopePeakBlock), typeof(PinkBrickUnderSlopePeak90Block), typeof(PinkBrickUnderSlopePeak180Block), typeof(PinkBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(PinkBrickItem))]
    public partial class PinkBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkBrickUnderSlopePeak270Block : Block
    { }

}
