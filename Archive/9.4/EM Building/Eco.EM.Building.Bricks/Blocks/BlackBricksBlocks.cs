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
    public partial class BlackBrickBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [LocDisplayName("Black Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class BlackBrickItem :
    BlockItem<BlackBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Black Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its Black!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(BlackBrickStacked1Block),
        typeof(BlackBrickStacked2Block),
        typeof(BlackBrickStacked3Block),
            typeof(BlackBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes; 
    }

    [Serialized, Solid] public class BlackBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlackBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlackBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlackBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 BlackBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [RotatedVariants(typeof(BlackBrickStairsBlock), typeof(BlackBrickStairs90Block), typeof(BlackBrickStairs180Block), typeof(BlackBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(BlackBrickRoofSideBlock), typeof(BlackBrickRoofSide90Block), typeof(BlackBrickRoofSide180Block), typeof(BlackBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(BlackBrickRoofTurnBlock), typeof(BlackBrickRoofTurn90Block), typeof(BlackBrickRoofTurn180Block), typeof(BlackBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(BlackBrickRoofCornerBlock), typeof(BlackBrickRoofCorner90Block), typeof(BlackBrickRoofCorner180Block), typeof(BlackBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(BlackBrickRoofPeakBlock), typeof(BlackBrickRoofPeak90Block), typeof(BlackBrickRoofPeak180Block), typeof(BlackBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(BlackBrickBasicSlopeSideBlock), typeof(BlackBrickBasicSlopeSide90Block), typeof(BlackBrickBasicSlopeSide180Block), typeof(BlackBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(BlackBrickBasicSlopePointBlock), typeof(BlackBrickBasicSlopePoint90Block), typeof(BlackBrickBasicSlopePoint180Block), typeof(BlackBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(BlackBrickUnderSlopeSideBlock), typeof(BlackBrickUnderSlopeSide90Block), typeof(BlackBrickUnderSlopeSide180Block), typeof(BlackBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(BlackBrickUnderSlopePeakBlock), typeof(BlackBrickUnderSlopePeak90Block), typeof(BlackBrickUnderSlopePeak180Block), typeof(BlackBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickUnderSlopePeak270Block : Block
    { }

}
