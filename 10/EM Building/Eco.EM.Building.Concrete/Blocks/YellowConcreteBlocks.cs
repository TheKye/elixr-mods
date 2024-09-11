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
    [Tag("Constructable")]
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class YellowReinforcedConcreteBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteBlock);
    }

    [Serialized]
    [LocDisplayName("Yellow Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Currency]
    [Tag("Currency"), Tag("Concrete"), Tag("Colored Concrete"), Tag("Constructable")]
    [LocDescription("A study construction material poured around a latice of rebar. And Its Yellow!")]
    [Tier(3)]
    public partial class YellowReinforcedConcreteItem : BlockItem<YellowReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Yellow Reinforced Concrete");

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
    [Tag("Constructable")]
    [IsForm(typeof(FloorFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteFloorBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFloorBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(WallFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteWallBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWallBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(CubeFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(ColumnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofPeakSetFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofCubeFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinColumnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteThinColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteThinColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(DoubleWindowFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteDoubleWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteDoubleWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderPeakSetFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteUnderPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(PeakSetFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcretePeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcretePeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(RoadBarrierFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoadBarrierBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoadBarrierBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(FlatRoofFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteFlatRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFlatRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(FenceFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteFenceBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFenceBlock);
    }

    [RotatedVariants(typeof(YellowReinforcedConcreteLadderBlock), typeof(YellowReinforcedConcreteLadder90Block), typeof(YellowReinforcedConcreteLadder180Block), typeof(YellowReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(LadderFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteLadderBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteLadder90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteLadder180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteLadder270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteStairsBlock), typeof(YellowReinforcedConcreteStairs90Block), typeof(YellowReinforcedConcreteStairs180Block), typeof(YellowReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(StairsFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderStairsBlock), typeof(YellowReinforcedConcreteUnderStairs90Block), typeof(YellowReinforcedConcreteUnderStairs180Block), typeof(YellowReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderStairsFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteBasicSlopeSideBlock), typeof(YellowReinforcedConcreteBasicSlopeSide90Block), typeof(YellowReinforcedConcreteBasicSlopeSide180Block), typeof(YellowReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteBasicSlopeCornerBlock), typeof(YellowReinforcedConcreteBasicSlopeCorner90Block), typeof(YellowReinforcedConcreteBasicSlopeCorner180Block), typeof(YellowReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteBasicSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteBasicSlopeTurnBlock), typeof(YellowReinforcedConcreteBasicSlopeTurn90Block), typeof(YellowReinforcedConcreteBasicSlopeTurn180Block), typeof(YellowReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteBasicSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteBasicSlopePointBlock), typeof(YellowReinforcedConcreteBasicSlopePoint90Block), typeof(YellowReinforcedConcreteBasicSlopePoint180Block), typeof(YellowReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(BasicSlopePointFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteStairsCornerBlock), typeof(YellowReinforcedConcreteStairsCorner90Block), typeof(YellowReinforcedConcreteStairsCorner180Block), typeof(YellowReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(StairsCornerFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteStairsCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteStairsCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteStairsCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteStairsCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteStairsTurnBlock), typeof(YellowReinforcedConcreteStairsTurn90Block), typeof(YellowReinforcedConcreteStairsTurn180Block), typeof(YellowReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(StairsTurnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteStairsTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteStairsTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteStairsTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteStairsTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderSlopeSideBlock), typeof(YellowReinforcedConcreteUnderSlopeSide90Block), typeof(YellowReinforcedConcreteUnderSlopeSide180Block), typeof(YellowReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderSlopeCornerBlock), typeof(YellowReinforcedConcreteUnderSlopeCorner90Block), typeof(YellowReinforcedConcreteUnderSlopeCorner180Block), typeof(YellowReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderSlopeTurnBlock), typeof(YellowReinforcedConcreteUnderSlopeTurn90Block), typeof(YellowReinforcedConcreteUnderSlopeTurn180Block), typeof(YellowReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderSlopePeakBlock), typeof(YellowReinforcedConcreteUnderSlopePeak90Block), typeof(YellowReinforcedConcreteUnderSlopePeak180Block), typeof(YellowReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteRoofSideBlock), typeof(YellowReinforcedConcreteRoofSide90Block), typeof(YellowReinforcedConcreteRoofSide180Block), typeof(YellowReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofSideFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteRoofTurnBlock), typeof(YellowReinforcedConcreteRoofTurn90Block), typeof(YellowReinforcedConcreteRoofTurn180Block), typeof(YellowReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofTurnFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteRoofCornerBlock), typeof(YellowReinforcedConcreteRoofCorner90Block), typeof(YellowReinforcedConcreteRoofCorner180Block), typeof(YellowReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofCornerFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteRoofPeakBlock), typeof(YellowReinforcedConcreteRoofPeak90Block), typeof(YellowReinforcedConcreteRoofPeak180Block), typeof(YellowReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(RoofPeakFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteUnderInnerPeakBlock), typeof(YellowReinforcedConcreteUnderInnerPeak90Block), typeof(YellowReinforcedConcreteUnderInnerPeak180Block), typeof(YellowReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteUnderInnerPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderInnerPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderInnerPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteUnderInnerPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteHalfSlopeABlock), typeof(YellowReinforcedConcreteHalfSlopeA90Block), typeof(YellowReinforcedConcreteHalfSlopeA180Block), typeof(YellowReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(HalfSlopeAFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteHalfSlopeABlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeABlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteHalfSlopeA90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteHalfSlopeA180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteHalfSlopeA270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA270Block);
    }


    [RotatedVariants(typeof(YellowReinforcedConcreteHalfSlopeBBlock), typeof(YellowReinforcedConcreteHalfSlopeB90Block), typeof(YellowReinforcedConcreteHalfSlopeB180Block), typeof(YellowReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(HalfSlopeBFormType), typeof(YellowReinforcedConcreteItem))]
    public partial class YellowReinforcedConcreteHalfSlopeBBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeBBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteHalfSlopeB90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteHalfSlopeB180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteHalfSlopeB270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB270Block);
    }
}
