using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Shared.Localization;
using EM.ECO.MOTD;

namespace Eco.EM.MOTD
{
        [ChatCommandHandler]
    public class MOTDCommands 
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
            ChatBaseExtended.CBChat(Defaults.appName + string.Format(Localizer.DoStr("Added to MOTD: {0}"),msg), user, ChatBase.MessageType.Temporary);
            MOTDManager.SaveData();
        }

        [ChatSubCommand("MOTDS", "Removes a message from the messages list", "motd-mrem", ChatAuthorizationLevel.Admin)]
        public static void RemMOTDMessage(User user, int index)
        {
            // check message index is valid
            if (index < 1 || index > MOTDManager.Data.Messages.Count)
            {
                ChatBaseExtended.CBChat(Defaults.appName + string.Format(Localizer.DoStr("Message {0} could not be found to remove."), index), user, ChatBase.MessageType.Temporary);
                return;
            }

            ChatBaseExtended.CBChat(Defaults.appName + string.Format(Localizer.DoStr("Removed: {0}"), MOTDManager.Data.Messages[index - 1]), user, ChatBase.MessageType.Temporary);
            MOTDManager.Data.Messages.RemoveAt(index - 1);
            MOTDManager.SaveData();
        }
    }
}
