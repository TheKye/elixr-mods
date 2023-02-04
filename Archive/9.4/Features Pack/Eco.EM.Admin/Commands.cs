using System;
using System.Collections.Generic;
using System.Linq;
using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Disasters;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Components;
using Eco.Gameplay.Property;
using Eco.Shared.Utils;
using Eco.Gameplay.UI;

namespace Eco.EM.Admin
{
    public class Admin : IChatCommandHandler
    {
        [ChatCommand("THIS THING IS AWESOME!", "gsas", ChatAuthorizationLevel.Admin)]
        public static void GiveSearchAndSelect(User user)
        {
            user.Player.PopupTypePicker(Localizer.DoStr("Pick An Item! ( Don't Pick a skill!!)"), typeof(Item), material => SetMaterial(material, user.Player));
            
        }

        private static void SetMaterial(List<Type> result, Player player)
        {
            if (result.Count == 0) return;

            //Put the first in the carry slot.
            player.User.Carrying.Modify(Item.Get(result[0]), 1);

            //Put the rest in the toolbar.
            int index = 1;
            foreach (var stack in player.User.Inventory.Toolbar.Stacks.Where(x => !(x.Item is ToolItem)))
            {
                if (index >= result.Count) break;
                var entry = result[index++];
                stack.Modify(Activator.CreateInstance(entry) as Item, 1);
            }
            AdminCommands.CarryAll(player.User, true);
        }

        [ChatCommand("Turn on Meteor", "meteor-on", ChatAuthorizationLevel.Admin)]
        public static void MeteorOn(User user)
        {
            DisasterPlugin.Settings.CreateMeteor = true;
            ChatBaseExtended.CBInfo("Meteor has been enabled", user);
        }

        [ChatCommand("Send an announcement to all the users in the server, it appears in their notifications bar so they will get it", "send-global", ChatAuthorizationLevel.Admin)]
        public static void SendAnnouncement(User user, string message)
        {
            message = $"{message}";
            ChatBaseExtended.CBAnnouncement(message, sendToAll: true);
        }

        [ChatCommand("Send a popup to all online users on the server with an ok button, means they have to read it", "send-popup", ChatAuthorizationLevel.Admin)]
        public static void SendAcceptAnnouncement(User user, string message)
        {
            message = $"{message}";
            ChatBaseExtended.CBOkBox(message);
        }

        [ChatCommand("Send an announcement to all the users in the server, it appears as an info panel so they will get it", "send-info", ChatAuthorizationLevel.Admin)]
        public static void SendInfoAnnouncement(User user, string title, string message)
        {
            message = $"{message}";
            ChatBaseExtended.CBAnnouncement(title, message, "Announcement");
        }

        [ChatCommand("Turn off Meteor", "meteor-off", ChatAuthorizationLevel.Admin)]
        public static void MeteorOff(User user)
        {
            DisasterPlugin.Settings.CreateMeteor = false;
            DisasterPlugin.TheMeteor.BlowUp();
            ChatBaseExtended.CBInfo("Meteor has been disabled", user);
        }

        [ChatCommand("Unclaim all of a users deeds, optionally return the claim flags or not ( default not)", "unclaim-all", ChatAuthorizationLevel.Admin)]
        public static void UnclaimAllProperty(User user, bool returnClaims, string targetUser)
        {
            targetUser = targetUser.Trim();
            User tgtUser = Base.GetUser(targetUser);
            LocString returnClaimText = returnClaims ? Localizer.DoStr("You Chose To Refund the Land Claim Papers") : Localizer.DoStr("You chose not to return Land Claims (Default)");
            int count = 0;

            if (tgtUser != null)
            {
                var prop = PropertyManager.AllOwnedDeeds(tgtUser);
                if (PropertyManager.PropertyForAlias(tgtUser).Any())
                {
                    foreach (var p in prop)
                    {   int numPlots = p.OwnedObjects.OfType<PropertyPlotHandle>().Count();
                        p.DeleteDeed(tgtUser.Player);
                        count += numPlots;
                    }
                    if (!returnClaims)
                    {
                        tgtUser.Inventory.ToolbarBackpack.RemoveItems<PropertyClaimItem>(count);
                    }
                    ChatBaseExtended.CBInfoBox(String.Format(Localizer.DoStr("{0}'s Property has been unclaimed, Removed {1} Claim Plots, And {2}"), tgtUser, count, returnClaimText), user);
                    return;
                }
                ChatBaseExtended.CBError($"No Property to unclaim.", user);
                return;
            }
            ChatBaseExtended.CBError(string.Format(Localizer.DoStr("Could not find anyone with the username {0}."), targetUser), user);
            return;
        }

        /*public static void BanErase(User user, string targetUser, string reason = "")
        {
            User tgtUser = Base.GetUserByName(targetUser);
            int count = 0;
            int cleanup = 0;
            if (tgtUser != null)
            {
                var prop = PropertyManager.AllOwnedDeeds(tgtUser);
                if (tgtUser.GetAllProperty().Count() >= 1)
                {
                    foreach (var p in prop)
                    {
                        foreach (var i in p.OwnedObjects.OfType<WorldObject>() )
                        {
                            cleanup++;
                            if (i.HasComponent<PublicStorageComponent>())
                            {
                                var storage = i.GetComponent<PublicStorageComponent>();
                                foreach (var item in storage.Inventories.AllStacks())
                                {
                                    cleanup+= item.Quantity;
                                }
                            }
                            i.Destroy();
                            Log.WriteLine(Localizer.DoStr($"{cleanup}"));
                        }
                        int numPlots = p.OwnedObjects.OfType<PropertyPlotHandle>().Count();
                        p.DeleteDeed(tgtUser.Player);
                        count += numPlots;
                    }
                    tgtUser.Inventory.ToolbarBackpack.Clear();
                    Log.WriteLine(Localizer.DoStr($"{tgtUser}'s Property has been unclaimed, Removed {count} Claim Plots, And Banned, Cleaned up a total {cleanup} Items"));
                    //ChatBase.Send(new ChatBase.Message(Localizer.DoStr($"{tgtUser}'s Property has been unclaimed, Removed {count} Claim Plots, And Banned, Cleaned up a total {cleanup} Items"), user));
                    UserManagerCommands.Ban(tgtUser, targetUser, reason);
                    return;
                }
                ChatBase.Send(new ChatBase.Message(Text.Error($"No Property to unclaim."), user));
            }
        }*/

        [ChatCommand("Reclaims All Dev Tools in the server, Optional true/false for removing the ones admins have as well.", "dev-reclaim", ChatAuthorizationLevel.Admin)]
        public static void ReclaimDevTool(User user, bool all = false)
        {
            int count = 0;
            WorldObjectManager.ForEach(x =>
            {
                if (x.HasComponent<PublicStorageComponent>())
                {
                    var storage = x.GetComponent<PublicStorageComponent>();
                    if (storage.Inventory.Stacks.Any(stack => stack.Item is DevtoolItem))
                    {
                        foreach (var dt in storage.Inventories)
                        {
                            int qty = dt.TotalNumberOfItems(typeof(DevtoolItem));
                            dt.TryRemoveItems(typeof(DevtoolItem), qty);
                            count += qty;
                        }
                    }
                }
            });
            foreach (var usr in UserManager.Users)
            {
                if (usr.Inventory.ToolbarBackpack.Stacks.Any(stack => stack.Item is DevtoolItem))
                {
                    int qty = usr.Inventory.TotalNumberOfItems(typeof(DevtoolItem));
                    if (all)
                    {
                        usr.Inventory.RemoveItems(typeof(DevtoolItem), qty);
                        count += qty;
                    }
                    else if (!all && !usr.IsAdmin)
                    {
                        usr.Inventory.RemoveItems(typeof(DevtoolItem), qty);
                        count += qty;
                    }
                }
            }
            ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("All Found Dev tools have been reclaimed. Reclaimed {0} Dev Tools."), count), user);
        }

        public static string ListToString(List<User> Users)
        {
            string[] userlines = new string[Users.Count];

            for (int i = 0; i <= Users.Count; i++)
            {
                userlines[i] += $"{Users[i].Name} - {Users[i].Reputation} - {Users[i].Player.SkillTitle}";
            }

            return string.Join("\n", userlines);
        }


    }
}
