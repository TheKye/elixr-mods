using Eco.Core.Utils;
using Eco.Shared.Localization;

namespace Eco.EM.Framework
{
    public class BaseConfig
    {
        [LocDescription("Whether or not to check EM pack versions and display them.")]
        public bool VersionDisplayEnabled { get; set; } = true;
    }
}
