﻿using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.Core.Items;
using Eco.EM.Building.Arches.BlockFormTypes;

namespace Eco.EM.Building.Arches
{
    #region Single Arches
    #region Base
    [RotatedVariants(typeof(SingleArchBaseMortaredSandstoneBlock), typeof(SingleArchBaseMortaredSandstone90Block), typeof(SingleArchBaseMortaredSandstone180Block), typeof(SingleArchBaseMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(MortaredSandstoneItem))]
    public partial class SingleArchBaseMortaredSandstoneBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredSandstone270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidMortaredSandstoneBlock), typeof(SingleArchMidMortaredSandstone90Block), typeof(SingleArchMidMortaredSandstone180Block), typeof(SingleArchMidMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchMidFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredSandstone270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopMortaredSandstoneBlock), typeof(SingleArchTopMortaredSandstone90Block), typeof(SingleArchTopMortaredSandstone180Block), typeof(SingleArchTopMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchTopFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredSandstone270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofMortaredSandstoneBlock), typeof(SingleArchRoofMortaredSandstone90Block), typeof(SingleArchRoofMortaredSandstone180Block), typeof(SingleArchRoofMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredSandstone270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftMortaredSandstoneBlock), typeof(BaseLeftMortaredSandstone90Block), typeof(BaseLeftMortaredSandstone180Block), typeof(BaseLeftMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseLeftFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredSandstone270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightMortaredSandstoneBlock), typeof(BaseRightMortaredSandstone90Block), typeof(BaseRightMortaredSandstone180Block), typeof(BaseRightMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseRightFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class BaseRightMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredSandstone270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidMortaredSandstoneBlock), typeof(BaseMidMortaredSandstone90Block), typeof(BaseMidMortaredSandstone180Block), typeof(BaseMidMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseMidFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class BaseMidMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredSandstone270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidMortaredSandstoneBlock), typeof(MidMidMortaredSandstone90Block), typeof(MidMidMortaredSandstone180Block), typeof(MidMidMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidMidFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class MidMidMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredSandstone270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftMortaredSandstoneBlock), typeof(MidLeftMortaredSandstone90Block), typeof(MidLeftMortaredSandstone180Block), typeof(MidLeftMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidLeftFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class MidLeftMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredSandstone270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightMortaredSandstoneBlock), typeof(MidRightMortaredSandstone90Block), typeof(MidRightMortaredSandstone180Block), typeof(MidRightMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidRightFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class MidRightMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredSandstone270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidMortaredSandstoneBlock), typeof(TopMidMortaredSandstone90Block), typeof(TopMidMortaredSandstone180Block), typeof(TopMidMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopMidFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class TopMidMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredSandstone270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftMortaredSandstoneBlock), typeof(TopLeftMortaredSandstone90Block), typeof(TopLeftMortaredSandstone180Block), typeof(TopLeftMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopLeftFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class TopLeftMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredSandstone270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightMortaredSandstoneBlock), typeof(TopRightMortaredSandstone90Block), typeof(TopRightMortaredSandstone180Block), typeof(TopRightMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopRightFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class TopRightMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredSandstone270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftMortaredSandstoneBlock), typeof(RoofLeftMortaredSandstone90Block), typeof(RoofLeftMortaredSandstone180Block), typeof(RoofLeftMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofLeftFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredSandstone270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightMortaredSandstoneBlock), typeof(RoofRightMortaredSandstone90Block), typeof(RoofRightMortaredSandstone180Block), typeof(RoofRightMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofRightFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class RoofRightMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredSandstone270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidMortaredSandstoneBlock), typeof(RoofMidMortaredSandstone90Block), typeof(RoofMidMortaredSandstone180Block), typeof(RoofMidMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofMidFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class RoofMidMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredSandstone270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseMortaredSandstoneBlock), typeof(InnerCornerBaseMortaredSandstone90Block), typeof(InnerCornerBaseMortaredSandstone180Block), typeof(InnerCornerBaseMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredSandstone270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidMortaredSandstoneBlock), typeof(InnerCornerMidMortaredSandstone90Block), typeof(InnerCornerMidMortaredSandstone180Block), typeof(InnerCornerMidMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredSandstone270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopMortaredSandstoneBlock), typeof(InnerCornerTopMortaredSandstone90Block), typeof(InnerCornerTopMortaredSandstone180Block), typeof(InnerCornerTopMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredSandstone270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseMortaredSandstoneBlock), typeof(OutterCornerBaseMortaredSandstone90Block), typeof(OutterCornerBaseMortaredSandstone180Block), typeof(OutterCornerBaseMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredSandstone270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidMortaredSandstoneBlock), typeof(OutterCornerMidMortaredSandstone90Block), typeof(OutterCornerMidMortaredSandstone180Block), typeof(OutterCornerMidMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredSandstone270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopMortaredSandstoneBlock), typeof(OutterCornerTopMortaredSandstone90Block), typeof(OutterCornerTopMortaredSandstone180Block), typeof(OutterCornerTopMortaredSandstone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(MortaredSandstoneItem))]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredSandstoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredSandstone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredSandstone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredSandstone270Block : Block
    { }
    #endregion
    #endregion
}
