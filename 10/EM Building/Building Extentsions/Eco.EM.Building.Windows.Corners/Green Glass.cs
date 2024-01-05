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
    [RotatedVariants(typeof(GreenGlassWall45Block), typeof(GreenGlassWall4590Block), typeof(GreenGlassWall45180Block), typeof(GreenGlassWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenGlassItem);

        public override Type BaseType => typeof(GlassWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenGlassWall4590Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenGlassWall45180Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class GreenGlassWall45270Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45270Block);
    }
}
