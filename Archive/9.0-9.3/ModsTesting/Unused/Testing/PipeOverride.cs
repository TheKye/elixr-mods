using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Shared.Localization;

namespace ModsTesting.Unused.Testing
{
    public class PipeOverride : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus() => Localizer.DoStr($"You dirty polluter!");
        public void Initialize(TimedTask timer) { ChimneyComponent.MaxPipeHorizontalOffset = 100; }
    }
}