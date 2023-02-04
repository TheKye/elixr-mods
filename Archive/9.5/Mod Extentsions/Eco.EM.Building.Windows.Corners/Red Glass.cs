using System;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.Mods.TechTree;
using Eco.EM.Building.Windows;
using Eco.EM.Framework.Extentsions;

namespace Eco.EM.Building.Blocks
{
    [RotatedVariants(typeof(RedGlassWall45Block), typeof(RedGlassWall4590Block), typeof(RedGlassWall45180Block), typeof(RedGlassWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(RedGlassItem))]
    public partial class RedGlassWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(RedGlassItem);

        public override Type BaseType => typeof(GlassWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedGlassWall4590Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedGlassWall45180Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RedGlassWall45270Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45270Block);
    }
}
