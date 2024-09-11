using Eco.Gameplay.Blocks;
using Eco.Shared.Localization;

namespace Eco.EM.Building.Shelving
{
    public partial class ShelvesFormGroup : FormGroup
    {
        public override string Name => "Shelves";
        public override LocString DisplayName => Localizer.DoStr("Shelves");
        public override LocString DisplayDescription => Localizer.DoStr("Shelves");
        public override int SortOrder => 18;
    }

    public partial class CatwalkFormGroup : FormGroup
    {
        public override string Name => "Catwalk";
        public override LocString DisplayName => Localizer.DoStr("Catwalks");
        public override LocString DisplayDescription => Localizer.DoStr("Catwalks");
        public override int SortOrder => 19;
    }
}