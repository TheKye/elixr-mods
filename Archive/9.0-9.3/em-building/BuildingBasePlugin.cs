using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.Shared.Localization;

namespace Eco.EM.Building
{
    public class BuildingBaseConfig : IStackSizeConfig
    {
        [LocDescription("Stacks")]
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; } = new SerializedSynchronizedCollection<StackSizeElement>();
    }

    public class BuildingBasePlugin : IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public const string version = "1.0.0";
        public const string packName = "Building Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus() => "Loaded and Well.. You Know.. Build Me.";

        public override string ToString() => Localizer.DoStr("EM Building");

        public void Initialize(TimedTask timer)
        {
            StackSizeController.Obj.InitializeStackConfig(Config);
        }

        public BuildingBasePlugin()
        {
            this.config = new PluginConfig<BuildingBaseConfig>("EM Building");
        }

        private PluginConfig<BuildingBaseConfig> config;
        public IPluginConfig PluginConfig => this.config;
        public BuildingBaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();
        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
    }
}
