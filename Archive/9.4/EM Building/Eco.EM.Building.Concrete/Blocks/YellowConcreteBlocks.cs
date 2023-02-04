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
    public partial class YellowReinforcedConcreteBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }

    [Serialized]
    [LocDisplayName("Yellow Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Colored Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class YellowReinforcedConcreteItem : BlockItem<YellowReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Yellow Reinforced Concrete");
        public override LocString DisplayDescription => Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Yellow!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(YellowReinforcedConcreteStacked1Block),
        typeof(YellowReinforcedConcreteStacked2Block),
        typeof(YellowReinforcedConcreteStacked3Block),
            typeof(YellowReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class YellowReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class YellowReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class YellowReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class YellowReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 YellowReinforcedConcrete

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcretePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
    }

    [RotatedVariants(typeof(YellowReinforcedConcreteLadderBlock), typeof(YellowReinforcedConcreteLadder90Block), typeof(YellowReinforcedConcreteLadder180Block), typeof(YellowReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteLadder270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteStairsBlock), typeof(YellowReinforcedConcreteStairs90Block), typeof(YellowReinforcedConcreteStairs180Block), typeof(YellowReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteStairs270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderStairsBlock), typeof(YellowReinforcedConcreteUnderStairs90Block), typeof(YellowReinforcedConcreteUnderStairs180Block), typeof(YellowReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteBasicSlopeSideBlock), typeof(YellowReinforcedConcreteBasicSlopeSide90Block), typeof(YellowReinforcedConcreteBasicSlopeSide180Block), typeof(YellowReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteBasicSlopeCornerBlock), typeof(YellowReinforcedConcreteBasicSlopeCorner90Block), typeof(YellowReinforcedConcreteBasicSlopeCorner180Block), typeof(YellowReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteBasicSlopeTurnBlock), typeof(YellowReinforcedConcreteBasicSlopeTurn90Block), typeof(YellowReinforcedConcreteBasicSlopeTurn180Block), typeof(YellowReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteBasicSlopePointBlock), typeof(YellowReinforcedConcreteBasicSlopePoint90Block), typeof(YellowReinforcedConcreteBasicSlopePoint180Block), typeof(YellowReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteStairsCornerBlock), typeof(YellowReinforcedConcreteStairsCorner90Block), typeof(YellowReinforcedConcreteStairsCorner180Block), typeof(YellowReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteStairsTurnBlock), typeof(YellowReinforcedConcreteStairsTurn90Block), typeof(YellowReinforcedConcreteStairsTurn180Block), typeof(YellowReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderSlopeSideBlock), typeof(YellowReinforcedConcreteUnderSlopeSide90Block), typeof(YellowReinforcedConcreteUnderSlopeSide180Block), typeof(YellowReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderSlopeCornerBlock), typeof(YellowReinforcedConcreteUnderSlopeCorner90Block), typeof(YellowReinforcedConcreteUnderSlopeCorner180Block), typeof(YellowReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderSlopeTurnBlock), typeof(YellowReinforcedConcreteUnderSlopeTurn90Block), typeof(YellowReinforcedConcreteUnderSlopeTurn180Block), typeof(YellowReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderSlopePeakBlock), typeof(YellowReinforcedConcreteUnderSlopePeak90Block), typeof(YellowReinforcedConcreteUnderSlopePeak180Block), typeof(YellowReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteRoofSideBlock), typeof(YellowReinforcedConcreteRoofSide90Block), typeof(YellowReinforcedConcreteRoofSide180Block), typeof(YellowReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteRoofTurnBlock), typeof(YellowReinforcedConcreteRoofTurn90Block), typeof(YellowReinforcedConcreteRoofTurn180Block), typeof(YellowReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteRoofCornerBlock), typeof(YellowReinforcedConcreteRoofCorner90Block), typeof(YellowReinforcedConcreteRoofCorner180Block), typeof(YellowReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteRoofPeakBlock), typeof(YellowReinforcedConcreteRoofPeak90Block), typeof(YellowReinforcedConcreteRoofPeak180Block), typeof(YellowReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderInnerPeakBlock), typeof(YellowReinforcedConcreteUnderInnerPeak90Block), typeof(YellowReinforcedConcreteUnderInnerPeak180Block), typeof(YellowReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteHalfSlopeABlock), typeof(YellowReinforcedConcreteHalfSlopeA90Block), typeof(YellowReinforcedConcreteHalfSlopeA180Block), typeof(YellowReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(YellowReinforcedConcreteHalfSlopeBBlock), typeof(YellowReinforcedConcreteHalfSlopeB90Block), typeof(YellowReinforcedConcreteHalfSlopeB180Block), typeof(YellowReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class YellowReinforcedConcreteHalfSlopeB270Block : Block
    { }

}
