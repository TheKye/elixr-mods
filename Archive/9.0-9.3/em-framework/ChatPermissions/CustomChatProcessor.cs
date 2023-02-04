namespace Eco.EM.Framework.Permissions
{
    using Eco.EM.Framework.Groups;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.EM.Framework.ChatBase;
    using Eco.Shared.Localization;
    using Eco.Core.Utils;
    using System.Linq;
    using System;

    // Custom chat command processor assists in overriding SLG defined Auth levels and allows us to assign standard command to our own processing logic
    public class EMCustomChatProcessor : ICommandProcessorHandler
    {
        private readonly static NLogWrapper adminCommandsLog = NLogWriter.GetConcreteLogger("admin_commands");

        public static Action<ChatCommand, User, bool> CommandProcessed;

        public EMCustomChatProcessor() { }

        [CommandProcessor]
        public static bool EMProcessCommand(ChatCommand command, User user)
        {
            // if an admin or developer & we have not overridden this in our config return true;
            if ((user.IsAdminOrDev && CommandGroupsManager.Config.DefaultAdminBehaviour)  || (command.AuthLevel == ChatAuthorizationLevel.User && CommandGroupsManager.Config.DefaultUserBehaviour))
            {
                if (command.AuthLevel >= ChatAuthorizationLevel.Admin)
                    LogAdminCommand(user, command.Name);

                CommandProcessed?.Invoke(command, user, true);
                return true;
            }
                
            var adapter = CommandGroupsManager.FindApapter(command.Name);

            if (adapter == null)
            {
                ChatBaseExtended.CBError(string.Format(Base.appName + "Command {0} not found", command.Name), user);
                return false;
            }

            // check the users groups permissions permissions
            if (GroupsManager.API.UserPermitted(user, adapter))
            {
                if (command.AuthLevel >= ChatAuthorizationLevel.Admin)
                    LogAdminCommand(user, command.Name);

                CommandProcessed?.Invoke(command, user, true);
                return true;
            }
            // default behaviour is to deny if command or user is not set
            ChatBaseExtended.CBError(string.Format(Base.appName + "You are not authorized to use the command {0}", command.Name), user);
            CommandProcessed?.Invoke(command, user, false);
            return false;
        }

        /// <summary> Adds info about admin command executed by <paramref name="user"/> to special admin commands log. </summary>
        private static void LogAdminCommand(User user, string text)
        {
            var level = UserManager.Config.AdminCommandsLoggingLevel;
            if (level == AdminCommandsLoggingLevels.None)
                return;

            adminCommandsLog.Info($"{user.Name} invoked admin command '{text}'");
            if (level == AdminCommandsLoggingLevels.LogFile)
                return;

            var chatMessage = Localizer.Do($"{user.Name} invoked admin command '{text}'");
            switch (UserManager.Config.AdminCommandsLoggingLevel)
            {
                case AdminCommandsLoggingLevels.LogFileAndNotifyAdmins:
                    foreach (var admin in UserManager.OnlineUsers.Where(u => u.IsAdmin))
                        ChatManager.ServerMessageToPlayer(chatMessage, admin);
                    break;
                case AdminCommandsLoggingLevels.LogFileAndNotifyEveryone:
                    ChatManager.ServerMessageToAll(chatMessage);
                    break;
            }
        }
    }
}