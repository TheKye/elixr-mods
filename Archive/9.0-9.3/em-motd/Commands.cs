using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using System.Threading;

namespace Eco.EM.MOTD
{
    public class MOTDCommands : IChatCommandHandler
    {
        [ChatCommand("Elixr Mods MOTD Plugin", ChatAuthorizationLevel.Admin)]
        public static void motd() { }

        [ChatSubCommand("motd", "Set the interval at which MOTDs will be displayed", "motd-interval", ChatAuthorizationLevel.Admin)]
        public static void SetInterval(User user, int Seconds)
        {
           
        }

        [ChatSubCommand("motd", "Toggles the mode between Slow and Fast.", "motd-mode", ChatAuthorizationLevel.Admin)]
        public static void ToggleMode(User user)
        {
           
        }

        [ChatSubCommand("motd", "Swtich on MOTDs", "motd-on",ChatAuthorizationLevel.Admin)]
        public static void Enable(User user)
        {
            
        }

        [ChatSubCommand("motd", "Swtich off MOTDs", "motd-off", ChatAuthorizationLevel.Admin)]
        public static void Disable(User user)
        {
            
        }

        [ChatSubCommand("motd", "Add a new Message to the MOTD list", "motd-add", ChatAuthorizationLevel.Admin)]
        public static void Add(User user, string Message)
        {
           
        }

        [ChatSubCommand("motd", "Remove a message from the MOTD List", "motd-remove", ChatAuthorizationLevel.Admin)]
        public static void Remove(User user, int MOTDID)
        {
            
        }

        [ChatSubCommand("motd", "List all messages in MOTD list", "motd-list", ChatAuthorizationLevel.Admin)]
        public static void List(User user)
        {
            
        }

        [ChatSubCommand("motd", "Reload MOTD Settings", "motd-reload", ChatAuthorizationLevel.Admin)]
        public static void Motdreload(User user)
        {
           
        }

        // DO NOT MODIFY THESE VALUES!
        private static Timer Timer;
        private static MOTDs motds = new MOTDs();
        private static int MessageStep = 0;
        private static bool loaded = false;
        private static string filename = "MOTD";
    }
}