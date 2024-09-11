using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Utils;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Admin.AdminExtentsions
{
    public class AutoRestartSystem : Singleton<AutoRestartSystem>, IModKitPlugin, IInitializablePlugin, IConfigurablePlugin
    {
        public IPluginConfig PluginConfig => config;
        public PluginConfig<AutoRestartConfig> config;
        private AutoRestartConfig Config => config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();

        public object GetEditObject() => this.config.Config;
        public AutoRestartSystem()
        {
            this.config = new PluginConfig<AutoRestartConfig>("EM-Restarts");
        }
        public string GetCategory() => "Elixr Mods";

        public string GetStatus() => "";

        public void Initialize(TimedTask timer)
        {
        }

        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
    }
}
