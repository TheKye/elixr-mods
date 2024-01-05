using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Admin.AFK
{
    [ChatCommandHandler]
    public class AFKCommands
    {
        [ChatCommand("Elixr Mods AFK Monitor Plugin", ChatAuthorizationLevel.Admin)]
        public static void Afk(User user)
        {
            ChatBaseExtended.CBInfo(string.Format("The Current Afk Timer is set to {0} Minutes", AFKPlugin.config.Interval), user);
        }

        [ChatSubCommand("afk", "Sets the length in minutes to let a player afk for.", "afk-timer", ChatAuthorizationLevel.Admin)]
        public static void AFKTimer(User user, int Minutes)
        {
            if (Minutes == 0)
            {
                AFKPlugin.config.Enabled = false;
                AFKPlugin.UserHistory.Clear();
                AFKPlugin.Save();
                ChatBaseExtended.CBInfo(string.Format("AFK Timer Has Been Disabled"), user);
                return;
            }
            if (!AFKPlugin.config.Enabled)
                AFKPlugin.config.Enabled = true;

            AFKPlugin.config.Interval = Minutes;
            AFKPlugin.Save();

            ChatBaseExtended.CBInfo(string.Format("Players will now be booted if they are idling for {0} {1}", Minutes, Minutes > 1 ? "minutes" : "minute"), user);
        }



        [ChatSubCommand("afk", "Enables/Disables AFK Monitor", "enable-afk", ChatAuthorizationLevel.Admin)]
        public static void AFKEnable(User user, bool ForceEnable = false)
        {
            if(ForceEnable)
            {
                if (AFKPlugin.config.Enabled)
                {
                    ChatBaseExtended.CBInfo("AFK Monitor is already Enabled", user);
                    return;
                }

                AFKPlugin.config.Enabled = true;

                AFKPlugin.Save();
                ChatBaseExtended.CBInfo(string.Format("AFK Monitor has been {0}", AFKPlugin.config.Enabled ? Text.Positive("Enabled") : Text.Negative("Disabled")), user);
                return;
            }

            switch (AFKPlugin.config.Enabled)
            {
                case true:
                    AFKPlugin.config.Enabled = false;
                    AFKPlugin.UserHistory.Clear();
                    break;
                case false:
                    AFKPlugin.config.Enabled = true;
                    break;
            }

            AFKPlugin.Save();
            ChatBaseExtended.CBInfo(string.Format("AFK Monitor has been {0}", AFKPlugin.config.Enabled ? Text.Positive("Enabled") : Text.Negative("Disabled")), user);
        }

        [ChatSubCommand("afk", "Enables AFK Monitor", "afk-kickadmin", ChatAuthorizationLevel.Admin)]
        public static void AFKKickAdmins(User user, bool kick = false)
        {
            AFKPlugin.config.KickAdmins = kick;
            AFKPlugin.Save();

            ChatBaseExtended.CBInfo(string.Format("Kicking of admins has been set to: {0}", kick ? Text.Positive("true") : Text.Negative("false")), user);
        }

        [ChatSubCommand("afk", "Reload afk Config", "afk-reload", ChatAuthorizationLevel.Admin)]
        public static void AfkReload(User user)
        {
            AFKPlugin.Reload();
            ChatBaseExtended.CBInfo(AFKPlugin.appName + "AFK configs Reloaded", user);
        }
    }
}
