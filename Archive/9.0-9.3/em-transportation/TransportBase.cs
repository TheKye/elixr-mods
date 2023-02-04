using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Transportation
{
    public class TransportBaseConfig : IStackSizeConfig
    {
        [LocDescription("Stacks")]
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; } = new SerializedSynchronizedCollection<StackSizeElement>();
    }

    class TransportBase : IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public const string version = "2.0.0";
        public const string packName = "Transportation Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus()
        {
            return "Loaded and ready to help..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM Transportation");
        }

        public TransportBase()
        {
            this.config = new PluginConfig<TransportBaseConfig>("EM-Transportation");
        }

        public void Initialize(TimedTask timer)
        {
            StackSizeController.Obj.InitializeStackConfig(Config);
        }

        private PluginConfig<TransportBaseConfig> config;
        public IPluginConfig PluginConfig => this.config;
        public TransportBaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();
        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
    }
}
