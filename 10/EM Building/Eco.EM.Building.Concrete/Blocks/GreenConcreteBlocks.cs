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
using Eco.EM.Framework.Extentsions;

namespace Eco.EM.Building.Concrete
{

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(3)]
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GreenReinforcedConcreteBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteBlock);
    }

    [Serialized]
    [LocDisplayName("Green Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Currency]
    [Tag("Currency"), Tag("Concrete"), Tag("Colored Concrete"), Tag("Constructable")]
    [LocDescription("A study construction material poured around a latice of rebar. And Its Green!")]
    [Tier(3)]
    public partial class GreenReinforcedConcreteItem : BlockItem<GreenReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Green Reinforced Concrete");
        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(GreenReinforcedConcreteStacked1Block),
        typeof(GreenReinforcedConcreteStacked2Block),
        typeof(GreenReinforcedConcreteStacked3Block),
            typeof(GreenReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class GreenReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreenReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreenReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreenReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GreenReinforcedConcrete

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteFloorBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFloorBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteWallBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWallBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteThinColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteThinColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteDoubleWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteDoubleWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteUnderPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcretePeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcretePeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoadBarrierBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoadBarrierBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteFlatRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFlatRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteFenceBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFenceBlock);
    }

    [RotatedVariants(typeof(GreenReinforcedConcreteLadderBlock), typeof(GreenReinforcedConcreteLadder90Block), typeof(GreenReinforcedConcreteLadder180Block), typeof(GreenReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteLadderBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteLadder90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteLadder180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteLadder270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteStairsBlock), typeof(GreenReinforcedConcreteStairs90Block), typeof(GreenReinforcedConcreteStairs180Block), typeof(GreenReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderStairsBlock), typeof(GreenReinforcedConcreteUnderStairs90Block), typeof(GreenReinforcedConcreteUnderStairs180Block), typeof(GreenReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteBasicSlopeSideBlock), typeof(GreenReinforcedConcreteBasicSlopeSide90Block), typeof(GreenReinforcedConcreteBasicSlopeSide180Block), typeof(GreenReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteBasicSlopeCornerBlock), typeof(GreenReinforcedConcreteBasicSlopeCorner90Block), typeof(GreenReinforcedConcreteBasicSlopeCorner180Block), typeof(GreenReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteBasicSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteBasicSlopeTurnBlock), typeof(GreenReinforcedConcreteBasicSlopeTurn90Block), typeof(GreenReinforcedConcreteBasicSlopeTurn180Block), typeof(GreenReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteBasicSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteBasicSlopePointBlock), typeof(GreenReinforcedConcreteBasicSlopePoint90Block), typeof(GreenReinforcedConcreteBasicSlopePoint180Block), typeof(GreenReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteStairsCornerBlock), typeof(GreenReinforcedConcreteStairsCorner90Block), typeof(GreenReinforcedConcreteStairsCorner180Block), typeof(GreenReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteStairsCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteStairsTurnBlock), typeof(GreenReinforcedConcreteStairsTurn90Block), typeof(GreenReinforcedConcreteStairsTurn180Block), typeof(GreenReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteStairsTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderSlopeSideBlock), typeof(GreenReinforcedConcreteUnderSlopeSide90Block), typeof(GreenReinforcedConcreteUnderSlopeSide180Block), typeof(GreenReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderSlopeCornerBlock), typeof(GreenReinforcedConcreteUnderSlopeCorner90Block), typeof(GreenReinforcedConcreteUnderSlopeCorner180Block), typeof(GreenReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderSlopeTurnBlock), typeof(GreenReinforcedConcreteUnderSlopeTurn90Block), typeof(GreenReinforcedConcreteUnderSlopeTurn180Block), typeof(GreenReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderSlopePeakBlock), typeof(GreenReinforcedConcreteUnderSlopePeak90Block), typeof(GreenReinforcedConcreteUnderSlopePeak180Block), typeof(GreenReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteRoofSideBlock), typeof(GreenReinforcedConcreteRoofSide90Block), typeof(GreenReinforcedConcreteRoofSide180Block), typeof(GreenReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteRoofTurnBlock), typeof(GreenReinforcedConcreteRoofTurn90Block), typeof(GreenReinforcedConcreteRoofTurn180Block), typeof(GreenReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteRoofCornerBlock), typeof(GreenReinforcedConcreteRoofCorner90Block), typeof(GreenReinforcedConcreteRoofCorner180Block), typeof(GreenReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteRoofPeakBlock), typeof(GreenReinforcedConcreteRoofPeak90Block), typeof(GreenReinforcedConcreteRoofPeak180Block), typeof(GreenReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderInnerPeakBlock), typeof(GreenReinforcedConcreteUnderInnerPeak90Block), typeof(GreenReinforcedConcreteUnderInnerPeak180Block), typeof(GreenReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderInnerPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderInnerPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderInnerPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderInnerPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteHalfSlopeABlock), typeof(GreenReinforcedConcreteHalfSlopeA90Block), typeof(GreenReinforcedConcreteHalfSlopeA180Block), typeof(GreenReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteHalfSlopeABlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeABlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeA90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeA180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeA270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA270Block);
    }


    [RotatedVariants(typeof(GreenReinforcedConcreteHalfSlopeBBlock), typeof(GreenReinforcedConcreteHalfSlopeB90Block), typeof(GreenReinforcedConcreteHalfSlopeB180Block), typeof(GreenReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteHalfSlopeBBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeBBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeB90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeB180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeB270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB270Block);
    }
}
