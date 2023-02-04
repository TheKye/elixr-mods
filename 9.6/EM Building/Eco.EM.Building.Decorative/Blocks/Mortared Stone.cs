using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.EM.Building.Decorative
{
    [RotatedVariants(typeof(MortaredStoneThinWallBraceBlock), typeof(MortaredStoneThinWallBrace90Block), typeof(MortaredStoneThinWallBrace180Block), typeof(MortaredStoneThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneThinWallBraceBlock :
            Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredStoneThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredStoneThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredStoneThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(MortaredStoneThinWallPoleBlock), typeof(MortaredStoneThinWallPole90Block), typeof(MortaredStoneThinWallPole180Block), typeof(MortaredStoneThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredStoneThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredStoneThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredStoneThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(MortaredStoneThinWallBeamBlock), typeof(MortaredStoneThinWallBeam90Block), typeof(MortaredStoneThinWallBeam180Block), typeof(MortaredStoneThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredStoneThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredStoneThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredStoneThinWallBeam270Block : Block
    { }

    [RotatedVariants(typeof(MortaredGraniteThinWallBraceBlock), typeof(MortaredGraniteThinWallBrace90Block), typeof(MortaredGraniteThinWallBrace180Block), typeof(MortaredGraniteThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(MortaredGraniteItem))]
    public partial class MortaredGraniteThinWallBraceBlock :
           Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredGraniteThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredGraniteThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredGraniteThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(MortaredGraniteThinWallPoleBlock), typeof(MortaredGraniteThinWallPole90Block), typeof(MortaredGraniteThinWallPole180Block), typeof(MortaredGraniteThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(MortaredGraniteItem))]
    public partial class MortaredGraniteThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredGraniteThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredGraniteThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredGraniteThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(MortaredGraniteThinWallBeamBlock), typeof(MortaredGraniteThinWallBeam90Block), typeof(MortaredGraniteThinWallBeam180Block), typeof(MortaredGraniteThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(MortaredGraniteItem))]
    public partial class MortaredGraniteThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredGraniteThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredGraniteThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredGraniteThinWallBeam270Block : Block
    { }

    [RotatedVariants(typeof(MortaredSandstoneThinWallBraceBlock), typeof(MortaredSandstoneThinWallBrace90Block), typeof(MortaredSandstoneThinWallBrace180Block), typeof(MortaredSandstoneThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneThinWallBraceBlock :
           Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredSandstoneThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredSandstoneThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredSandstoneThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(MortaredSandstoneThinWallPoleBlock), typeof(MortaredSandstoneThinWallPole90Block), typeof(MortaredSandstoneThinWallPole180Block), typeof(MortaredSandstoneThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredSandstoneThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredSandstoneThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredSandstoneThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(MortaredSandstoneThinWallBeamBlock), typeof(MortaredSandstoneThinWallBeam90Block), typeof(MortaredSandstoneThinWallBeam180Block), typeof(MortaredSandstoneThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredSandstoneThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredSandstoneThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredSandstoneThinWallBeam270Block : Block
    { }

    [RotatedVariants(typeof(MortaredLimestoneThinWallBraceBlock), typeof(MortaredLimestoneThinWallBrace90Block), typeof(MortaredLimestoneThinWallBrace180Block), typeof(MortaredLimestoneThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(MortaredLimestoneItem))]
    public partial class MortaredLimestoneThinWallBraceBlock :
           Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredLimestoneThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredLimestoneThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredLimestoneThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(MortaredLimestoneThinWallPoleBlock), typeof(MortaredLimestoneThinWallPole90Block), typeof(MortaredLimestoneThinWallPole180Block), typeof(MortaredLimestoneThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(MortaredLimestoneItem))]
    public partial class MortaredLimestoneThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredLimestoneThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredLimestoneThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredLimestoneThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(MortaredLimestoneThinWallBeamBlock), typeof(MortaredLimestoneThinWallBeam90Block), typeof(MortaredLimestoneThinWallBeam180Block), typeof(MortaredLimestoneThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(MortaredLimestoneItem))]
    public partial class MortaredLimestoneThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredLimestoneThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredLimestoneThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class MortaredLimestoneThinWallBeam270Block : Block
    { }
}