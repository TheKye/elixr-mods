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
    [RotatedVariants(typeof(BlueReinforcedConcreteWall45Block), typeof(BlueReinforcedConcreteWall4590Block), typeof(BlueReinforcedConcreteWall45180Block), typeof(BlueReinforcedConcreteWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(BlueReinforcedConcreteItem))]
    [Tag("Constructable")]
    public partial class BlueReinforcedConcreteWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class BlueReinforcedConcreteWall4590Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class BlueReinforcedConcreteWall45180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class BlueReinforcedConcreteWall45270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45270Block);
    }
}
