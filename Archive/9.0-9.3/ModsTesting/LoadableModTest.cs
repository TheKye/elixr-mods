using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Shared.Localization;
using Eco.Shared.Utils;

namespace Eco.EM.ModsTesting
{
    public class LoadableModTest : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus() => "Tester Mod";

        public LoadableModTest()
        {
            Log.WriteLine(Localizer.DoStr("INSIDE TEST MOD CCTR... "));
        }

        public void Initialize(TimedTask timer)
        {
            Log.WriteLine(Localizer.DoStr("INSIDE TEST MOD INIT... "));
        }
    }
}
