using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Building.Windows;
using Eco.EM.Framework.Extentsions;
using Eco.Core.Items;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(BlackGlassWall45Block), typeof(BlackGlassWall4590Block), typeof(BlackGlassWall45180Block), typeof(BlackGlassWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(BlackGlassItem))]
    [Tag("Constructable")]
    public partial class BlackGlassWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackGlassItem);

        public override Type BaseType => typeof(GlassWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassWall4590Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassWall45180Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassWall45270Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45270Block);
    }
}
