using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Building.Bricks;
using Eco.EM.Building.Arches;
using Eco.Core.Items;

namespace Eco.EM.Building.Bricks.Arches
{
    #region Single Arches
    #region Base
    [RotatedVariants(typeof(SingleArchBaseBlueBrickBlock), typeof(SingleArchBaseBlueBrick90Block), typeof(SingleArchBaseBlueBrick180Block), typeof(SingleArchBaseBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(BlueBrickItem))]
    public partial class SingleArchBaseBlueBrickBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchBaseBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseBlueBrick270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidBlueBrickBlock), typeof(SingleArchMidBlueBrick90Block), typeof(SingleArchMidBlueBrick180Block), typeof(SingleArchMidBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchMidFormType), typeof(BlueBrickItem))]
    public partial class SingleArchMidBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchMidBlueBrick270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopBlueBrickBlock), typeof(SingleArchTopBlueBrick90Block), typeof(SingleArchTopBlueBrick180Block), typeof(SingleArchTopBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchTopFormType), typeof(BlueBrickItem))]
    public partial class SingleArchTopBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopBlueBrick270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofBlueBrickBlock), typeof(SingleArchRoofBlueBrick90Block), typeof(SingleArchRoofBlueBrick180Block), typeof(SingleArchRoofBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofBlueBrick270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftBlueBrickBlock), typeof(BaseLeftBlueBrick90Block), typeof(BaseLeftBlueBrick180Block), typeof(BaseLeftBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseLeftFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class BaseLeftBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftBlueBrick270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightBlueBrickBlock), typeof(BaseRightBlueBrick90Block), typeof(BaseRightBlueBrick180Block), typeof(BaseRightBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BaseRightFormType), typeof(BlueBrickItem))]
    public partial class BaseRightBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightBlueBrick270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidBlueBrickBlock), typeof(BaseMidBlueBrick90Block), typeof(BaseMidBlueBrick180Block), typeof(BaseMidBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseMidFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class BaseMidBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidBlueBrick270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidBlueBrickBlock), typeof(MidMidBlueBrick90Block), typeof(MidMidBlueBrick180Block), typeof(MidMidBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidMidFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class MidMidBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidBlueBrick270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftBlueBrickBlock), typeof(MidLeftBlueBrick90Block), typeof(MidLeftBlueBrick180Block), typeof(MidLeftBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidLeftFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class MidLeftBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftBlueBrick270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightBlueBrickBlock), typeof(MidRightBlueBrick90Block), typeof(MidRightBlueBrick180Block), typeof(MidRightBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(MidRightFormType), typeof(BlueBrickItem))]
    public partial class MidRightBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightBlueBrick270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidBlueBrickBlock), typeof(TopMidBlueBrick90Block), typeof(TopMidBlueBrick180Block), typeof(TopMidBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(TopMidFormType), typeof(BlueBrickItem))]
    public partial class TopMidBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidBlueBrick270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftBlueBrickBlock), typeof(TopLeftBlueBrick90Block), typeof(TopLeftBlueBrick180Block), typeof(TopLeftBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopLeftFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class TopLeftBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftBlueBrick270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightBlueBrickBlock), typeof(TopRightBlueBrick90Block), typeof(TopRightBlueBrick180Block), typeof(TopRightBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopRightFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class TopRightBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightBlueBrick270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftBlueBrickBlock), typeof(RoofLeftBlueBrick90Block), typeof(RoofLeftBlueBrick180Block), typeof(RoofLeftBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofLeftFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class RoofLeftBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftBlueBrick270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightBlueBrickBlock), typeof(RoofRightBlueBrick90Block), typeof(RoofRightBlueBrick180Block), typeof(RoofRightBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofRightFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class RoofRightBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightBlueBrick270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidBlueBrickBlock), typeof(RoofMidBlueBrick90Block), typeof(RoofMidBlueBrick180Block), typeof(RoofMidBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofMidFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class RoofMidBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidBlueBrick270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseBlueBrickBlock), typeof(InnerCornerBaseBlueBrick90Block), typeof(InnerCornerBaseBlueBrick180Block), typeof(InnerCornerBaseBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseBlueBrick270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidBlueBrickBlock), typeof(InnerCornerMidBlueBrick90Block), typeof(InnerCornerMidBlueBrick180Block), typeof(InnerCornerMidBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidBlueBrick270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopBlueBrickBlock), typeof(InnerCornerTopBlueBrick90Block), typeof(InnerCornerTopBlueBrick180Block), typeof(InnerCornerTopBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopBlueBrick270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseBlueBrickBlock), typeof(OutterCornerBaseBlueBrick90Block), typeof(OutterCornerBaseBlueBrick180Block), typeof(OutterCornerBaseBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(BlueBrickItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseBlueBrick270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidBlueBrickBlock), typeof(OutterCornerMidBlueBrick90Block), typeof(OutterCornerMidBlueBrick180Block), typeof(OutterCornerMidBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerMidFormType), typeof(BlueBrickItem))]
    public partial class OutterCornerMidBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidBlueBrick270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopBlueBrickBlock), typeof(OutterCornerTopBlueBrick90Block), typeof(OutterCornerTopBlueBrick180Block), typeof(OutterCornerTopBlueBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerTopFormType), typeof(BlueBrickItem))]
    public partial class OutterCornerTopBlueBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopBlueBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopBlueBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopBlueBrick270Block : Block
    { }
    #endregion
    #endregion
}
