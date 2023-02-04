using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.Nid.ChatTags
{
    public class Commands : IChatCommandHandler
    {
        [ChatSubCommand("Tags", "This command will change the chat tags for this module to use icons or full text", ChatAuthorizationLevel.Admin)]
        public static bool UseIcons(User user, bool useIcons)
        {
            if (useIcons)
                return ChatTagsExtendedInit.API.Config.UseIcons = true;
            else
                return ChatTagsExtendedInit.API.Config.UseIcons = false;
        }
    }
}
