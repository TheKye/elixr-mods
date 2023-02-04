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

namespace Eco.EM.Games
{
    public class GamesBaseConfig : IStackSizeConfig
    {
        [LocDescription("Stacks")]
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; } = new SerializedSynchronizedCollection<StackSizeElement>();
    }

    class GamesBase : IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public const string version = "1.0.0";
        public const string packName = "Games Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus()
        {
            return "Loaded and Ready To Play..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM Games");
        }

        public GamesBase()
        {
            this.config = new PluginConfig<GamesBaseConfig>("EM-Games");
        }

        public void Initialize(TimedTask timer)
        {
            StackSizeController.Obj.InitializeStackConfig(Config);
        }

        private PluginConfig<GamesBaseConfig> config;
        public IPluginConfig PluginConfig => this.config;
        public GamesBaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();
        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();
    }
}
