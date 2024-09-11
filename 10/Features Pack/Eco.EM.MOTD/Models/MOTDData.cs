using Eco.EM.Framework;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Plugins.Networking;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using Eco.Simulation.Time;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EM.ECO.MOTD
{
    public class MOTDData
    {

        public List<string> Messages = new List<string>();

        private string _title;
        private string _body;

        public void DisplayMOTD(User user)
        {
            Task.Delay(MOTDManager.Obj.Config.TimeDelayOnLogin * 5000);
            Task.Run(() => {
                if (MOTDManager.Obj.Config.ShowOnLogin)
                {
                    user.Player.LargeInfoBox(ReplaceEMTags(_title, user), ReplaceEMTags(_body, user));
                }
                if (MOTDManager.Obj.Config.PostToChat)
                {
                    user.Player.MsgLocStr($"{ReplaceEMTags(_title, user)} \n{ReplaceEMTags(_body, user)}");
                }
            });
        }

        private LocString ReplaceEMTags(string s, User user)
        {
            MatchEvaluator evaluator = new MatchEvaluator(match => TagEvaluater(match, user));

            return Localizer.DoStr(Regex.Replace(s, @"\{{2}([A-Z]+)\}{2}", evaluator));
        }

        private string TagEvaluater(Match match, User user)
        {
            switch (match.Value)
            {
                case "{{USER}}":
                    return user.Name;
                case "{{SERVER}}":
                    return NetworkManager.Config.Description;
                case "{{UPTIME}}":
                    return Math.Round(WorldTime.Day).ToString();
                case "{{DISCORD}}":
                    return Localizer.DoStr($"{NetworkManager.Config.DiscordAddress}");
                case "{{WEBPAGE}}":
                    return Localizer.DoStr($"{NetworkManager.Config.WebServerUrl.UILinkGeneric()}");
                case "{{MESSAGELIST}}":
                    return FormatMessages(Messages);
                default:
                    return match.Value;
            }
        }

        private string FormatMessages(List<string> messages)
        {
            string fm = "";

            foreach (var mes in Messages)
            {
                fm += $" - {mes}\n";
            }

            return fm;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public void SetBody(string body)
        {
            _body = body;
        }
    }
}