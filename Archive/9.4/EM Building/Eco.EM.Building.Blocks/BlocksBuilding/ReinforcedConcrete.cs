using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(ReinforcedConcreteWall45Block), typeof(ReinforcedConcreteWall4590Block), typeof(ReinforcedConcreteWall45180Block), typeof(ReinforcedConcreteWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteWall45Block :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(ReinforcedConcreteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class ReinforcedConcreteWall45270Block : Block
    { }
}
