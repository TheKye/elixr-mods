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
    public partial class RedReinforcedConcreteBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteBlock);
    }

    [Serialized]
    [LocDisplayName("Red Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Currency]
    [Tag("Currency"), Tag("Concrete", 1), Tag("Colored Concrete", 1), Tag("Constructable", 1)]
    [Tier(3)]
    public partial class RedReinforcedConcreteItem : BlockItem<RedReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Red Reinforced Concrete");
        public override LocString DisplayDescription => Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Red!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(RedReinforcedConcreteStacked1Block),
        typeof(RedReinforcedConcreteStacked2Block),
        typeof(RedReinforcedConcreteStacked3Block),
            typeof(RedReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class RedReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class RedReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class RedReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class RedReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 RedReinforcedConcrete

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteFloorBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFloorBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteWallBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWallBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteRoofPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteRoofCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteThinColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteThinColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteDoubleWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteDoubleWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteUnderPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteUnderPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcretePeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcretePeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteRoadBarrierBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoadBarrierBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteFlatRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFlatRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteFenceBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFenceBlock);
    }

    [RotatedVariants(typeof(RedReinforcedConcreteLadderBlock), typeof(RedReinforcedConcreteLadder90Block), typeof(RedReinforcedConcreteLadder180Block), typeof(RedReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteLadderBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteLadder90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteLadder180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteLadder270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteStairsBlock), typeof(RedReinforcedConcreteStairs90Block), typeof(RedReinforcedConcreteStairs180Block), typeof(RedReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteUnderStairsBlock), typeof(RedReinforcedConcreteUnderStairs90Block), typeof(RedReinforcedConcreteUnderStairs180Block), typeof(RedReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteUnderStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteBasicSlopeSideBlock), typeof(RedReinforcedConcreteBasicSlopeSide90Block), typeof(RedReinforcedConcreteBasicSlopeSide180Block), typeof(RedReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteBasicSlopeCornerBlock), typeof(RedReinforcedConcreteBasicSlopeCorner90Block), typeof(RedReinforcedConcreteBasicSlopeCorner180Block), typeof(RedReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteBasicSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteBasicSlopeTurnBlock), typeof(RedReinforcedConcreteBasicSlopeTurn90Block), typeof(RedReinforcedConcreteBasicSlopeTurn180Block), typeof(RedReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteBasicSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteBasicSlopePointBlock), typeof(RedReinforcedConcreteBasicSlopePoint90Block), typeof(RedReinforcedConcreteBasicSlopePoint180Block), typeof(RedReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteStairsCornerBlock), typeof(RedReinforcedConcreteStairsCorner90Block), typeof(RedReinforcedConcreteStairsCorner180Block), typeof(RedReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteStairsCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteStairsCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteStairsCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteStairsCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteStairsTurnBlock), typeof(RedReinforcedConcreteStairsTurn90Block), typeof(RedReinforcedConcreteStairsTurn180Block), typeof(RedReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteStairsTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteStairsTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteStairsTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteStairsTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteUnderSlopeSideBlock), typeof(RedReinforcedConcreteUnderSlopeSide90Block), typeof(RedReinforcedConcreteUnderSlopeSide180Block), typeof(RedReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteUnderSlopeCornerBlock), typeof(RedReinforcedConcreteUnderSlopeCorner90Block), typeof(RedReinforcedConcreteUnderSlopeCorner180Block), typeof(RedReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteUnderSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteUnderSlopeTurnBlock), typeof(RedReinforcedConcreteUnderSlopeTurn90Block), typeof(RedReinforcedConcreteUnderSlopeTurn180Block), typeof(RedReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteUnderSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteUnderSlopePeakBlock), typeof(RedReinforcedConcreteUnderSlopePeak90Block), typeof(RedReinforcedConcreteUnderSlopePeak180Block), typeof(RedReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteRoofSideBlock), typeof(RedReinforcedConcreteRoofSide90Block), typeof(RedReinforcedConcreteRoofSide180Block), typeof(RedReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteRoofSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteRoofTurnBlock), typeof(RedReinforcedConcreteRoofTurn90Block), typeof(RedReinforcedConcreteRoofTurn180Block), typeof(RedReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteRoofTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteRoofCornerBlock), typeof(RedReinforcedConcreteRoofCorner90Block), typeof(RedReinforcedConcreteRoofCorner180Block), typeof(RedReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteRoofPeakBlock), typeof(RedReinforcedConcreteRoofPeak90Block), typeof(RedReinforcedConcreteRoofPeak180Block), typeof(RedReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteUnderInnerPeakBlock), typeof(RedReinforcedConcreteUnderInnerPeak90Block), typeof(RedReinforcedConcreteUnderInnerPeak180Block), typeof(RedReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteUnderInnerPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderInnerPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderInnerPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteUnderInnerPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteHalfSlopeABlock), typeof(RedReinforcedConcreteHalfSlopeA90Block), typeof(RedReinforcedConcreteHalfSlopeA180Block), typeof(RedReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteHalfSlopeABlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeABlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteHalfSlopeA90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteHalfSlopeA180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteHalfSlopeA270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA270Block);
    }


    [RotatedVariants(typeof(RedReinforcedConcreteHalfSlopeBBlock), typeof(RedReinforcedConcreteHalfSlopeB90Block), typeof(RedReinforcedConcreteHalfSlopeB180Block), typeof(RedReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(RedReinforcedConcreteItem))]
    public partial class RedReinforcedConcreteHalfSlopeBBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeBBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteHalfSlopeB90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteHalfSlopeB180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class RedReinforcedConcreteHalfSlopeB270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB270Block);
    }
}
