using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Extentsions;
using Eco.EM.Building.Concrete;
using Eco.Core.Items;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(WhiteReinforcedConcreteWall45Block), typeof(WhiteReinforcedConcreteWall4590Block), typeof(WhiteReinforcedConcreteWall45180Block), typeof(WhiteReinforcedConcreteWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(WhiteReinforcedConcreteItem))]
    [Tag("Constructable")]
    public partial class WhiteReinforcedConcreteWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(WhiteReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class WhiteReinforcedConcreteWall4590Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class WhiteReinforcedConcreteWall45180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class WhiteReinforcedConcreteWall45270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45270Block);
    }
}
