using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Eco.EM.Framework.ChatBase
{
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Services;
using Eco.Shared.Utils;

    public class ChatBase : IModKitPlugin
    {
        public enum RecipientType
        {
            Server,
            Player
        }
        public enum MessageType
        {
            Temporary,
            Permanent,
            InfoPanel,
            CustomInfo,
            OkBox,
            GlobalAnnoucement
        }

        /// <summary>
        /// Announcements Can only be made to the server and can show as either a Popup Box or an Info Panel
        /// you can specify if you would like to use a popup box or the Info Panel
        /// To Specify if its a popup or Info panel you just need to enter 2 strings at the start or just one
        /// a single string will make it a popup, 2 strings will make it an info panel, 
        /// The announcement doesn't support use of the Custom Info Panel though
        /// Remember Info Panels can be customized
        /// Announcements will also show up in the chat In the General Section
        /// An announcement will only show for online users, for offline users as well use Global Announcement
        /// </summary>
        public struct Announcement
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;

            public string Title;
            public string Content;
            public MessageCategory MessageCategory;
            public DefaultChatTags DefaultChatTags;
            public MessageType MessageType;
            public string Instance;
            public bool SendToAll;
            public bool SendToChat;

            public Announcement(string content, bool sendToAll = false, bool sendToChat = false)
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.General;
                MessageType = MessageType.OkBox;
                SendToAll = sendToAll;
                SendToChat = sendToChat;
                Instance = null;
            }

            public Announcement(string title, string content, string instance, bool sendToAll = false, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.General;
                MessageType = MessageType.InfoPanel;
                SendToAll = sendToAll;
                SendToChat = sendToChat;
                Instance = instance;
            }

            public Announcement(string title, string content, string instance, MessageType messageType, bool sendToAll = false, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.General;
                MessageType = messageType;
                SendToAll = sendToAll;
                SendToChat = sendToChat;
                Instance = instance;
            }
        }

        /// <summary>
        /// Chat is used to Send Only to the Server Chat
        /// It can be sent to a player or the entire server
        /// You can also specify which channel it is posted too, Default is General
        /// MessageType = Temp Or Permanent Message - Default is Temporary
        /// DefaultChatTags = Which Channel to post the message too IE: General, Trades, Notifications etc - Default Is General
        /// </summary>
        public struct Chat
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;

            public RecipientType RecipientType; //Server Or User
            public MessageType MessageType; //Temp Or Not 

            public string Content;
            public MessageCategory MessageCategory;
            public DefaultChatTags DefaultChatTags;

            public Chat(string content)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.General;
                MessageType = MessageType.Temporary;
            }

            public Chat(string content, MessageType messageType)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.General;
                MessageType = messageType;
            }

            public Chat(string content, DefaultChatTags defaultChatTags)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }

            public Chat(string content, MessageType messageType, DefaultChatTags defaultChatTags)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = defaultChatTags;
                MessageType = messageType;
            }

            public Chat(string content, User user)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.General;
                MessageType = MessageType.Temporary;
            }

            public Chat(string content, User user, MessageType messageType)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.General;
                MessageType = messageType;
            }

            public Chat(string content, User user, DefaultChatTags defaultChatTags)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }

            public Chat(string content, User user, MessageType messageType, DefaultChatTags defaultChatTags)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = defaultChatTags;
                MessageType = messageType;
            }

            public Chat(string content, Player player)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.General;
                MessageType = MessageType.Temporary;
            }

            public Chat(string content, Player player, MessageType messageType)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.General;
                MessageType = messageType;
            }

            public Chat(string content, Player player, DefaultChatTags defaultChatTags)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }

            public Chat(string content, Player player, MessageType messageType, DefaultChatTags defaultChatTags)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = defaultChatTags;
                MessageType = messageType;
            }
        }

        /// <summary>
        /// Error is the same as the Error box shown to players, this can be sent to all players or a single player
        /// this only accepts content input
        /// </summary>
        public struct Error
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;

            public string Content;
            public MessageCategory MessageCategory;

            public Error(string content)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Error;
            }

            public Error(string content, User user)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Error;
            }

            public Error(string content, Player player)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Error;
            }
        }

        /// <summary>
        /// Info Sends a little info panel down the bottom similar to the Error and Warning just in a light style box with light text
        /// Info boxes can be sent to a single player or all players on the server
        /// </summary>
        public struct Info
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;

            public string Content;
            public MessageCategory MessageCategory;

            public Info(string content)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Info;
            }

            public Info(string content, User user)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Info;
            }

            public Info(string content, Player player)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Info;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public struct InfoBox
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;

            public string Content;
            public MessageCategory MessageCategory;

            public InfoBox(string content)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.InfoBox;
            }

            public InfoBox(string content, User user)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.InfoBox;
            }

            public InfoBox(string content, Player player)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.InfoBox;
            }
        }

        /// <summary>
        /// While it may be a little on the confusing side, The InfoPane Struct allows for using the InfoPanel or the CustomPanel
        /// This is used for displaying information in a popup info box that can be resized, contain large messages or just for a nicer feel when sending 
        /// large amounts of info to players
        /// This will also post the message to the Notifications Channel as a permanent Message so users can look back on them, this can be sent to all online players 
        /// or just a single player
        /// you may also set it too temp if you like
        /// DefaultChatTags = Which Channel to post the message too IE: General, Trades, Notifications etc - Default Is General
        /// MessageType is a bool - False = Send Info Panel, True = Send Custom Info Panel - Default is False
        /// TempMessage is a bool - False = Sends a Permanent Message to the Notifications part in the chat, True = Send a Temporary Notification to the chat
        /// Some Players May miss the info panel so as a secondary measure we added the notifications addition just incase people miss it and can go back and 
        /// have a look
        /// </summary>
        public struct InfoPane
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;
            public bool UseCustomPane;
            public bool TempMessage;
            public bool SendToChat;

            public string Title;
            public string Content;
            public string Instance;
            public MessageCategory ChatCategory;
            public DefaultChatTags DefaultChatTags;

            public InfoPane(string title, string content, string instance, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                UseCustomPane = false;
                TempMessage = false;
                SendToChat = sendToChat;
                Instance = instance;
            }
            public InfoPane(string title, string content, string instance, bool useCustomPane, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                UseCustomPane = useCustomPane;
                TempMessage = false;
                SendToChat = sendToChat;
                Instance = instance;
            }
            public InfoPane(string title, string content, string instance, bool useCustomPane, bool tempMessage, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                UseCustomPane = useCustomPane;
                TempMessage = tempMessage;
                SendToChat = sendToChat;
                Instance = instance;
            }
            public InfoPane(string title, string content, string instance, User user, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                UseCustomPane = false;
                TempMessage = false;
                SendToChat = sendToChat;
                Instance = instance;
            }
            public InfoPane(string title, string content, string instance, User user, bool useCustomPane, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                UseCustomPane = useCustomPane;
                TempMessage = false;
                SendToChat = sendToChat;
                Instance = instance;
            }
            public InfoPane(string title, string content, string instance, User user, bool useCustomPane, bool tempMessage, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                UseCustomPane = useCustomPane;
                TempMessage = tempMessage;
                SendToChat = sendToChat;
                Instance = instance;
            }
            public InfoPane(string title, string content, string instance, Player player, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                UseCustomPane = false;
                TempMessage = false;
                SendToChat = sendToChat;
                Instance = instance;
            }
            public InfoPane(string title, string content, string instance, Player player, bool useCustomPane, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                UseCustomPane = useCustomPane;
                TempMessage = false;
                SendToChat = sendToChat;
                Instance = instance;
            }
            public InfoPane(string title, string content, string instance, Player player, bool useCustomPane, bool tempMessage, bool sendToChat = false)
            {
                Title = title;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                ChatCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                UseCustomPane = useCustomPane;
                TempMessage = tempMessage;
                SendToChat = sendToChat;
                Instance = instance;
            }
        }

        /// <summary>
        /// Mail sends a new "Mail Message" to a selected users Mailbox ( The notifications bar on the right)
        /// You can specify a tag for this message but im not sure what the tags actually do.. Default is Notification
        /// These can be sent to the entire server (even offline players) or a single player
        /// </summary>
        public struct Mail
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;

            public string Content;
            public string Tag;

            public Mail(string content)
            {
                Content = content;
                Player = null;
                User = null;
                Tag = "Notification";
                RecipientType = RecipientType.Server;
            }
            public Mail(string content, string tag)
            {
                Content = content;
                Player = null;
                User = null;
                Tag = tag;
                RecipientType = RecipientType.Server;
            }
            public Mail(string content, User user)
            {
                Content = content;
                Player = user.Player;
                User = user;
                Tag = "Notification";
                RecipientType = RecipientType.Player;
            }
            public Mail(string content, string tag, User user)
            {
                Content = content;
                Player = user.Player;
                User = user;
                Tag = tag;
                RecipientType = RecipientType.Player;
            }
            public Mail(string content, Player player)
            {
                Content = content;
                Player = player;
                User = player.User;
                Tag = "Notification";
                RecipientType = RecipientType.Player;
            }
            public Mail(string content, string tag, Player player)
            {
                Content = content;
                Player = player;
                User = player.User;
                Tag = tag;
                RecipientType = RecipientType.Player;
            }
        }

        /// <summary>
        /// ChatBase.Message is an older function but it is the most flexible,
        /// this may require some advanced knowledge to use
        /// </summary>
        public struct Message
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;
            public MessageType MessageType;

            public string Title;
            public string Content;
            public MessageCategory MessageCategory;
            public DefaultChatTags DefaultChatTags;

            public Message(string content)
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = MessageType.Temporary;
            }
            public Message(string content, MessageType messageType)
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = messageType;
            }
            public Message(string content, DefaultChatTags defaultChatTags)
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }
            public Message(string content, MessageCategory messageCategory, DefaultChatTags defaultChatTags)
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = messageCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }
            public Message(string content, MessageCategory messageCategory, DefaultChatTags defaultChatTags, MessageType messageType)
            {
                Title = string.Empty;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = messageCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = messageType;
            }
            public Message(string title, string content)
            {
                Title = title;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = string.IsNullOrWhiteSpace(title) ? MessageType.OkBox : MessageType.InfoPanel;
            }
            public Message(string title, string content, MessageType messageType)
            {
                Title = title;
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = messageType;
            }
            public Message(string content, User user)
            {
                Title = string.Empty;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = MessageType.Temporary;
            }
            public Message(string content, User user, MessageType messageType)
            {
                Title = string.Empty;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = messageType;
            }
            public Message(string content, User user, DefaultChatTags defaultChatTags)
            {
                Title = string.Empty;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }
            public Message(string content, User user, MessageCategory messageCategory, DefaultChatTags defaultChatTags)
            {
                Title = string.Empty;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = messageCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }
            public Message(string content, User user, MessageCategory messageCategory, DefaultChatTags defaultChatTags, MessageType messageType)
            {
                Title = string.Empty;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = messageCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = messageType;
            }
            public Message(string title, string content, User user)
            {
                Title = title;
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = string.IsNullOrWhiteSpace(title) ? MessageType.OkBox : MessageType.InfoPanel;
            }
            public Message(string content, Player player)
            {
                Title = string.Empty;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = MessageType.Temporary;
            }
            public Message(string content, Player player, MessageType messageType)
            {
                Title = string.Empty;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = messageType;
            }
            public Message(string content, Player player, DefaultChatTags defaultChatTags)
            {
                Title = string.Empty;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }
            public Message(string content, Player player, MessageCategory messageCategory, DefaultChatTags defaultChatTags)
            {
                Title = string.Empty;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = messageCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = MessageType.Temporary;
            }
            public Message(string content, Player player, MessageCategory messageCategory, DefaultChatTags defaultChatTags, MessageType messageType)
            {
                Title = string.Empty;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = messageCategory;
                DefaultChatTags = defaultChatTags;
                MessageType = messageType;
            }
            public Message(string title, string content, Player player)
            {
                Title = title;
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Chat;
                DefaultChatTags = DefaultChatTags.Notifications;
                MessageType = string.IsNullOrWhiteSpace(title) ? MessageType.OkBox : MessageType.InfoPanel;
            }

        }

        /// <summary>
        /// OkBox is a Popup Ok Box
        /// this can be used for when you want to make sure the user got the message
        /// </summary>
        public struct OkBox
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;

            public string Content;

            public OkBox(string content)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
            }

            public OkBox(string content, User user)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
            }

            public OkBox(string content, Player player)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
            }
        }

        /// <summary>
        /// Warning Sends a little Warning Box to the player, For Completion's sake we have also made it so this can be sent to all players online as well
        /// this only accepts a message and a user
        /// </summary>
        public struct Warning
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;

            public string Content;
            public MessageCategory MessageCategory;

            public Warning(string content)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Warning;
            }

            public Warning(string content, User user)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Warning;
            }

            public Warning(string content, Player player)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Warning;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public struct Whisper
        {
            public Player Player;   // Required for RecipientType.Player;
            public User User;       // Required for RecipientType.User;
            public RecipientType RecipientType;

            public string Content;
            public MessageCategory MessageCategory;

            public Whisper(string content)
            {
                Content = content;
                Player = null;
                User = null;
                RecipientType = RecipientType.Server;
                MessageCategory = MessageCategory.Whisper;
            }

            public Whisper(string content, User user)
            {
                Content = content;
                Player = user.Player;
                User = user;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Whisper;
            }

            public Whisper(string content, Player player)
            {
                Content = content;
                Player = player;
                User = player.User;
                RecipientType = RecipientType.Player;
                MessageCategory = MessageCategory.Whisper;
            }
        }

        #region Announcement
        public static bool Send(Announcement Message)
        {
            return Message.RecipientType switch
            {
                RecipientType.Server => SendToServer(Message),
                RecipientType.Player => false,
                _ => false,
            };
        }
        internal static bool SendToServer(Announcement Message)
        {
            try
            {
                switch (Message.MessageType)
                {
                    case MessageType.InfoPanel:
                        foreach (var user in Base.OnlineUsers)
                        {
                            user.Player.OpenInfoPanel(Message.Title, Message.Content, Message.MessageCategory.ToString());
                        }
                        break;
                    case MessageType.CustomInfo:
                        foreach (var user in Base.OnlineUsers)
                        {
                            user.Player.OpenCustomPanel(Message.Title, Message.Content, Message.MessageCategory.ToString());
                        }
                        break;
                    case MessageType.OkBox:
                        foreach (var user in Base.OnlineUsers)
                        {
                            user.Player.OkBoxLoc($"{Message.Content}");
                        }
                        break;
                }
                if (Message.SendToAll)
                    ChatManager.GlobalNotification($"{Message.Content}", Message.DefaultChatTags, true);
                if (Message.SendToChat)
                    ChatManager.ServerMessageToAll(Localizer.DoStr(Message.Content));
                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region Chat
        public static bool Send(Chat Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(Chat Message)
        {
            switch (Message.MessageType)
            {
                case MessageType.Temporary:
                    ChatManager.ServerMessageToPlayer(Localizer.DoStr(Message.Content), Message.User, Message.DefaultChatTags, Message.MessageCategory, true);
                    break;
                case MessageType.Permanent:
                    ChatManager.ServerMessageToPlayer(Localizer.DoStr(Message.Content), Message.User, Message.DefaultChatTags, Message.MessageCategory, false);
                    break;
            }

            return true;
        }
        internal static bool SendToServer(Chat Message)
        {
            try
            {
                switch (Message.MessageType)
                {
                    case MessageType.Temporary:
                        ChatManager.ServerMessageToAll(Localizer.DoStr(Message.Content));
                        break;
                    case MessageType.Permanent:
                        ChatManager.ServerMessageToAll(Localizer.DoStr(Message.Content));
                        break;
                }

                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region Error
        public static bool Send(Error Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(Error Message)
        {
            Message.Player.Msg(Localizer.DoStr(Text.Error(Message.Content)), Message.MessageCategory);
            return true;
        }
        internal static bool SendToServer(Error Message)
        {
            try
            {
                foreach (var user in Base.OnlineUsers)
                {
                    user.Player.Msg(Localizer.DoStr(Text.Error(Message.Content)), Message.MessageCategory);
                }
                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region Info
        public static bool Send(Info Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(Info Message)
        {
            Message.Player.Msg(Localizer.DoStr(Text.Info(Message.Content)), Message.MessageCategory);
            return true;
        }
        internal static bool SendToServer(Info Message)
        {
            try
            {
                foreach (var user in Base.OnlineUsers)
                {
                    user.Player.Msg(Localizer.DoStr(Text.Info(Message.Content)), Message.MessageCategory);
                }
                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region InfoBox
        public static bool Send(InfoBox Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(InfoBox Message)
        {
            Message.Player.Msg(Localizer.DoStr(Text.InfoLight(Message.Content)), Message.MessageCategory);
            return true;
        }
        internal static bool SendToServer(InfoBox Message)
        {
            try
            {
                foreach (var user in Base.OnlineUsers)
                {
                    user.Player.Msg(Localizer.DoStr(Text.InfoLight(Message.Content)), Message.MessageCategory);
                }
                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region InfoPane
        public static bool Send(InfoPane Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(InfoPane Message)
        {
            switch (Message.UseCustomPane)
            {
                case true:
                    Message.Player.OpenCustomPanel(Message.Title, Message.Content, Message.Instance);
                    break;
                case false:
                    Message.Player.OpenInfoPanel(Message.Title, Message.Content, Message.Instance);
                    break;
            }
            if (Message.SendToChat)
            {
                if (Message.TempMessage)
                    ChatManager.ServerMessageToPlayer(Localizer.DoStr(Message.Content), Message.User, Message.DefaultChatTags, Message.ChatCategory, true);
                else
                    ChatManager.ServerMessageToPlayer(Localizer.DoStr(Message.Content), Message.User, Message.DefaultChatTags, Message.ChatCategory, false);
            }
            return true;
        }
        internal static bool SendToServer(InfoPane Message)
        {
            try
            {
                switch (Message.UseCustomPane)
                {
                    case true:
                        foreach (var user in Base.OnlineUsers)
                        {
                            user.Player.OpenCustomPanel(Message.Title, Message.Content, Message.Instance);
                        }
                        break;
                    case false:
                        foreach (var user in Base.OnlineUsers)
                        {
                            user.Player.OpenInfoPanel(Message.Title, Message.Content, Message.Instance);
                        }
                        break;
                }
                if (Message.TempMessage)
                    ChatManager.ServerMessageToAll(Localizer.DoStr(Message.Content), DefaultChatTags.Notifications, Message.ChatCategory, forceTemporary: true);
                else
                    ChatManager.ServerMessageToAll(Localizer.DoStr(Message.Content));

                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region Mail
        public static bool Send(Mail Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(Mail Message)
        {
            var mailMessage = new MailMessage(Message.Content, Message.Tag);

            Message.User.Mailbox.Add(mailMessage, Message.User.IsOnline);
            return true;
        }
        internal static bool SendToServer(Mail Message)
        {
            try
            {
                var mailMessage = new MailMessage(Message.Content, Message.Tag);
                foreach (var user in Base.Users)
                {
                    user.Mailbox.Add(mailMessage, user.IsOnline);
                }
                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region Message
        public static bool Send(Message Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(Message Message)
        {
            switch (Message.MessageType)
            {
                case MessageType.InfoPanel:
                    Message.Player.OpenInfoPanel(Message.Title, Message.Content, Message.MessageCategory.ToString());
                    break;
                case MessageType.CustomInfo:
                    Message.Player.OpenCustomPanel(Message.Title, Message.Content, Message.MessageCategory.ToString());
                    break;
                case MessageType.OkBox:
                    Message.Player.OkBoxLoc($"{Message.Content}");
                    break;
                case MessageType.Temporary:
                    ChatManager.ServerMessageToPlayer(Localizer.DoStr(Message.Content), Message.User, Message.DefaultChatTags, Message.MessageCategory, true);
                    break;
                case MessageType.Permanent:
                    ChatManager.ServerMessageToPlayer(Localizer.DoStr(Message.Content), Message.User, Message.DefaultChatTags, Message.MessageCategory, false);
                    break;
            }

            return true;
        }
        internal static bool SendToServer(Message Message)
        {
            try
            {
                switch (Message.MessageType)
                {
                    case MessageType.InfoPanel:
                        foreach (var user in Base.OnlineUsers)
                        {
                            user.Player.OpenInfoPanel(Message.Title, Message.Content, Message.MessageCategory.ToString());
                        }
                        break;
                    case MessageType.OkBox:
                        foreach (var user in Base.OnlineUsers)
                        {
                            user.Player.OkBoxLoc($"{Message.Content}");
                        }
                        break;
                    case MessageType.Temporary:
                        ChatManager.ServerMessageToAll(Localizer.DoStr(Message.Content), forceTemporary: true);
                        break;
                    case MessageType.Permanent:
                        ChatManager.ServerMessageToAll(Localizer.DoStr(Message.Content));
                        break;
                    case MessageType.GlobalAnnoucement:
                        ChatManager.GlobalNotification($"{Message.Content}", Message.DefaultChatTags, true);
                        break;
                }

                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region OkBox
        public static bool Send(OkBox Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(OkBox Message)
        {
            Message.Player.OkBoxLoc($"{Message.Content}");
            return true;
        }
        internal static bool SendToServer(OkBox Message)
        {
            try
            {
                foreach (var user in Base.OnlineUsers)
                {
                    user.Player.OkBoxLoc($"{Message.Content}");
                }
                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region Warning
        public static bool Send(Warning Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(Warning Message)
        {
            Message.Player.Msg(Localizer.DoStr(Text.Warning(Message.Content)), Message.MessageCategory);
            return true;
        }
        internal static bool SendToServer(Warning Message)
        {
            try
            {
                foreach (var user in Base.OnlineUsers)
                {
                    user.Player.Msg(Localizer.DoStr(Text.Warning(Message.Content)), Message.MessageCategory);
                }
                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion
        #region Whisper
        public static bool Send(Whisper Message)
        {
            switch (Message.RecipientType)
            {
                case RecipientType.Player:
                    if (Message.Player == null)
                        return false;
                    return SendToPlayer(Message);
                case RecipientType.Server:
                    return SendToServer(Message);
            }

            return false;
        }
        internal static bool SendToPlayer(Whisper Message)
        {
            Message.Player.Msg(Localizer.DoStr(Text.WhisperLight(Message.Content)), Message.MessageCategory);
            return true;
        }
        internal static bool SendToServer(Whisper Message)
        {
            try
            {
                foreach (var user in Base.OnlineUsers)
                {
                    user.Player.Msg(Localizer.DoStr(Text.WhisperLight(Message.Content)), Message.MessageCategory);
                }
                return true;
            }
            catch (Exception e)
            {
                Log.WriteErrorLineLocStr($"There was an error, Error was: {e}");
                return false;
            }
        }
        #endregion

        public string GetStatus()
        {
            return "Active";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM - Chatbase");
        }
    }
}