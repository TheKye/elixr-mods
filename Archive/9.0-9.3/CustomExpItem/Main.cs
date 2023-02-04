namespace CustomExpItem
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ExpExchanger : IModKitPlugin
    {
        private const string _logFile = "XPLogs.txt";
        private const string _subPath = "/Exp/Logs";
        private const string _path = "./Configs/Mods";
        private string newline = $"Server Rebooted, adding break: Server Restarted at: {DateTime.Now}";

        public ExpExchanger()
        {
            if (!Directory.Exists(_path + _subPath))
            {
                Directory.CreateDirectory(_path + _subPath);
            }

            if (!File.Exists(Path.Combine(_path + _subPath, _logFile)))
            {
                File.Create(Path.Combine(_path + _subPath, _logFile));
                Eco.Shared.Utils.Log.WriteLine(Localizer.DoStr("Log File not found, Creating new one."));
            }
                
            StreamWriter stream = File.AppendText(Path.Combine(_path + _subPath, _logFile));
            stream.WriteLineAsync(newline);
            stream.Close();

        }

        public static void Log(string port)
        {
            StreamWriter stream = File.AppendText(Path.Combine(_path + _subPath, _logFile));
            stream.WriteLineAsync(port);
            stream.Close();
        }

        public string GetStatus()
        {
            return "";
        }

    }
}
