using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.Core.Items;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(LumberWall45Block), typeof(LumberWall4590Block), typeof(LumberWall45180Block), typeof(LumberWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeWallFormType), typeof(LumberItem))]
    public partial class LumberWall45Block :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(LumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class LumberWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class LumberWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class LumberWall45270Block : Block
    { }

    [RotatedVariants(typeof(HardwoodLumberWall45Block), typeof(HardwoodLumberWall4590Block), typeof(HardwoodLumberWall45180Block), typeof(HardwoodLumberWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeWallFormType), typeof(HardwoodLumberItem))]
    public partial class HardwoodLumberWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HardwoodLumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class HardwoodLumberWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class HardwoodLumberWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class HardwoodLumberWall45270Block : Block
    { }

    [RotatedVariants(typeof(SoftwoodLumberWall45Block), typeof(SoftwoodLumberWall4590Block), typeof(SoftwoodLumberWall45180Block), typeof(SoftwoodLumberWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeWallFormType), typeof(SoftwoodLumberItem))]
    public partial class SoftwoodLumberWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(SoftwoodLumberItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SoftwoodLumberWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SoftwoodLumberWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class SoftwoodLumberWall45270Block : Block
    { }

}
