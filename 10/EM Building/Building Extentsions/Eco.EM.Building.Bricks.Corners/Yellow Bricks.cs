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
    [RotatedVariants(typeof(YellowBrickWall45Block), typeof(YellowBrickWall4590Block), typeof(YellowBrickWall45180Block), typeof(YellowBrickWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(YellowBrickItem))]
    [Tag("Constructable")]
    public partial class YellowBrickWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowBrickItem);

        public override Type BaseType => typeof(BrickWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class YellowBrickWall4590Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class YellowBrickWall45180Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class YellowBrickWall45270Block : NBlock
    {
        public override Type BaseType => typeof(BrickWall45270Block);
    }
}
