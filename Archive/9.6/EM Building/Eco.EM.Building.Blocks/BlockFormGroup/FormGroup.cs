using Eco.Gameplay.Blocks;
using Eco.Shared.Localization;

namespace Eco.EM.Building.Blocks
{

    public partial class DegreeFormGroup : FormGroup
    {
        public override string Name => "45 Degree Blocks";
        public override LocString DisplayName => Localizer.DoStr("45 Degree Blocks");
        public override LocString DisplayDescription => Localizer.DoStr("45 Degree Blocks For that Detailed Builder");
        public override int SortOrder => 15;
    }
}
 