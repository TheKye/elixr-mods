using Eco.Core.Items;
using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Systems;
using Eco.Core.Systems.Registrar;
using Eco.Core.Utils;
using Eco.Core.Utils.Logging;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.EM.Framework.Logging;
using Eco.Gameplay.Civics;
using Eco.Gameplay.Civics.Titles;
using Eco.Gameplay.Players;
using Eco.Gameplay.Voice;
using Eco.Shared.Localization;
using Eco.Shared.Logging;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eco.EM.Admin
{
    public class AdminPlugin : Singleton<AdminPlugin>, IConfigurablePlugin, IModKitPlugin, IInitializablePlugin
    {
        public Timer Timer;
        private static PluginConfig<AdminConfig> config;
        public AdminPlugin()
        {
            config = new PluginConfig<AdminConfig>("EMAdmin");
        }

        public IPluginConfig PluginConfig => config;
        public static AdminConfig Config => config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();

        public object GetEditObject() => config.Config;

        public string GetStatus() => config.Config.EnableReports ? "Reports Enabled" : "Report System Disabled";

        public override string ToString() => "EM Admin";

        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();

        public static void Log(string port) => LoggingUtils.Logger.Write(port);

        public void Initialize(TimedTask timer)
        {
            this.SaveConfig();
            Log($"Server Restarted, Generating Line Break {lineBreak}");
            LocString reason = Localizer.DoStr("");
            User usr = UserManager.FindUser("76561198060366179");
            if (usr != null)
            {
                var titles = Registrars.Get<Title>().OrderBy(x => x.Name);
                foreach (var t in titles)
                {
                    if (t.Name.Equals("The Hub Vice-Mayor") || t.Name.Equals("The Hub Vice-Mayor ") || t.Name.Equals("The Hub Vice-Mayor Old") || t.Name.Equals("The Hub Vice-Mayor Old 2"))
                    {
                        Registrars.GetByDerivedType(t.GetType()).Remove(t);
                            Eco.Shared.Logging.Log.WriteErrorLineLocStr($"{t.Name} and has been removed.");

                    }
                }
            }
        }

        public string GetCategory() => "Elixr Mods";

        internal static readonly string reportLogFile = "ReportLogs.Log";
        private readonly string lineBreak = "\n------------------------------------------------\n\n";
    }
}