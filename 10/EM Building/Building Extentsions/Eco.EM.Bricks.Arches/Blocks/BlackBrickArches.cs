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
    [RotatedVariants(typeof(SingleArchBaseBlackBrickBlock), typeof(SingleArchBaseBlackBrick90Block), typeof(SingleArchBaseBlackBrick180Block), typeof(SingleArchBaseBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchBaseFormType), typeof(BlackBrickItem))]
    public partial class SingleArchBaseBlackBrickBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBaseBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBaseBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBaseBlackBrick270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidBlackBrickBlock), typeof(SingleArchMidBlackBrick90Block), typeof(SingleArchMidBlackBrick180Block), typeof(SingleArchMidBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchMidFormType), typeof(BlackBrickItem))]
    public partial class SingleArchMidBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidBlackBrick270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopBlackBrickBlock), typeof(SingleArchTopBlackBrick90Block), typeof(SingleArchTopBlackBrick180Block), typeof(SingleArchTopBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchTopFormType), typeof(BlackBrickItem))]
    public partial class SingleArchTopBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopBlackBrick270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofBlackBrickBlock), typeof(SingleArchRoofBlackBrick90Block), typeof(SingleArchRoofBlackBrick180Block), typeof(SingleArchRoofBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(BlackBrickItem))]
    public partial class SingleArchRoofBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofBlackBrick270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftBlackBrickBlock), typeof(BaseLeftBlackBrick90Block), typeof(BaseLeftBlackBrick180Block), typeof(BaseLeftBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseLeftFormType), typeof(BlackBrickItem))]
    public partial class BaseLeftBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftBlackBrick270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightBlackBrickBlock), typeof(BaseRightBlackBrick90Block), typeof(BaseRightBlackBrick180Block), typeof(BaseRightBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseRightFormType), typeof(BlackBrickItem))]
    public partial class BaseRightBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightBlackBrick270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidBlackBrickBlock), typeof(BaseMidBlackBrick90Block), typeof(BaseMidBlackBrick180Block), typeof(BaseMidBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseMidFormType), typeof(BlackBrickItem))]
    public partial class BaseMidBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidBlackBrick270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidBlackBrickBlock), typeof(MidMidBlackBrick90Block), typeof(MidMidBlackBrick180Block), typeof(MidMidBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidMidFormType), typeof(BlackBrickItem))]
    public partial class MidMidBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidBlackBrick270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftBlackBrickBlock), typeof(MidLeftBlackBrick90Block), typeof(MidLeftBlackBrick180Block), typeof(MidLeftBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidLeftFormType), typeof(BlackBrickItem))]
    public partial class MidLeftBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftBlackBrick270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightBlackBrickBlock), typeof(MidRightBlackBrick90Block), typeof(MidRightBlackBrick180Block), typeof(MidRightBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidRightFormType), typeof(BlackBrickItem))]
    public partial class MidRightBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightBlackBrick270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidBlackBrickBlock), typeof(TopMidBlackBrick90Block), typeof(TopMidBlackBrick180Block), typeof(TopMidBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopMidFormType), typeof(BlackBrickItem))]
    public partial class TopMidBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidBlackBrick270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftBlackBrickBlock), typeof(TopLeftBlackBrick90Block), typeof(TopLeftBlackBrick180Block), typeof(TopLeftBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopLeftFormType), typeof(BlackBrickItem))]
    public partial class TopLeftBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftBlackBrick270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightBlackBrickBlock), typeof(TopRightBlackBrick90Block), typeof(TopRightBlackBrick180Block), typeof(TopRightBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopRightFormType), typeof(BlackBrickItem))]
    public partial class TopRightBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightBlackBrick270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftBlackBrickBlock), typeof(RoofLeftBlackBrick90Block), typeof(RoofLeftBlackBrick180Block), typeof(RoofLeftBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofLeftFormType), typeof(BlackBrickItem))]
    public partial class RoofLeftBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftBlackBrick270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightBlackBrickBlock), typeof(RoofRightBlackBrick90Block), typeof(RoofRightBlackBrick180Block), typeof(RoofRightBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofRightFormType), typeof(BlackBrickItem))]
    public partial class RoofRightBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightBlackBrick270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidBlackBrickBlock), typeof(RoofMidBlackBrick90Block), typeof(RoofMidBlackBrick180Block), typeof(RoofMidBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofMidFormType), typeof(BlackBrickItem))]
    public partial class RoofMidBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidBlackBrick270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseBlackBrickBlock), typeof(InnerCornerBaseBlackBrick90Block), typeof(InnerCornerBaseBlackBrick180Block), typeof(InnerCornerBaseBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(BlackBrickItem))]
    public partial class InnerCornerBaseBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBaseBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBaseBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBaseBlackBrick270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidBlackBrickBlock), typeof(InnerCornerMidBlackBrick90Block), typeof(InnerCornerMidBlackBrick180Block), typeof(InnerCornerMidBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(BlackBrickItem))]
    public partial class InnerCornerMidBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidBlackBrick270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopBlackBrickBlock), typeof(InnerCornerTopBlackBrick90Block), typeof(InnerCornerTopBlackBrick180Block), typeof(InnerCornerTopBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(BlackBrickItem))]
    public partial class InnerCornerTopBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopBlackBrick270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseBlackBrickBlock), typeof(OutterCornerBaseBlackBrick90Block), typeof(OutterCornerBaseBlackBrick180Block), typeof(OutterCornerBaseBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(BlackBrickItem))]
    public partial class OutterCornerBaseBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBaseBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBaseBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBaseBlackBrick270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidBlackBrickBlock), typeof(OutterCornerMidBlackBrick90Block), typeof(OutterCornerMidBlackBrick180Block), typeof(OutterCornerMidBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(BlackBrickItem))]
    public partial class OutterCornerMidBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidBlackBrick270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopBlackBrickBlock), typeof(OutterCornerTopBlackBrick90Block), typeof(OutterCornerTopBlackBrick180Block), typeof(OutterCornerTopBlackBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(BlackBrickItem))]
    public partial class OutterCornerTopBlackBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopBlackBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopBlackBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopBlackBrick270Block : Block
    { }
    #endregion
    #endregion
}
