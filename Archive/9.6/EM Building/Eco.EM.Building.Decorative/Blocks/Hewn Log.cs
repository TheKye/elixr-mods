using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.EM.Building.Decorative
{
    [RotatedVariants(typeof(HewnThinWallBraceBlock), typeof(HewnThinWallBrace90Block), typeof(HewnThinWallBrace180Block), typeof(HewnThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(HewnLogItem))]
    public partial class HewnThinWallBraceBlock :
            Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HewnThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HewnThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HewnThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(HewnThinWallPoleBlock), typeof(HewnThinWallPole90Block), typeof(HewnThinWallPole180Block), typeof(HewnThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(HewnLogItem))]
    public partial class HewnThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HewnThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HewnThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HewnThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(HewnThinWallBeamBlock), typeof(HewnThinWallBeam90Block), typeof(HewnThinWallBeam180Block), typeof(HewnThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(HewnLogItem))]
    public partial class HewnThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HewnThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HewnThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HewnThinWallBeam270Block : Block
    { }

    [RotatedVariants(typeof(HardwoodHewnThinWallBraceBlock), typeof(HardwoodHewnThinWallBrace90Block), typeof(HardwoodHewnThinWallBrace180Block), typeof(HardwoodHewnThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnThinWallBraceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HardwoodHewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodHewnThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodHewnThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodHewnThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(HardwoodHewnThinWallPoleBlock), typeof(HardwoodHewnThinWallPole90Block), typeof(HardwoodHewnThinWallPole180Block), typeof(HardwoodHewnThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HardwoodHewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodHewnThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodHewnThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodHewnThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(HardwoodHewnThinWallBeamBlock), typeof(HardwoodHewnThinWallBeam90Block), typeof(HardwoodHewnThinWallBeam180Block), typeof(HardwoodHewnThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HardwoodHewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodHewnThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodHewnThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class HardwoodHewnThinWallBeam270Block : Block
    { }

    [RotatedVariants(typeof(SoftwoodHewnThinWallBraceBlock), typeof(SoftwoodHewnThinWallBrace90Block), typeof(SoftwoodHewnThinWallBrace180Block), typeof(SoftwoodHewnThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodHewnThinWallBraceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(SoftwoodHewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodHewnThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodHewnThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodHewnThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(SoftwoodHewnThinWallPoleBlock), typeof(SoftwoodHewnThinWallPole90Block), typeof(SoftwoodHewnThinWallPole180Block), typeof(SoftwoodHewnThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodHewnThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(SoftwoodHewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodHewnThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodHewnThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodHewnThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(SoftwoodHewnThinWallBeamBlock), typeof(SoftwoodHewnThinWallBeam90Block), typeof(SoftwoodHewnThinWallBeam180Block), typeof(SoftwoodHewnThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodHewnThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(SoftwoodHewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodHewnThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodHewnThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class SoftwoodHewnThinWallBeam270Block : Block
    { }
}