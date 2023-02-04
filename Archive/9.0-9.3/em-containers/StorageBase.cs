using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.Shared.Localization;

namespace Eco.EM.Storage
{
    class StorageBasePlugin : IModKitPlugin, IInitializablePlugin, IConfigurablePlugin
    {
        public const string version = "2.1.0";
        public const string packName = "Storage Kit Version:";
        public const string application = "[Elixr Mods]:";

        private readonly PluginConfig<StorageBaseConfig> config;
        public StorageBasePlugin()
        {
            this.config = new PluginConfig<StorageBaseConfig>("EM-Storage");
        }

        public IPluginConfig PluginConfig => this.config;
        public StorageBaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();

        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();

        public string GetStatus() => "Loaded and holding all things valuable..";

        public override string ToString() => Localizer.DoStr("EM Storage");

        public void Initialize(TimedTask timer)
        {
            StackSizeController.Obj.InitializeStackConfig(Config);
        }
    }
}
