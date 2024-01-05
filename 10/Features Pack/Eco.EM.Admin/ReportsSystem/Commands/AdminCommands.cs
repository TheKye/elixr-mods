using Eco.Core.Plugins.Interfaces;
using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.Logging;
using Eco.EM.Framework.Text;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using static Eco.EM.Framework.Utils.ColoredText;

namespace Eco.EM.Admin.ReportsSystem
{
    [ChatCommandHandler]
    public class AdminCommands
    {
        [ChatSubCommand("ReportSystem", "Used to check a players Active Warning List", "list-warnings", ChatAuthorizationLevel.Admin)]
        public static void ListWarnings(IChatClient chatClient, User targetUser)
        {
            var playerData = WarningManager.Data.GetWarningDataUser(targetUser.Name);
            if (playerData == null)
            {
                chatClient.MsgLocStr("There where no Warnings issued for this player.");
                return;
            }

            User adminIsUser = PlayerUtils.GetUser(chatClient.Name);

            var warnings = playerData.ListActiveWarnings();
            var oldWarnings = playerData.ListWarningHistory();

            string message = "";
            message += "Active Warnings: " + warnings + "\n\nOld Warnings: " + oldWarnings;

            if (adminIsUser == null)
                chatClient.MsgLocStr($"Warning List for Player: {targetUser.Name}. {message}");
            else
                ChatBaseExtended.CBInfoPane($"Player Warnings List For Player: {targetUser.Name}", $"Warning List for Player: {targetUser.Name}. {message}", "Reports", adminIsUser);

        }

        [ChatSubCommand("ReportSystem", "Used to Issue a warning to a player, Info Logged: Player Name, Reason for warning and User who issued the warning", "issue-warning", ChatAuthorizationLevel.Admin)]
        public static void IssueWarning(IChatClient chatClient, User targetUser, string message, int warningTime = 30)
        {
            var issuer = PlayerUtils.GetUser(chatClient.Name);
            //Remove all leading and trailing whitespace just in-case for int parsing.
            message = message.Trim();

            if (issuer == targetUser)
            {
                chatClient.ErrorLocStr("You Just Warned Yourself, Yay! You have been Very Bad. Now. Don't do it again.");
                return;
            }

            try
            {
                //Check if a pre-defined Warning Message is being used, if not then ignore
                int preDefined = int.TryParse(message, out preDefined) ? preDefined : 0;

                if (issuer != null)
                    WarningManager.Data.WarnUser(issuer, targetUser.Name, message, warningTime, preDefined);
                else
                    WarningManager.Data.WarnUser(targetUser, targetUser.Name, message, warningTime, preDefined);
            }
            catch (Exception e)
            {
                chatClient.MsgLocStr(e.ToString());
                return;
            }

            if (!targetUser.IsOnline)
            {
                chatClient.MsgLocStr("Current user is not online, we have sent a notification to their mailbox but you may want to inform them when they log in next.");
                targetUser.MailLoc($"{message}", Shared.Services.NotificationCategory.Admin);
            }
            else
                targetUser.Player.OpenInfoPanel("<color=red>You Have Received a Warning From the Admins.</color>", message, "ReportSystem");

            string response = MessageUtils.ConfigureDiscordMessageWarn(chatClient, targetUser.Name, message);
            chatClient.MsgLocStr(response);
        }

        [ChatSubCommand("ReportSystem", "Used to Revoke a warning issued to a player", "revoke-warning", ChatAuthorizationLevel.Admin)]
        public static void RevokeWarning(IChatClient chatClient, User targetUser, int warningNo, string reason = "")
        {
            var playerData = WarningManager.Data.GetWarningDataUser(targetUser.Name);
            if (playerData == null)
            {
                chatClient.MsgLocStr("There where no warnings issued for this player to revoke.");
                return;
            }

            if (warningNo == 0)
            {
                chatClient.MsgLocStr("Warning Numbers go from 1 onwards, 0 is not an acceptable number for the warning you wish to revoke, to check the warning list of a player run /warning-list playername");
            }

            if (string.IsNullOrWhiteSpace(reason))
                reason = "Admin Decided to revoke the warning without giving a reason";
            try
            {
                playerData.RevokeWarning(warningNo, chatClient.Name, reason);
            }
            catch (Exception e)
            {
                chatClient.MsgLocStr(e.Message);
                return;
            }
            chatClient.MsgLocStr($"Warning Has been Revoked for {targetUser}. It will remain in the Logs but as an Inactive Warning.");
        }

        [ChatSubCommand("ReportSystem", "Used to Revoke a ban implemented by the auto ban system", ChatAuthorizationLevel.Admin)]
        public static void RevokeBan(IChatClient chatClient, User targetUser, string reason = "")
        {
            var playerData = WarningManager.Data.GetWarningDataUser(targetUser.Name);
            if (playerData == null)
            {
                chatClient.MsgLocStr("There where no bans issued for this player to revoke.");
                return;
            }

            if (string.IsNullOrWhiteSpace(reason))
                reason = "Admin Decided to revoke the ban without giving a reason";
            try
            {
                playerData.RevokeBan(chatClient.Name, reason);
            }
            catch (Exception e)
            {
                chatClient.MsgLocStr(e.Message);
                return;
            }
            chatClient.MsgLocStr($"The Ban Issued to {targetUser} Has been Revoked. It will remain in the Logs for reference purposes.");
        }

        [ChatSubCommand("ReportSystem", "Configure the Reporting System From in game, Settings are: enablereports (true/false), enablehelp(true/false), adminrole(string adminname), notifyadmins(true/false), webhookurl(string url), servername(string name)", "config-reports", ChatAuthorizationLevel.Admin)]
        public static void ConfigureReports(IChatClient chatClient, string setting, string value)
        {
            var settings = setting.Trim().ToLower();
            var values = value.Trim();
            var admincon = AdminPlugin.Config;
            var admin = AdminPlugin.Obj;

            switch (settings)
            {
                case "enablereports":
                    switch (values.ToLower())
                    {
                        case "true":
                            admincon.EnableReports = true;
                            admin.SaveConfig();
                            chatClient.MsgLocStr($"Report System has been: {"Enabled".Green()}, If you haven't be sure to set the WebhookURL");
                            return;
                        case "false":
                            admincon.EnableReports = false;
                            admin.SaveConfig();
                            chatClient.MsgLocStr($"Report System has been: {"Disabled".Red()}");
                            return;
                        default:
                            chatClient.MsgLocStr($"please only type true or false for enabling or disabling the report system.");
                            return;
                    }
                case "enablehelp":
                    switch (values.ToLower())
                    {
                        case "true":
                            admincon.EnableHelpRequests = true;
                            admin.SaveConfig();
                            chatClient.MsgLocStr($"Help System has been: {"Enabled".Green()}, If you haven't be sure to set the WebhookURL");
                            return;
                        case "false":
                            admincon.EnableHelpRequests = false;
                            admin.SaveConfig();
                            chatClient.MsgLocStr($"Help System has been: {"Disabled".Red()}");
                            return;
                        default:
                            chatClient.MsgLocStr($"please only type true or false for enabling or disabling the Help system.");
                            return;
                    }
                case "adminrole":
                    admincon.AdminRoleID = ulong.Parse(values);
                    admin.SaveConfig();
                    chatClient.MsgLocStr($"Admin Role to notify has been set to: {values.Green()}, Please ensure this is correct.");
                    return;
                case "notifyadmins":
                    switch (values.ToLower())
                    {
                        case "true":
                            admincon.NotifyAdmin = true;
                            admin.SaveConfig();
                            chatClient.MsgLocStr($"Admin Notifications has been: {"Enabled".Green()}, If you haven't be sure to set the WebhookURL");
                            return;
                        case "false":
                            admincon.NotifyAdmin = false;
                            admin.SaveConfig();
                            chatClient.MsgLocStr($"Admin Notifications has been: {"Disabled".Red()}");
                            return;
                        default:
                            chatClient.MsgLocStr($"please only type true or false for enabling or disabling the Admin Notifications.");
                            return;
                    }
                case "webhookurl":
                    admincon.Webhook = values;
                    admin.SaveConfig();
                    chatClient.MsgLocStr($"Discord Webhook URL has been set to: {"Enabled".Green()}, Please ensure this is correct.");
                    return;
                case "servername":
                    admincon.MultiServerReportName = values;
                    admin.SaveConfig();
                    chatClient.MsgLocStr($"Multi Server Report Name has been set to: {values.Green()}, Please ensure this is correct.");
                    return;
                default:
                    chatClient.MsgLocStr($"It seems you haven't entered in the correct setting to change: Please use: EnableReports, EnableHelp, AdminRole, NotifyAdmins, WebHookURL or ServerName");
                    return;
            }
        }

        [ChatSubCommand("ReportSystem", "Add To the Predefined List of Warnings", "pre-list-add", ChatAuthorizationLevel.Admin)]
        public static void AddToPreList(IChatClient chatClient, string warning)
        {
            WarningManager.Data.AddToPreDefined(warning);

            chatClient.MsgLocStr($"\"{warning}\" Has been added to the list of predefined warnings, to check this list and their id's please use /list-predefined");
        }

        [ChatSubCommand("ReportSystem", "Show the List of Predefined warnings and their ID", "list-predefined", ChatAuthorizationLevel.Admin)]
        public static void ListPredefined(IChatClient chatClient)
        {
            User adminIsUser = PlayerUtils.GetUser(chatClient.Name);

            var list = WarningManager.Data.ListPreDefined();

            if (adminIsUser == null)
                chatClient.MsgLocStr($"Predefined Warning List: \n{list}");
            else
                ChatBaseExtended.CBInfoPane($"Predefined Warning List", $"{list}", "Reports", adminIsUser);
        }

        [ChatSubCommand("ReportSystem", "Remove a Predefined Warning from the List (Requires its ID, use /list-predefined to check the ids)", "remove-predefined", ChatAuthorizationLevel.Admin)]
        public static void RemovePredefined(IChatClient chatClient, int id)
        {
            try
            {
                string warning = WarningManager.Data.GetPredefined(id);

                WarningManager.Data.RemoveFromPreDefined(id);
                chatClient.MsgLocStr($"{warning} Was Removed from the Predefined List");
                return;

            }
            catch
            {
                chatClient.MsgLocStr("We could not find a warning to remove or there was an issue trying to remove the selected warning");
            }
        }

        [ChatSubCommand("ReportSystem", "Configure the Warnings System From in game,", ChatAuthorizationLevel.Admin)]
        public static void ConfigureWarnings(IChatClient chatClient, string setting, string value)
        {

        }
    }
}
