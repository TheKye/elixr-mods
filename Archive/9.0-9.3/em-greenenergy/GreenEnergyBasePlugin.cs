using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.Shared.Localization;

namespace Eco.EM.GreenEnergy
{
    public class GreenEnergyBaseConfig : IStackSizeConfig
    {
        [LocDescription("Stacks")]
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; } = new SerializedSynchronizedCollection<StackSizeElement>();
    }

    public class GreenEnergyBasePlugin : IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public const string version = "2.0.0";
        public const string packName = "GreenEnergy Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus() => "Loaded and feeling hungry..";

        public override string ToString() => Localizer.DoStr("EM GreenEnergy");

        public void Initialize(TimedTask timer)
        {
            StackSizeController.Obj.InitializeStackConfig(Config);
        }

        public GreenEnergyBasePlugin()
        {
            this.config = new PluginConfig<GreenEnergyBaseConfig>("EM-GreenEnergy");
        }

        private readonly PluginConfig<GreenEnergyBaseConfig> config;
        public IPluginConfig PluginConfig => this.config;
        public GreenEnergyBaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();
        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
    }
}
