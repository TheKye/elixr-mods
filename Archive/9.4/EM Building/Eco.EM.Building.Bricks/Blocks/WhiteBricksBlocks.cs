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
    public partial class WhiteBrickBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [LocDisplayName("White Bricks")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Colored Bricks", 1)]
    [Tag("Constructable", 1)]
    [Tier(2)]
    public partial class WhiteBrickItem :
    BlockItem<WhiteBrickBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("White Bricks");
        public override LocString DisplayDescription => Localizer.DoStr("Durable building material made from fired blocks and mortar. And Its White!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(WhiteBrickStacked1Block),
        typeof(WhiteBrickStacked2Block),
        typeof(WhiteBrickStacked3Block),
            typeof(WhiteBrickStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes; 
    }

    [Serialized, Solid] public class WhiteBrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class WhiteBrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class WhiteBrickStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class WhiteBrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 WhiteBrick

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FloorFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WallFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ColumnFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(AqueductFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickAqueductBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCubeFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }




    [RotatedVariants(typeof(WhiteBrickStairsBlock), typeof(WhiteBrickStairs90Block), typeof(WhiteBrickStairs180Block), typeof(WhiteBrickStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(StairsFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickStairs270Block : Block
    { }
    [RotatedVariants(typeof(WhiteBrickRoofSideBlock), typeof(WhiteBrickRoofSide90Block), typeof(WhiteBrickRoofSide180Block), typeof(WhiteBrickRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofSideFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofSide270Block : Block
    { }
    [RotatedVariants(typeof(WhiteBrickRoofTurnBlock), typeof(WhiteBrickRoofTurn90Block), typeof(WhiteBrickRoofTurn180Block), typeof(WhiteBrickRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofTurnFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofTurn270Block : Block
    { }
    [RotatedVariants(typeof(WhiteBrickRoofCornerBlock), typeof(WhiteBrickRoofCorner90Block), typeof(WhiteBrickRoofCorner180Block), typeof(WhiteBrickRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofCornerFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofCorner270Block : Block
    { }
    [RotatedVariants(typeof(WhiteBrickRoofPeakBlock), typeof(WhiteBrickRoofPeak90Block), typeof(WhiteBrickRoofPeak180Block), typeof(WhiteBrickRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofPeakFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickRoofPeak270Block : Block
    { }
    [RotatedVariants(typeof(WhiteBrickBasicSlopeSideBlock), typeof(WhiteBrickBasicSlopeSide90Block), typeof(WhiteBrickBasicSlopeSide180Block), typeof(WhiteBrickBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickBasicSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(WhiteBrickBasicSlopePointBlock), typeof(WhiteBrickBasicSlopePoint90Block), typeof(WhiteBrickBasicSlopePoint180Block), typeof(WhiteBrickBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickBasicSlopePoint270Block : Block
    { }
    [RotatedVariants(typeof(WhiteBrickUnderSlopeSideBlock), typeof(WhiteBrickUnderSlopeSide90Block), typeof(WhiteBrickUnderSlopeSide180Block), typeof(WhiteBrickUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickUnderSlopeSide270Block : Block
    { }
    [RotatedVariants(typeof(WhiteBrickUnderSlopePeakBlock), typeof(WhiteBrickUnderSlopePeak90Block), typeof(WhiteBrickUnderSlopePeak180Block), typeof(WhiteBrickUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(WhiteBrickItem))]
    public partial class WhiteBrickUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class WhiteBrickUnderSlopePeak270Block : Block
    { }

}
