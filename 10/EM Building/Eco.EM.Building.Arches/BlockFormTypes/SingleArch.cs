using System;
using Eco.Gameplay.Blocks;
using Eco.Shared.Localization;

namespace Eco.EM.Building.Arches
{

    public partial class SingleArchBaseFormType : FormType
    {
        public override string Name => "SingleArchBase";
        public override LocString DisplayName => Localizer.DoStr("Arch Single Base");
        public override LocString DisplayDescription => Localizer.DoStr("Single Arch Pieces, Base Layer");
        public override Type GroupType => typeof(SingleArchFormGroup);
        public override int SortOrder => 1;
        public override int MinTier => 1;
    }
 
    public partial class SingleArchMidFormType : FormType
    {
        public override string Name => "SingleArchMid";
        public override LocString DisplayName => Localizer.DoStr("Arch Single Mid");
        public override LocString DisplayDescription => Localizer.DoStr("Single Arch Pieces, Middle Layer");
        public override Type GroupType => typeof(SingleArchFormGroup);
        public override int SortOrder => 2;
        public override int MinTier => 1;
    }

    public partial class SingleArchTopFormType : FormType
    {
        public override string Name => "SingleArchTop";
        public override LocString DisplayName => Localizer.DoStr("Arch Single Top");
        public override LocString DisplayDescription => Localizer.DoStr("Single Arch Pieces, Top Layer");
        public override Type GroupType => typeof(SingleArchFormGroup);
        public override int SortOrder => 3;
        public override int MinTier => 1;
    }

    public partial class SingleArchRoofFormType : FormType
    {
        public override string Name => "SingleArchRoof";
        public override LocString DisplayName => Localizer.DoStr("Arch Single Roof");
        public override LocString DisplayDescription => Localizer.DoStr("Single Arch Pieces, Roof Layer");
        public override Type GroupType => typeof(SingleArchFormGroup);
        public override int SortOrder => 4;
        public override int MinTier => 1;
    }
}
