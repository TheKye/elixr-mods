using System;
using Eco.Gameplay.Blocks;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;

namespace Eco.EM.Building.Blocks
{

    public partial class FFDegreeWallFormType : FormType
    {
        public override string Name => "FFDegreeWall";
        public override LocString DisplayName => Localizer.DoStr("45 Degree Wall");
        public override LocString DisplayDescription => Localizer.DoStr("45 Degree Wall");
        public override Type GroupType => typeof(DegreeFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class FFDegreeRoadFormType : FormType
    {
        public override string Name => "FFDegreeRoad";
        public override LocString DisplayName => Localizer.DoStr("45 Degree Road");
        public override LocString DisplayDescription => Localizer.DoStr("45 Degree Road block");
        public override Type GroupType => typeof(BasicFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class FFDegreeRoadLineFormType : FormType
    {
        public override string Name => "FFDegreeRoadLine";
        public override LocString DisplayName => Localizer.DoStr("45 Degree Road Line");
        public override LocString DisplayDescription => Localizer.DoStr("45 Degree Road Line for marking the road edge");
        public override Type GroupType => typeof(BasicFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class FFDegreeRoadLineGapFormType : FormType
    {
        public override string Name => "FFDegreeRoadGap";
        public override LocString DisplayName => Localizer.DoStr("45 Degree Road Gap");
        public override LocString DisplayDescription => Localizer.DoStr("45 Degree Road Gap for filling in the missing gaps in the lines");
        public override Type GroupType => typeof(BasicFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }

    public partial class FFDegreeRoadMiddleLineFormType : FormType
    {
        public override string Name => "FFDegreeRoadMiddleLine";
        public override LocString DisplayName => Localizer.DoStr("45 Degree Road Middle Line");
        public override LocString DisplayDescription => Localizer.DoStr("45 Degree Road Middle Line to separate lanes on the angle");
        public override Type GroupType => typeof(BasicFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }
}
