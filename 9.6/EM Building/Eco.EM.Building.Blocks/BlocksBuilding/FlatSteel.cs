using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(FlatSteelWall45Block), typeof(FlatSteelWall4590Block), typeof(FlatSteelWall45180Block), typeof(FlatSteelWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(4)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(FlatSteelItem))]
    public partial class FlatSteelWall45Block :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(FlatSteelItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(4)]
    public partial class FlatSteelWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(4)]
    public partial class FlatSteelWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(4)]
    public partial class FlatSteelWall45270Block : Block
    { }
}
