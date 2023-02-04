using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.Networking;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.ModKit;
using Eco.Shared.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Eco.EM.Framework
{
    class BaseCommands : IChatCommandHandler
    {
        [ChatCommand("version", "Display the current installed version of EM")]
        public static void Version(User user)
        {
            ChatBaseExtended.CBChat(string.Format(Base.appName) + " " + BasePlugin.Obj.Versions.GetChat(), user);
        }
    }

    public class EMVersioning
    {
        #region VersionChecking
        // Loops through all assemblies loaded and return the packInfo of those that contain "Elixr Solutions" as the Company name.
        private static Dictionary<string, string> GetEMInstalledInfo()
        {
            Dictionary<string, string> installedPacks = new Dictionary<string, string>();

            // recursively find all *.dll files in the mods folder.
            string[] filepaths = Directory.GetFiles(ModKitPlugin.ModDirectory, "*.dll", SearchOption.AllDirectories);

            foreach (var file in filepaths)
            {
                var info = FileVersionInfo.GetVersionInfo(file);

                if (info != null && info.CompanyName == "Elixr Solutions")
                {
                    if (!installedPacks.ContainsKey(info.ProductName))
                        installedPacks.Add(info.ProductName, info.ProductVersion);
                }
            }

            return installedPacks;
        }

        private class EMRequestObject
        {
            public string Status { get; set; }
            public Dictionary<string, string> rows { get; set; }
        }

        // returns a dictionary of the up to date EM packs and their Versions.
        private EMRequestObject GetEMMasterInfo()
        {
            const string emWeb = "https://elixrmods.com/api/v1/GetVersions?apikey=uaRVGlDndFUIlwKJ";
            var request = Network.GetRequest(emWeb);
            return JsonConvert.DeserializeObject<EMRequestObject>(request);
        }

        // Returns a formatted string of the installed EMPack versions for either console or chat.
        private void EMVersion(bool console, out string chat)
        {
            chat = "";
            try
            {                
                var packs = GetEMInstalledInfo();
                var check = GetEMMasterInfo();
                string latestPack = "";

                if (check.Status != "200" || check.rows == null || check.rows.Count == 0)
                {
                    System.Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.WriteLine(Localizer.DoStr(string.Format("Unable to contact webserver for latest pack info")));
                }
                else
                    latestPack = check.rows["EM Framework"];


                if (console)
                    PrintSinglePackConsole("EM Framework", packs["EM Framework"], latestPack);
                else
                    chat += PrintSingleStringChat("EM Framework", packs["EM Framework"], latestPack);

                // Go through other packs skipping EM Framework
                foreach (var p in packs)
                {
                    if (p.Key == "EM Framework")
                        continue;

                    if (check.rows.ContainsKey(p.Key))
                        latestPack = check.rows[p.Key];
                    else
                        latestPack = null;

                    if (console)
                        PrintSinglePackConsole(p.Key, p.Value, latestPack);
                    else
                        chat += PrintSingleStringChat(p.Key, p.Value, latestPack);
                }
            }
            catch (Exception)
            {
                if (console)
                {
                    System.Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.WriteLine(Localizer.DoStr(string.Format("An error occured while attempting to check versions. Please contact the EM Development Team")));
                    System.Console.ResetColor();
                }
                else
                    chat += string.Format("<color=red>{0}</color>", "An error occured while attempting to check versions.Please contact the EM Development Team");
            }
        }

        private bool CheckPackVersion(string iVers, string mVers)
        {
            return (iVers == mVers);
        }

        // Formats the console output for the EM Pack Info.
        private void PrintSinglePackConsole(string name, string iVers, string mVers)
        {
            bool match = CheckPackVersion(iVers, mVers);

            // EM Pack Names should always be in Magenta
            // normal Text in Yellow
            // version text in Green if current version matches master version
            // version text in Red if current version lower than master version
            // Colors should also reset so it doesn't overwrite default colors
            // Added in time log to match in
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write(Localizer.DoStr($"[{DateTime.Now:hh:mm:ss)}] "));

            System.Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.Write(Localizer.DoStr(string.Format("{0}", name)));

            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write(Localizer.DoStr(string.Format(" - Installed version ")));

            if (match)
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Write(string.Format("({0}) \n", iVers));
            }
            else
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write(string.Format("({0}) ", iVers));
            }

            if (!match && mVers != "")
            {
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write(Localizer.DoStr(string.Format(": Latest Version ({0}) \n", mVers)));
            }
            System.Console.ResetColor();
        }

        // Formats the game text output for the EM Pack Info.
        private string PrintSingleStringChat(string name, string iVers, string mVers)
        {
            bool match = CheckPackVersion(iVers, mVers);

            // EM Pack Names should always be in Magenta
            // normal Text in Yellow
            // version text in Green if current version matches master version
            // version text in Red if current version lower than master version
            StringBuilder sb = new StringBuilder();

            sb.Append(Localizer.DoStr(string.Format("<color=purple>{0}</color>", name)));
            sb.Append(Localizer.DoStr(string.Format(" <color=yellow>- Installed version </color>")));

            if (match)
                sb.Append(string.Format("<color=green>({0}) </color>", iVers));
            else
                sb.Append(string.Format("<color=red>({0}) </color>", iVers));

            if (!match && mVers != "")
                sb.Append(Localizer.DoStr(string.Format("<color=yellow>: Latest Version ({0}) </color>\n", mVers)));

            return sb.ToString();
        }

        public void GetInit()
        {
            EMVersion(true, out string _);
        }

        public string GetChat()
        {
            EMVersion(false, out string chat);
            return chat;
        }
        #endregion
    }
}
