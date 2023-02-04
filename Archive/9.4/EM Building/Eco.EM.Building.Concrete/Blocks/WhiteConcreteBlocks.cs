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

namespace Eco.EM.Building.Concrete
{
    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(3)]
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class WhiteReinforcedConcreteBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }

    [Serialized]
    [LocDisplayName("White Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Colored Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class WhiteReinforcedConcreteItem :
    BlockItem<WhiteReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("White Reinforced Concrete");
        public override LocString DisplayDescription => Localizer.DoStr("A study construction material poured around a latice of rebar. And Its White!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(WhiteReinforcedConcreteStacked1Block),
        typeof(WhiteReinforcedConcreteStacked2Block),
        typeof(WhiteReinforcedConcreteStacked3Block),
            typeof(WhiteReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class WhiteReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class WhiteReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class WhiteReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class WhiteReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 WhiteReinforcedConcrete


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcretePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
    }



    [RotatedVariants(typeof(WhiteReinforcedConcreteLadderBlock), typeof(WhiteReinforcedConcreteLadder90Block), typeof(WhiteReinforcedConcreteLadder180Block), typeof(WhiteReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteLadder270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteStairsBlock), typeof(WhiteReinforcedConcreteStairs90Block), typeof(WhiteReinforcedConcreteStairs180Block), typeof(WhiteReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteStairs270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteUnderStairsBlock), typeof(WhiteReinforcedConcreteUnderStairs90Block), typeof(WhiteReinforcedConcreteUnderStairs180Block), typeof(WhiteReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteBasicSlopeSideBlock), typeof(WhiteReinforcedConcreteBasicSlopeSide90Block), typeof(WhiteReinforcedConcreteBasicSlopeSide180Block), typeof(WhiteReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteBasicSlopeCornerBlock), typeof(WhiteReinforcedConcreteBasicSlopeCorner90Block), typeof(WhiteReinforcedConcreteBasicSlopeCorner180Block), typeof(WhiteReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteBasicSlopeTurnBlock), typeof(WhiteReinforcedConcreteBasicSlopeTurn90Block), typeof(WhiteReinforcedConcreteBasicSlopeTurn180Block), typeof(WhiteReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteBasicSlopePointBlock), typeof(WhiteReinforcedConcreteBasicSlopePoint90Block), typeof(WhiteReinforcedConcreteBasicSlopePoint180Block), typeof(WhiteReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteStairsCornerBlock), typeof(WhiteReinforcedConcreteStairsCorner90Block), typeof(WhiteReinforcedConcreteStairsCorner180Block), typeof(WhiteReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteStairsTurnBlock), typeof(WhiteReinforcedConcreteStairsTurn90Block), typeof(WhiteReinforcedConcreteStairsTurn180Block), typeof(WhiteReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteUnderSlopeSideBlock), typeof(WhiteReinforcedConcreteUnderSlopeSide90Block), typeof(WhiteReinforcedConcreteUnderSlopeSide180Block), typeof(WhiteReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteUnderSlopeCornerBlock), typeof(WhiteReinforcedConcreteUnderSlopeCorner90Block), typeof(WhiteReinforcedConcreteUnderSlopeCorner180Block), typeof(WhiteReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteUnderSlopeTurnBlock), typeof(WhiteReinforcedConcreteUnderSlopeTurn90Block), typeof(WhiteReinforcedConcreteUnderSlopeTurn180Block), typeof(WhiteReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteUnderSlopePeakBlock), typeof(WhiteReinforcedConcreteUnderSlopePeak90Block), typeof(WhiteReinforcedConcreteUnderSlopePeak180Block), typeof(WhiteReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteRoofSideBlock), typeof(WhiteReinforcedConcreteRoofSide90Block), typeof(WhiteReinforcedConcreteRoofSide180Block), typeof(WhiteReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteRoofTurnBlock), typeof(WhiteReinforcedConcreteRoofTurn90Block), typeof(WhiteReinforcedConcreteRoofTurn180Block), typeof(WhiteReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteRoofCornerBlock), typeof(WhiteReinforcedConcreteRoofCorner90Block), typeof(WhiteReinforcedConcreteRoofCorner180Block), typeof(WhiteReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteRoofPeakBlock), typeof(WhiteReinforcedConcreteRoofPeak90Block), typeof(WhiteReinforcedConcreteRoofPeak180Block), typeof(WhiteReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteUnderInnerPeakBlock), typeof(WhiteReinforcedConcreteUnderInnerPeak90Block), typeof(WhiteReinforcedConcreteUnderInnerPeak180Block), typeof(WhiteReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteHalfSlopeABlock), typeof(WhiteReinforcedConcreteHalfSlopeA90Block), typeof(WhiteReinforcedConcreteHalfSlopeA180Block), typeof(WhiteReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(WhiteReinforcedConcreteHalfSlopeBBlock), typeof(WhiteReinforcedConcreteHalfSlopeB90Block), typeof(WhiteReinforcedConcreteHalfSlopeB180Block), typeof(WhiteReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(WhiteReinforcedConcreteItem))]
    public partial class WhiteReinforcedConcreteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class WhiteReinforcedConcreteHalfSlopeB270Block : Block
    { }

}
