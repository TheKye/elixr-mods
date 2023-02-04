using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.Console;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Doors
{
    public class DoorsBaseConfig : IStackSizeConfig
    {
        [LocDescription("Stacks")]
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; } = new SerializedSynchronizedCollection<StackSizeElement>();
    }

    class DoorsBase : IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public const string version = "2.1.0";
        public const string packName = "Doors Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus()
        {
            return "Loaded and ready to open..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM Doors");
        }

        public DoorsBase()
        {
            this.config = new PluginConfig<DoorsBaseConfig>("EM-Doors");
        }

        public void Initialize(TimedTask timer)
        {
            StackSizeController.Obj.InitializeStackConfig(Config);
        }

        private PluginConfig<DoorsBaseConfig> config;
        public IPluginConfig PluginConfig => this.config;
        public DoorsBaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();
        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
    }
}
