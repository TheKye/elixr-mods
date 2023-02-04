namespace Eco.EM.Pm
{
using Eco.Core.IoC;
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
    public class FWCommands : IChatCommandHandler
    {
        [ChatCommand("Send a private message to someone.")]
        public static void PM(User user, string targetplayer, string message)
        {
            try
            {
                message = $"{message.Trim()}";
                var text = Base.appName + $"You have a new message from: {user.Name} \n{message}";
                var targetUser = Base.GetUserByName(targetplayer);

                // The Many conditions to check before we can send a message
                if (targetUser == null)
                {
                    ChatBaseExtended.CBError(Base.appName + $"{targetplayer} Doesn't exist, did you type the name wrong?", user);
                    return;
                }

                if (targetUser.IsOnline)
                {
                    ChatBaseExtended.CBChat(Base.appName + $"Your Message has been sent to: {targetUser.Name}", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBChat(Base.appName + $"Please note, all pms are logged to a file for admins to read for player safety.", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBInfoPane("New Message!", Localizer.DoStr(Base.appName + $"You have a new message from: {user.Name} \n{message}"), "PM", targetUser, true, true);
                    PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
                    return;
                } else 
                {
                    ChatBaseExtended.CBChat(Base.appName + $"{targetUser.Name} isn't online right now, so we will leave them a message!", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBChat(Base.appName + $"Please note, all pms are logged to a file for admins to read for player safety.", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBMail(text, DefaultChatTags.Notifications.TagName(), targetUser);
                    PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
                    return;
                }
            }
            catch(Exception e)
            {
                Log.WriteErrorLineLocStr(Base.appNameCon + e.ToString());
            }
        }

        [ChatCommand("Get Full Server PM Log.", ChatAuthorizationLevel.Admin)]
        public static void ServerPMLog(User user)
        {
            StringBuilder logString = new StringBuilder();
            logString.Append(PMManager.GetFullLog());
            ChatBaseExtended.CBInfoPane("Server PM History", logString.ToString(), "PM", user);
        }

        [ChatCommand("Get Player PM Log.", ChatAuthorizationLevel.Admin)]
        public static void PlayerPMLog(User user, string targetPlayer)
        {
            var targetUser = Base.GetUserByName(targetPlayer);
            if (targetUser == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{targetPlayer} Doesn't exist, did you type the name wrong?", user);
                return;
            }

            StringBuilder logString = new StringBuilder();
            logString.Append(PMManager.GetPlayerPMLog(targetPlayer));
            ChatBaseExtended.CBInfoPane($"{targetPlayer}'s PM Log", logString.ToString(), "PM", user);
        }

        [ChatCommand("Get My PM Log.")]
        public static void MyPMLog(User user)
        {
            StringBuilder logString = new StringBuilder();
            logString.Append(PMManager.GetPlayerPMLog(user.Name));
            ChatBaseExtended.CBInfoPane($"{user.Name}'s PM Log", logString.ToString(), "PM", user);
        }

        [ChatCommand("Get Messages with Player.")]
        public static void MyPMWith(User user, string targetPlayer)
        {
            var targetUser = Base.GetUserByName(targetPlayer);
            if (targetUser == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{targetPlayer} Doesn't exist, did you type the name wrong?", user);
                return;
            }

            StringBuilder logString = new StringBuilder();
            logString.Append(PMManager.GetMessagesWithPlayer(user, targetPlayer));
            ChatBaseExtended.CBInfoPane($"PM with {targetPlayer}", logString.ToString(), "PM", user);
        }

        [ChatCommand("Reply to Last Sender.")]
        public static void Reply(User user, string message)
        {
            string targetplayer = PMManager.GetLastPlayer(user);

            try
            {
                message = $"{message.Trim()}";
                var text = Base.appName + $"You have a new message from: {user.Name} \n{message}";
                var targetUser = Base.GetUserByName(targetplayer);

                if (targetUser == null)
                {
                    ChatBaseExtended.CBChat(Base.appName + $"{targetplayer} Doesn't exist, did you type the name wrong?", user, ChatBase.MessageType.Temporary);
                    return;
                }

                if (targetUser.IsOnline)
                {
                    ChatBaseExtended.CBChat(Base.appName + $"Your Message has been sent to: {targetUser.Name}", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBChat(Base.appName + $"Please note, all pms are logged to a file for admins to read for player safety.", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBInfoPane("New Message!", Localizer.DoStr(Base.appName + $"You have a new message from: {user.Name} \n{message}"), "PM", targetUser);
                    PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
                    return;
                }
                else
                {
                    ChatBaseExtended.CBChat(Base.appName + $"{targetUser.Name} isn't online right now, so we will leave them a message!", user, ChatBase.MessageType.Temporary);
                    ChatBaseExtended.CBChat(Base.appName + $"Please note, all pms are logged to a file for admins to read for player safety.", user, ChatBase.MessageType.Temporary);
                    targetUser.Mailbox.Add(new MailMessage(text, DefaultChatTags.Notifications.TagName()), true);
                    PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
                    return;
                }
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr(Base.appNameCon + e.ToString());
            }

        }

    }
}
