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
    [RotatedVariants(typeof(SingleArchBaseWhiteBrickBlock), typeof(SingleArchBaseWhiteBrick90Block), typeof(SingleArchBaseWhiteBrick180Block), typeof(SingleArchBaseWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchBaseFormType), typeof(WhiteBrickItem))]
    public partial class SingleArchBaseWhiteBrickBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBaseWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBaseWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBaseWhiteBrick270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidWhiteBrickBlock), typeof(SingleArchMidWhiteBrick90Block), typeof(SingleArchMidWhiteBrick180Block), typeof(SingleArchMidWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchMidFormType), typeof(WhiteBrickItem))]
    public partial class SingleArchMidWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidWhiteBrick270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopWhiteBrickBlock), typeof(SingleArchTopWhiteBrick90Block), typeof(SingleArchTopWhiteBrick180Block), typeof(SingleArchTopWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchTopFormType), typeof(WhiteBrickItem))]
    public partial class SingleArchTopWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopWhiteBrick270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofWhiteBrickBlock), typeof(SingleArchRoofWhiteBrick90Block), typeof(SingleArchRoofWhiteBrick180Block), typeof(SingleArchRoofWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(WhiteBrickItem))]
    public partial class SingleArchRoofWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofWhiteBrick270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftWhiteBrickBlock), typeof(BaseLeftWhiteBrick90Block), typeof(BaseLeftWhiteBrick180Block), typeof(BaseLeftWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseLeftFormType), typeof(WhiteBrickItem))]
    public partial class BaseLeftWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftWhiteBrick270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightWhiteBrickBlock), typeof(BaseRightWhiteBrick90Block), typeof(BaseRightWhiteBrick180Block), typeof(BaseRightWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseRightFormType), typeof(WhiteBrickItem))]
    public partial class BaseRightWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightWhiteBrick270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidWhiteBrickBlock), typeof(BaseMidWhiteBrick90Block), typeof(BaseMidWhiteBrick180Block), typeof(BaseMidWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseMidFormType), typeof(WhiteBrickItem))]
    public partial class BaseMidWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidWhiteBrick270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidWhiteBrickBlock), typeof(MidMidWhiteBrick90Block), typeof(MidMidWhiteBrick180Block), typeof(MidMidWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidMidFormType), typeof(WhiteBrickItem))]
    public partial class MidMidWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidWhiteBrick270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftWhiteBrickBlock), typeof(MidLeftWhiteBrick90Block), typeof(MidLeftWhiteBrick180Block), typeof(MidLeftWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidLeftFormType), typeof(WhiteBrickItem))]
    public partial class MidLeftWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftWhiteBrick270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightWhiteBrickBlock), typeof(MidRightWhiteBrick90Block), typeof(MidRightWhiteBrick180Block), typeof(MidRightWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidRightFormType), typeof(WhiteBrickItem))]
    public partial class MidRightWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightWhiteBrick270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidWhiteBrickBlock), typeof(TopMidWhiteBrick90Block), typeof(TopMidWhiteBrick180Block), typeof(TopMidWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopMidFormType), typeof(WhiteBrickItem))]
    public partial class TopMidWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidWhiteBrick270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftWhiteBrickBlock), typeof(TopLeftWhiteBrick90Block), typeof(TopLeftWhiteBrick180Block), typeof(TopLeftWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopLeftFormType), typeof(WhiteBrickItem))]
    public partial class TopLeftWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftWhiteBrick270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightWhiteBrickBlock), typeof(TopRightWhiteBrick90Block), typeof(TopRightWhiteBrick180Block), typeof(TopRightWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopRightFormType), typeof(WhiteBrickItem))]
    public partial class TopRightWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightWhiteBrick270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftWhiteBrickBlock), typeof(RoofLeftWhiteBrick90Block), typeof(RoofLeftWhiteBrick180Block), typeof(RoofLeftWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofLeftFormType), typeof(WhiteBrickItem))]
    public partial class RoofLeftWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftWhiteBrick270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightWhiteBrickBlock), typeof(RoofRightWhiteBrick90Block), typeof(RoofRightWhiteBrick180Block), typeof(RoofRightWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofRightFormType), typeof(WhiteBrickItem))]
    public partial class RoofRightWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightWhiteBrick270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidWhiteBrickBlock), typeof(RoofMidWhiteBrick90Block), typeof(RoofMidWhiteBrick180Block), typeof(RoofMidWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofMidFormType), typeof(WhiteBrickItem))]
    public partial class RoofMidWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidWhiteBrick270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseWhiteBrickBlock), typeof(InnerCornerBaseWhiteBrick90Block), typeof(InnerCornerBaseWhiteBrick180Block), typeof(InnerCornerBaseWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(WhiteBrickItem))]
    public partial class InnerCornerBaseWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBaseWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBaseWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBaseWhiteBrick270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidWhiteBrickBlock), typeof(InnerCornerMidWhiteBrick90Block), typeof(InnerCornerMidWhiteBrick180Block), typeof(InnerCornerMidWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(WhiteBrickItem))]
    public partial class InnerCornerMidWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidWhiteBrick270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopWhiteBrickBlock), typeof(InnerCornerTopWhiteBrick90Block), typeof(InnerCornerTopWhiteBrick180Block), typeof(InnerCornerTopWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(WhiteBrickItem))]
    public partial class InnerCornerTopWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopWhiteBrick270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseWhiteBrickBlock), typeof(OutterCornerBaseWhiteBrick90Block), typeof(OutterCornerBaseWhiteBrick180Block), typeof(OutterCornerBaseWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(WhiteBrickItem))]
    public partial class OutterCornerBaseWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBaseWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBaseWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBaseWhiteBrick270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidWhiteBrickBlock), typeof(OutterCornerMidWhiteBrick90Block), typeof(OutterCornerMidWhiteBrick180Block), typeof(OutterCornerMidWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(WhiteBrickItem))]
    public partial class OutterCornerMidWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidWhiteBrick270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopWhiteBrickBlock), typeof(OutterCornerTopWhiteBrick90Block), typeof(OutterCornerTopWhiteBrick180Block), typeof(OutterCornerTopWhiteBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(WhiteBrickItem))]
    public partial class OutterCornerTopWhiteBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopWhiteBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopWhiteBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopWhiteBrick270Block : Block
    { }
    #endregion
    #endregion
}
