using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.Core.Items;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(HewnLogWall45Block), typeof(HewnLogWall4590Block), typeof(HewnLogWall45180Block), typeof(HewnLogWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeWallFormType), typeof(HewnLogItem))]
    public partial class HewnLogWall45Block :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class HewnLogWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class HewnLogWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class HewnLogWall45270Block : Block
    { }

    [RotatedVariants(typeof(HardwoodHewnLogWall45Block), typeof(HardwoodHewnLogWall4590Block), typeof(HardwoodHewnLogWall45180Block), typeof(HardwoodHewnLogWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeWallFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(HardwoodHewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class HardwoodHewnLogWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class HardwoodHewnLogWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class HardwoodHewnLogWall45270Block : Block
    { }

    [RotatedVariants(typeof(SoftwoodHewnLogWall45Block), typeof(SoftwoodHewnLogWall4590Block), typeof(SoftwoodHewnLogWall45180Block), typeof(SoftwoodHewnLogWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeWallFormType), typeof(SoftwoodHewnLogItem))]
    public partial class SoftwoodHewnLogWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(SoftwoodHewnLogItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SoftwoodHewnLogWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SoftwoodHewnLogWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [Tag("Constructable")]
    public partial class SoftwoodHewnLogWall45270Block : Block
    { }

}
