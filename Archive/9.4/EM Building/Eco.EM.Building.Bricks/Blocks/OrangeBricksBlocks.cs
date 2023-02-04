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
    public partial class OrangeBrickBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [LocDisplayName("Orange Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class OrangeBrickItem :
    BlockItem<OrangeBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Orange Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Orange!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(OrangeBrickStacked1Block),
        typeof(OrangeBrickStacked2Block),
        typeof(OrangeBrickStacked3Block),
            typeof(OrangeBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class OrangeBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class OrangeBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 OrangeBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [RotatedVariants(typeof(OrangeBrickStairsBlock), typeof(OrangeBrickStairs90Block), typeof(OrangeBrickStairs180Block), typeof(OrangeBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(OrangeBrickRoofSideBlock), typeof(OrangeBrickRoofSide90Block), typeof(OrangeBrickRoofSide180Block), typeof(OrangeBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(OrangeBrickRoofTurnBlock), typeof(OrangeBrickRoofTurn90Block), typeof(OrangeBrickRoofTurn180Block), typeof(OrangeBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(OrangeBrickRoofCornerBlock), typeof(OrangeBrickRoofCorner90Block), typeof(OrangeBrickRoofCorner180Block), typeof(OrangeBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(OrangeBrickRoofPeakBlock), typeof(OrangeBrickRoofPeak90Block), typeof(OrangeBrickRoofPeak180Block), typeof(OrangeBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(OrangeBrickBasicSlopeSideBlock), typeof(OrangeBrickBasicSlopeSide90Block), typeof(OrangeBrickBasicSlopeSide180Block), typeof(OrangeBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(OrangeBrickBasicSlopePointBlock), typeof(OrangeBrickBasicSlopePoint90Block), typeof(OrangeBrickBasicSlopePoint180Block), typeof(OrangeBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(OrangeBrickUnderSlopeSideBlock), typeof(OrangeBrickUnderSlopeSide90Block), typeof(OrangeBrickUnderSlopeSide180Block), typeof(OrangeBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(OrangeBrickUnderSlopePeakBlock), typeof(OrangeBrickUnderSlopePeak90Block), typeof(OrangeBrickUnderSlopePeak180Block), typeof(OrangeBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(OrangeBrickItem))]
    public partial class OrangeBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeBrickUnderSlopePeak270Block : Block
    { }

}
