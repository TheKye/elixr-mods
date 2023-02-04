namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public partial class SingleArchFormGroup : FormGroup
    {
        public override string Name => "Single Arch";
        public override LocString DisplayName => Localizer.DoStr("Single Arch");
        public override LocString DisplayDescription => Localizer.DoStr("Single Arch");
        public override int SortOrder => 15;
    }

    public partial class ArchFormGroup : FormGroup
    {
        public override string Name => "Arch";
        public override LocString DisplayName => Localizer.DoStr("Arch");
        public override LocString DisplayDescription => Localizer.DoStr("Arch");
        public override int SortOrder => 14;
    }
}