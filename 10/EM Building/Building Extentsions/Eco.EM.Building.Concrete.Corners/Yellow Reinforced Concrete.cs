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
    [RotatedVariants(typeof(YellowReinforcedConcreteWall45Block), typeof(YellowReinforcedConcreteWall4590Block), typeof(YellowReinforcedConcreteWall45180Block), typeof(YellowReinforcedConcreteWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(YellowReinforcedConcreteItem))]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(YellowReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteWall4590Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteWall45180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [Tag("Constructable")]
    public partial class YellowReinforcedConcreteWall45270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45270Block);
    }
}
