using Eco.Core.Items;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Machines.Vehicles
{

    public partial class TrainTracksStraightFormType : FormType
    {
        public override string Name => "Rails";
        public override LocString DisplayName => Localizer.DoStr("Train Track Straight");
        public override LocString DisplayDescription => Localizer.DoStr("Single Train Track");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class TrainTracksMiddleFormType : FormType
    {
        public override string Name => "Rails";
        public override LocString DisplayName => Localizer.DoStr("Train Track Middle");
        public override LocString DisplayDescription => Localizer.DoStr("Single Train Track");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    [Serialized]
    [RotatedVariants(typeof(RailRoadStraightBlock), typeof(RailRoadStraight90Block), typeof(RailRoadStraight180Block), typeof(RailRoadStraight270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(TrainTracksStraightFormType), typeof(BrickItem))]
    public partial class RailRoadStraightBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RailRoadStraight90Block : Block
    { }

    [Serialized]
    [Tag("Constructable")]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RailRoadStraight180Block : Block
    { }

    [Serialized]
    [Tag("Constructable")]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RailRoadStraight270Block : Block
    { }

    [Serialized]
    [RotatedVariants(typeof(RailRoadMiddleBlock), typeof(RailRoadMiddle90Block), typeof(RailRoadMiddle180Block), typeof(RailRoadMiddle270Block))]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(TrainTracksMiddleFormType), typeof(BrickItem))]
    public partial class RailRoadMiddleBlock :
Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrickItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class RailRoadMiddle90Block : Block
    { }

    [Serialized]
    [Tag("Constructable")]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RailRoadMiddle180Block : Block
    { }

    [Serialized]
    [Tag("Constructable")]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class RailRoadMiddle270Block : Block
    { }
}
