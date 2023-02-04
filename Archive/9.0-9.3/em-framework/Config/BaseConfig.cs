using Eco.Core.Utils;
using Eco.Shared.Localization;

namespace Eco.EM.Framework
{
    public class BaseConfig : IStackSizeConfig
    {
        [LocDescription("Whether or not to check EM pack versions and display them.")]
        public bool VersionDisplayEnabled { get; set; } = true;

        [LocDescription("Whether or not to allow control of vanilla StackSizes")]
        public bool VanillaStackSizeChanger { get; set; } = false;
        
        [LocDescription("Vanilla Stack Sizes: Editing stacksizes here requires a server restart. Changing the stack size of some items may have no ingame effect due to item data. Items added by modded .cs files will also appear here.")]
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; } = new SerializedSynchronizedCollection<StackSizeElement>();
    }
}
