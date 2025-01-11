using System;
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
    [RotatedVariants(typeof(SingleArchBaseMortaredLimestoneBlock), typeof(SingleArchBaseMortaredLimestone90Block), typeof(SingleArchBaseMortaredLimestone180Block), typeof(SingleArchBaseMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(MortaredLimestoneItem))]
    public partial class SingleArchBaseMortaredLimestoneBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredLimestone270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidMortaredLimestoneBlock), typeof(SingleArchMidMortaredLimestone90Block), typeof(SingleArchMidMortaredLimestone180Block), typeof(SingleArchMidMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchMidFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredLimestone270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopMortaredLimestoneBlock), typeof(SingleArchTopMortaredLimestone90Block), typeof(SingleArchTopMortaredLimestone180Block), typeof(SingleArchTopMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchTopFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredLimestone270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofMortaredLimestoneBlock), typeof(SingleArchRoofMortaredLimestone90Block), typeof(SingleArchRoofMortaredLimestone180Block), typeof(SingleArchRoofMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredLimestone270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftMortaredLimestoneBlock), typeof(BaseLeftMortaredLimestone90Block), typeof(BaseLeftMortaredLimestone180Block), typeof(BaseLeftMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseLeftFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredLimestone270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightMortaredLimestoneBlock), typeof(BaseRightMortaredLimestone90Block), typeof(BaseRightMortaredLimestone180Block), typeof(BaseRightMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseRightFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class BaseRightMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredLimestone270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidMortaredLimestoneBlock), typeof(BaseMidMortaredLimestone90Block), typeof(BaseMidMortaredLimestone180Block), typeof(BaseMidMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseMidFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class BaseMidMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredLimestone270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidMortaredLimestoneBlock), typeof(MidMidMortaredLimestone90Block), typeof(MidMidMortaredLimestone180Block), typeof(MidMidMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidMidFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class MidMidMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredLimestone270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftMortaredLimestoneBlock), typeof(MidLeftMortaredLimestone90Block), typeof(MidLeftMortaredLimestone180Block), typeof(MidLeftMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidLeftFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class MidLeftMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredLimestone270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightMortaredLimestoneBlock), typeof(MidRightMortaredLimestone90Block), typeof(MidRightMortaredLimestone180Block), typeof(MidRightMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidRightFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class MidRightMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredLimestone270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidMortaredLimestoneBlock), typeof(TopMidMortaredLimestone90Block), typeof(TopMidMortaredLimestone180Block), typeof(TopMidMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopMidFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class TopMidMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredLimestone270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftMortaredLimestoneBlock), typeof(TopLeftMortaredLimestone90Block), typeof(TopLeftMortaredLimestone180Block), typeof(TopLeftMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopLeftFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class TopLeftMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredLimestone270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightMortaredLimestoneBlock), typeof(TopRightMortaredLimestone90Block), typeof(TopRightMortaredLimestone180Block), typeof(TopRightMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopRightFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class TopRightMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredLimestone270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftMortaredLimestoneBlock), typeof(RoofLeftMortaredLimestone90Block), typeof(RoofLeftMortaredLimestone180Block), typeof(RoofLeftMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofLeftFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredLimestone270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightMortaredLimestoneBlock), typeof(RoofRightMortaredLimestone90Block), typeof(RoofRightMortaredLimestone180Block), typeof(RoofRightMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofRightFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class RoofRightMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredLimestone270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidMortaredLimestoneBlock), typeof(RoofMidMortaredLimestone90Block), typeof(RoofMidMortaredLimestone180Block), typeof(RoofMidMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofMidFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class RoofMidMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredLimestone270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseMortaredLimestoneBlock), typeof(InnerCornerBaseMortaredLimestone90Block), typeof(InnerCornerBaseMortaredLimestone180Block), typeof(InnerCornerBaseMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredLimestone270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidMortaredLimestoneBlock), typeof(InnerCornerMidMortaredLimestone90Block), typeof(InnerCornerMidMortaredLimestone180Block), typeof(InnerCornerMidMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredLimestone270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopMortaredLimestoneBlock), typeof(InnerCornerTopMortaredLimestone90Block), typeof(InnerCornerTopMortaredLimestone180Block), typeof(InnerCornerTopMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredLimestone270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseMortaredLimestoneBlock), typeof(OutterCornerBaseMortaredLimestone90Block), typeof(OutterCornerBaseMortaredLimestone180Block), typeof(OutterCornerBaseMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredLimestone270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidMortaredLimestoneBlock), typeof(OutterCornerMidMortaredLimestone90Block), typeof(OutterCornerMidMortaredLimestone180Block), typeof(OutterCornerMidMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredLimestone270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopMortaredLimestoneBlock), typeof(OutterCornerTopMortaredLimestone90Block), typeof(OutterCornerTopMortaredLimestone180Block), typeof(OutterCornerTopMortaredLimestone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(MortaredLimestoneItem))]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredLimestoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredLimestone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredLimestone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredLimestone270Block : Block
    { }
    #endregion
    #endregion
}
