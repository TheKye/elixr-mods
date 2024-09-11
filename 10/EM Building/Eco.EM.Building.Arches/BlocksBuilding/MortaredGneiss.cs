using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.Core.Items;

namespace Eco.EM.Building.Arches
{
    #region Single Arches
    #region Base
    [RotatedVariants(typeof(SingleArchBaseMortaredGneissBlock), typeof(SingleArchBaseMortaredGneiss90Block), typeof(SingleArchBaseMortaredGneiss180Block), typeof(SingleArchBaseMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(MortaredGneissItem))]
    public partial class SingleArchBaseMortaredGneissBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredGneiss270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidMortaredGneissBlock), typeof(SingleArchMidMortaredGneiss90Block), typeof(SingleArchMidMortaredGneiss180Block), typeof(SingleArchMidMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchMidFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredGneiss270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopMortaredGneissBlock), typeof(SingleArchTopMortaredGneiss90Block), typeof(SingleArchTopMortaredGneiss180Block), typeof(SingleArchTopMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchTopFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredGneiss270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofMortaredGneissBlock), typeof(SingleArchRoofMortaredGneiss90Block), typeof(SingleArchRoofMortaredGneiss180Block), typeof(SingleArchRoofMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredGneiss270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftMortaredGneissBlock), typeof(BaseLeftMortaredGneiss90Block), typeof(BaseLeftMortaredGneiss180Block), typeof(BaseLeftMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseLeftFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredGneiss270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightMortaredGneissBlock), typeof(BaseRightMortaredGneiss90Block), typeof(BaseRightMortaredGneiss180Block), typeof(BaseRightMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseRightFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class BaseRightMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredGneiss270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidMortaredGneissBlock), typeof(BaseMidMortaredGneiss90Block), typeof(BaseMidMortaredGneiss180Block), typeof(BaseMidMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseMidFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class BaseMidMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredGneiss270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidMortaredGneissBlock), typeof(MidMidMortaredGneiss90Block), typeof(MidMidMortaredGneiss180Block), typeof(MidMidMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidMidFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class MidMidMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredGneiss270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftMortaredGneissBlock), typeof(MidLeftMortaredGneiss90Block), typeof(MidLeftMortaredGneiss180Block), typeof(MidLeftMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidLeftFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class MidLeftMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredGneiss270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightMortaredGneissBlock), typeof(MidRightMortaredGneiss90Block), typeof(MidRightMortaredGneiss180Block), typeof(MidRightMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidRightFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class MidRightMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredGneiss270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidMortaredGneissBlock), typeof(TopMidMortaredGneiss90Block), typeof(TopMidMortaredGneiss180Block), typeof(TopMidMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopMidFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class TopMidMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredGneiss270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftMortaredGneissBlock), typeof(TopLeftMortaredGneiss90Block), typeof(TopLeftMortaredGneiss180Block), typeof(TopLeftMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopLeftFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class TopLeftMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredGneiss270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightMortaredGneissBlock), typeof(TopRightMortaredGneiss90Block), typeof(TopRightMortaredGneiss180Block), typeof(TopRightMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopRightFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class TopRightMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredGneiss270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftMortaredGneissBlock), typeof(RoofLeftMortaredGneiss90Block), typeof(RoofLeftMortaredGneiss180Block), typeof(RoofLeftMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofLeftFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredGneiss270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightMortaredGneissBlock), typeof(RoofRightMortaredGneiss90Block), typeof(RoofRightMortaredGneiss180Block), typeof(RoofRightMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofRightFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class RoofRightMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredGneiss270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidMortaredGneissBlock), typeof(RoofMidMortaredGneiss90Block), typeof(RoofMidMortaredGneiss180Block), typeof(RoofMidMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofMidFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class RoofMidMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredGneiss270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseMortaredGneissBlock), typeof(InnerCornerBaseMortaredGneiss90Block), typeof(InnerCornerBaseMortaredGneiss180Block), typeof(InnerCornerBaseMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredGneiss270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidMortaredGneissBlock), typeof(InnerCornerMidMortaredGneiss90Block), typeof(InnerCornerMidMortaredGneiss180Block), typeof(InnerCornerMidMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredGneiss270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopMortaredGneissBlock), typeof(InnerCornerTopMortaredGneiss90Block), typeof(InnerCornerTopMortaredGneiss180Block), typeof(InnerCornerTopMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredGneiss270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseMortaredGneissBlock), typeof(OutterCornerBaseMortaredGneiss90Block), typeof(OutterCornerBaseMortaredGneiss180Block), typeof(OutterCornerBaseMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredGneiss270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidMortaredGneissBlock), typeof(OutterCornerMidMortaredGneiss90Block), typeof(OutterCornerMidMortaredGneiss180Block), typeof(OutterCornerMidMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredGneiss270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopMortaredGneissBlock), typeof(OutterCornerTopMortaredGneiss90Block), typeof(OutterCornerTopMortaredGneiss180Block), typeof(OutterCornerTopMortaredGneiss270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(MortaredGneissItem))]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredGneissBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredGneiss90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredGneiss180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredGneiss270Block : Block
    { }
    #endregion
    #endregion
}
