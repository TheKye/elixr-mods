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
    [IsForm(typeof(ShelvesFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodShelfBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(ShelvesBlockFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodShelfSolidBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }
    #region Catwalks
    [Serialized]
    [RotatedVariants(typeof(HardwoodCatwalkCornerBlock), typeof(HardwoodCatwalkCorner90Block), typeof(HardwoodCatwalkCorner180Block), typeof(HardwoodCatwalkCorner270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkCornerFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodCatwalkCornerBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkCorner270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HardwoodCatwalkSideBlock), typeof(HardwoodCatwalkSide90Block), typeof(HardwoodCatwalkSide180Block), typeof(HardwoodCatwalkSide270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkSideFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodCatwalkSideBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkSide270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HardwoodCatwalkSingleBlock), typeof(HardwoodCatwalkSingle90Block), typeof(HardwoodCatwalkSingle180Block), typeof(HardwoodCatwalkSingle270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkSingleFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodCatwalkSingleBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkSingle90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkSingle180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkSingle270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HardwoodCatwalkInnerCornerBlock), typeof(HardwoodCatwalkInnerCorner90Block), typeof(HardwoodCatwalkInnerCorner180Block), typeof(HardwoodCatwalkInnerCorner270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkInnerCornerFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodCatwalkInnerCornerBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkInnerCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkInnerCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkInnerCorner270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HardwoodCatwalkExtenBlock), typeof(HardwoodCatwalkExten90Block), typeof(HardwoodCatwalkExten180Block), typeof(HardwoodCatwalkExten270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkExtenFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodCatwalkExtenBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkExten90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkExten180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkExten270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(HardwoodCatwalkMiddleBlock), typeof(HardwoodCatwalkMiddle90Block), typeof(HardwoodCatwalkMiddle180Block), typeof(HardwoodCatwalkMiddle270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(CatwalkExtenFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodCatwalkMiddleBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkMiddle90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkMiddle180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class HardwoodCatwalkMiddle270Block : Block
    { }
    #endregion
}
