using Eco.Gameplay.Blocks;
using Eco.Shared.Localization;

namespace Eco.EM.Building.Arches
{

    public partial class SingleArchFormGroup : FormGroup
    {
        public override string Name => "Single Arch";
        public override LocString DisplayName => Localizer.DoStr("Single Arch");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Pieces used to make Single Standing Archways");
        public override int SortOrder => 15;
    }

    public partial class ArchFormGroup : FormGroup
    {
        public override string Name => "Arch";
        public override LocString DisplayName => Localizer.DoStr("Arch");
        public override LocString DisplayDescription => Localizer.DoStr("Arch Pieces used to make Large Extending Archways");
        public override int SortOrder => 14;
    }
}
 