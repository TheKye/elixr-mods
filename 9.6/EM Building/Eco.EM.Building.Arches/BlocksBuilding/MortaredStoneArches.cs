using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;

namespace Eco.EM.Building.Arches
{
    #region Single Arches
    #region Base
    [RotatedVariants(typeof(SingleArchBaseMortaredStoneBlock), typeof(SingleArchBaseMortaredStone90Block), typeof(SingleArchBaseMortaredStone180Block), typeof(SingleArchBaseMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchBaseFormType), typeof(MortaredStoneItem))]
    public partial class SingleArchBaseMortaredStoneBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchBaseMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchBaseMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchBaseMortaredStone270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidMortaredStoneBlock), typeof(SingleArchMidMortaredStone90Block), typeof(SingleArchMidMortaredStone180Block), typeof(SingleArchMidMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchMidFormType), typeof(MortaredStoneItem))]
    public partial class SingleArchMidMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchMidMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchMidMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchMidMortaredStone270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopMortaredStoneBlock), typeof(SingleArchTopMortaredStone90Block), typeof(SingleArchTopMortaredStone180Block), typeof(SingleArchTopMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchTopFormType), typeof(MortaredStoneItem))]
    public partial class SingleArchTopMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchTopMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchTopMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchTopMortaredStone270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofMortaredStoneBlock), typeof(SingleArchRoofMortaredStone90Block), typeof(SingleArchRoofMortaredStone180Block), typeof(SingleArchRoofMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(MortaredStoneItem))]
    public partial class SingleArchRoofMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchRoofMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchRoofMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SingleArchRoofMortaredStone270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftMortaredStoneBlock), typeof(BaseLeftMortaredStone90Block), typeof(BaseLeftMortaredStone180Block), typeof(BaseLeftMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseLeftFormType), typeof(MortaredStoneItem))]
    public partial class BaseLeftMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class BaseLeftMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class BaseLeftMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class BaseLeftMortaredStone270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightMortaredStoneBlock), typeof(BaseRightMortaredStone90Block), typeof(BaseRightMortaredStone180Block), typeof(BaseRightMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseRightFormType), typeof(MortaredStoneItem))]
    public partial class BaseRightMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class BaseRightMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class BaseRightMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class BaseRightMortaredStone270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidMortaredStoneBlock), typeof(BaseMidMortaredStone90Block), typeof(BaseMidMortaredStone180Block), typeof(BaseMidMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(BaseMidFormType), typeof(MortaredStoneItem))]
    public partial class BaseMidMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class BaseMidMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class BaseMidMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class BaseMidMortaredStone270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidMortaredStoneBlock), typeof(MidMidMortaredStone90Block), typeof(MidMidMortaredStone180Block), typeof(MidMidMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidMidFormType), typeof(MortaredStoneItem))]
    public partial class MidMidMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MidMidMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MidMidMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MidMidMortaredStone270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftMortaredStoneBlock), typeof(MidLeftMortaredStone90Block), typeof(MidLeftMortaredStone180Block), typeof(MidLeftMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidLeftFormType), typeof(MortaredStoneItem))]
    public partial class MidLeftMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MidLeftMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MidLeftMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MidLeftMortaredStone270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightMortaredStoneBlock), typeof(MidRightMortaredStone90Block), typeof(MidRightMortaredStone180Block), typeof(MidRightMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(MidRightFormType), typeof(MortaredStoneItem))]
    public partial class MidRightMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MidRightMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MidRightMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MidRightMortaredStone270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidMortaredStoneBlock), typeof(TopMidMortaredStone90Block), typeof(TopMidMortaredStone180Block), typeof(TopMidMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopMidFormType), typeof(MortaredStoneItem))]
    public partial class TopMidMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class TopMidMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class TopMidMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class TopMidMortaredStone270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftMortaredStoneBlock), typeof(TopLeftMortaredStone90Block), typeof(TopLeftMortaredStone180Block), typeof(TopLeftMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopLeftFormType), typeof(MortaredStoneItem))]
    public partial class TopLeftMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class TopLeftMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class TopLeftMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class TopLeftMortaredStone270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightMortaredStoneBlock), typeof(TopRightMortaredStone90Block), typeof(TopRightMortaredStone180Block), typeof(TopRightMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(TopRightFormType), typeof(MortaredStoneItem))]
    public partial class TopRightMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class TopRightMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class TopRightMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class TopRightMortaredStone270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftMortaredStoneBlock), typeof(RoofLeftMortaredStone90Block), typeof(RoofLeftMortaredStone180Block), typeof(RoofLeftMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofLeftFormType), typeof(MortaredStoneItem))]
    public partial class RoofLeftMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class RoofLeftMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class RoofLeftMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class RoofLeftMortaredStone270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightMortaredStoneBlock), typeof(RoofRightMortaredStone90Block), typeof(RoofRightMortaredStone180Block), typeof(RoofRightMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofRightFormType), typeof(MortaredStoneItem))]
    public partial class RoofRightMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class RoofRightMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class RoofRightMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class RoofRightMortaredStone270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidMortaredStoneBlock), typeof(RoofMidMortaredStone90Block), typeof(RoofMidMortaredStone180Block), typeof(RoofMidMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(RoofMidFormType), typeof(MortaredStoneItem))]
    public partial class RoofMidMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class RoofMidMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class RoofMidMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class RoofMidMortaredStone270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseMortaredStoneBlock), typeof(InnerCornerBaseMortaredStone90Block), typeof(InnerCornerBaseMortaredStone180Block), typeof(InnerCornerBaseMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(MortaredStoneItem))]
    public partial class InnerCornerBaseMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class InnerCornerBaseMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class InnerCornerBaseMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class InnerCornerBaseMortaredStone270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidMortaredStoneBlock), typeof(InnerCornerMidMortaredStone90Block), typeof(InnerCornerMidMortaredStone180Block), typeof(InnerCornerMidMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(MortaredStoneItem))]
    public partial class InnerCornerMidMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class InnerCornerMidMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class InnerCornerMidMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class InnerCornerMidMortaredStone270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopMortaredStoneBlock), typeof(InnerCornerTopMortaredStone90Block), typeof(InnerCornerTopMortaredStone180Block), typeof(InnerCornerTopMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(MortaredStoneItem))]
    public partial class InnerCornerTopMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class InnerCornerTopMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class InnerCornerTopMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class InnerCornerTopMortaredStone270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseMortaredStoneBlock), typeof(OutterCornerBaseMortaredStone90Block), typeof(OutterCornerBaseMortaredStone180Block), typeof(OutterCornerBaseMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(MortaredStoneItem))]
    public partial class OutterCornerBaseMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class OutterCornerBaseMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class OutterCornerBaseMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class OutterCornerBaseMortaredStone270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidMortaredStoneBlock), typeof(OutterCornerMidMortaredStone90Block), typeof(OutterCornerMidMortaredStone180Block), typeof(OutterCornerMidMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(MortaredStoneItem))]
    public partial class OutterCornerMidMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class OutterCornerMidMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class OutterCornerMidMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class OutterCornerMidMortaredStone270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopMortaredStoneBlock), typeof(OutterCornerTopMortaredStone90Block), typeof(OutterCornerTopMortaredStone180Block), typeof(OutterCornerTopMortaredStone270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(MortaredStoneItem))]
    public partial class OutterCornerTopMortaredStoneBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class OutterCornerTopMortaredStone90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class OutterCornerTopMortaredStone180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class OutterCornerTopMortaredStone270Block : Block
    { }
    #endregion
    #endregion
}
