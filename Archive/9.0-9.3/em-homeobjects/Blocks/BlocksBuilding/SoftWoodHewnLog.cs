namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(ShelvesFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodShelfBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(ShelvesBlockFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftWoodShelfSolidBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodHewnLogItem); } }
    }
    #region Catwalks
    [Serialized]
    [RotatedVariants(typeof(SoftwoodCatwalkCornerBlock), typeof(SoftwoodCatwalkCorner90Block), typeof(SoftwoodCatwalkCorner180Block), typeof(SoftwoodCatwalkCorner270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkCornerFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodCatwalkCornerBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkCorner270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(SoftwoodCatwalkSideBlock), typeof(SoftwoodCatwalkSide90Block), typeof(SoftwoodCatwalkSide180Block), typeof(SoftwoodCatwalkSide270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkSideFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodCatwalkSideBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkSide270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(SoftwoodCatwalkSingleBlock), typeof(SoftwoodCatwalkSingle90Block), typeof(SoftwoodCatwalkSingle180Block), typeof(SoftwoodCatwalkSingle270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkSingleFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodCatwalkSingleBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkSingle90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkSingle180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkSingle270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(SoftwoodCatwalkInnerCornerBlock), typeof(SoftwoodCatwalkInnerCorner90Block), typeof(SoftwoodCatwalkInnerCorner180Block), typeof(SoftwoodCatwalkInnerCorner270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkInnerCornerFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodCatwalkInnerCornerBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkInnerCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkInnerCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkInnerCorner270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(SoftwoodCatwalkExtenBlock), typeof(SoftwoodCatwalkExten90Block), typeof(SoftwoodCatwalkExten180Block), typeof(SoftwoodCatwalkExten270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkExtenFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodCatwalkExtenBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkExten90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkExten180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkExten270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(SoftwoodCatwalkMiddleBlock), typeof(SoftwoodCatwalkMiddle90Block), typeof(SoftwoodCatwalkMiddle180Block), typeof(SoftwoodCatwalkMiddle270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkExtenFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodCatwalkMiddleBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkMiddle90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkMiddle180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class SoftwoodCatwalkMiddle270Block : Block
    { }
    #endregion
}
