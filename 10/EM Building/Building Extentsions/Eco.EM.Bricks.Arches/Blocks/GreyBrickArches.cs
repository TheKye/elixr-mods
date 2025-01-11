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

namespace Eco.EM.Building.Bricks.Arches
{
    #region Single Arches
    #region Base
    [RotatedVariants(typeof(SingleArchBaseGreyBrickBlock), typeof(SingleArchBaseGreyBrick90Block), typeof(SingleArchBaseGreyBrick180Block), typeof(SingleArchBaseGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(GreyBrickItem))]
    public partial class SingleArchBaseGreyBrickBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchBaseGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseGreyBrick270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidGreyBrickBlock), typeof(SingleArchMidGreyBrick90Block), typeof(SingleArchMidGreyBrick180Block), typeof(SingleArchMidGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchMidFormType), typeof(GreyBrickItem))]
    public partial class SingleArchMidGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchMidGreyBrick270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopGreyBrickBlock), typeof(SingleArchTopGreyBrick90Block), typeof(SingleArchTopGreyBrick180Block), typeof(SingleArchTopGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchTopFormType), typeof(GreyBrickItem))]
    public partial class SingleArchTopGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopGreyBrick270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofGreyBrickBlock), typeof(SingleArchRoofGreyBrick90Block), typeof(SingleArchRoofGreyBrick180Block), typeof(SingleArchRoofGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofGreyBrick270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftGreyBrickBlock), typeof(BaseLeftGreyBrick90Block), typeof(BaseLeftGreyBrick180Block), typeof(BaseLeftGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseLeftFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class BaseLeftGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftGreyBrick270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightGreyBrickBlock), typeof(BaseRightGreyBrick90Block), typeof(BaseRightGreyBrick180Block), typeof(BaseRightGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BaseRightFormType), typeof(GreyBrickItem))]
    public partial class BaseRightGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightGreyBrick270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidGreyBrickBlock), typeof(BaseMidGreyBrick90Block), typeof(BaseMidGreyBrick180Block), typeof(BaseMidGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseMidFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class BaseMidGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidGreyBrick270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidGreyBrickBlock), typeof(MidMidGreyBrick90Block), typeof(MidMidGreyBrick180Block), typeof(MidMidGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidMidFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class MidMidGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidGreyBrick270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftGreyBrickBlock), typeof(MidLeftGreyBrick90Block), typeof(MidLeftGreyBrick180Block), typeof(MidLeftGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidLeftFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class MidLeftGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftGreyBrick270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightGreyBrickBlock), typeof(MidRightGreyBrick90Block), typeof(MidRightGreyBrick180Block), typeof(MidRightGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(MidRightFormType), typeof(GreyBrickItem))]
    public partial class MidRightGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightGreyBrick270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidGreyBrickBlock), typeof(TopMidGreyBrick90Block), typeof(TopMidGreyBrick180Block), typeof(TopMidGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(TopMidFormType), typeof(GreyBrickItem))]
    public partial class TopMidGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidGreyBrick270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftGreyBrickBlock), typeof(TopLeftGreyBrick90Block), typeof(TopLeftGreyBrick180Block), typeof(TopLeftGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopLeftFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class TopLeftGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftGreyBrick270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightGreyBrickBlock), typeof(TopRightGreyBrick90Block), typeof(TopRightGreyBrick180Block), typeof(TopRightGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopRightFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class TopRightGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightGreyBrick270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftGreyBrickBlock), typeof(RoofLeftGreyBrick90Block), typeof(RoofLeftGreyBrick180Block), typeof(RoofLeftGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofLeftFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class RoofLeftGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftGreyBrick270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightGreyBrickBlock), typeof(RoofRightGreyBrick90Block), typeof(RoofRightGreyBrick180Block), typeof(RoofRightGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofRightFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class RoofRightGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightGreyBrick270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidGreyBrickBlock), typeof(RoofMidGreyBrick90Block), typeof(RoofMidGreyBrick180Block), typeof(RoofMidGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofMidFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class RoofMidGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidGreyBrick270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseGreyBrickBlock), typeof(InnerCornerBaseGreyBrick90Block), typeof(InnerCornerBaseGreyBrick180Block), typeof(InnerCornerBaseGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseGreyBrick270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidGreyBrickBlock), typeof(InnerCornerMidGreyBrick90Block), typeof(InnerCornerMidGreyBrick180Block), typeof(InnerCornerMidGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidGreyBrick270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopGreyBrickBlock), typeof(InnerCornerTopGreyBrick90Block), typeof(InnerCornerTopGreyBrick180Block), typeof(InnerCornerTopGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopGreyBrick270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseGreyBrickBlock), typeof(OutterCornerBaseGreyBrick90Block), typeof(OutterCornerBaseGreyBrick180Block), typeof(OutterCornerBaseGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(GreyBrickItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseGreyBrick270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidGreyBrickBlock), typeof(OutterCornerMidGreyBrick90Block), typeof(OutterCornerMidGreyBrick180Block), typeof(OutterCornerMidGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerMidFormType), typeof(GreyBrickItem))]
    public partial class OutterCornerMidGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidGreyBrick270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopGreyBrickBlock), typeof(OutterCornerTopGreyBrick90Block), typeof(OutterCornerTopGreyBrick180Block), typeof(OutterCornerTopGreyBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerTopFormType), typeof(GreyBrickItem))]
    public partial class OutterCornerTopGreyBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopGreyBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopGreyBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopGreyBrick270Block : Block
    { }
    #endregion
    #endregion
}
