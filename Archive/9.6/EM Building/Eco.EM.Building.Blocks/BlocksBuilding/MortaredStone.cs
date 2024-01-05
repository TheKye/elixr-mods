using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(MortaredStoneWall45Block), typeof(MortaredStoneWall4590Block), typeof(MortaredStoneWall45180Block), typeof(MortaredStoneWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneWall45Block :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredStoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredStoneWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredStoneWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredStoneWall45270Block : Block
    { }

    [RotatedVariants(typeof(MortaredSandstoneWall45Block), typeof(MortaredSandstoneWall4590Block), typeof(MortaredSandstoneWall45180Block), typeof(MortaredSandstoneWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredSandstoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredSandstoneWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredSandstoneWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredSandstoneWall45270Block : Block
    { }

    [RotatedVariants(typeof(MortaredLimestoneWall45Block), typeof(MortaredLimestoneWall4590Block), typeof(MortaredLimestoneWall45180Block), typeof(MortaredLimestoneWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(MortaredLimestoneItem))]
    public partial class MortaredLimestoneWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredLimestoneItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredLimestoneWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredLimestoneWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredLimestoneWall45270Block : Block
    { }

    [RotatedVariants(typeof(MortaredGraniteWall45Block), typeof(MortaredGraniteWall4590Block), typeof(MortaredGraniteWall45180Block), typeof(MortaredGraniteWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(MortaredGraniteItem))]
    public partial class MortaredGraniteWall45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(MortaredGraniteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredGraniteWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredGraniteWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(1)]
    public partial class MortaredGraniteWall45270Block : Block
    { }
}
