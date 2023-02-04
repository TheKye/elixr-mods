namespace Eco.EM
{
    using Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    public class ChatBase : IModKitPlugin
    {
        public struct Message
        {
            public RecipientType RecipientType;
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public MessageType MessageType;

            public string Title;
            public string Content;
            public MessageCategory ChatCategory;
            public DefaultChatTags DefaultChatTags;

            public Message( string content )
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = MessageType.Temporary;
            }

            public Message( string content, MessageType messageType )
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = messageType;
            }

            public Message( string content, User user )
            {
                Title = string.Empty;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = MessageType.Temporary;
            }

            public Message( string content, Player player )
            {
                Title = string.Empty;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = MessageType.Temporary;
            }

            public Message( string content, User user, MessageType messageType )
            {
                Title = string.Empty;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Server;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = messageType;
            }


            public Message( string content, Player player, MessageType messageType )
            {
                Title = string.Empty;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Server;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = messageType;
            }

            public Message( string content, MessageCategory chatCategory, DefaultChatTags defaultChatTags )
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                ChatCategory = chatCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }

            public Message( string content, MessageCategory chatCategory, DefaultChatTags defaultChatTags, MessageType messageType )
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                ChatCategory = chatCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = messageType;
            }

            public Message( string content, User user, MessageCategory chatCategory, DefaultChatTags defaultChatTags )
            {
                Title = string.Empty;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                ChatCategory = chatCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }

            public Message( string content, Player player, MessageCategory chatCategory, DefaultChatTags defaultChatTags )
            {
                Title = string.Empty;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                ChatCategory = chatCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }

            public Message( string content, User user, MessageCategory chatCategory, DefaultChatTags defaultChatTags, MessageType messageType )
            {
                Title = string.Empty;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                ChatCategory = chatCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = messageType;
            }

            public Message( string content, Player player, MessageCategory chatCategory, DefaultChatTags defaultChatTags, MessageType messageType )
            {
                Title = string.Empty;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                ChatCategory = chatCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = messageType;
            }

            public Message( string title, string content )
            {
                Title = title;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = ( string.IsNullOrWhiteSpace( title ) ) ? MessageType.Popup : MessageType.Announcement;
            }

            public Message( string title, string content, MessageType messageType )
            {
                Title = title;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = ( string.IsNullOrWhiteSpace( title ) ) ? MessageType.Popup : MessageType.Announcement;
            }

            public Message( string title, string content, User user )
            {
                Title = title;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = ( string.IsNullOrWhiteSpace( title ) ) ? MessageType.Popup : MessageType.Announcement;
            }

            public Message( string title, string content, Player player )
            {
                Title = title;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = ( string.IsNullOrWhiteSpace( title ) ) ? MessageType.Popup : MessageType.Announcement;
            }
        }
        public enum RecipientType
        {
            Server,
            Player
        }
        public enum MessageType
        {
            Temporary,
            Permanent,
            Announcement,
            Popup
        }

        public static bool Send( Message Message )
        {
            string content = $"{Message.Content}";

            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;

                    return SendToPlayer( Message );
                case RecipientType.Server:
                    return SendToServer( Message );
            }

            return false;
        }

        internal static bool SendToPlayer( Message Message )
        {
            switch (Message.MessageType)
            {
                case MessageType.Announcement:
                    Message.Player.OpenInfoPanel( Message.Title, Message.Content.ToString( ) );
                    break;
                case MessageType.Popup:
                    Message.Player.OkBoxLoc( $"{Message.Content}" );
                    break;
                case MessageType.Temporary:
                    Message.Player.MsgLocStr( Localizer.DoStr( Message.Content.ToString( ) ), Message.ChatCategory);
                    break;
                case MessageType.Permanent:
                    ChatManager.ServerMessageToPlayer( Localizer.DoStr( Message.Content.ToString( ) ), Message.User, Message.DefaultChatTags, Message.ChatCategory );
                    break;
            }

            return true;
        }

        internal static bool SendToServer( Message Message )
        {
            try
            {
                switch (Message.MessageType)
                {
                    case MessageType.Announcement:
                        foreach (var user in Base.OnlineUsers)
                        {
                            user.Player.OpenInfoPanel( Message.Title, Message.Content.ToString( ) );
                        }
                        break;
                    case MessageType.Popup:
                        foreach (var user in Base.OnlineUsers)
                        {
                            user.Player.OkBoxLoc( $"{Message.Content}" );
                        }
                        break;
                    case MessageType.Temporary:
                        ChatManager.ServerMessageToAll( Localizer.DoStr( Message.Content.ToString( ) ) );
                        break;
                    case MessageType.Permanent:
                        ChatManager.ServerMessageToAll( Localizer.DoStr( Message.Content.ToString( ) ) );
                        break;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetStatus()
        {
            return "Active";
        }
    }
}