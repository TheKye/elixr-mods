using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Math;
using Eco.Shared.Services;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Framework.Testing
{
    public class ObjectLineUp : IChatCommandHandler
    {
        [ChatCommand("Elixr Mods Testing Group", ChatAuthorizationLevel.Admin)]
        public static void EMTest() { }

        [ChatSubCommand("EMTest", "Retrieve all objects from the same namespace as an object spawn them in world.", "em-lineup", ChatAuthorizationLevel.Admin)]
        public static void NamespaceLineUp(User user, string itemlookup, bool _namespace = true)
        {
            // Find the item by the given string
            var item = (WorldObjectItem)Item.Get(itemlookup);
            
            // If nothing is found report it and break
            if (item == null )
            {
                user.Player.MsgLoc($"Couldn't find any item matching that value", MessageCategory.Error);
                return;
            }

            // Get the object from the item
            var obj = item.WorldObjectType;

            // Declare the list to be populated
            List<Type> list;

            if (_namespace)
            {
                // Get the namespace of the object & cast all objects in that namespace to a list
                var ns = obj.Namespace;
                list = typeof(WorldObject).CreatableTypes().Where(x => x.Namespace == ns).ToList();
            }
            else
            {
                // Get the assembly of the object & cast all objects in that assembly to a list
                var asm = obj.Assembly;
                list = typeof(WorldObject).CreatableTypes().Where(x => x.Assembly == asm).ToList();
            }

            // Make sure list isn't empty
            if (list.Count == 0)
            {
                user.Player.MsgLoc($"No items found in the {(_namespace ? "Namespace" : "Assembly")}", MessageCategory.Error);
                return;
            }

            // Line up the objects
            LineUp(user, list);
        }

        internal static void LineUp(User user, List<Type> list)
        {
            var center = (Vector3i)user.Position;
            Quaternion standard = user.FacingDir.ToQuat();
            var count = 0;

            foreach (Type obj in list)
            {
                var spawnPos = center + (user.FacingDir.ToVec() * 2 * (count + 1));
                WorldObjectManager.ForceAdd(obj, user, spawnPos, standard, false);
                count++;
            }
        }
    }
}
