using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;

namespace Eco.EM.Admin.ReportsSystem
{
    public class BasicCommands : IChatCommandHandler
    {
        // Cooldown Timers for using the commands
        private static readonly Dictionary<User, double> reportEnableTimes = new();
        private static readonly Dictionary<User, double> helpEnableTimes = new();

        [ChatSubCommand("ReportSystem", "Used to Report another player to the admins via a discord notification", "report-player")]
        public static void ReportPlayer(User user, User userToReport, string message)
        {

            if (user == userToReport)
            {
                ChatBaseExtended.CBError("You Can't Report Yourself. Silly.", user);
                return;
            }

            if (!AdminPlugin.Obj.Config.EnableReports)
            {
                ChatBaseExtended.CBError("The Report system has not been enabled by the Admins, Please talk to them to have the report system enabled", user);
                return;
            }

            if (string.IsNullOrWhiteSpace(message) || message.Length < 10)
            {
                ChatBaseExtended.CBError("You need to give a proper message to be able to send to the admins. please make sure you give them as much info as you can", user);
                return;
            }

            if (reportEnableTimes.TryGetValue(user, out var enableTime) && enableTime > TimeUtil.Seconds)
            {
                user.Player.ErrorLocStr($"Report Player is on cooldown, try again in { (int)Math.Ceiling(enableTime - TimeUtil.Seconds)} seconds.");
            }
            else
            {
                reportEnableTimes[user] = TimeUtil.Seconds + AdminPlugin.Obj.Config.ReportCoolDown;

                var response = MessageUtils.ConfigureDiscordMessageReport(user, userToReport.Name, message);
                string generatedMessage = $"[{DateTime.Now:hh:mm:ss}] - {user.Name} Reported: {userToReport.Name}, Reason: {message}";
                AdminPlugin.Log(generatedMessage);
                ChatBaseExtended.CBOkBox(response, user);
            }
        }

        [ChatSubCommand("ReportSystem", "Used to Request Help from Admins, Don't Abuse it otherwise they may disable it", "helpme")]
        public static void RequestHelp(User user, string message)
        {

            if (!AdminPlugin.Obj.Config.EnableHelpRequests)
            {
                ChatBaseExtended.CBError("The Help system has not been enabled by the Admins, Please talk to them to have the report system enabled", user);
                return;
            }

            if (helpEnableTimes.TryGetValue(user, out var enableTime) && enableTime > TimeUtil.Seconds)
            {
                user.Player.ErrorLocStr($"Helpme is on cooldown, try again in { (int)Math.Ceiling(enableTime - TimeUtil.Seconds)} seconds.");
            }
            else
            {
                helpEnableTimes[user] = TimeUtil.Seconds + AdminPlugin.Obj.Config.HelpCoolDown;
                
                var response = MessageUtils.ConfigureDiscordMessageHelp(user, message);
                ChatBaseExtended.CBOkBox(response, user);
            }
        }

        [ChatSubCommand("ReportSystem", "Used to check your current and previous issued warnings", "mywarnings")]
        public static void MyWarnings(User user)
        {
            var playerData = WarningManager.Data.GetWarningDataUser(user.Name);
            if (playerData == null)
            {
                ChatBaseExtended.CBError("There where no Warnings issued for you.", user);
                return;
            }

            var warnings = playerData.ListActiveWarnings();
            var oldWarnings = playerData.ListWarningHistory();

            string message = "";
            message += "Active Warnings: " + warnings + "\n\nOld Warnings: " + oldWarnings;

            ChatBaseExtended.CBInfoPane($"Player Warnings List For Player: {user.Name}", $"Warning List for Player: {user.Name}. {message}", "Reports", user);
        }
    }
}
