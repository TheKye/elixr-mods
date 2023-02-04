using Eco.Core.Utils;
using Eco.EM.Framework.Discord;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Admin
{
    internal class MessageUtils
    {
        internal static string ConfigureDiscordMessageReport(User user, string targetUser, string messageToSend)
        {
            var adminc = AdminPlugin.Obj.Config;

            var url = adminc.MultiChannelSystem ? adminc.ReportChannelWebhook : adminc.Webhook;
            if (string.IsNullOrWhiteSpace(url))
                return "Web HookURL is not configured. Please talk to the admins.";

            var serverName = string.IsNullOrWhiteSpace(adminc.MultiServerReportName) ? "Your Server" : adminc.MultiServerReportName;
            DiscordWebhook hook = new();
            hook.Url = url;

            string adminRole = adminc.NotifyAdmin ? $"<@&{adminc.AdminRoleID}> " : "Admins";

            DiscordMessage message = new()
            {
                Content = $"Attention {adminRole}! New Report From: {serverName}",
                TTS = false, //read message to everyone on the channel
                Username = "Elixr Mods - Report System",
                AvatarUrl = "https://elixrmods.com/Assets/img/logos/EMICON-text.png"
            };

            //embeds
            DiscordEmbed embed = new()
            {
                Title = $"New Report From: {user.Name}",
                Description = $"{targetUser} has been Reported. Reason: \n" + messageToSend + $"\n\nPlayer Location: X:{user.Player.Position.X}, Y:{user.Player.Position.Y}, Z:{user.Player.Position.Z}",
                Url = "",
                Timestamp = DateTime.Now,
                Color = System.Drawing.Color.Red, //alpha will be ignored, you can use any RGB color
                Footer = new EmbedFooter() { Text = "Brought to you by Elixr Mods - Admin Reports System", IconUrl = "https://elixrmods.com/Assets/img/logos/EMICON-text.png" },
            };

            //set embed
            message.Embeds = new();
            message.Embeds.Add(embed);

            hook.Send(message);
            return "Your Report has been sent to the admins, they will be in touch with you as soon as they can!";
        }

        internal static string ConfigureDiscordMessageWarn(IChatClient chatClient, string targetUser, string messageToSend)
        {
            var adminc = AdminPlugin.Obj.Config;
            var url = adminc.MultiChannelSystem ? adminc.WarningLogsWebhook : adminc.Webhook;
            if (string.IsNullOrWhiteSpace(url))
                return "Web HookURL is not configured. This needs to be enabled for Discord Logging. But this warning has still been loged to the Warnings Log File.";

            var serverName = string.IsNullOrWhiteSpace(adminc.MultiServerReportName) ? "Your Server" : adminc.MultiServerReportName;
            DiscordWebhook hook = new();
            hook.Url = url;

            DiscordMessage message = new()
            {
                Content = $"Attention, A New Warning Has Been Issued on: {serverName}",
                TTS = false, //read message to everyone on the channel
                Username = "Elixr Mods - Report System",
                AvatarUrl = "https://elixrmods.com/Assets/img/logos/EMICON-text.png"
            };

            //embeds
            DiscordEmbed embed = new()
            {
                Title = $"New Warning Has been Issued By: {chatClient.Name}",
                Description = $"{targetUser} has been Issued a Warning. Reason: \n" + messageToSend,
                Url = "",
                Timestamp = DateTime.Now,
                Color = System.Drawing.Color.OrangeRed, //alpha will be ignored, you can use any RGB color
                Footer = new EmbedFooter() { Text = "Brought to you by Elixr Mods - Admin Reports System", IconUrl = "https://elixrmods.com/Assets/img/logos/EMICON-text.png" },
            };

            //set embed
            message.Embeds = new();
            message.Embeds.Add(embed);

            hook.Send(message);
            return "Your Warning has been sent to the User. It has also been logged to discord and the Warning Log File for your records.";
        }

        internal static string ConfigureDiscordMessageHelp(User user, string messageToSend)
        {
            var adminc = AdminPlugin.Obj.Config;

            var url = adminc.MultiChannelSystem ? adminc.HelpChannelWebhook : adminc.Webhook;
            if (string.IsNullOrWhiteSpace(url))
                return "Web HookURL is not configured. Please talk to the admins.";

            var serverName = string.IsNullOrWhiteSpace(adminc.MultiServerReportName) ? "Your Server" : adminc.MultiServerReportName;
            DiscordWebhook hook = new();
            hook.Url = url;

            string adminRole = adminc.NotifyAdmin ? $"<@&{adminc.AdminRoleID}>" : "Admins";

            DiscordMessage message = new()
            {
                Content = $"Attention {adminRole} New Help Request From: {serverName}",
                TTS = false, //read message to everyone on the channel
                Username = "Elixr Mods - Report System",
                AvatarUrl = "https://elixrmods.com/Assets/img/logos/EMICON-text.png"
            };

            //embeds
            DiscordEmbed embed = new()
            {
                Title = $"New Help Request From: {user.Name}",
                Description = messageToSend + $"\n\nPlayer Location: X:{(int)user.Player.Position.X}, Y:{(int)user.Player.Position.Y}, Z:{(int)user.Player.Position.Z}",
                Url = "",
                Timestamp = DateTime.Now,
                Color = System.Drawing.Color.Orange, //alpha will be ignored, you can use any RGB color
                Footer = new EmbedFooter() { Text = "Brought to you by Elixr Mods - Admin Reports System", IconUrl = "https://elixrmods.com/Assets/img/logos/EMICON-text.png" },
            };

            //set embed
            message.Embeds = new();
            message.Embeds.Add(embed);

            hook.Send(message);
            return string.IsNullOrWhiteSpace(adminc.CustomHelpResponseMessage) ? "Your Help Request has been sent to the admins, they will be in touch with you as soon as they can!" : adminc.CustomHelpResponseMessage;
        }
    }
}
