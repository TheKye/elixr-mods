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
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Systems.NewTooltip.TooltipLibraryFiles;
using Eco.Mods.TechTree;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Civics;
using Eco.Gameplay.Settlements;
using Eco.Gameplay.Minimap;
using Eco.Simulation.WorldLayers;
using Eco.Gameplay.Items.InventoryRelated;
using Eco.Gameplay.Systems;
using Eco.Shared.Math;
using Eco.Gameplay.Skills;

namespace Eco.EM.Admin
{
    [ChatCommandHandler]
    public class Admin
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
            player.User.Carrying.ModifyFractional(Item.Get(result[0]), 1);

            //Put the rest in the toolbar.
            int index = 1;
            foreach (var stack in player.User.Inventory.Toolbar.Stacks.Where(x => x.Item is not ToolItem && x.Item is not Skill))
            {
                if (index >= result.Count) break;
                var entry = result[index++];
                stack.ModifyFractional(Activator.CreateInstance(entry) as Item, 1);
            }
            AdminCommands.CarryAll(player.User, true);
        }
        /*
        [ChatCommand("Turn on Meteor", "meteor-on", ChatAuthorizationLevel.Admin)]
        public static void MeteorOn(User user)
        {
            DisasterPlugin.Settings. = true;
            ChatBaseExtended.CBInfo("Meteor has been enabled", user);
        }
        */
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
            DisasterPlugin.TheMeteor.ShootMeteor();
            ChatBaseExtended.CBInfo("Meteor has been disabled", user);
        }

        [ChatCommand("Unclaim all of a users deeds, optionally return the claim flags or not ( default not)", "unclaim-all", ChatAuthorizationLevel.Admin)]
        public static void UnclaimAllProperty(User user, bool returnClaims, string targetUser)
        {
            targetUser = targetUser.Trim();
            User tgtUser = PlayerUtils.GetUser(targetUser);
            LocString returnClaimText = returnClaims ? Localizer.DoStr("You Chose To Refund the Land Claim Papers") : Localizer.DoStr("You chose not to return Land Claims (Default)");
            int count = 0;

            if (tgtUser != null)
            {
                IEnumerable<Deed> prop = PropertyManager.AllOwnedDeeds(tgtUser);
                if (PropertyManager.PropertyForAlias(tgtUser).Any())
                {
                    foreach (var p in prop)
                    {
                        if (p == null) continue;
                        int numPlots = p.PlotCount;
                        p.Destroy();
                        p.DeleteDeed(tgtUser.Player);
                        count += numPlots;
                    }
                    if (!returnClaims)
                    {
                        tgtUser.Inventory.ToolbarBackpack.RemoveItems<ClaimPaperItem>(count);
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

        [ChatCommand("Remove a bugged draft town that has no foundation", ChatAuthorizationLevel.Admin)]
        public static void RemovedDraftTown(User user, Settlement settlement)
        {
            if (settlement != null && !settlement.HasValidConstitution)
            {
                settlement.Destroyed();
                user.Player.MsgLocStr($"{settlement.Name} has been removed from the world.");
                WorldLayerManager.Obj.RemoveLayer(settlement.Name);
                SettlementManager.Obj.ForceUpdateAllSettlements();
            }
            else
                user.Player.ErrorLocStr($"{settlement.Name} has a valid consitution and can not be removed this way");
        }

        [ChatCommand("Destroys a made town", ChatAuthorizationLevel.Admin)]
        public static void RemoveTown(User user, Settlement settlement)
        {
            if (settlement != null)
            {
                settlement.Destroyed();
                user.Player.MsgLocStr($"{settlement.Name} has been removed from the world.");
                SettlementManager.Obj.ForceUpdateAllSettlements();
            }
        }

        /*public static void BanErase(User user, string targetUser, string reason = "")
        {
            User tgtUser = Defaults.GetUserByName(targetUser);
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
                    //ChatDefaults.Send(new ChatDefaults.Message(Localizer.DoStr($"{tgtUser}'s Property has been unclaimed, Removed {count} Claim Plots, And Banned, Cleaned up a total {cleanup} Items"), user));
                    UserManagerCommands.Ban(tgtUser, targetUser, reason);
                    return;
                }
                ChatDefaults.Send(new ChatDefaults.Message(Text.Error($"No Property to unclaim."), user));
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
                    if (storage.Inventory.AllInventories.Any(stack => stack.Stacks.Any(x => x.Item is DevtoolItem)))
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
                foreach (var stack in usr.Inventory.AllInventories.AllStacks())
                {
                    int qty = usr.Inventory.TotalNumberOfItems(typeof(DevtoolItem));
                    if (all && qty > 0)
                    {
                        usr.Inventory.RemoveItems(typeof(DevtoolItem), qty);
                        count += qty;
                    }
                    else if (!all && !usr.IsAdmin && qty > 0)
                    {
                        usr.Inventory.RemoveItems(typeof(DevtoolItem), qty);
                        count += qty;
                    }
                }
            }
            ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("All Found Dev tools have been reclaimed. Reclaimed {0} Dev Tools."), count), user);
        }

        [ChatCommand("Pays All Players x Amount of a Chosen Currency", "fund", ChatAuthorizationLevel.Admin)]
        public static void FundPlayersCurrency(User user, Currency curreny, int amount = 100)
        {
            if (curreny == null)
            {
                ChatBaseExtended.CBError("Currency Not Found", user);
                return;
            }

            foreach (var usr in UserManager.Users)
            {
                usr.BankAccount.AddCurrency(curreny, amount);
                usr.BankAccount.BalanceChanged.Invoke(curreny);
            }
            ChatBaseExtended.CBInfoBox(string.Format(Localizer.DoStr("All Players have been paid {0} {1}"), amount, curreny), user);
        }

        [ChatCommand("Grant All players a specific item and the amount of that item", "grant-allplayers", ChatAuthorizationLevel.Admin)]
        public static void GiveAllPlayers(IChatClient user, string item, int amount = 1, bool includeOffline = false)
        {
            var itemToGive = Item.Get(item);


            if (itemToGive == null)
            {
                user.ErrorLocStr($"{item} Is not a valid item, did you type the name correctly?");
                return;
            }
            
            //fallback incase of requiring void storage access
            List<ItemStack> stacks = null;
            stacks.Add(new ItemStack(itemToGive, amount));
            switch (includeOffline)
            {
                case true:
                    foreach (var u in UserManager.Users)
                    {
                        var succeed = u.Inventory.TryAddItemsNonUnique(itemToGive.GetType(), amount);
                        if (!succeed)
                            GameData.Obj.VoidStorageManager.FillNewVoidStorage(stacks, Localizer.DoStr("Granted Items"), u, Vector3i.NegOne, "");
                        u.Mail(Localizer.DoStr($"The Admin of this server has granted you {amount} {(amount > 1 ? (string.IsNullOrWhiteSpace(itemToGive.DisplayNamePlural) ? itemToGive.DisplayName : itemToGive.DisplayNamePlural ): itemToGive.DisplayName)}, If the item is not in your inventory, check your void storage"), Shared.Services.NotificationCategory.Notifications);
                    }
                    user.MsgLocStr($"All Players have been given {itemToGive.DisplayName}");
                    break;
                case false:
                    foreach (var u in UserManager.OnlineUsers)
                    {
                        var succeed = u.Inventory.TryAddItemsNonUnique(itemToGive.GetType(), amount);
                        if (!succeed)
                            GameData.Obj.VoidStorageManager.FillNewVoidStorage(stacks, Localizer.DoStr("Granted Items"), u, Vector3i.NegOne, "");
                        u.Mail(Localizer.DoStr($"The Admin of this server has granted you {amount} {(amount > 1 ? (string.IsNullOrWhiteSpace(itemToGive.DisplayNamePlural) ? itemToGive.DisplayName : itemToGive.DisplayNamePlural ): itemToGive.DisplayName)}, If the item is not in your inventory, check your void storage"), Shared.Services.NotificationCategory.Notifications);
                    }
                    user.MsgLocStr($"All Online Players have been given {itemToGive.DisplayName}");
                    break;
            }
        }

        public static string ListToString(List<User> Users)
        {
            string[] userlines = new string[Users.Count];

            for (int i = 0; i <= Users.Count; i++)
            {
                userlines[i] += $"{Users[i].Name} - {Users[i].Reputation}";
            }

            return string.Join("\n", userlines);
        }

    }
}
