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
    public partial class OrangeReinforcedConcreteBlock :
        Block
        , IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }

    [Serialized]
    [LocDisplayName("Orange Reinforced Concrete")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Currency]
    [Tag("Currency")]
    [Tag("Concrete", 1)]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class OrangeReinforcedConcreteItem :
    BlockItem<OrangeReinforcedConcreteBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Orange Reinforced Concrete"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar. And Its Orange!"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
        typeof(OrangeReinforcedConcreteStacked1Block),
        typeof(OrangeReinforcedConcreteStacked2Block),
        typeof(OrangeReinforcedConcreteStacked3Block),
            typeof(OrangeReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class OrangeReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class OrangeReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 OrangeReinforcedConcrete


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(CubeFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ColumnFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakSetFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCubeFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(ThinColumnFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(DoubleWindowFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderPeakSetFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(PeakSetFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcretePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoadBarrierFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FlatRoofFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FenceFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(OrangeReinforcedConcreteItem); } }
    }



    [RotatedVariants(typeof(OrangeReinforcedConcreteLadderBlock), typeof(OrangeReinforcedConcreteLadder90Block), typeof(OrangeReinforcedConcreteLadder180Block), typeof(OrangeReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(LadderFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteLadder270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteStairsBlock), typeof(OrangeReinforcedConcreteStairs90Block), typeof(OrangeReinforcedConcreteStairs180Block), typeof(OrangeReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteStairs270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteUnderStairsBlock), typeof(OrangeReinforcedConcreteUnderStairs90Block), typeof(OrangeReinforcedConcreteUnderStairs180Block), typeof(OrangeReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderStairsFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteBasicSlopeSideBlock), typeof(OrangeReinforcedConcreteBasicSlopeSide90Block), typeof(OrangeReinforcedConcreteBasicSlopeSide180Block), typeof(OrangeReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeSideFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteBasicSlopeCornerBlock), typeof(OrangeReinforcedConcreteBasicSlopeCorner90Block), typeof(OrangeReinforcedConcreteBasicSlopeCorner180Block), typeof(OrangeReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteBasicSlopeTurnBlock), typeof(OrangeReinforcedConcreteBasicSlopeTurn90Block), typeof(OrangeReinforcedConcreteBasicSlopeTurn180Block), typeof(OrangeReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteBasicSlopePointBlock), typeof(OrangeReinforcedConcreteBasicSlopePoint90Block), typeof(OrangeReinforcedConcreteBasicSlopePoint180Block), typeof(OrangeReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(BasicSlopePointFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteStairsCornerBlock), typeof(OrangeReinforcedConcreteStairsCorner90Block), typeof(OrangeReinforcedConcreteStairsCorner180Block), typeof(OrangeReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsCornerFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteStairsTurnBlock), typeof(OrangeReinforcedConcreteStairsTurn90Block), typeof(OrangeReinforcedConcreteStairsTurn180Block), typeof(OrangeReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(StairsTurnFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteUnderSlopeSideBlock), typeof(OrangeReinforcedConcreteUnderSlopeSide90Block), typeof(OrangeReinforcedConcreteUnderSlopeSide180Block), typeof(OrangeReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeSideFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteUnderSlopeCornerBlock), typeof(OrangeReinforcedConcreteUnderSlopeCorner90Block), typeof(OrangeReinforcedConcreteUnderSlopeCorner180Block), typeof(OrangeReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteUnderSlopeTurnBlock), typeof(OrangeReinforcedConcreteUnderSlopeTurn90Block), typeof(OrangeReinforcedConcreteUnderSlopeTurn180Block), typeof(OrangeReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteUnderSlopePeakBlock), typeof(OrangeReinforcedConcreteUnderSlopePeak90Block), typeof(OrangeReinforcedConcreteUnderSlopePeak180Block), typeof(OrangeReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderSlopePeakFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteRoofSideBlock), typeof(OrangeReinforcedConcreteRoofSide90Block), typeof(OrangeReinforcedConcreteRoofSide180Block), typeof(OrangeReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofSideFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteRoofTurnBlock), typeof(OrangeReinforcedConcreteRoofTurn90Block), typeof(OrangeReinforcedConcreteRoofTurn180Block), typeof(OrangeReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofTurnFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteRoofCornerBlock), typeof(OrangeReinforcedConcreteRoofCorner90Block), typeof(OrangeReinforcedConcreteRoofCorner180Block), typeof(OrangeReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofCornerFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteRoofPeakBlock), typeof(OrangeReinforcedConcreteRoofPeak90Block), typeof(OrangeReinforcedConcreteRoofPeak180Block), typeof(OrangeReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofPeakFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteUnderInnerPeakBlock), typeof(OrangeReinforcedConcreteUnderInnerPeak90Block), typeof(OrangeReinforcedConcreteUnderInnerPeak180Block), typeof(OrangeReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(UnderInnerPeakFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteHalfSlopeABlock), typeof(OrangeReinforcedConcreteHalfSlopeA90Block), typeof(OrangeReinforcedConcreteHalfSlopeA180Block), typeof(OrangeReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeAFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(OrangeReinforcedConcreteHalfSlopeBBlock), typeof(OrangeReinforcedConcreteHalfSlopeB90Block), typeof(OrangeReinforcedConcreteHalfSlopeB180Block), typeof(OrangeReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(HalfSlopeBFormType), typeof(OrangeReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteHalfSlopeB270Block : Block
    { }

}
