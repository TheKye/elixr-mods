using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.Core.Items;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(AsphaltConcreteRoad45Block), typeof(AsphaltConcreteRoad4590Block), typeof(AsphaltConcreteRoad45180Block), typeof(AsphaltConcreteRoad45270Block))]
    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeRoadFormType), typeof(AsphaltConcreteItem))]
    public partial class AsphaltConcreteRoad45Block :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AsphaltConcreteItem);
    }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoad4590Block : Block
    { }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoad45180Block : Block
    { }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoad45270Block : Block
    { }

    [RotatedVariants(typeof(AsphaltConcreteRoadLineMid45Block), typeof(AsphaltConcreteRoadLineMid4590Block), typeof(AsphaltConcreteRoadLineMid45180Block), typeof(AsphaltConcreteRoadLineMid45270Block))]
    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeRoadMiddleLineFormType), typeof(AsphaltConcreteItem))]
    public partial class AsphaltConcreteRoadLineMid45Block :
    Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AsphaltConcreteItem);
    }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoadLineMid4590Block : Block
    { }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoadLineMid45180Block : Block
    { }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoadLineMid45270Block : Block
    { }


    [RotatedVariants(typeof(AsphaltConcreteRoadLineGap45Block), typeof(    AsphaltConcreteRoadLineGap4590Block), typeof(    AsphaltConcreteRoadLineGap45180Block), typeof(    AsphaltConcreteRoadLineGap45270Block))]
    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeRoadLineGapFormType), typeof(AsphaltConcreteItem))]
    public partial class AsphaltConcreteRoadLineGap45Block :
Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AsphaltConcreteItem);
    }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoadLineGap4590Block : Block
    { }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class     AsphaltConcreteRoadLineGap45180Block : Block
    { }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class     AsphaltConcreteRoadLineGap45270Block : Block
    { }

    [RotatedVariants(typeof(AsphaltConcreteRoadLine45Block), typeof(AsphaltConcreteRoadLine4590Block), typeof(AsphaltConcreteRoadLine45180Block), typeof(AsphaltConcreteRoadLine45270Block))]
    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FFDegreeRoadLineFormType), typeof(AsphaltConcreteItem))]
    public partial class AsphaltConcreteRoadLine45Block :
Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(AsphaltConcreteItem);
    }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoadLine4590Block : Block
    { }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoadLine45180Block : Block
    { }

    [Serialized]
    [Road(1.4f, typeof(AsphaltConcreteItem)), Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class AsphaltConcreteRoadLine45270Block : Block
    { }
}
