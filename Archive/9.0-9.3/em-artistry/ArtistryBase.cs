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

namespace Eco.EM.Artistry
{
    class ArtistryBase : IInitializablePlugin, IModKitPlugin, IConfigurablePlugin
    {
        public const string version = "2.0.0";
        public const string packName = "Artistry Pack Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus()
        {
            return "Loaded and getting creative..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM Artistry");
        }

        /// <summary>
        /// Apply the new skills to each person who logs into the server if they do not have it.
        /// This is required to have the UI add the profession correctly also.
        /// </summary>
        public void Initialize(TimedTask timer)
        {
            UserManager.OnUserLoggedIn.Add(u =>
            {
                if (!u.Skillset.HasSkill(typeof(ArtistSkill)))
                    u.Skillset.LearnSkill(typeof(ArtistSkill));
            });

            StackSizeController.Obj.InitializeStackConfig(Config);
        }

        public ArtistryBase()
        {
            this.config = new PluginConfig<ArtistryBaseConfig>("EM-Artistry");
        }

        private PluginConfig<ArtistryBaseConfig> config;
        public IPluginConfig PluginConfig => this.config;
        public ArtistryBaseConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();
        public object GetEditObject() => this.config.Config;
        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();

    }

    public class ArtistryBaseConfig : IStackSizeConfig
    {
        [LocDescription("Stacks")]
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; } = new SerializedSynchronizedCollection<StackSizeElement>();
    }
}
