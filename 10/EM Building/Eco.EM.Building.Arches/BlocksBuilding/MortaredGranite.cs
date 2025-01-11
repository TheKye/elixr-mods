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
    [RotatedVariants(typeof(SingleArchBaseMortaredGraniteBlock), typeof(SingleArchBaseMortaredGranite90Block), typeof(SingleArchBaseMortaredGranite180Block), typeof(SingleArchBaseMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(MortaredGraniteItem))]
    public partial class SingleArchBaseMortaredGraniteBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchBaseMortaredGranite270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidMortaredGraniteBlock), typeof(SingleArchMidMortaredGranite90Block), typeof(SingleArchMidMortaredGranite180Block), typeof(SingleArchMidMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchMidFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchMidMortaredGranite270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopMortaredGraniteBlock), typeof(SingleArchTopMortaredGranite90Block), typeof(SingleArchTopMortaredGranite180Block), typeof(SingleArchTopMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchTopFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchTopMortaredGranite270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofMortaredGraniteBlock), typeof(SingleArchRoofMortaredGranite90Block), typeof(SingleArchRoofMortaredGranite180Block), typeof(SingleArchRoofMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SingleArchRoofMortaredGranite270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftMortaredGraniteBlock), typeof(BaseLeftMortaredGranite90Block), typeof(BaseLeftMortaredGranite180Block), typeof(BaseLeftMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseLeftFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseLeftMortaredGranite270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightMortaredGraniteBlock), typeof(BaseRightMortaredGranite90Block), typeof(BaseRightMortaredGranite180Block), typeof(BaseRightMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseRightFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class BaseRightMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseRightMortaredGranite270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidMortaredGraniteBlock), typeof(BaseMidMortaredGranite90Block), typeof(BaseMidMortaredGranite180Block), typeof(BaseMidMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseMidFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class BaseMidMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class BaseMidMortaredGranite270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidMortaredGraniteBlock), typeof(MidMidMortaredGranite90Block), typeof(MidMidMortaredGranite180Block), typeof(MidMidMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidMidFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class MidMidMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidMidMortaredGranite270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftMortaredGraniteBlock), typeof(MidLeftMortaredGranite90Block), typeof(MidLeftMortaredGranite180Block), typeof(MidLeftMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidLeftFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class MidLeftMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidLeftMortaredGranite270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightMortaredGraniteBlock), typeof(MidRightMortaredGranite90Block), typeof(MidRightMortaredGranite180Block), typeof(MidRightMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidRightFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class MidRightMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class MidRightMortaredGranite270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidMortaredGraniteBlock), typeof(TopMidMortaredGranite90Block), typeof(TopMidMortaredGranite180Block), typeof(TopMidMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopMidFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class TopMidMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopMidMortaredGranite270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftMortaredGraniteBlock), typeof(TopLeftMortaredGranite90Block), typeof(TopLeftMortaredGranite180Block), typeof(TopLeftMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopLeftFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class TopLeftMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopLeftMortaredGranite270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightMortaredGraniteBlock), typeof(TopRightMortaredGranite90Block), typeof(TopRightMortaredGranite180Block), typeof(TopRightMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopRightFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class TopRightMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class TopRightMortaredGranite270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftMortaredGraniteBlock), typeof(RoofLeftMortaredGranite90Block), typeof(RoofLeftMortaredGranite180Block), typeof(RoofLeftMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofLeftFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofLeftMortaredGranite270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightMortaredGraniteBlock), typeof(RoofRightMortaredGranite90Block), typeof(RoofRightMortaredGranite180Block), typeof(RoofRightMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofRightFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class RoofRightMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofRightMortaredGranite270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidMortaredGraniteBlock), typeof(RoofMidMortaredGranite90Block), typeof(RoofMidMortaredGranite180Block), typeof(RoofMidMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofMidFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class RoofMidMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class RoofMidMortaredGranite270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseMortaredGraniteBlock), typeof(InnerCornerBaseMortaredGranite90Block), typeof(InnerCornerBaseMortaredGranite180Block), typeof(InnerCornerBaseMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseMortaredGranite270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidMortaredGraniteBlock), typeof(InnerCornerMidMortaredGranite90Block), typeof(InnerCornerMidMortaredGranite180Block), typeof(InnerCornerMidMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerMidMortaredGranite270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopMortaredGraniteBlock), typeof(InnerCornerTopMortaredGranite90Block), typeof(InnerCornerTopMortaredGranite180Block), typeof(InnerCornerTopMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class InnerCornerTopMortaredGranite270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseMortaredGraniteBlock), typeof(OutterCornerBaseMortaredGranite90Block), typeof(OutterCornerBaseMortaredGranite180Block), typeof(OutterCornerBaseMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseMortaredGranite270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidMortaredGraniteBlock), typeof(OutterCornerMidMortaredGranite90Block), typeof(OutterCornerMidMortaredGranite180Block), typeof(OutterCornerMidMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerMidMortaredGranite270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopMortaredGraniteBlock), typeof(OutterCornerTopMortaredGranite90Block), typeof(OutterCornerTopMortaredGranite180Block), typeof(OutterCornerTopMortaredGranite270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(MortaredGraniteItem))]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredGraniteBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredGranite90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredGranite180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class OutterCornerTopMortaredGranite270Block : Block
    { }
    #endregion
    #endregion
}
