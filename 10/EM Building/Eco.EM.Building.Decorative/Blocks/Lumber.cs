using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.EM.Building.Decorative
{
    [RotatedVariants(typeof(LumberThinWallBraceBlock), typeof(LumberThinWallBrace90Block), typeof(LumberThinWallBrace180Block), typeof(LumberThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(LumberItem))]
    public partial class LumberThinWallBraceBlock :
            Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(LumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class LumberThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class LumberThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class LumberThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(LumberThinWallPoleBlock), typeof(LumberThinWallPole90Block), typeof(LumberThinWallPole180Block), typeof(LumberThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(LumberItem))]
    public partial class LumberThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(LumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class LumberThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class LumberThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class LumberThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(LumberThinWallBeamBlock), typeof(LumberThinWallBeam90Block), typeof(LumberThinWallBeam180Block), typeof(LumberThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(LumberItem))]
    public partial class LumberThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(LumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class LumberThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class LumberThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class LumberThinWallBeam270Block : Block
    { }

    [RotatedVariants(typeof(HardwoodLumberThinWallBraceBlock), typeof(HardwoodLumberThinWallBrace90Block), typeof(HardwoodLumberThinWallBrace180Block), typeof(HardwoodLumberThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(HardwoodLumberItem))]
    public partial class HardwoodLumberThinWallBraceBlock :
           Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HardwoodLumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodLumberThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodLumberThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodLumberThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(HardwoodLumberThinWallPoleBlock), typeof(HardwoodLumberThinWallPole90Block), typeof(HardwoodLumberThinWallPole180Block), typeof(HardwoodLumberThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(HardwoodLumberItem))]
    public partial class HardwoodLumberThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HardwoodLumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodLumberThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodLumberThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodLumberThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(HardwoodLumberThinWallBeamBlock), typeof(HardwoodLumberThinWallBeam90Block), typeof(HardwoodLumberThinWallBeam180Block), typeof(HardwoodLumberThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(HardwoodLumberItem))]
    public partial class HardwoodLumberThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HardwoodLumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodLumberThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodLumberThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodLumberThinWallBeam270Block : Block
    { }

    [RotatedVariants(typeof(SoftwoodLumberThinWallBraceBlock), typeof(SoftwoodLumberThinWallBrace90Block), typeof(SoftwoodLumberThinWallBrace180Block), typeof(SoftwoodLumberThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(SoftwoodLumberItem))]
    public partial class SoftwoodLumberThinWallBraceBlock :
           Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(SoftwoodLumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodLumberThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodLumberThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodLumberThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(SoftwoodLumberThinWallPoleBlock), typeof(SoftwoodLumberThinWallPole90Block), typeof(SoftwoodLumberThinWallPole180Block), typeof(SoftwoodLumberThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(SoftwoodLumberItem))]
    public partial class SoftwoodLumberThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(SoftwoodLumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodLumberThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodLumberThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodLumberThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(SoftwoodLumberThinWallBeamBlock), typeof(SoftwoodLumberThinWallBeam90Block), typeof(SoftwoodLumberThinWallBeam180Block), typeof(SoftwoodLumberThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(SoftwoodLumberItem))]
    public partial class SoftwoodLumberThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(SoftwoodLumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodLumberThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodLumberThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodLumberThinWallBeam270Block : Block
    { }
}