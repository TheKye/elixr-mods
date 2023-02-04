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
    public partial class BlackReinforcedConcreteBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }

    [Serialized]
    [LocDisplayName("Black Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Colored Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class BlackReinforcedConcreteItem :
    BlockItem<BlackReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Black Reinforced Concrete");
        public override LocString DisplayDescription => Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Black!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(BlackReinforcedConcreteStacked1Block),
        typeof(BlackReinforcedConcreteStacked2Block),
        typeof(BlackReinforcedConcreteStacked3Block),
            typeof(BlackReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class BlackReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlackReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlackReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlackReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 BlackReinforcedConcrete

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcretePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackReinforcedConcreteItem);
    }



    [RotatedVariants(typeof(BlackReinforcedConcreteLadderBlock), typeof(BlackReinforcedConcreteLadder90Block), typeof(BlackReinforcedConcreteLadder180Block), typeof(BlackReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteLadder270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteStairsBlock), typeof(BlackReinforcedConcreteStairs90Block), typeof(BlackReinforcedConcreteStairs180Block), typeof(BlackReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteStairs270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteUnderStairsBlock), typeof(BlackReinforcedConcreteUnderStairs90Block), typeof(BlackReinforcedConcreteUnderStairs180Block), typeof(BlackReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteBasicSlopeSideBlock), typeof(BlackReinforcedConcreteBasicSlopeSide90Block), typeof(BlackReinforcedConcreteBasicSlopeSide180Block), typeof(BlackReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteBasicSlopeCornerBlock), typeof(BlackReinforcedConcreteBasicSlopeCorner90Block), typeof(BlackReinforcedConcreteBasicSlopeCorner180Block), typeof(BlackReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteBasicSlopeTurnBlock), typeof(BlackReinforcedConcreteBasicSlopeTurn90Block), typeof(BlackReinforcedConcreteBasicSlopeTurn180Block), typeof(BlackReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteBasicSlopePointBlock), typeof(BlackReinforcedConcreteBasicSlopePoint90Block), typeof(BlackReinforcedConcreteBasicSlopePoint180Block), typeof(BlackReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteStairsCornerBlock), typeof(BlackReinforcedConcreteStairsCorner90Block), typeof(BlackReinforcedConcreteStairsCorner180Block), typeof(BlackReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteStairsTurnBlock), typeof(BlackReinforcedConcreteStairsTurn90Block), typeof(BlackReinforcedConcreteStairsTurn180Block), typeof(BlackReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteUnderSlopeSideBlock), typeof(BlackReinforcedConcreteUnderSlopeSide90Block), typeof(BlackReinforcedConcreteUnderSlopeSide180Block), typeof(BlackReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteUnderSlopeCornerBlock), typeof(BlackReinforcedConcreteUnderSlopeCorner90Block), typeof(BlackReinforcedConcreteUnderSlopeCorner180Block), typeof(BlackReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteUnderSlopeTurnBlock), typeof(BlackReinforcedConcreteUnderSlopeTurn90Block), typeof(BlackReinforcedConcreteUnderSlopeTurn180Block), typeof(BlackReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteUnderSlopePeakBlock), typeof(BlackReinforcedConcreteUnderSlopePeak90Block), typeof(BlackReinforcedConcreteUnderSlopePeak180Block), typeof(BlackReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteRoofSideBlock), typeof(BlackReinforcedConcreteRoofSide90Block), typeof(BlackReinforcedConcreteRoofSide180Block), typeof(BlackReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteRoofTurnBlock), typeof(BlackReinforcedConcreteRoofTurn90Block), typeof(BlackReinforcedConcreteRoofTurn180Block), typeof(BlackReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteRoofCornerBlock), typeof(BlackReinforcedConcreteRoofCorner90Block), typeof(BlackReinforcedConcreteRoofCorner180Block), typeof(BlackReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteRoofPeakBlock), typeof(BlackReinforcedConcreteRoofPeak90Block), typeof(BlackReinforcedConcreteRoofPeak180Block), typeof(BlackReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteUnderInnerPeakBlock), typeof(BlackReinforcedConcreteUnderInnerPeak90Block), typeof(BlackReinforcedConcreteUnderInnerPeak180Block), typeof(BlackReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteHalfSlopeABlock), typeof(BlackReinforcedConcreteHalfSlopeA90Block), typeof(BlackReinforcedConcreteHalfSlopeA180Block), typeof(BlackReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(BlackReinforcedConcreteHalfSlopeBBlock), typeof(BlackReinforcedConcreteHalfSlopeB90Block), typeof(BlackReinforcedConcreteHalfSlopeB180Block), typeof(BlackReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(BlackReinforcedConcreteItem))]
    public partial class BlackReinforcedConcreteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlackReinforcedConcreteHalfSlopeB270Block : Block
    { }

}
