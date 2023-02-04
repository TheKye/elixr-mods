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
    public partial class PurpleBrickBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [LocDisplayName("Purple Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class PurpleBrickItem :
    BlockItem<PurpleBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Purple Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Purple!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(PurpleBrickStacked1Block),
        typeof(PurpleBrickStacked2Block),
        typeof(PurpleBrickStacked3Block),
            typeof(PurpleBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class PurpleBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class PurpleBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 PurpleBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }




    [RotatedVariants(typeof(PurpleBrickStairsBlock), typeof(PurpleBrickStairs90Block), typeof(PurpleBrickStairs180Block), typeof(PurpleBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(PurpleBrickRoofSideBlock), typeof(PurpleBrickRoofSide90Block), typeof(PurpleBrickRoofSide180Block), typeof(PurpleBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(PurpleBrickRoofTurnBlock), typeof(PurpleBrickRoofTurn90Block), typeof(PurpleBrickRoofTurn180Block), typeof(PurpleBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(PurpleBrickRoofCornerBlock), typeof(PurpleBrickRoofCorner90Block), typeof(PurpleBrickRoofCorner180Block), typeof(PurpleBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(PurpleBrickRoofPeakBlock), typeof(PurpleBrickRoofPeak90Block), typeof(PurpleBrickRoofPeak180Block), typeof(PurpleBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(PurpleBrickBasicSlopeSideBlock), typeof(PurpleBrickBasicSlopeSide90Block), typeof(PurpleBrickBasicSlopeSide180Block), typeof(PurpleBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(PurpleBrickBasicSlopePointBlock), typeof(PurpleBrickBasicSlopePoint90Block), typeof(PurpleBrickBasicSlopePoint180Block), typeof(PurpleBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(PurpleBrickUnderSlopeSideBlock), typeof(PurpleBrickUnderSlopeSide90Block), typeof(PurpleBrickUnderSlopeSide180Block), typeof(PurpleBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(PurpleBrickUnderSlopePeakBlock), typeof(PurpleBrickUnderSlopePeak90Block), typeof(PurpleBrickUnderSlopePeak180Block), typeof(PurpleBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(PurpleBrickItem))]
    public partial class PurpleBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PurpleBrickUnderSlopePeak270Block : Block
    { }

}
