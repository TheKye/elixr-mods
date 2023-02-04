using Eco.Core.Items;
using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Core.Utils.Logging;
using Eco.EM.Framework;
using Eco.EM.Framework.FileManager;
using Eco.EM.Framework.Logging;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
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
        public PluginConfig<AdminConfig> config;
        public AdminPlugin()
        {
            this.config = new PluginConfig<AdminConfig>("EMAdmin");
        }
        public NLogWriter logger = LoggingUtils.RegisterNewLogger("EM-Reports");

        public IPluginConfig PluginConfig => config;
        public AdminConfig Config => this.config.Config;
        public ThreadSafeAction<object, string> ParamChanged { get; set; } = new ThreadSafeAction<object, string>();

        public object GetEditObject() => this.config.Config;

        public string GetStatus() => config.Config.EnableReports ? "Reports Enabled" : "Report System Disabled";

        public override string ToString() => "EM Admin";

        public void OnEditObjectChanged(object o, string param) => this.SaveConfig();

        public static void Log(string port) => Obj.logger.Write(port);

        public void Initialize(TimedTask timer)
        {
            this.SaveConfig();
            Log($"[{DateTime.Now:hh:mm:ss}] - Server Restarted, Generating Line Break {lineBreak}");

        }

        internal static readonly string reportLogFile = "ReportLogs.Log";
        private readonly string lineBreak = "\n------------------------------------------------\n\n";
    }
}