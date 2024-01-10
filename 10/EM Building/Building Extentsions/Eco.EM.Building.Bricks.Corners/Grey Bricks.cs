using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Building.Bricks;
using Eco.EM.Framework.Extentsions;
using Eco.Core.Items;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(GreyBrickWall45Block), typeof(GreyBrickWall4590Block), typeof(GreyBrickWall45180Block), typeof(GreyBrickWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(GreyBrickItem))]
    public partial class GreyBrickWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreyBrickItem);

        public override Type BaseType => typeof(BrickWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class GreyBrickWall4590Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class GreyBrickWall45180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [Tag("Constructable")]
    [BlockTier(2)]
    public partial class GreyBrickWall45270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45270Block);
    }
}
