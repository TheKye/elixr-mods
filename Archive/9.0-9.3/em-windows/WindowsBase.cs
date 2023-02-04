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

namespace Eco.EM.Windows
{
    public class WindowsBaseConfig : IStackSizeConfig
    {
        [LocDescription("Stacks")]
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; } = new SerializedSynchronizedCollection<StackSizeElement>();
    }

    class WindowsBase : IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public const string version = "2.0.0";
        public const string packName = "Windows Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus()
        {
            return "Loaded and Looking Pretty..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM Windows");
        }

        public WindowsBase()
        {
            this.config = new PluginConfig<WindowsBaseConfig>("EM-Windows");
        }

        public void Initialize(TimedTask timer)
        {
            StackSizeController.Obj.InitializeStackConfig(Config);
        }

        private PluginConfig<WindowsBaseConfig> config;
        public IPluginConfig PluginConfig => this.config;
        public WindowsBaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();
        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
    }
}
