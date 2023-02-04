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
    public partial class BlueReinforcedConcreteBlock :
       Block
       , IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
    }

    [Serialized]
    [LocDisplayName("Blue Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Colored Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class BlueReinforcedConcreteItem :
    BlockItem<BlueReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Blue Reinforced Concrete");
        public override LocString DisplayDescription => Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Blue!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(BlueReinforcedConcreteStacked1Block),
        typeof(BlueReinforcedConcreteStacked2Block),
        typeof(BlueReinforcedConcreteStacked3Block),
            typeof(BlueReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class BlueReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlueReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlueReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlueReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 BlueReinforcedConcrete


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcretePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(BlueReinforcedConcreteItem); } }
    }



    [RotatedVariants(typeof(BlueReinforcedConcreteLadderBlock), typeof(BlueReinforcedConcreteLadder90Block), typeof(BlueReinforcedConcreteLadder180Block), typeof(BlueReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteLadder270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteStairsBlock), typeof(BlueReinforcedConcreteStairs90Block), typeof(BlueReinforcedConcreteStairs180Block), typeof(BlueReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairs270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderStairsBlock), typeof(BlueReinforcedConcreteUnderStairs90Block), typeof(BlueReinforcedConcreteUnderStairs180Block), typeof(BlueReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteBasicSlopeSideBlock), typeof(BlueReinforcedConcreteBasicSlopeSide90Block), typeof(BlueReinforcedConcreteBasicSlopeSide180Block), typeof(BlueReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteBasicSlopeCornerBlock), typeof(BlueReinforcedConcreteBasicSlopeCorner90Block), typeof(BlueReinforcedConcreteBasicSlopeCorner180Block), typeof(BlueReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteBasicSlopeTurnBlock), typeof(BlueReinforcedConcreteBasicSlopeTurn90Block), typeof(BlueReinforcedConcreteBasicSlopeTurn180Block), typeof(BlueReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteBasicSlopePointBlock), typeof(BlueReinforcedConcreteBasicSlopePoint90Block), typeof(BlueReinforcedConcreteBasicSlopePoint180Block), typeof(BlueReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteStairsCornerBlock), typeof(BlueReinforcedConcreteStairsCorner90Block), typeof(BlueReinforcedConcreteStairsCorner180Block), typeof(BlueReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteStairsTurnBlock), typeof(BlueReinforcedConcreteStairsTurn90Block), typeof(BlueReinforcedConcreteStairsTurn180Block), typeof(BlueReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderSlopeSideBlock), typeof(BlueReinforcedConcreteUnderSlopeSide90Block), typeof(BlueReinforcedConcreteUnderSlopeSide180Block), typeof(BlueReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderSlopeCornerBlock), typeof(BlueReinforcedConcreteUnderSlopeCorner90Block), typeof(BlueReinforcedConcreteUnderSlopeCorner180Block), typeof(BlueReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderSlopeTurnBlock), typeof(BlueReinforcedConcreteUnderSlopeTurn90Block), typeof(BlueReinforcedConcreteUnderSlopeTurn180Block), typeof(BlueReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderSlopePeakBlock), typeof(BlueReinforcedConcreteUnderSlopePeak90Block), typeof(BlueReinforcedConcreteUnderSlopePeak180Block), typeof(BlueReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteRoofSideBlock), typeof(BlueReinforcedConcreteRoofSide90Block), typeof(BlueReinforcedConcreteRoofSide180Block), typeof(BlueReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteRoofTurnBlock), typeof(BlueReinforcedConcreteRoofTurn90Block), typeof(BlueReinforcedConcreteRoofTurn180Block), typeof(BlueReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteRoofCornerBlock), typeof(BlueReinforcedConcreteRoofCorner90Block), typeof(BlueReinforcedConcreteRoofCorner180Block), typeof(BlueReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteRoofPeakBlock), typeof(BlueReinforcedConcreteRoofPeak90Block), typeof(BlueReinforcedConcreteRoofPeak180Block), typeof(BlueReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderInnerPeakBlock), typeof(BlueReinforcedConcreteUnderInnerPeak90Block), typeof(BlueReinforcedConcreteUnderInnerPeak180Block), typeof(BlueReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteHalfSlopeABlock), typeof(BlueReinforcedConcreteHalfSlopeA90Block), typeof(BlueReinforcedConcreteHalfSlopeA180Block), typeof(BlueReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(BlueReinforcedConcreteHalfSlopeBBlock), typeof(BlueReinforcedConcreteHalfSlopeB90Block), typeof(BlueReinforcedConcreteHalfSlopeB180Block), typeof(BlueReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeB270Block : Block
    { }

}
