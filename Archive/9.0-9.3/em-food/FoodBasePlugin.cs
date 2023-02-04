using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.Shared.Localization;

namespace Eco.EM.Food
{
    public class FoodBaseConfig : IStackSizeConfig
    {
        [LocDescription("Stacks")]
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; } = new SerializedSynchronizedCollection<StackSizeElement>();
    }

    public class FoodBasePlugin : IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public const string version = "2.0.0";
        public const string packName = "Food Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus() => "Loaded and feeling hungry..";

        public override string ToString() => Localizer.DoStr("EM Food");

        public void Initialize(TimedTask timer)
        {
            StackSizeController.Obj.InitializeStackConfig(Config);
        }

        public FoodBasePlugin()
        {
            this.config = new PluginConfig<FoodBaseConfig>("EM-Food");
        }

        private PluginConfig<FoodBaseConfig> config;
        public IPluginConfig PluginConfig => this.config;
        public FoodBaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();
        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
    }
}
