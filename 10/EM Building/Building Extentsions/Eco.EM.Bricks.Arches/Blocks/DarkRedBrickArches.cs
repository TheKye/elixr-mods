using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Building.Bricks;
using Eco.EM.Building.Arches;
using Eco.Core.Items;
using Eco.EM.Building.Arches.BlockFormTypes;

namespace Eco.EM.Bricks.Arches.Blocks
{
    #region Single Arches
    #region Base
    [RotatedVariants(typeof(SingleArchBaseDarkRedBrickBlock), typeof(SingleArchBaseDarkRedBrick90Block), typeof(SingleArchBaseDarkRedBrick180Block), typeof(SingleArchBaseDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(DarkRedBrickItem))]
    public partial class SingleArchBaseDarkRedBrickBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchBaseDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseDarkRedBrick270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidDarkRedBrickBlock), typeof(SingleArchMidDarkRedBrick90Block), typeof(SingleArchMidDarkRedBrick180Block), typeof(SingleArchMidDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchMidFormType), typeof(DarkRedBrickItem))]
    public partial class SingleArchMidDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchMidDarkRedBrick270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopDarkRedBrickBlock), typeof(SingleArchTopDarkRedBrick90Block), typeof(SingleArchTopDarkRedBrick180Block), typeof(SingleArchTopDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchTopFormType), typeof(DarkRedBrickItem))]
    public partial class SingleArchTopDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopDarkRedBrick270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofDarkRedBrickBlock), typeof(SingleArchRoofDarkRedBrick90Block), typeof(SingleArchRoofDarkRedBrick180Block), typeof(SingleArchRoofDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofDarkRedBrick270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftDarkRedBrickBlock), typeof(BaseLeftDarkRedBrick90Block), typeof(BaseLeftDarkRedBrick180Block), typeof(BaseLeftDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseLeftFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class BaseLeftDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftDarkRedBrick270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightDarkRedBrickBlock), typeof(BaseRightDarkRedBrick90Block), typeof(BaseRightDarkRedBrick180Block), typeof(BaseRightDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BaseRightFormType), typeof(DarkRedBrickItem))]
    public partial class BaseRightDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightDarkRedBrick270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidDarkRedBrickBlock), typeof(BaseMidDarkRedBrick90Block), typeof(BaseMidDarkRedBrick180Block), typeof(BaseMidDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseMidFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class BaseMidDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidDarkRedBrick270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidDarkRedBrickBlock), typeof(MidMidDarkRedBrick90Block), typeof(MidMidDarkRedBrick180Block), typeof(MidMidDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidMidFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class MidMidDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidDarkRedBrick270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftDarkRedBrickBlock), typeof(MidLeftDarkRedBrick90Block), typeof(MidLeftDarkRedBrick180Block), typeof(MidLeftDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidLeftFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class MidLeftDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftDarkRedBrick270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightDarkRedBrickBlock), typeof(MidRightDarkRedBrick90Block), typeof(MidRightDarkRedBrick180Block), typeof(MidRightDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(MidRightFormType), typeof(DarkRedBrickItem))]
    public partial class MidRightDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightDarkRedBrick270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidDarkRedBrickBlock), typeof(TopMidDarkRedBrick90Block), typeof(TopMidDarkRedBrick180Block), typeof(TopMidDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(TopMidFormType), typeof(DarkRedBrickItem))]
    public partial class TopMidDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidDarkRedBrick270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftDarkRedBrickBlock), typeof(TopLeftDarkRedBrick90Block), typeof(TopLeftDarkRedBrick180Block), typeof(TopLeftDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopLeftFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class TopLeftDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftDarkRedBrick270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightDarkRedBrickBlock), typeof(TopRightDarkRedBrick90Block), typeof(TopRightDarkRedBrick180Block), typeof(TopRightDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopRightFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class TopRightDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightDarkRedBrick270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftDarkRedBrickBlock), typeof(RoofLeftDarkRedBrick90Block), typeof(RoofLeftDarkRedBrick180Block), typeof(RoofLeftDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofLeftFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class RoofLeftDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftDarkRedBrick270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightDarkRedBrickBlock), typeof(RoofRightDarkRedBrick90Block), typeof(RoofRightDarkRedBrick180Block), typeof(RoofRightDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofRightFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class RoofRightDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightDarkRedBrick270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidDarkRedBrickBlock), typeof(RoofMidDarkRedBrick90Block), typeof(RoofMidDarkRedBrick180Block), typeof(RoofMidDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ARoofMidFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class RoofMidDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidDarkRedBrick270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseDarkRedBrickBlock), typeof(InnerCornerBaseDarkRedBrick90Block), typeof(InnerCornerBaseDarkRedBrick180Block), typeof(InnerCornerBaseDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseDarkRedBrick270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidDarkRedBrickBlock), typeof(InnerCornerMidDarkRedBrick90Block), typeof(InnerCornerMidDarkRedBrick180Block), typeof(InnerCornerMidDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidDarkRedBrick270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopDarkRedBrickBlock), typeof(InnerCornerTopDarkRedBrick90Block), typeof(InnerCornerTopDarkRedBrick180Block), typeof(InnerCornerTopDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopDarkRedBrick270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseDarkRedBrickBlock), typeof(OutterCornerBaseDarkRedBrick90Block), typeof(OutterCornerBaseDarkRedBrick180Block), typeof(OutterCornerBaseDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(DarkRedBrickItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseDarkRedBrick270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidDarkRedBrickBlock), typeof(OutterCornerMidDarkRedBrick90Block), typeof(OutterCornerMidDarkRedBrick180Block), typeof(OutterCornerMidDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerMidFormType), typeof(DarkRedBrickItem))]
    public partial class OutterCornerMidDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidDarkRedBrick270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopDarkRedBrickBlock), typeof(OutterCornerTopDarkRedBrick90Block), typeof(OutterCornerTopDarkRedBrick180Block), typeof(OutterCornerTopDarkRedBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerTopFormType), typeof(DarkRedBrickItem))]
    public partial class OutterCornerTopDarkRedBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DarkRedBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopDarkRedBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopDarkRedBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopDarkRedBrick270Block : Block
    { }
    #endregion
    #endregion
}
