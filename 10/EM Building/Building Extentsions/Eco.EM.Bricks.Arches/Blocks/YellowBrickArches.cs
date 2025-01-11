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
    [RotatedVariants(typeof(SingleArchBaseYellowBrickBlock), typeof(SingleArchBaseYellowBrick90Block), typeof(SingleArchBaseYellowBrick180Block), typeof(SingleArchBaseYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchBaseFormType), typeof(YellowBrickItem))]
    public partial class SingleArchBaseYellowBrickBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchBaseYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchBaseYellowBrick270Block : Block
    { }

    #endregion
    #region Mid
    [RotatedVariants(typeof(SingleArchMidYellowBrickBlock), typeof(SingleArchMidYellowBrick90Block), typeof(SingleArchMidYellowBrick180Block), typeof(SingleArchMidYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchMidFormType), typeof(YellowBrickItem))]
    public partial class SingleArchMidYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class SingleArchMidYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchMidYellowBrick270Block : Block
    { }
    #endregion
    #region Top
    [RotatedVariants(typeof(SingleArchTopYellowBrickBlock), typeof(SingleArchTopYellowBrick90Block), typeof(SingleArchTopYellowBrick180Block), typeof(SingleArchTopYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(SingleArchTopFormType), typeof(YellowBrickItem))]
    public partial class SingleArchTopYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchTopYellowBrick270Block : Block
    { }
    #endregion
    #region Roof
    [RotatedVariants(typeof(SingleArchRoofYellowBrickBlock), typeof(SingleArchRoofYellowBrick90Block), typeof(SingleArchRoofYellowBrick180Block), typeof(SingleArchRoofYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(SingleArchRoofFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class SingleArchRoofYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SingleArchRoofYellowBrick270Block : Block
    { }
    #endregion
    #endregion
    #region Multi Arches
    #region BaseLeft
    [RotatedVariants(typeof(BaseLeftYellowBrickBlock), typeof(BaseLeftYellowBrick90Block), typeof(BaseLeftYellowBrick180Block), typeof(BaseLeftYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseLeftFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class BaseLeftYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseLeftYellowBrick270Block : Block
    { }
    #endregion
    #region Base Right
    [RotatedVariants(typeof(BaseRightYellowBrickBlock), typeof(BaseRightYellowBrick90Block), typeof(BaseRightYellowBrick180Block), typeof(BaseRightYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(BaseRightFormType), typeof(YellowBrickItem))]
    public partial class BaseRightYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseRightYellowBrick270Block : Block
    { }

    #endregion
    #region Base Mid
    [RotatedVariants(typeof(BaseMidYellowBrickBlock), typeof(BaseMidYellowBrick90Block), typeof(BaseMidYellowBrick180Block), typeof(BaseMidYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(BaseMidFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class BaseMidYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BaseMidYellowBrick270Block : Block
    { }
    #endregion
    #region Mid Mid
    [RotatedVariants(typeof(MidMidYellowBrickBlock), typeof(MidMidYellowBrick90Block), typeof(MidMidYellowBrick180Block), typeof(MidMidYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidMidFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class MidMidYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidMidYellowBrick270Block : Block
    { }
    #endregion
    #region Mid Left
    [RotatedVariants(typeof(MidLeftYellowBrickBlock), typeof(MidLeftYellowBrick90Block), typeof(MidLeftYellowBrick180Block), typeof(MidLeftYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(MidLeftFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class MidLeftYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidLeftYellowBrick270Block : Block
    { }
    #endregion
    #region Mid Right
    [RotatedVariants(typeof(MidRightYellowBrickBlock), typeof(MidRightYellowBrick90Block), typeof(MidRightYellowBrick180Block), typeof(MidRightYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(MidRightFormType), typeof(YellowBrickItem))]
    public partial class MidRightYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class MidRightYellowBrick270Block : Block
    { }
    #endregion
    #region Top Mid
    [RotatedVariants(typeof(TopMidYellowBrickBlock), typeof(TopMidYellowBrick90Block), typeof(TopMidYellowBrick180Block), typeof(TopMidYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(TopMidFormType), typeof(YellowBrickItem))]
    public partial class TopMidYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopMidYellowBrick270Block : Block
    { }
    #endregion
    #region Top Left
    [RotatedVariants(typeof(TopLeftYellowBrickBlock), typeof(TopLeftYellowBrick90Block), typeof(TopLeftYellowBrick180Block), typeof(TopLeftYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopLeftFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class TopLeftYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopLeftYellowBrick270Block : Block
    { }
    #endregion
    #region Top Right
    [RotatedVariants(typeof(TopRightYellowBrickBlock), typeof(TopRightYellowBrick90Block), typeof(TopRightYellowBrick180Block), typeof(TopRightYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(TopRightFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class TopRightYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class TopRightYellowBrick270Block : Block
    { }
    #endregion
    #region RoofLeft
    [RotatedVariants(typeof(RoofLeftYellowBrickBlock), typeof(RoofLeftYellowBrick90Block), typeof(RoofLeftYellowBrick180Block), typeof(RoofLeftYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofLeftFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class RoofLeftYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofLeftYellowBrick270Block : Block
    { }
    #endregion
    #region Roof Right
    [RotatedVariants(typeof(RoofRightYellowBrickBlock), typeof(RoofRightYellowBrick90Block), typeof(RoofRightYellowBrick180Block), typeof(RoofRightYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(RoofRightFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class RoofRightYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofRightYellowBrick270Block : Block
    { }
    #endregion
    #region Roof Mid
    [RotatedVariants(typeof(RoofMidYellowBrickBlock), typeof(RoofMidYellowBrick90Block), typeof(RoofMidYellowBrick180Block), typeof(RoofMidYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof( RoofMidFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class RoofMidYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RoofMidYellowBrick270Block : Block
    { }
    #endregion
    #region Inner Base
    [RotatedVariants(typeof(InnerCornerBaseYellowBrickBlock), typeof(InnerCornerBaseYellowBrick90Block), typeof(InnerCornerBaseYellowBrick180Block), typeof(InnerCornerBaseYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerBaseFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerBaseYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerBaseYellowBrick270Block : Block
    { }
    #endregion
    #region Inner Mid
    [RotatedVariants(typeof(InnerCornerMidYellowBrickBlock), typeof(InnerCornerMidYellowBrick90Block), typeof(InnerCornerMidYellowBrick180Block), typeof(InnerCornerMidYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerMidFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerMidYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerMidYellowBrick270Block : Block
    { }
    #endregion
    #region Inner Top
    [RotatedVariants(typeof(InnerCornerTopYellowBrickBlock), typeof(InnerCornerTopYellowBrick90Block), typeof(InnerCornerTopYellowBrick180Block), typeof(InnerCornerTopYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(InnerCornerTopFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class InnerCornerTopYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class InnerCornerTopYellowBrick270Block : Block
    { }
    #endregion
    #region Outter Base
    [RotatedVariants(typeof(OutterCornerBaseYellowBrickBlock), typeof(OutterCornerBaseYellowBrick90Block), typeof(OutterCornerBaseYellowBrick180Block), typeof(OutterCornerBaseYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(OutterCornerBaseFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class OutterCornerBaseYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerBaseYellowBrick270Block : Block
    { }
    #endregion
    #region Outter Mid
    [RotatedVariants(typeof(OutterCornerMidYellowBrickBlock), typeof(OutterCornerMidYellowBrick90Block), typeof(OutterCornerMidYellowBrick180Block), typeof(OutterCornerMidYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerMidFormType), typeof(YellowBrickItem))]
    public partial class OutterCornerMidYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerMidYellowBrick270Block : Block
    { }
    #endregion
    #region Outter Top
    [RotatedVariants(typeof(OutterCornerTopYellowBrickBlock), typeof(OutterCornerTopYellowBrick90Block), typeof(OutterCornerTopYellowBrick180Block), typeof(OutterCornerTopYellowBrick270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(OutterCornerTopFormType), typeof(YellowBrickItem))]
    public partial class OutterCornerTopYellowBrickBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopYellowBrick90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopYellowBrick180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class OutterCornerTopYellowBrick270Block : Block
    { }
    #endregion
    #endregion
}
