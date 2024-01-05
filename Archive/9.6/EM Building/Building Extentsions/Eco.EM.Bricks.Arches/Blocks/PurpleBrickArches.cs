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
    [RotatedVariants(typeof(SingleArchBasePurpleBrickBlock), typeof(SingleArchBasePurpleBrick90Block), typeof(SingleArchBasePurpleBrick180Block), typeof(SingleArchBasePurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchBaseFormType), typeof(PurpleBrickItem))]
    public partial class SingleArchBasePurpleBrickBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBasePurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBasePurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchBasePurpleBrick270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidPurpleBrickBlock), typeof(SingleArchMidPurpleBrick90Block), typeof(SingleArchMidPurpleBrick180Block), typeof(SingleArchMidPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchMidFormType), typeof(PurpleBrickItem))]
    public partial class SingleArchMidPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchMidPurpleBrick270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopPurpleBrickBlock), typeof(SingleArchTopPurpleBrick90Block), typeof(SingleArchTopPurpleBrick180Block), typeof(SingleArchTopPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchTopFormType), typeof(PurpleBrickItem))]
    public partial class SingleArchTopPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchTopPurpleBrick270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofPurpleBrickBlock), typeof(SingleArchRoofPurpleBrick90Block), typeof(SingleArchRoofPurpleBrick180Block), typeof(SingleArchRoofPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(PurpleBrickItem))]
    public partial class SingleArchRoofPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SingleArchRoofPurpleBrick270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftPurpleBrickBlock), typeof(BaseLeftPurpleBrick90Block), typeof(BaseLeftPurpleBrick180Block), typeof(BaseLeftPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseLeftFormType), typeof(PurpleBrickItem))]
    public partial class BaseLeftPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseLeftPurpleBrick270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightPurpleBrickBlock), typeof(BaseRightPurpleBrick90Block), typeof(BaseRightPurpleBrick180Block), typeof(BaseRightPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseRightFormType), typeof(PurpleBrickItem))]
    public partial class BaseRightPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseRightPurpleBrick270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidPurpleBrickBlock), typeof(BaseMidPurpleBrick90Block), typeof(BaseMidPurpleBrick180Block), typeof(BaseMidPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseMidFormType), typeof(PurpleBrickItem))]
    public partial class BaseMidPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BaseMidPurpleBrick270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidPurpleBrickBlock), typeof(MidMidPurpleBrick90Block), typeof(MidMidPurpleBrick180Block), typeof(MidMidPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidMidFormType), typeof(PurpleBrickItem))]
    public partial class MidMidPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidMidPurpleBrick270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftPurpleBrickBlock), typeof(MidLeftPurpleBrick90Block), typeof(MidLeftPurpleBrick180Block), typeof(MidLeftPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidLeftFormType), typeof(PurpleBrickItem))]
    public partial class MidLeftPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidLeftPurpleBrick270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightPurpleBrickBlock), typeof(MidRightPurpleBrick90Block), typeof(MidRightPurpleBrick180Block), typeof(MidRightPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidRightFormType), typeof(PurpleBrickItem))]
    public partial class MidRightPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MidRightPurpleBrick270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidPurpleBrickBlock), typeof(TopMidPurpleBrick90Block), typeof(TopMidPurpleBrick180Block), typeof(TopMidPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopMidFormType), typeof(PurpleBrickItem))]
    public partial class TopMidPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopMidPurpleBrick270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftPurpleBrickBlock), typeof(TopLeftPurpleBrick90Block), typeof(TopLeftPurpleBrick180Block), typeof(TopLeftPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopLeftFormType), typeof(PurpleBrickItem))]
    public partial class TopLeftPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopLeftPurpleBrick270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightPurpleBrickBlock), typeof(TopRightPurpleBrick90Block), typeof(TopRightPurpleBrick180Block), typeof(TopRightPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopRightFormType), typeof(PurpleBrickItem))]
    public partial class TopRightPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class TopRightPurpleBrick270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftPurpleBrickBlock), typeof(RoofLeftPurpleBrick90Block), typeof(RoofLeftPurpleBrick180Block), typeof(RoofLeftPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofLeftFormType), typeof(PurpleBrickItem))]
    public partial class RoofLeftPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofLeftPurpleBrick270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightPurpleBrickBlock), typeof(RoofRightPurpleBrick90Block), typeof(RoofRightPurpleBrick180Block), typeof(RoofRightPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofRightFormType), typeof(PurpleBrickItem))]
    public partial class RoofRightPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofRightPurpleBrick270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidPurpleBrickBlock), typeof(RoofMidPurpleBrick90Block), typeof(RoofMidPurpleBrick180Block), typeof(RoofMidPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofMidFormType), typeof(PurpleBrickItem))]
    public partial class RoofMidPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RoofMidPurpleBrick270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBasePurpleBrickBlock), typeof(InnerCornerBasePurpleBrick90Block), typeof(InnerCornerBasePurpleBrick180Block), typeof(InnerCornerBasePurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(PurpleBrickItem))]
    public partial class InnerCornerBasePurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBasePurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBasePurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerBasePurpleBrick270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidPurpleBrickBlock), typeof(InnerCornerMidPurpleBrick90Block), typeof(InnerCornerMidPurpleBrick180Block), typeof(InnerCornerMidPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(PurpleBrickItem))]
    public partial class InnerCornerMidPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerMidPurpleBrick270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopPurpleBrickBlock), typeof(InnerCornerTopPurpleBrick90Block), typeof(InnerCornerTopPurpleBrick180Block), typeof(InnerCornerTopPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(PurpleBrickItem))]
    public partial class InnerCornerTopPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class InnerCornerTopPurpleBrick270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBasePurpleBrickBlock), typeof(OutterCornerBasePurpleBrick90Block), typeof(OutterCornerBasePurpleBrick180Block), typeof(OutterCornerBasePurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(PurpleBrickItem))]
    public partial class OutterCornerBasePurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBasePurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBasePurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerBasePurpleBrick270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidPurpleBrickBlock), typeof(OutterCornerMidPurpleBrick90Block), typeof(OutterCornerMidPurpleBrick180Block), typeof(OutterCornerMidPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerMidFormType), typeof(PurpleBrickItem))]
    public partial class OutterCornerMidPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerMidPurpleBrick270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopPurpleBrickBlock), typeof(OutterCornerTopPurpleBrick90Block), typeof(OutterCornerTopPurpleBrick180Block), typeof(OutterCornerTopPurpleBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerTopFormType), typeof(PurpleBrickItem))]
    public partial class OutterCornerTopPurpleBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PurpleBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopPurpleBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopPurpleBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OutterCornerTopPurpleBrick270Block : Block
    { }
    #endregion
    #endregion
}
