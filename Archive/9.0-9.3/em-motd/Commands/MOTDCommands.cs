using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using EM.ECO.MOTD;

namespace Eco.EM.MOTD
{
    public class MOTDCommands: IChatCommandHandler
    {
        [ChatCommand("MOTD commands", ChatAuthorizationLevel.Admin)]
        public static void MOTDS(User user) { }

        [ChatSubCommand("MOTDS", "Reload the MOTD from a config change", "motd-reload", ChatAuthorizationLevel.Admin)]
        public static void ReloadMOTD(User user)
        {
            MOTDManager.LoadMOTD();
        }

        [ChatSubCommand("MOTDS", "Reopen the MOTD as a user ", "motd", ChatAuthorizationLevel.User)]
        public static void ReopenMOTD(User user)
        {
            MOTDManager.Data.DisplayMOTD(user);
        }

        [ChatSubCommand("MOTDS", "Adds a message to the messages list", "motd-madd", ChatAuthorizationLevel.Admin)]
        public static void AddMOTDMessage(User user, string msg)
        {
            MOTDManager.Data.Messages.Add(msg);
            ChatBaseExtended.CBChat(Base.appName + $"Added to MOTD: {msg}", user, ChatBase.MessageType.Temporary);
            MOTDManager.SaveData();
        }

        [ChatSubCommand("MOTDS", "Removes a message from the messages list", "motd-mrem", ChatAuthorizationLevel.Admin)]
        public static void RemMOTDMessage(User user, int index)
        {
            // check message index is valid
            if (index < 1 || index > MOTDManager.Data.Messages.Count)
            {
                ChatBaseExtended.CBChat(Base.appName + $"Message {index} could not be found to remove.", user, ChatBase.MessageType.Temporary);
                return;
            }

            ChatBaseExtended.CBChat(Base.appName + $"Removed: {MOTDManager.Data.Messages[index - 1]}", user, ChatBase.MessageType.Temporary);
            MOTDManager.Data.Messages.RemoveAt(index - 1);
            MOTDManager.SaveData();
        }
    }
}
