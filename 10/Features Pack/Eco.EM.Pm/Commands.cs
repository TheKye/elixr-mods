namespace Eco.EM.Pm
{
using Eco.Shared.IoC;
using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using Eco.Shared.Services;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Eco.Gameplay.Systems.Messaging.Chat.Commands;
    using Eco.EM.Framework.Utils;
    using Eco.Gameplay.Systems.Messaging.Mail;
    using Eco.Shared.Logging;

    [ChatCommandHandler]
    public class FWCommands
    {
        [ChatCommand("Send a private message to someone.")]
        public static void PM(User user, string targetplayer, string message)
        {
            try
            {
                message = $"{message.Trim()}";
                var text = Defaults.appName + $"You have a new message from: {user.Name} \n{message}";
                var targetUser = PlayerUtils.GetUserByName(targetplayer);

                // The Many conditions to check before we can send a message
                if (targetUser == null)
                {
                    ChatBaseExtended.CBError(Defaults.appName + $"{targetplayer} Doesn't exist, did you type the name wrong?", user);
                    return;
                }

                if (targetUser.IsOnline)
                {
                    ChatBaseExtended.CBChat(Defaults.appName + $"Your Message has been sent to: {targetUser.Name}", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBChat(Defaults.appName + $"Please note, all pms are logged to a file for admins to read for player safety.", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBInfoPane("New Message!", Localizer.DoStr(Defaults.appName + $"You have a new message from: {user.Name} \n{message}"), "PMs", targetUser, ChatBase.PanelType.InfoPanel, true);
                    PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
                    return;
                } else 
                {
                    ChatBaseExtended.CBChat(Defaults.appName + $"{targetUser.Name} isn't online right now, so we will leave them a message!", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBChat(Defaults.appName + $"Please note, all pms are logged to a file for admins to read for player safety.", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBMail(text, NotificationCategory.Notifications.TagName(), targetUser);
                    PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
                    return;
                }
            }
            catch(Exception e)
            {
                Log.WriteErrorLineLocStr(Defaults.appNameCon + e.ToString());
            }
        }

        [ChatCommand("Get Full Server PM Log.", ChatAuthorizationLevel.Admin)]
        public static void ServerPMLog(User user)
        {
            StringBuilder logString = new();
            logString.Append(PMManager.GetFullLog());
            ChatBaseExtended.CBInfoPane("Server PM History", logString.ToString(), "PMs", user);
        }

        [ChatCommand("Get Player PM Log.", ChatAuthorizationLevel.Admin)]
        public static void PlayerPMLog(User user, string targetPlayer)
        {
            var targetUser = PlayerUtils.GetUserByName(targetPlayer);
            if (targetUser == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + $"{targetPlayer} Doesn't exist, did you type the name wrong?", user);
                return;
            }

            StringBuilder logString = new();
            logString.Append(PMManager.GetPlayerPMLog(targetPlayer));
            ChatBaseExtended.CBInfoPane($"{targetPlayer}'s PM Log", logString.ToString(), "PMs", user);
        }

        [ChatCommand("Get My PM Log.")]
        public static void MyPMLog(User user)
        {
            StringBuilder logString = new();
            logString.Append(PMManager.GetPlayerPMLog(user.Name));
            ChatBaseExtended.CBInfoPane($"{user.Name}'s PM Log", logString.ToString(), "PMs", user);
        }

        [ChatCommand("Get Messages with Player.")]
        public static void MyPMWith(User user, string targetPlayer)
        {
            var targetUser = PlayerUtils.GetUserByName(targetPlayer);
            if (targetUser == null)
            {
                ChatBaseExtended.CBError(Defaults.appName + $"{targetPlayer} Doesn't exist, did you type the name wrong?", user);
                return;
            }

            StringBuilder logString = new();
            logString.Append(PMManager.GetMessagesWithPlayer(user, targetPlayer));
            ChatBaseExtended.CBInfoPane($"PM with {targetPlayer}", logString.ToString(), "PMs", user);
        }

        [ChatCommand("Reply to Last Sender.")]
        public static void Reply(User user, string message)
        {
            string targetplayer = PMManager.GetLastPlayer(user);

            try
            {
                message = $"{message.Trim()}";
                var text = Defaults.appName + $"You have a new message from: {user.Name} \n{message}";
                var targetUser = PlayerUtils.GetUserByName(targetplayer);

                if (targetUser == null)
                {
                    ChatBaseExtended.CBChat(Defaults.appName + $"{targetplayer} Doesn't exist, did you type the name wrong?", user, ChatBase.MessageType.Temporary);
                    return;
                }

                if (targetUser.IsOnline)
                {
                    ChatBaseExtended.CBChat(Defaults.appName + $"Your Message has been sent to: {targetUser.Name}", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBChat(Defaults.appName + $"Please note, all pms are logged to a file for admins to read for player safety.", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBInfoPane("New Message!", Localizer.DoStr(Defaults.appName + $"You have a new message from: {user.Name} \n{message}"), "PMs", targetUser);
                    PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
                    return;
                }
                else
                {
                    ChatBaseExtended.CBChat(Defaults.appName + $"{targetUser.Name} isn't online right now, so we will leave them a message!", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBChat(Defaults.appName + $"Please note, all pms are logged to a file for admins to read for player safety.", user, ChatBase.MessageType.Temporary);
                    targetUser.Mailbox.Add(new MailMessage(text, NotificationCategory.Notifications.TagName()), true);
                    PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
                    return;
                }
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr(Defaults.appNameCon + e.ToString());
            }

        }

    }
}
