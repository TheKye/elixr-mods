using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.EM.Building.Decorative
{
    [RotatedVariants(typeof(BrickThinWallBraceBlock), typeof(BrickThinWallBrace90Block), typeof(BrickThinWallBrace180Block), typeof(BrickThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(BrickItem))]
    public partial class BrickThinWallBraceBlock :
            Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(BrickThinWallUnderBraceBlock), typeof(BrickThinWallUnderBrace90Block), typeof(BrickThinWallUnderBrace180Block), typeof(BrickThinWallUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinUnderBraceFormType), typeof(BrickItem))]
    public partial class BrickThinWallUnderBraceBlock :
            Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallUnderBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallUnderBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallUnderBrace270Block : Block
    { }

    [RotatedVariants(typeof(BrickThinWallPoleBlock), typeof(BrickThinWallPole90Block), typeof(BrickThinWallPole180Block), typeof(BrickThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(BrickItem))]
    public partial class BrickThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(BrickThinWallBeamBlock), typeof(BrickThinWallBeam90Block), typeof(BrickThinWallBeam180Block), typeof(BrickThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(BrickItem))]
    public partial class BrickThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallBeam270Block : Block
    { }

    [RotatedVariants(typeof(BrickThinWallLowerBeamBlock), typeof(BrickThinWallLowerBeam90Block), typeof(BrickThinWallLowerBeam180Block), typeof(BrickThinWallLowerBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinLowerBeamFormType), typeof(BrickItem))]
    public partial class BrickThinWallLowerBeamBlock :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallLowerBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallLowerBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrickThinWallLowerBeam270Block : Block
    { }
}