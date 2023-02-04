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
    [IsForm(typeof(ShelvesFormType), typeof(HewnLogItem))]
    public partial class HewnLogShelfBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(ShelvesBlockFormType), typeof(HewnLogItem))]
    public partial class HewnLogShelfSolidBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }
    #region Catwalks
    [Serialized]
    [RotatedVariants(typeof(HewnLogCatwalkCornerBlock), typeof(HewnLogCatwalkCorner90Block), typeof(HewnLogCatwalkCorner180Block), typeof(HewnLogCatwalkCorner270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkCornerFormType), typeof(HewnLogItem))]
    public partial class HewnLogCatwalkCornerBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkCorner270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HewnLogCatwalkSideBlock), typeof(HewnLogCatwalkSide90Block), typeof(HewnLogCatwalkSide180Block), typeof(HewnLogCatwalkSide270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkSideFormType), typeof(HewnLogItem))]
    public partial class HewnLogCatwalkSideBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkSide270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HewnLogCatwalkSingleBlock), typeof(HewnLogCatwalkSingle90Block), typeof(HewnLogCatwalkSingle180Block), typeof(HewnLogCatwalkSingle270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkSingleFormType), typeof(HewnLogItem))]
    public partial class HewnLogCatwalkSingleBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkSingle90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkSingle180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkSingle270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HewnLogCatwalkInnerCornerBlock), typeof(HewnLogCatwalkInnerCorner90Block), typeof(HewnLogCatwalkInnerCorner180Block), typeof(HewnLogCatwalkInnerCorner270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkInnerCornerFormType), typeof(HewnLogItem))]
    public partial class HewnLogCatwalkInnerCornerBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkInnerCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkInnerCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkInnerCorner270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HewnLogCatwalkExtenBlock), typeof(HewnLogCatwalkExten90Block), typeof(HewnLogCatwalkExten180Block), typeof(HewnLogCatwalkExten270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkExtenFormType), typeof(HewnLogItem))]
    public partial class HewnLogCatwalkExtenBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkExten90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkExten180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkExten270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HewnLogCatwalkMiddleBlock), typeof(HewnLogCatwalkMiddle90Block), typeof(HewnLogCatwalkMiddle180Block), typeof(HewnLogCatwalkMiddle270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkExtenFormType), typeof(HewnLogItem))]
    public partial class HewnLogCatwalkMiddleBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkMiddle90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkMiddle180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HewnLogCatwalkMiddle270Block : Block
    { }
    #endregion
}
