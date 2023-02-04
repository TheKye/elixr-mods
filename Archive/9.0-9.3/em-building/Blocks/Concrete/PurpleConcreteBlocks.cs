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
    public partial class PurpleReinforcedConcreteBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }

    [Serialized]
    [LocDisplayName("Purple Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class PurpleReinforcedConcreteItem :
    BlockItem<PurpleReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Purple Reinforced Concrete"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Purple!"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
        typeof(PurpleReinforcedConcreteStacked1Block),
        typeof(PurpleReinforcedConcreteStacked2Block),
        typeof(PurpleReinforcedConcreteStacked3Block),
            typeof(PurpleReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class PurpleReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class PurpleReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 PurpleReinforcedConcrete


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcretePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(PurpleReinforcedConcreteItem); } }
    }



    [RotatedVariants(typeof(PurpleReinforcedConcreteLadderBlock), typeof(PurpleReinforcedConcreteLadder90Block), typeof(PurpleReinforcedConcreteLadder180Block), typeof(PurpleReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteLadder270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteStairsBlock), typeof(PurpleReinforcedConcreteStairs90Block), typeof(PurpleReinforcedConcreteStairs180Block), typeof(PurpleReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteStairs270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteUnderStairsBlock), typeof(PurpleReinforcedConcreteUnderStairs90Block), typeof(PurpleReinforcedConcreteUnderStairs180Block), typeof(PurpleReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteBasicSlopeSideBlock), typeof(PurpleReinforcedConcreteBasicSlopeSide90Block), typeof(PurpleReinforcedConcreteBasicSlopeSide180Block), typeof(PurpleReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteBasicSlopeCornerBlock), typeof(PurpleReinforcedConcreteBasicSlopeCorner90Block), typeof(PurpleReinforcedConcreteBasicSlopeCorner180Block), typeof(PurpleReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteBasicSlopeTurnBlock), typeof(PurpleReinforcedConcreteBasicSlopeTurn90Block), typeof(PurpleReinforcedConcreteBasicSlopeTurn180Block), typeof(PurpleReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteBasicSlopePointBlock), typeof(PurpleReinforcedConcreteBasicSlopePoint90Block), typeof(PurpleReinforcedConcreteBasicSlopePoint180Block), typeof(PurpleReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteStairsCornerBlock), typeof(PurpleReinforcedConcreteStairsCorner90Block), typeof(PurpleReinforcedConcreteStairsCorner180Block), typeof(PurpleReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteStairsTurnBlock), typeof(PurpleReinforcedConcreteStairsTurn90Block), typeof(PurpleReinforcedConcreteStairsTurn180Block), typeof(PurpleReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteUnderSlopeSideBlock), typeof(PurpleReinforcedConcreteUnderSlopeSide90Block), typeof(PurpleReinforcedConcreteUnderSlopeSide180Block), typeof(PurpleReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteUnderSlopeCornerBlock), typeof(PurpleReinforcedConcreteUnderSlopeCorner90Block), typeof(PurpleReinforcedConcreteUnderSlopeCorner180Block), typeof(PurpleReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteUnderSlopeTurnBlock), typeof(PurpleReinforcedConcreteUnderSlopeTurn90Block), typeof(PurpleReinforcedConcreteUnderSlopeTurn180Block), typeof(PurpleReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteUnderSlopePeakBlock), typeof(PurpleReinforcedConcreteUnderSlopePeak90Block), typeof(PurpleReinforcedConcreteUnderSlopePeak180Block), typeof(PurpleReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteRoofSideBlock), typeof(PurpleReinforcedConcreteRoofSide90Block), typeof(PurpleReinforcedConcreteRoofSide180Block), typeof(PurpleReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteRoofTurnBlock), typeof(PurpleReinforcedConcreteRoofTurn90Block), typeof(PurpleReinforcedConcreteRoofTurn180Block), typeof(PurpleReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteRoofCornerBlock), typeof(PurpleReinforcedConcreteRoofCorner90Block), typeof(PurpleReinforcedConcreteRoofCorner180Block), typeof(PurpleReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteRoofPeakBlock), typeof(PurpleReinforcedConcreteRoofPeak90Block), typeof(PurpleReinforcedConcreteRoofPeak180Block), typeof(PurpleReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteUnderInnerPeakBlock), typeof(PurpleReinforcedConcreteUnderInnerPeak90Block), typeof(PurpleReinforcedConcreteUnderInnerPeak180Block), typeof(PurpleReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteHalfSlopeABlock), typeof(PurpleReinforcedConcreteHalfSlopeA90Block), typeof(PurpleReinforcedConcreteHalfSlopeA180Block), typeof(PurpleReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(PurpleReinforcedConcreteHalfSlopeBBlock), typeof(PurpleReinforcedConcreteHalfSlopeB90Block), typeof(PurpleReinforcedConcreteHalfSlopeB180Block), typeof(PurpleReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(PurpleReinforcedConcreteItem))]
    public partial class PurpleReinforcedConcreteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class PurpleReinforcedConcreteHalfSlopeB270Block : Block
    { }

}
