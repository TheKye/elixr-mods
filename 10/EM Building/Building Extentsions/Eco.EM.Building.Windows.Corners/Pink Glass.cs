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
    [RotatedVariants(typeof(PinkGlassWall45Block), typeof(PinkGlassWall4590Block), typeof(PinkGlassWall45180Block), typeof(PinkGlassWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(PinkGlassItem))]
    public partial class PinkGlassWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(PinkGlassItem);

        public override Type BaseType => typeof(GlassWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkGlassWall4590Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkGlassWall45180Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class PinkGlassWall45270Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45270Block);
    }
}
