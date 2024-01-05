using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.EM.Building.Decorative
{
    [RotatedVariants(typeof(CorrugatedSteelThinWallBraceBlock), typeof(CorrugatedSteelThinWallBrace90Block), typeof(CorrugatedSteelThinWallBrace180Block), typeof(CorrugatedSteelThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(CorrugatedSteelItem))]
    public partial class CorrugatedSteelThinWallBraceBlock :
            Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(CorrugatedSteelItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class CorrugatedSteelThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class CorrugatedSteelThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class CorrugatedSteelThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(CorrugatedSteelThinWallPoleBlock), typeof(CorrugatedSteelThinWallPole90Block), typeof(CorrugatedSteelThinWallPole180Block), typeof(CorrugatedSteelThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(CorrugatedSteelItem))]
    public partial class CorrugatedSteelThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(CorrugatedSteelItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class CorrugatedSteelThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class CorrugatedSteelThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class CorrugatedSteelThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(CorrugatedSteelThinWallBeamBlock), typeof(CorrugatedSteelThinWallBeam90Block), typeof(CorrugatedSteelThinWallBeam180Block), typeof(CorrugatedSteelThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(CorrugatedSteelItem))]
    public partial class CorrugatedSteelThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(CorrugatedSteelItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class CorrugatedSteelThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class CorrugatedSteelThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class CorrugatedSteelThinWallBeam270Block : Block
    { }
}