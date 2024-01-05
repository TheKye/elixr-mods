using System;
using Eco.Gameplay.Blocks;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;

namespace Eco.EM.Building.Decorative
{

    public partial class ThinBraceFormType : FormType
    {
        public override string Name => "ThinBrace";
        public override LocString DisplayName => Localizer.DoStr("Thin Brace");
        public override LocString DisplayDescription => Localizer.DoStr("A Thin Brace that can be used as a crossbeam support");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 4;
        public override int MinTier => 1;
    }

    public partial class ThinUnderBraceFormType : FormType
    {
        public override string Name => "ThinUnderBrace";
        public override LocString DisplayName => Localizer.DoStr("Thin Under Brace");
        public override LocString DisplayDescription => Localizer.DoStr("A Thin Brace that can be used as a crossbeam support");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 7;
        public override int MinTier => 1;
    }

    public partial class ThinPoleFormType : FormType
    {
        public override string Name => "ThinPole";
        public override LocString DisplayName => Localizer.DoStr("Thin Pole");
        public override LocString DisplayDescription => Localizer.DoStr("A Thin Pole that can be used as vertical support");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 5;
        public override int MinTier => 1;
    }

    public partial class ThinBeamFormType : FormType
    {
        public override string Name => "ThinBeam";
        public override LocString DisplayName => Localizer.DoStr("Thin Beam");
        public override LocString DisplayDescription => Localizer.DoStr("A Thin Beam that can be used as light support in doorways");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 6;
        public override int MinTier => 1;
    }

    public partial class ThinLowerBeamFormType : FormType
    {
        public override string Name => "ThinLowerBeam";
        public override LocString DisplayName => Localizer.DoStr("Thin Lower Beam");
        public override LocString DisplayDescription => Localizer.DoStr("A Thin Beam that can be used as light support in doorways");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 6;
        public override int MinTier => 1;
    }
}
