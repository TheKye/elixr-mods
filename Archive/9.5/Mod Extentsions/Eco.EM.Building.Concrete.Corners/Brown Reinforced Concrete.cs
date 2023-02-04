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
    [RotatedVariants(typeof(BrownReinforcedConcreteWall45Block), typeof(BrownReinforcedConcreteWall4590Block), typeof(BrownReinforcedConcreteWall45180Block), typeof(BrownReinforcedConcreteWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(ReinforcedConcreteItem))]
    public partial class BrownReinforcedConcreteWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownReinforcedConcreteItem);
        public override Type BaseType => typeof(ReinforcedConcreteWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownReinforcedConcreteWall4590Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownReinforcedConcreteWall45180Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    public partial class BrownReinforcedConcreteWall45270Block : NBlock
    {
        public override Type BaseType => typeof(ReinforcedConcreteWall45270Block);
    }
}
