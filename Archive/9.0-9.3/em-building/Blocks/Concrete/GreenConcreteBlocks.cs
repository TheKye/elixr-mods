using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Core.Items;

namespace Eco.EM.Building
{

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(3)]
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GreenReinforcedConcreteBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }

    [Serialized]
    [LocDisplayName("Green Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class GreenReinforcedConcreteItem :
    BlockItem<GreenReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Green Reinforced Concrete"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Green!"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
        typeof(GreenReinforcedConcreteStacked1Block),
        typeof(GreenReinforcedConcreteStacked2Block),
        typeof(GreenReinforcedConcreteStacked3Block),
            typeof(GreenReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class GreenReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreenReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreenReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreenReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GreenReinforcedConcrete


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcretePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GreenReinforcedConcreteItem); } }
    }



    [RotatedVariants(typeof(GreenReinforcedConcreteLadderBlock), typeof(GreenReinforcedConcreteLadder90Block), typeof(GreenReinforcedConcreteLadder180Block), typeof(GreenReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteLadder270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteStairsBlock), typeof(GreenReinforcedConcreteStairs90Block), typeof(GreenReinforcedConcreteStairs180Block), typeof(GreenReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairs270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderStairsBlock), typeof(GreenReinforcedConcreteUnderStairs90Block), typeof(GreenReinforcedConcreteUnderStairs180Block), typeof(GreenReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteBasicSlopeSideBlock), typeof(GreenReinforcedConcreteBasicSlopeSide90Block), typeof(GreenReinforcedConcreteBasicSlopeSide180Block), typeof(GreenReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteBasicSlopeCornerBlock), typeof(GreenReinforcedConcreteBasicSlopeCorner90Block), typeof(GreenReinforcedConcreteBasicSlopeCorner180Block), typeof(GreenReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteBasicSlopeTurnBlock), typeof(GreenReinforcedConcreteBasicSlopeTurn90Block), typeof(GreenReinforcedConcreteBasicSlopeTurn180Block), typeof(GreenReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteBasicSlopePointBlock), typeof(GreenReinforcedConcreteBasicSlopePoint90Block), typeof(GreenReinforcedConcreteBasicSlopePoint180Block), typeof(GreenReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteStairsCornerBlock), typeof(GreenReinforcedConcreteStairsCorner90Block), typeof(GreenReinforcedConcreteStairsCorner180Block), typeof(GreenReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteStairsTurnBlock), typeof(GreenReinforcedConcreteStairsTurn90Block), typeof(GreenReinforcedConcreteStairsTurn180Block), typeof(GreenReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderSlopeSideBlock), typeof(GreenReinforcedConcreteUnderSlopeSide90Block), typeof(GreenReinforcedConcreteUnderSlopeSide180Block), typeof(GreenReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderSlopeCornerBlock), typeof(GreenReinforcedConcreteUnderSlopeCorner90Block), typeof(GreenReinforcedConcreteUnderSlopeCorner180Block), typeof(GreenReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderSlopeTurnBlock), typeof(GreenReinforcedConcreteUnderSlopeTurn90Block), typeof(GreenReinforcedConcreteUnderSlopeTurn180Block), typeof(GreenReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderSlopePeakBlock), typeof(GreenReinforcedConcreteUnderSlopePeak90Block), typeof(GreenReinforcedConcreteUnderSlopePeak180Block), typeof(GreenReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteRoofSideBlock), typeof(GreenReinforcedConcreteRoofSide90Block), typeof(GreenReinforcedConcreteRoofSide180Block), typeof(GreenReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteRoofTurnBlock), typeof(GreenReinforcedConcreteRoofTurn90Block), typeof(GreenReinforcedConcreteRoofTurn180Block), typeof(GreenReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteRoofCornerBlock), typeof(GreenReinforcedConcreteRoofCorner90Block), typeof(GreenReinforcedConcreteRoofCorner180Block), typeof(GreenReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteRoofPeakBlock), typeof(GreenReinforcedConcreteRoofPeak90Block), typeof(GreenReinforcedConcreteRoofPeak180Block), typeof(GreenReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteUnderInnerPeakBlock), typeof(GreenReinforcedConcreteUnderInnerPeak90Block), typeof(GreenReinforcedConcreteUnderInnerPeak180Block), typeof(GreenReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteHalfSlopeABlock), typeof(GreenReinforcedConcreteHalfSlopeA90Block), typeof(GreenReinforcedConcreteHalfSlopeA180Block), typeof(GreenReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(GreenReinforcedConcreteHalfSlopeBBlock), typeof(GreenReinforcedConcreteHalfSlopeB90Block), typeof(GreenReinforcedConcreteHalfSlopeB180Block), typeof(GreenReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(GreenReinforcedConcreteItem))]
    public partial class GreenReinforcedConcreteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class GreenReinforcedConcreteHalfSlopeB270Block : Block
    { }

}
