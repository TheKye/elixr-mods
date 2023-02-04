using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(AshlarShaleWall45Block), typeof(AshlarShaleWall4590Block), typeof(AshlarShaleWall45180Block), typeof(AshlarShaleWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleWall45Block :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AshlarShaleItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarShaleWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarShaleWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarShaleWall45270Block : Block
    { }

    [RotatedVariants(typeof(AshlarGneissWall45Block), typeof(AshlarGneissWall4590Block), typeof(AshlarGneissWall45180Block), typeof(AshlarGneissWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(AshlarGneissItem))]
    public partial class AshlarGneissWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AshlarGneissItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarGneissWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarGneissWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarGneissWall45270Block : Block
    { }

    [RotatedVariants(typeof(AshlarLimestoneWall45Block), typeof(AshlarLimestoneWall4590Block), typeof(AshlarLimestoneWall45180Block), typeof(AshlarLimestoneWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AshlarLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarLimestoneWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarLimestoneWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarLimestoneWall45270Block : Block
    { }

    [RotatedVariants(typeof(AshlarSandstoneWall45Block), typeof(AshlarSandstoneWall4590Block), typeof(AshlarSandstoneWall45180Block), typeof(AshlarSandstoneWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(AshlarSandstoneItem))]
    public partial class AshlarSandstoneWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AshlarSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarSandstoneWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarSandstoneWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarSandstoneWall45270Block : Block
    { }

    [RotatedVariants(typeof(AshlarBasaltWall45Block), typeof(AshlarBasaltWall4590Block), typeof(AshlarBasaltWall45180Block), typeof(AshlarBasaltWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(AshlarBasaltItem))]
    public partial class AshlarBasaltWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AshlarBasaltItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarBasaltWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarBasaltWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarBasaltWall45270Block : Block
    { }

    [RotatedVariants(typeof(AshlarGraniteWall45Block), typeof(AshlarGraniteWall4590Block), typeof(AshlarGraniteWall45180Block), typeof(AshlarGraniteWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteWall45Block :
Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AshlarGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarGraniteWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarGraniteWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class AshlarGraniteWall45270Block : Block
    { }

    
}
