using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.Core.Items;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(CorrugatedSteelWall45Block), typeof(CorrugatedSteelWall4590Block), typeof(CorrugatedSteelWall45180Block), typeof(CorrugatedSteelWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeWallFormType), typeof(CorrugatedSteelItem))]
    public partial class CorrugatedSteelWall45Block :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(CorrugatedSteelItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class CorrugatedSteelWall4590Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class CorrugatedSteelWall45180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class CorrugatedSteelWall45270Block : Block
    { }
}
