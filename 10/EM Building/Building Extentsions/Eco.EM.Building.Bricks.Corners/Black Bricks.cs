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
    [RotatedVariants(typeof(BlackBrickWall45Block), typeof(BlackBrickWall4590Block), typeof(BlackBrickWall45180Block), typeof(BlackBrickWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(BlackBrickItem))]
    public partial class BlackBrickWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackBrickItem);

        public override Type BaseType => typeof(BrickWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickWall4590Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickWall45180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BlackBrickWall45270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45270Block);
    }
}
