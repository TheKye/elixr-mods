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
    [RotatedVariants(typeof(GreenBrickWall45Block), typeof(GreenBrickWall4590Block), typeof(GreenBrickWall45180Block), typeof(GreenBrickWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(GreenBrickItem))]
    public partial class GreenBrickWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenBrickItem);

        public override Type BaseType => typeof(BrickWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickWall4590Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickWall45180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenBrickWall45270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45270Block);
    }
}
