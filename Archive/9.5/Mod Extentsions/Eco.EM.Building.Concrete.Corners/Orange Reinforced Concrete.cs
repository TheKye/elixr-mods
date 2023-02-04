using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Extentsions;
using Eco.EM.Building.Concrete;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(OrangeReinforcedConcreteWall45Block), typeof(OrangeReinforcedConcreteWall4590Block), typeof(OrangeReinforcedConcreteWall45180Block), typeof(OrangeReinforcedConcreteWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(ReinforcedConcreteItem))]
    public partial class OrangeReinforcedConcreteWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteWall4590Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteWall45180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class OrangeReinforcedConcreteWall45270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45270Block);
    }
}
