namespace VoteMod.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using VoteMod.Helpers;

    public static class ChatHelper
    {
        public static void SendMessageToPlayer(string message, User user, bool isTemp = true)
        {
            ChatManager.ServerMessageToPlayer(Localizer.DoStr(message), user, forceTemporary: isTemp);
        }
    }
}
