using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;

namespace Eco.EM.Building.Decorative
{
    [RotatedVariants(typeof(ReinforcedConcreteThinWallBraceBlock), typeof(ReinforcedConcreteThinWallBrace90Block), typeof(ReinforcedConcreteThinWallBrace180Block), typeof(ReinforcedConcreteThinWallBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBraceFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteThinWallBraceBlock :
            Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ReinforcedConcreteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteThinWallBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteThinWallBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteThinWallBrace270Block : Block
    { }

    [RotatedVariants(typeof(ReinforcedConcreteThinWallPoleBlock), typeof(ReinforcedConcreteThinWallPole90Block), typeof(ReinforcedConcreteThinWallPole180Block), typeof(ReinforcedConcreteThinWallPole270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinPoleFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteThinWallPoleBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ReinforcedConcreteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteThinWallPole90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteThinWallPole180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteThinWallPole270Block : Block
    { }

    [RotatedVariants(typeof(ReinforcedConcreteThinWallBeamBlock), typeof(ReinforcedConcreteThinWallBeam90Block), typeof(ReinforcedConcreteThinWallBeam180Block), typeof(ReinforcedConcreteThinWallBeam270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinBeamFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteThinWallBeamBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ReinforcedConcreteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteThinWallBeam90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteThinWallBeam180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteThinWallBeam270Block : Block
    { }
}