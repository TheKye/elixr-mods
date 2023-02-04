using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using System;

namespace Eco.Nid.ChatTags
{
    public class ChatTagsExtendedInit : IModKitPlugin, IInitializablePlugin, IConfigurablePlugin
    {
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();

        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();

        public IPluginConfig PluginConfig => this.config;
        private readonly PluginConfig<ExtendedConfig> config;
        public ExtendedConfig Config => this.config.Config;

        public static ChatTagsExtendedInit API { get; private set; }

        public string GetStatus()
        {
            return "";
        }

        public void Initialize(TimedTask timer)
        {
            throw new NotImplementedException();
        }

    }
}
