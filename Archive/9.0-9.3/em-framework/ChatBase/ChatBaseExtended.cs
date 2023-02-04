using Eco.Gameplay.Players;
using Eco.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;
using static Eco.EM.Framework.ChatBase.ChatBase;

namespace Eco.EM.Framework.ChatBase
{
    /// <summary>
    /// ChatBaseExtended Just Provides some default methods for the chat base itself, so instead of adding in: 
    /// ChatBase.Send(new ChatBase.MessageTyp());
    /// You will be able to just use a simple method the same way, this is basically just in case you would like to keep your code shortened and simple
    /// Basic usage will be like:
    /// ChatBaseExtended.CBChat(string, user);
    /// Alternatively you could set the Using as a static using
    /// using static Eco.EM.Framework.ChatBase.ChatBaseExtended;
    /// and that will allow you to just use the methods defined here.
    /// to abool Conflicts all Method start with CB
    /// </summary>
    public class ChatBaseExtended
    {
        public static bool CBAnnouncement(string content, bool sendToAll = false, bool sendToChat = false) => Send(new Announcement(content, sendToAll, sendToChat));
        public static bool CBAnnouncement(string title, string content, string instance, bool sendToAll = false, bool sendToChat = false) => Send(new Announcement(title, content, instance, sendToAll, sendToChat));
        public static bool CBAnnouncement(string title, string content, string instance, MessageType messageType, bool sendToAll = false, bool sendToChat = false) => Send(new Announcement(title, content, instance, messageType, sendToAll, sendToChat));

        public static bool CBChat(string Content) => Send(new Chat(Content));
        public static bool CBChat(string content, MessageType messageType) => Send(new Chat(content, messageType));
        public static bool CBChat(string content, DefaultChatTags defaultChatTags) => Send(new Chat(content, defaultChatTags));
        public static bool CBChat(string content, MessageType messageType, DefaultChatTags defaultChatTags) => Send(new Chat(content, messageType, defaultChatTags));

        public static bool CBChat(string Content, User user) => Send(new Chat(Content, user));
        public static bool CBChat(string content, User user, MessageType messageType) => Send(new Chat(content, user, messageType));
        public static bool CBChat(string content, User user, DefaultChatTags defaultChatTags) => Send(new Chat(content, user, defaultChatTags));
        public static bool CBChat(string content, User user, MessageType messageType, DefaultChatTags defaultChatTags) => Send(new Chat(content, user, messageType, defaultChatTags));

        public static bool CBChat(string Content, Player player) => Send(new Chat(Content, player));
        public static bool CBChat(string content, Player player, MessageType messageType) => Send(new Chat(content, player, messageType));
        public static bool CBChat(string content, Player player, DefaultChatTags defaultChatTags) => Send(new Chat(content, player, defaultChatTags));
        public static bool CBChat(string content, Player player, MessageType messageType, DefaultChatTags defaultChatTags) => Send(new Chat(content, player, messageType, defaultChatTags));

        public static bool CBError(string content) => Send(new Error(content));
        public static bool CBError(string content, User user) => Send(new Error(content, user));
        public static bool CBError(string content, Player player) => Send(new Error(content, player));

        public static bool CBInfo(string content) => Send(new Info(content));
        public static bool CBInfo(string content, User user) => Send(new Info(content, user));
        public static bool CBInfo(string content, Player player) => Send(new Info(content, player));

        public static bool CBInfoBox(string content) => Send(new InfoBox(content));
        public static bool CBInfoBox(string content, User user) => Send(new InfoBox(content, user));
        public static bool CBInfoBox(string content, Player player) => Send(new InfoBox(content, player));

        public static bool CBInfoPane(string title, string content, string instance, bool sendToChat = false) => Send(new InfoPane(title, content, instance, sendToChat));
        public static bool CBInfoPane(string title, string content, string instance, bool messageType, bool sendToChat = false) => Send(new InfoPane(title, content, instance, messageType, sendToChat));
        public static bool CBInfoPane(string title, string content, string instance, bool messageType, bool tempMessage, bool sendToChat = false) => Send(new InfoPane(title, content, instance, messageType, tempMessage, sendToChat));

        public static bool CBInfoPane(string title, string content, string instance, User user, bool sendToChat = false) => Send(new InfoPane(title, content, instance, user, sendToChat));
        public static bool CBInfoPane(string title, string content, string instance, User user, bool messageType, bool sendToChat = false) => Send(new InfoPane(title, content, instance, user, messageType, sendToChat));
        public static bool CBInfoPane(string title, string content, string instance, User user, bool messageType, bool tempMessage, bool sendToChat = false) => Send(new InfoPane(title, content, instance, user, messageType, tempMessage, sendToChat));

        public static bool CBInfoPane(string title, string content, string instance, Player player, bool sendToChat = false) => Send(new InfoPane(title, content, instance, player, sendToChat));
        public static bool CBInfoPane(string title, string content, string instance, Player player, bool messageType, bool sendToChat = false) => Send(new InfoPane(title, content, instance, player, messageType, sendToChat));
        public static bool CBInfoPane(string title, string content, string instance, Player player, bool messageType, bool tempMessage, bool sendToChat = false) => Send(new InfoPane(title, content, instance, player, messageType, tempMessage, sendToChat));

        public static bool CBMail(string content) => Send(new Mail(content));
        public static bool CBMail(string content, string tag) => Send(new Mail(content, tag));
        public static bool CBMail(string content, User user) => Send(new Mail(content, user));
        public static bool CBMail(string content, string tag, User user) => Send(new Mail(content, tag, user));
        public static bool CBMail(string content, Player player) => Send(new Mail(content, player));
        public static bool CBMail(string content, string tag, Player player) => Send(new Mail(content, tag, player));

        public static bool CBMessage(string content) => Send(new Message(content));
        public static bool CBMessage(string content, MessageType messageType) => Send(new Message(content, messageType));
        public static bool CBMessage(string content, DefaultChatTags defaultChatTags) => Send(new Message(content, defaultChatTags));
        public static bool CBMessage(string content, MessageCategory messageCategory, DefaultChatTags defaultChatTags) => Send(new Message(content, messageCategory, defaultChatTags));
        public static bool CBMessage(string content, MessageCategory messageCategory, DefaultChatTags defaultChatTags, MessageType messageType) => Send(new Message(content, messageCategory, defaultChatTags, messageType));
        public static bool CBMessage(string title, string content) => Send(new Message(title, content));
        public static bool CBMessage(string title, string content, MessageType messageType) => Send(new Message(title, content, messageType));

        public static bool CBMessage(string content, User user) => Send(new Message(content, user));
        public static bool CBMessage(string content, User user, MessageType messageType) => Send(new Message(content, user, messageType));
        public static bool CBMessage(string content, User user, DefaultChatTags defaultChatTags) => Send(new Message(content, user, defaultChatTags));
        public static bool CBMessage(string content, User user, MessageCategory messageCategory, DefaultChatTags defaultChatTags) => Send(new Message(content, user, messageCategory, defaultChatTags));
        public static bool CBMessage(string content, User user, MessageCategory messageCategory, DefaultChatTags defaultChatTags, MessageType messageType) => Send(new Message(content, user, messageCategory, defaultChatTags, messageType));
        public static bool CBMessage(string title, string content, User user) => Send(new Message(title, content, user));

        public static bool CBMessage(string content, Player player) => Send(new Message(content, player));
        public static bool CBMessage(string content, Player player, MessageType messageType) => Send(new Message(content, player, messageType));
        public static bool CBMessage(string content, Player player, DefaultChatTags defaultChatTags) => Send(new Message(content, player, defaultChatTags));
        public static bool CBMessage(string content, Player player, MessageCategory messageCategory, DefaultChatTags defaultChatTags) => Send(new Message(content, player, messageCategory, defaultChatTags));
        public static bool CBMessage(string content, Player player, MessageCategory messageCategory, DefaultChatTags defaultChatTags, MessageType messageType) => Send(new Message(content, player, messageCategory, defaultChatTags, messageType));
        public static bool CBMessage(string title, string content, Player player) => Send(new Message(title, content, player));

        public static bool CBOkBox(string content) => Send(new OkBox(content));
        public static bool CBOkBox(string content, User user) => Send(new OkBox(content, user));
        public static bool CBOkBox(string content, Player player) => Send(new OkBox(content, player));

        public static bool CBWarning(string content) => Send(new Warning(content));
        public static bool CBWarning(string content, User user) => Send(new Warning(content, user));
        public static bool CBWarning(string content, Player player) => Send(new Warning(content, player));

        public static bool CBWhisper(string content) => Send(new Whisper(content));
        public static bool CBWhisper(string content, User user) => Send(new Whisper(content, user));
        public static bool CBWhisper(string content, Player player) => Send(new Whisper(content, player));

    }
}
