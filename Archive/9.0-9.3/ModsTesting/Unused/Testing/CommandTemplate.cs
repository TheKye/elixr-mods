using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModsTesting.Unused.Testing
{
    public class CommandTemplate : IChatCommandHandler
    {
        /// <summary>
        /// Chat Command Parent
        /// string (Help Text), ChatAuthorizationLevel
        /// </summary>
        [ChatCommand("Elixr Mods Testing Group", ChatAuthorizationLevel.User)]
        public static void RandomItem() { }

        /// <summary>
        /// Chat Sub Command
        /// string (Parent Command), string (Help Text), string (Shortcut), ChatAuthorizationLevel
        /// </summary>
        /// <param name="user"></param>
        [ChatSubCommand("RandomItem", "Random Item.", "randi", ChatAuthorizationLevel.User)]
        public static void GiveRandomItem(User user)
        {
            // trys to add a random item to the users inventory
            user.Inventory.TryAddItem(Item.RandomItem);
        }
    }
}
