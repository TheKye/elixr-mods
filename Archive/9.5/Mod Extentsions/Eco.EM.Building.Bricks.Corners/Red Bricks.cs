using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Building.Bricks;
using Eco.EM.Framework.Extentsions;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(RedBrickWall45Block), typeof(RedBrickWall4590Block), typeof(RedBrickWall45180Block), typeof(RedBrickWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(RedBrickItem))]
    public partial class RedBrickWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedBrickItem);

        public override Type BaseType => typeof(BrickWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickWall4590Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickWall45180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedBrickWall45270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45270Block);
    }
}
