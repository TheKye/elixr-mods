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
    [RotatedVariants(typeof(OrangeGlassWall45Block), typeof(OrangeGlassWall4590Block), typeof(OrangeGlassWall45180Block), typeof(OrangeGlassWall45270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FFDegreeWallFormType), typeof(OrangeGlassItem))]
    public partial class OrangeGlassWall45Block : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(OrangeGlassItem);

        public override Type BaseType => typeof(GlassWall45Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeGlassWall4590Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall4590Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeGlassWall45180Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class OrangeGlassWall45270Block : NBlock
    {
        public override Type BaseType => typeof(GlassWall45270Block);
    }
}
