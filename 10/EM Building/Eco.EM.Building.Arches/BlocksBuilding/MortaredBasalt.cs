﻿using Eco.Core.Items;
using Eco.EM.Building.Arches.BlockFormTypes;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.EM.Building.Arches
{
    #region Single Arches
    #region Base
    [RotatedVariants(typeof(SingleArchBaseMortaredBasaltBlock), typeof(SingleArchBaseMortaredBasalt90Block), typeof(SingleArchBaseMortaredBasalt180Block), typeof(SingleArchBaseMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(MortaredBasaltItem))]
    public partial class SingleArchBaseMortaredBasaltBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredBasalt270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidMortaredBasaltBlock), typeof(SingleArchMidMortaredBasalt90Block), typeof(SingleArchMidMortaredBasalt180Block), typeof(SingleArchMidMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchMidFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredBasalt270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopMortaredBasaltBlock), typeof(SingleArchTopMortaredBasalt90Block), typeof(SingleArchTopMortaredBasalt180Block), typeof(SingleArchTopMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchTopFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredBasalt270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofMortaredBasaltBlock), typeof(SingleArchRoofMortaredBasalt90Block), typeof(SingleArchRoofMortaredBasalt180Block), typeof(SingleArchRoofMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredBasalt270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftMortaredBasaltBlock), typeof(BaseLeftMortaredBasalt90Block), typeof(BaseLeftMortaredBasalt180Block), typeof(BaseLeftMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseLeftFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredBasalt270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightMortaredBasaltBlock), typeof(BaseRightMortaredBasalt90Block), typeof(BaseRightMortaredBasalt180Block), typeof(BaseRightMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseRightFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class BaseRightMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredBasalt270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidMortaredBasaltBlock), typeof(BaseMidMortaredBasalt90Block), typeof(BaseMidMortaredBasalt180Block), typeof(BaseMidMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseMidFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class BaseMidMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredBasalt270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidMortaredBasaltBlock), typeof(MidMidMortaredBasalt90Block), typeof(MidMidMortaredBasalt180Block), typeof(MidMidMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidMidFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MidMidMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredBasalt270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftMortaredBasaltBlock), typeof(MidLeftMortaredBasalt90Block), typeof(MidLeftMortaredBasalt180Block), typeof(MidLeftMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidLeftFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MidLeftMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredBasalt270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightMortaredBasaltBlock), typeof(MidRightMortaredBasalt90Block), typeof(MidRightMortaredBasalt180Block), typeof(MidRightMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidRightFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class MidRightMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredBasalt270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidMortaredBasaltBlock), typeof(TopMidMortaredBasalt90Block), typeof(TopMidMortaredBasalt180Block), typeof(TopMidMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopMidFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class TopMidMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredBasalt270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftMortaredBasaltBlock), typeof(TopLeftMortaredBasalt90Block), typeof(TopLeftMortaredBasalt180Block), typeof(TopLeftMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopLeftFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class TopLeftMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredBasalt270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightMortaredBasaltBlock), typeof(TopRightMortaredBasalt90Block), typeof(TopRightMortaredBasalt180Block), typeof(TopRightMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopRightFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class TopRightMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredBasalt270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftMortaredBasaltBlock), typeof(RoofLeftMortaredBasalt90Block), typeof(RoofLeftMortaredBasalt180Block), typeof(RoofLeftMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofLeftFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredBasalt270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightMortaredBasaltBlock), typeof(RoofRightMortaredBasalt90Block), typeof(RoofRightMortaredBasalt180Block), typeof(RoofRightMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofRightFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class RoofRightMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredBasalt270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidMortaredBasaltBlock), typeof(RoofMidMortaredBasalt90Block), typeof(RoofMidMortaredBasalt180Block), typeof(RoofMidMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofMidFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class RoofMidMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredBasalt270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseMortaredBasaltBlock), typeof(InnerCornerBaseMortaredBasalt90Block), typeof(InnerCornerBaseMortaredBasalt180Block), typeof(InnerCornerBaseMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredBasalt270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidMortaredBasaltBlock), typeof(InnerCornerMidMortaredBasalt90Block), typeof(InnerCornerMidMortaredBasalt180Block), typeof(InnerCornerMidMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredBasalt270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopMortaredBasaltBlock), typeof(InnerCornerTopMortaredBasalt90Block), typeof(InnerCornerTopMortaredBasalt180Block), typeof(InnerCornerTopMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredBasalt270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseMortaredBasaltBlock), typeof(OutterCornerBaseMortaredBasalt90Block), typeof(OutterCornerBaseMortaredBasalt180Block), typeof(OutterCornerBaseMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredBasalt270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidMortaredBasaltBlock), typeof(OutterCornerMidMortaredBasalt90Block), typeof(OutterCornerMidMortaredBasalt180Block), typeof(OutterCornerMidMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredBasalt270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopMortaredBasaltBlock), typeof(OutterCornerTopMortaredBasalt90Block), typeof(OutterCornerTopMortaredBasalt180Block), typeof(OutterCornerTopMortaredBasalt270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(MortaredBasaltItem))]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredBasaltBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredBasalt90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredBasalt180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredBasalt270Block : Block
    { }
    #endregion
    #endregion
}
