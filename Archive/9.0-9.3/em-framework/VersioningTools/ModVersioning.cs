using Eco.EM.Framework.Networking;
using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Players;
using Eco.ModKit;
using Eco.Shared.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Eco.EM.Framework.VersioningTools
{
    public class ModVersioning
    {
        private static Dictionary<string, string> GetModInstalledInfo(string ModIdentity)
        {
            Dictionary<string, string> installedPacks = new Dictionary<string, string>();

            string[] filepaths = Directory.GetFiles(ModKitPlugin.ModDirectory, "*.dll", SearchOption.AllDirectories);

            foreach (var file in filepaths)
            {
                var info = FileVersionInfo.GetVersionInfo(file);

                if (info != null && info.CompanyName == ModIdentity)
                {
                    if (!installedPacks.ContainsKey(info.ProductName))
                        installedPacks.Add(info.ProductName, info.ProductVersion);
                }
            }

            return installedPacks;
        }

        private class ModRequestObject
        {
            public int status { get; set; }
            public Dictionary<string, object> modfile { get; set; }
        }

        private static ModRequestObject GetModMasterInfo(string modId, string modApi)
        {
            string EcoModIo = $"https://api.mod.io/v1/games/6/mods/{modId}?api_key={modApi}";
            var request = Network.GetRequest(EcoModIo);
            return JsonConvert.DeserializeObject<ModRequestObject>(request);
        }

        private static void ModVersion(string modId, string modApi, string ModIdentity, string displayName, ConsoleColor mainColor, string appName, ConsoleColor textColor = ConsoleColor.Yellow, bool sendChat = false)
        {
            var packs = GetModInstalledInfo(ModIdentity);
            var check = GetModMasterInfo(modId, modApi);
            string latestPack = "";
            if (check.status != 1)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(Localizer.DoStr(string.Format("Unable to contact webserver for latest pack info")));
                return;
            }
            else
            latestPack = (string)check.modfile["version"];

            PrintSinglePackConsole(displayName, packs[appName], latestPack, mainColor, textColor);
            if (sendChat)
            {
                UserManager.OnUserLoggedIn.Add(u =>
                {
                    if (u.IsAdmin)
                    {
                        ChatBaseExtended.CBError(string.Format("<color=red>Attention Admin!</color>" + " " + PrintSingleStringChat(displayName, packs[appName], latestPack, mainColor.ToString(), textColor.ToString())),u);
                    }
                });
            }
        }

        private static void PrintSinglePackConsole(string name, string iVers, string mVers, ConsoleColor mainColor, ConsoleColor textColor = ConsoleColor.Yellow)
        {
            bool match = CheckPackVersion(iVers, mVers);

            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write(Localizer.DoStr($"[{DateTime.Now:hh:mm:ss}] "));

            System.Console.ForegroundColor = mainColor;
            System.Console.Write(Localizer.DoStr(string.Format("{0}", name)));

            System.Console.ForegroundColor = textColor;
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
            if (!match)
            {
                System.Console.ForegroundColor = textColor;
                System.Console.Write(Localizer.DoStr(string.Format(": Latest Version ({0}) \n", mVers)));
            }
            System.Console.ResetColor();
        }

        // Formats the game text output for the Mod Pack Info.
        private static string PrintSingleStringChat(string name, string iVers, string mVers, string mainColor, string secondColor)
        {
            bool match = CheckPackVersion(iVers, mVers);

            StringBuilder sb = new StringBuilder();

            sb.Append(Localizer.DoStr(string.Format("<color={0}>{1}</color>", mainColor, name)));
            sb.Append(Localizer.DoStr(string.Format(" <color={0}>- Installed version </color>", secondColor)));

            if (match)
            {
                sb.Append(string.Format("<color=green>({0}) </color>", iVers));
            }
            else
            {
                sb.Append(string.Format("<color=red>({0}) </color>", iVers));
            }

            if (!match && mVers != "")
                sb.Append(Localizer.DoStr(string.Format("<color=yellow>: Latest Version ({0}) </color>\n", mVers)));

            return sb.ToString();
        }

        private static bool CheckPackVersion(string iVers, string mVers)
        {
            return (iVers == mVers);
        }

        public static void GetModInit(string modId, string modApi, string ModIdentity, string displayName, ConsoleColor mainColor, string appName, ConsoleColor textColor = ConsoleColor.Yellow, bool sendChat = false)
        {
            ModVersion(modId, modApi, ModIdentity, displayName, mainColor, appName, textColor, sendChat);
        }
    }
}
