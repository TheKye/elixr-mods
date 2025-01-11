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
    [RotatedVariants(typeof(SingleArchBaseOrangeBrickBlock), typeof(SingleArchBaseOrangeBrick90Block), typeof(SingleArchBaseOrangeBrick180Block), typeof(SingleArchBaseOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(OrangeBrickItem))]
    public partial class SingleArchBaseOrangeBrickBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchBaseOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseOrangeBrick270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidOrangeBrickBlock), typeof(SingleArchMidOrangeBrick90Block), typeof(SingleArchMidOrangeBrick180Block), typeof(SingleArchMidOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchMidFormType), typeof(OrangeBrickItem))]
    public partial class SingleArchMidOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchMidOrangeBrick270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopOrangeBrickBlock), typeof(SingleArchTopOrangeBrick90Block), typeof(SingleArchTopOrangeBrick180Block), typeof(SingleArchTopOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchTopFormType), typeof(OrangeBrickItem))]
    public partial class SingleArchTopOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopOrangeBrick270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofOrangeBrickBlock), typeof(SingleArchRoofOrangeBrick90Block), typeof(SingleArchRoofOrangeBrick180Block), typeof(SingleArchRoofOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofOrangeBrick270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftOrangeBrickBlock), typeof(BaseLeftOrangeBrick90Block), typeof(BaseLeftOrangeBrick180Block), typeof(BaseLeftOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseLeftFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class BaseLeftOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftOrangeBrick270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightOrangeBrickBlock), typeof(BaseRightOrangeBrick90Block), typeof(BaseRightOrangeBrick180Block), typeof(BaseRightOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BaseRightFormType), typeof(OrangeBrickItem))]
    public partial class BaseRightOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightOrangeBrick270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidOrangeBrickBlock), typeof(BaseMidOrangeBrick90Block), typeof(BaseMidOrangeBrick180Block), typeof(BaseMidOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseMidFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class BaseMidOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidOrangeBrick270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidOrangeBrickBlock), typeof(MidMidOrangeBrick90Block), typeof(MidMidOrangeBrick180Block), typeof(MidMidOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidMidFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class MidMidOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidOrangeBrick270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftOrangeBrickBlock), typeof(MidLeftOrangeBrick90Block), typeof(MidLeftOrangeBrick180Block), typeof(MidLeftOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidLeftFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class MidLeftOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftOrangeBrick270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightOrangeBrickBlock), typeof(MidRightOrangeBrick90Block), typeof(MidRightOrangeBrick180Block), typeof(MidRightOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(MidRightFormType), typeof(OrangeBrickItem))]
    public partial class MidRightOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightOrangeBrick270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidOrangeBrickBlock), typeof(TopMidOrangeBrick90Block), typeof(TopMidOrangeBrick180Block), typeof(TopMidOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(TopMidFormType), typeof(OrangeBrickItem))]
    public partial class TopMidOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidOrangeBrick270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftOrangeBrickBlock), typeof(TopLeftOrangeBrick90Block), typeof(TopLeftOrangeBrick180Block), typeof(TopLeftOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopLeftFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class TopLeftOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftOrangeBrick270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightOrangeBrickBlock), typeof(TopRightOrangeBrick90Block), typeof(TopRightOrangeBrick180Block), typeof(TopRightOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopRightFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class TopRightOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightOrangeBrick270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftOrangeBrickBlock), typeof(RoofLeftOrangeBrick90Block), typeof(RoofLeftOrangeBrick180Block), typeof(RoofLeftOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofLeftFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class RoofLeftOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftOrangeBrick270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightOrangeBrickBlock), typeof(RoofRightOrangeBrick90Block), typeof(RoofRightOrangeBrick180Block), typeof(RoofRightOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofRightFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class RoofRightOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightOrangeBrick270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidOrangeBrickBlock), typeof(RoofMidOrangeBrick90Block), typeof(RoofMidOrangeBrick180Block), typeof(RoofMidOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ARoofMidFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class RoofMidOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidOrangeBrick270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseOrangeBrickBlock), typeof(InnerCornerBaseOrangeBrick90Block), typeof(InnerCornerBaseOrangeBrick180Block), typeof(InnerCornerBaseOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseOrangeBrick270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidOrangeBrickBlock), typeof(InnerCornerMidOrangeBrick90Block), typeof(InnerCornerMidOrangeBrick180Block), typeof(InnerCornerMidOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidOrangeBrick270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopOrangeBrickBlock), typeof(InnerCornerTopOrangeBrick90Block), typeof(InnerCornerTopOrangeBrick180Block), typeof(InnerCornerTopOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopOrangeBrick270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseOrangeBrickBlock), typeof(OutterCornerBaseOrangeBrick90Block), typeof(OutterCornerBaseOrangeBrick180Block), typeof(OutterCornerBaseOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(OrangeBrickItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseOrangeBrick270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidOrangeBrickBlock), typeof(OutterCornerMidOrangeBrick90Block), typeof(OutterCornerMidOrangeBrick180Block), typeof(OutterCornerMidOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerMidFormType), typeof(OrangeBrickItem))]
    public partial class OutterCornerMidOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidOrangeBrick270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopOrangeBrickBlock), typeof(OutterCornerTopOrangeBrick90Block), typeof(OutterCornerTopOrangeBrick180Block), typeof(OutterCornerTopOrangeBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerTopFormType), typeof(OrangeBrickItem))]
    public partial class OutterCornerTopOrangeBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopOrangeBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopOrangeBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopOrangeBrick270Block : Block
    { }
    #endregion
    #endregion
}
