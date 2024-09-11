using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.Core.Items;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(FramedGlassWall45Block), typeof(FramedGlassWall4590Block), typeof(FramedGlassWall45180Block), typeof(FramedGlassWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(4)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeWallFormType), typeof(FramedGlassItem))]
    public partial class FramedGlassWall45Block :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(FramedGlassItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(4)]
    [Tag("Constructable")]
    public partial class FramedGlassWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(4)]
    [Tag("Constructable")]
    public partial class FramedGlassWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(4)]
    [Tag("Constructable")]
    public partial class FramedGlassWall45270Block : Block
    { }
}
