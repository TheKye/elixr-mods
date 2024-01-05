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
    public partial class BlueReinforcedConcreteBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteBlock);
    }

    [Serialized]
    [LocDisplayName("Blue Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Currency]
    [Tag("Currency"), Tag("Concrete", 1), Tag("Colored Concrete", 1), Tag("Constructable", 1)]
    [Tier(3)]
    public partial class BlueReinforcedConcreteItem : BlockItem<BlueReinforcedConcreteBlock>
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
    public partial class BlueReinforcedConcreteFloorBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFloorBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteWallBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWallBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteThinColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteThinColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteDoubleWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteDoubleWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteUnderPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcretePeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcretePeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoadBarrierBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoadBarrierBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteFlatRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFlatRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteFenceBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFenceBlock);
    }

    [RotatedVariants(typeof(BlueReinforcedConcreteLadderBlock), typeof(BlueReinforcedConcreteLadder90Block), typeof(BlueReinforcedConcreteLadder180Block), typeof(BlueReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteLadderBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteLadder90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteLadder180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteLadder270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteStairsBlock), typeof(BlueReinforcedConcreteStairs90Block), typeof(BlueReinforcedConcreteStairs180Block), typeof(BlueReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderStairsBlock), typeof(BlueReinforcedConcreteUnderStairs90Block), typeof(BlueReinforcedConcreteUnderStairs180Block), typeof(BlueReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteBasicSlopeSideBlock), typeof(BlueReinforcedConcreteBasicSlopeSide90Block), typeof(BlueReinforcedConcreteBasicSlopeSide180Block), typeof(BlueReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteBasicSlopeCornerBlock), typeof(BlueReinforcedConcreteBasicSlopeCorner90Block), typeof(BlueReinforcedConcreteBasicSlopeCorner180Block), typeof(BlueReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteBasicSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteBasicSlopeTurnBlock), typeof(BlueReinforcedConcreteBasicSlopeTurn90Block), typeof(BlueReinforcedConcreteBasicSlopeTurn180Block), typeof(BlueReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteBasicSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteBasicSlopePointBlock), typeof(BlueReinforcedConcreteBasicSlopePoint90Block), typeof(BlueReinforcedConcreteBasicSlopePoint180Block), typeof(BlueReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteStairsCornerBlock), typeof(BlueReinforcedConcreteStairsCorner90Block), typeof(BlueReinforcedConcreteStairsCorner180Block), typeof(BlueReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteStairsCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteStairsTurnBlock), typeof(BlueReinforcedConcreteStairsTurn90Block), typeof(BlueReinforcedConcreteStairsTurn180Block), typeof(BlueReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteStairsTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteStairsTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderSlopeSideBlock), typeof(BlueReinforcedConcreteUnderSlopeSide90Block), typeof(BlueReinforcedConcreteUnderSlopeSide180Block), typeof(BlueReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderSlopeCornerBlock), typeof(BlueReinforcedConcreteUnderSlopeCorner90Block), typeof(BlueReinforcedConcreteUnderSlopeCorner180Block), typeof(BlueReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderSlopeTurnBlock), typeof(BlueReinforcedConcreteUnderSlopeTurn90Block), typeof(BlueReinforcedConcreteUnderSlopeTurn180Block), typeof(BlueReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderSlopePeakBlock), typeof(BlueReinforcedConcreteUnderSlopePeak90Block), typeof(BlueReinforcedConcreteUnderSlopePeak180Block), typeof(BlueReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteRoofSideBlock), typeof(BlueReinforcedConcreteRoofSide90Block), typeof(BlueReinforcedConcreteRoofSide180Block), typeof(BlueReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteRoofTurnBlock), typeof(BlueReinforcedConcreteRoofTurn90Block), typeof(BlueReinforcedConcreteRoofTurn180Block), typeof(BlueReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteRoofCornerBlock), typeof(BlueReinforcedConcreteRoofCorner90Block), typeof(BlueReinforcedConcreteRoofCorner180Block), typeof(BlueReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteRoofPeakBlock), typeof(BlueReinforcedConcreteRoofPeak90Block), typeof(BlueReinforcedConcreteRoofPeak180Block), typeof(BlueReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteUnderInnerPeakBlock), typeof(BlueReinforcedConcreteUnderInnerPeak90Block), typeof(BlueReinforcedConcreteUnderInnerPeak180Block), typeof(BlueReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteUnderInnerPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderInnerPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderInnerPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteUnderInnerPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteHalfSlopeABlock), typeof(BlueReinforcedConcreteHalfSlopeA90Block), typeof(BlueReinforcedConcreteHalfSlopeA180Block), typeof(BlueReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteHalfSlopeABlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeABlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeA90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeA180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeA270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA270Block);
    }


    [RotatedVariants(typeof(BlueReinforcedConcreteHalfSlopeBBlock), typeof(BlueReinforcedConcreteHalfSlopeB90Block), typeof(BlueReinforcedConcreteHalfSlopeB180Block), typeof(BlueReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(BlueReinforcedConcreteItem))]
    public partial class BlueReinforcedConcreteHalfSlopeBBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeBBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeB90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeB180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BlueReinforcedConcreteHalfSlopeB270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB270Block);
    }
}
