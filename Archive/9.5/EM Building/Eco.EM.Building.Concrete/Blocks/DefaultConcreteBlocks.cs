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
    public partial class ColorReinforcedConcreteBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteBlock);
    }

    [Serialized]
    [LocDisplayName("Color Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency"), Tag("Concrete", 1), Tag("Colored Concrete", 1), Tag("Constructable", 1)]
    [Tier(3)]
    public partial class ColorReinforcedConcreteItem : BlockItem<ColorReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Color Reinforced Concrete");
        public override LocString DisplayDescription => Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Color!");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
        typeof(ColorReinforcedConcreteStacked1Block),
        typeof(ColorReinforcedConcreteStacked2Block),
        typeof(ColorReinforcedConcreteStacked3Block),
            typeof(ColorReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized, Solid] public class ColorReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class ColorReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class ColorReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class ColorReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 ColorReinforcedConcrete

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteFloorBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFloorBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteWallBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWallBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem); 
        public override Type BaseType => typeof(ReinforcedConcreteCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem); 
        public override Type BaseType => typeof(ReinforcedConcreteRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteRoofPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteRoofCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoofCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteThinColumnBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteThinColumnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteDoubleWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteDoubleWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteUnderPeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteUnderPeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcretePeakSetBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcretePeakSetBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteRoadBarrierBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteRoadBarrierBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteFlatRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFlatRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteFenceBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ColorReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteFenceBlock);
    }

    [RotatedVariants(typeof(ColorReinforcedConcreteLadderBlock), typeof(ColorReinforcedConcreteLadder90Block), typeof(ColorReinforcedConcreteLadder180Block), typeof(ColorReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteLadderBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteLadder90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteLadder180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteLadder270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadder270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteStairsBlock), typeof(ColorReinforcedConcreteStairs90Block), typeof(ColorReinforcedConcreteStairs180Block), typeof(ColorReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairs270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteUnderStairsBlock), typeof(ColorReinforcedConcreteUnderStairs90Block), typeof(ColorReinforcedConcreteUnderStairs180Block), typeof(ColorReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteUnderStairsBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairsBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderStairs90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderStairs180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderStairs270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderStairs270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteBasicSlopeSideBlock), typeof(ColorReinforcedConcreteBasicSlopeSide90Block), typeof(ColorReinforcedConcreteBasicSlopeSide180Block), typeof(ColorReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteBasicSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeSide270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteBasicSlopeCornerBlock), typeof(ColorReinforcedConcreteBasicSlopeCorner90Block), typeof(ColorReinforcedConcreteBasicSlopeCorner180Block), typeof(ColorReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteBasicSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeCorner270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteBasicSlopeTurnBlock), typeof(ColorReinforcedConcreteBasicSlopeTurn90Block), typeof(ColorReinforcedConcreteBasicSlopeTurn180Block), typeof(ColorReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteBasicSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopeTurn270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteBasicSlopePointBlock), typeof(ColorReinforcedConcreteBasicSlopePoint90Block), typeof(ColorReinforcedConcreteBasicSlopePoint180Block), typeof(ColorReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteBasicSlopePointBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePointBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopePoint90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopePoint180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteBasicSlopePoint270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteBasicSlopePoint270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteStairsCornerBlock), typeof(ColorReinforcedConcreteStairsCorner90Block), typeof(ColorReinforcedConcreteStairsCorner180Block), typeof(ColorReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteStairsCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteStairsCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteStairsCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteStairsCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsCorner270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteStairsTurnBlock), typeof(ColorReinforcedConcreteStairsTurn90Block), typeof(ColorReinforcedConcreteStairsTurn180Block), typeof(ColorReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteStairsTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteStairsTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteStairsTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteStairsTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteStairsTurn270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteUnderSlopeSideBlock), typeof(ColorReinforcedConcreteUnderSlopeSide90Block), typeof(ColorReinforcedConcreteUnderSlopeSide180Block), typeof(ColorReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteUnderSlopeSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopeSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopeSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteLadderBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopeSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeSide270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteUnderSlopeCornerBlock), typeof(ColorReinforcedConcreteUnderSlopeCorner90Block), typeof(ColorReinforcedConcreteUnderSlopeCorner180Block), typeof(ColorReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteUnderSlopeCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopeCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopeCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopeCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeCorner270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteUnderSlopeTurnBlock), typeof(ColorReinforcedConcreteUnderSlopeTurn90Block), typeof(ColorReinforcedConcreteUnderSlopeTurn180Block), typeof(ColorReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteUnderSlopeTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopeTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopeTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopeTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopeTurn270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteUnderSlopePeakBlock), typeof(ColorReinforcedConcreteUnderSlopePeak90Block), typeof(ColorReinforcedConcreteUnderSlopePeak180Block), typeof(ColorReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteUnderSlopePeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopePeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopePeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderSlopePeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderSlopePeak270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteRoofSideBlock), typeof(ColorReinforcedConcreteRoofSide90Block), typeof(ColorReinforcedConcreteRoofSide180Block), typeof(ColorReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteRoofSideBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSideBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofSide90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofSide180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofSide270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofSide270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteRoofTurnBlock), typeof(ColorReinforcedConcreteRoofTurn90Block), typeof(ColorReinforcedConcreteRoofTurn180Block), typeof(ColorReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteRoofTurnBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofTurn90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofTurn180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofTurn270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofTurn270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteRoofCornerBlock), typeof(ColorReinforcedConcreteRoofCorner90Block), typeof(ColorReinforcedConcreteRoofCorner180Block), typeof(ColorReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteRoofCornerBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofCorner90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofCorner180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofCorner270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofCorner270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteRoofPeakBlock), typeof(ColorReinforcedConcreteRoofPeak90Block), typeof(ColorReinforcedConcreteRoofPeak180Block), typeof(ColorReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteRoofPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteRoofPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteRoofPeak270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteUnderInnerPeakBlock), typeof(ColorReinforcedConcreteUnderInnerPeak90Block), typeof(ColorReinforcedConcreteUnderInnerPeak180Block), typeof(ColorReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteUnderInnerPeakBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeakBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderInnerPeak90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderInnerPeak180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteUnderInnerPeak270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteUnderInnerPeak270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteHalfSlopeABlock), typeof(ColorReinforcedConcreteHalfSlopeA90Block), typeof(ColorReinforcedConcreteHalfSlopeA180Block), typeof(ColorReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteHalfSlopeABlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeABlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteHalfSlopeA90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteHalfSlopeA180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteHalfSlopeA270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeA270Block);
    }


    [RotatedVariants(typeof(ColorReinforcedConcreteHalfSlopeBBlock), typeof(ColorReinforcedConcreteHalfSlopeB90Block), typeof(ColorReinforcedConcreteHalfSlopeB180Block), typeof(ColorReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(ColorReinforcedConcreteItem))]
    public partial class ColorReinforcedConcreteHalfSlopeBBlock : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeBBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteHalfSlopeB90Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteHalfSlopeB180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class ColorReinforcedConcreteHalfSlopeB270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteHalfSlopeB270Block);
    }
}
