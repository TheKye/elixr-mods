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
    public partial class BlueBrickBlock :
       Block
       , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [LocDisplayName("Blue Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class BlueBrickItem :
    BlockItem<BlueBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Blue Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Blue!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(BlueBrickStacked1Block),
        typeof(BlueBrickStacked2Block),
        typeof(BlueBrickStacked3Block),
            typeof(BlueBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class BlueBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlueBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlueBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlueBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 BlueBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [RotatedVariants(typeof(BlueBrickStairsBlock), typeof(BlueBrickStairs90Block), typeof(BlueBrickStairs180Block), typeof(BlueBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(BlueBrickRoofSideBlock), typeof(BlueBrickRoofSide90Block), typeof(BlueBrickRoofSide180Block), typeof(BlueBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(BlueBrickRoofTurnBlock), typeof(BlueBrickRoofTurn90Block), typeof(BlueBrickRoofTurn180Block), typeof(BlueBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(BlueBrickRoofCornerBlock), typeof(BlueBrickRoofCorner90Block), typeof(BlueBrickRoofCorner180Block), typeof(BlueBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(BlueBrickRoofPeakBlock), typeof(BlueBrickRoofPeak90Block), typeof(BlueBrickRoofPeak180Block), typeof(BlueBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(BlueBrickBasicSlopeSideBlock), typeof(BlueBrickBasicSlopeSide90Block), typeof(BlueBrickBasicSlopeSide180Block), typeof(BlueBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(BlueBrickBasicSlopePointBlock), typeof(BlueBrickBasicSlopePoint90Block), typeof(BlueBrickBasicSlopePoint180Block), typeof(BlueBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(BlueBrickUnderSlopeSideBlock), typeof(BlueBrickUnderSlopeSide90Block), typeof(BlueBrickUnderSlopeSide180Block), typeof(BlueBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(BlueBrickUnderSlopePeakBlock), typeof(BlueBrickUnderSlopePeak90Block), typeof(BlueBrickUnderSlopePeak180Block), typeof(BlueBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(BlueBrickItem))]
    public partial class BlueBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlueBrickUnderSlopePeak270Block : Block
    { }

}
