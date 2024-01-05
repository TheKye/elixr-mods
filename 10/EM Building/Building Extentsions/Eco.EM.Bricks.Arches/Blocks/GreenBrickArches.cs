using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Building.Bricks;
using Eco.EM.Building.Arches;

namespace Eco.EM.Building.Bricks.Arches
{
    #region Single Arches
    #region Base
    [RotatedVariants(typeof(SingleArchBaseGreenBrickBlock), typeof(SingleArchBaseGreenBrick90Block), typeof(SingleArchBaseGreenBrick180Block), typeof(SingleArchBaseGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchBaseFormType), typeof(GreenBrickItem))]
    public partial class SingleArchBaseGreenBrickBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBaseGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBaseGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBaseGreenBrick270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidGreenBrickBlock), typeof(SingleArchMidGreenBrick90Block), typeof(SingleArchMidGreenBrick180Block), typeof(SingleArchMidGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchMidFormType), typeof(GreenBrickItem))]
    public partial class SingleArchMidGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidGreenBrick270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopGreenBrickBlock), typeof(SingleArchTopGreenBrick90Block), typeof(SingleArchTopGreenBrick180Block), typeof(SingleArchTopGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchTopFormType), typeof(GreenBrickItem))]
    public partial class SingleArchTopGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopGreenBrick270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofGreenBrickBlock), typeof(SingleArchRoofGreenBrick90Block), typeof(SingleArchRoofGreenBrick180Block), typeof(SingleArchRoofGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(GreenBrickItem))]
    public partial class SingleArchRoofGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofGreenBrick270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftGreenBrickBlock), typeof(BaseLeftGreenBrick90Block), typeof(BaseLeftGreenBrick180Block), typeof(BaseLeftGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseLeftFormType), typeof(GreenBrickItem))]
    public partial class BaseLeftGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftGreenBrick270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightGreenBrickBlock), typeof(BaseRightGreenBrick90Block), typeof(BaseRightGreenBrick180Block), typeof(BaseRightGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseRightFormType), typeof(GreenBrickItem))]
    public partial class BaseRightGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightGreenBrick270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidGreenBrickBlock), typeof(BaseMidGreenBrick90Block), typeof(BaseMidGreenBrick180Block), typeof(BaseMidGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseMidFormType), typeof(GreenBrickItem))]
    public partial class BaseMidGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidGreenBrick270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidGreenBrickBlock), typeof(MidMidGreenBrick90Block), typeof(MidMidGreenBrick180Block), typeof(MidMidGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidMidFormType), typeof(GreenBrickItem))]
    public partial class MidMidGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidGreenBrick270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftGreenBrickBlock), typeof(MidLeftGreenBrick90Block), typeof(MidLeftGreenBrick180Block), typeof(MidLeftGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidLeftFormType), typeof(GreenBrickItem))]
    public partial class MidLeftGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftGreenBrick270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightGreenBrickBlock), typeof(MidRightGreenBrick90Block), typeof(MidRightGreenBrick180Block), typeof(MidRightGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidRightFormType), typeof(GreenBrickItem))]
    public partial class MidRightGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightGreenBrick270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidGreenBrickBlock), typeof(TopMidGreenBrick90Block), typeof(TopMidGreenBrick180Block), typeof(TopMidGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopMidFormType), typeof(GreenBrickItem))]
    public partial class TopMidGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidGreenBrick270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftGreenBrickBlock), typeof(TopLeftGreenBrick90Block), typeof(TopLeftGreenBrick180Block), typeof(TopLeftGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopLeftFormType), typeof(GreenBrickItem))]
    public partial class TopLeftGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftGreenBrick270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightGreenBrickBlock), typeof(TopRightGreenBrick90Block), typeof(TopRightGreenBrick180Block), typeof(TopRightGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopRightFormType), typeof(GreenBrickItem))]
    public partial class TopRightGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightGreenBrick270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftGreenBrickBlock), typeof(RoofLeftGreenBrick90Block), typeof(RoofLeftGreenBrick180Block), typeof(RoofLeftGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofLeftFormType), typeof(GreenBrickItem))]
    public partial class RoofLeftGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftGreenBrick270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightGreenBrickBlock), typeof(RoofRightGreenBrick90Block), typeof(RoofRightGreenBrick180Block), typeof(RoofRightGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofRightFormType), typeof(GreenBrickItem))]
    public partial class RoofRightGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightGreenBrick270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidGreenBrickBlock), typeof(RoofMidGreenBrick90Block), typeof(RoofMidGreenBrick180Block), typeof(RoofMidGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofMidFormType), typeof(GreenBrickItem))]
    public partial class RoofMidGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidGreenBrick270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseGreenBrickBlock), typeof(InnerCornerBaseGreenBrick90Block), typeof(InnerCornerBaseGreenBrick180Block), typeof(InnerCornerBaseGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(GreenBrickItem))]
    public partial class InnerCornerBaseGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBaseGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBaseGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBaseGreenBrick270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidGreenBrickBlock), typeof(InnerCornerMidGreenBrick90Block), typeof(InnerCornerMidGreenBrick180Block), typeof(InnerCornerMidGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(GreenBrickItem))]
    public partial class InnerCornerMidGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidGreenBrick270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopGreenBrickBlock), typeof(InnerCornerTopGreenBrick90Block), typeof(InnerCornerTopGreenBrick180Block), typeof(InnerCornerTopGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(GreenBrickItem))]
    public partial class InnerCornerTopGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopGreenBrick270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseGreenBrickBlock), typeof(OutterCornerBaseGreenBrick90Block), typeof(OutterCornerBaseGreenBrick180Block), typeof(OutterCornerBaseGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(GreenBrickItem))]
    public partial class OutterCornerBaseGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBaseGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBaseGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBaseGreenBrick270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidGreenBrickBlock), typeof(OutterCornerMidGreenBrick90Block), typeof(OutterCornerMidGreenBrick180Block), typeof(OutterCornerMidGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(GreenBrickItem))]
    public partial class OutterCornerMidGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidGreenBrick270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopGreenBrickBlock), typeof(OutterCornerTopGreenBrick90Block), typeof(OutterCornerTopGreenBrick180Block), typeof(OutterCornerTopGreenBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(GreenBrickItem))]
    public partial class OutterCornerTopGreenBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopGreenBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopGreenBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopGreenBrick270Block : Block
    { }
    #endregion
    #endregion
}
