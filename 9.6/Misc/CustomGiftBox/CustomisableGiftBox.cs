using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace ECO.EM.CustomRequests
{
    // This is how the gift box works. Don't change this unless you are sure you know what you are doing.
    [Serialized]
    [Category("Hidden")]
    [LocDisplayName("A Gift Box")]
        [ChatCommandHandler]
    public partial class CustomisableGiftBoxItem : Item
    {
        // Description displayed
        public override LocString DisplayDescription { get { return Localizer.DoStr($"Open to reveal a surprise!"); } }

        // Tooltip on hover
        [Tooltip(500, typeof(Controls))]
        public string ControlsTooltip => Text.Style(Text.Styles.Controls, Localizer.Do($"[Right-click to open]"));

        // Contents
        [Serialized] public IGiftBox Box { get; set; }

        // Opening the box and inventory checks.
        public override string OnUsed(Player player, ItemStack itemStack) { itemStack.TryModifyStack(player.User, -1, () => Open(player)); return ""; }

        protected bool Open(Player player)
        {
            bool voidUsed = false;
            using (var changes = InventoryChangeSet.New(player.User.Inventory, player.User))
            {
                // if no valid pack was found provide message
                if (Box == null)
                {
                    player.User.MsgLocStr($"No gift was found to open. Contact Admin");
                    return false;
                }

                List<ItemStack> stacks = new List<ItemStack>();

                // attempt to add inventory
                foreach (var kvp in Box.Contents)
                {
                    if (!player.User.Inventory.TryAddItems(kvp.Key, kvp.Value, player.User))
                        stacks.Add(new ItemStack(kvp.Key, kvp.Value));                           
                }

                if (stacks.Count > 0)
                {
                    GameData.Obj.VoidStorageManager.FillNewVoidStorage(
                        stacks,
                        Localizer.DoStr("Rewards for Donating"),
                        player.User,
                        Vector3i.NegOne);
                    if (!voidUsed) voidUsed = true;
                }

                for (int i = 0; i < Box.LevelUps; i++)
                {
                    player.User.UserXP.AddExperience(1 + (player.User.UserXP.NextStarCost - player.User.UserXP.XP));
                }

                // display custom message
                if (Box.UsePopUp)
                    player.OpenCustomPanel("Thank You", $"{Box.CustomMessage}", "GratitudePanel");
                else
                    player.User.MsgLocStr($"{Box.CustomMessage}");

            }

            // Msg to player regarding void inventory
            if (voidUsed)
                player.User.MsgLoc($"Could not fit all pack items in inventory, placed into void storage (access with icon next to backpack button).");

            return true;
        }

        // Special built container for All Boxes created above, is built on server load to ensure it is up to date
        private static List<IGiftBox> allBoxes = typeof(IGiftBox).InstancesOfCreatableTypesParallel<IGiftBox>(typeof(IGiftBox).Assembly).ToList();
        private static List<IGiftBox> AllBoxes { get => allBoxes; }

        // Commands
        [ChatCommand("Elixr Mods Simple Rewards", ChatAuthorizationLevel.Admin)]
        public static void Rewards() { }

        [ChatSubCommand("Rewards", "Rewards a specific player with a giftbox you choose", "reward", ChatAuthorizationLevel.Admin)]
        public static void GiveReward(User user, string player, string giftBox)
        {
            IGiftBox gift = null;
            User target = null;
            bool givetoall = false;
            giftBox = giftBox.Trim();

            if (player == "GIVEALL")
                givetoall = true;
            else
            {
                // ensure player exists
                foreach (var name in UserManager.Users)
                {
                    if (name.Name.ToLower() == player.ToLower()) { target = name; break; }
                }
            }         

            if (target == null && !givetoall) { user.MsgLocStr("Unable to find the target player requested"); return; }

            // ensure box exists
            foreach (var box in AllBoxes)
            {
                if (box.GetType().Name.ToLower() == giftBox.ToLower()) { gift = box; break; }
            }

            if (gift == null) { user.MsgLocStr("No Box found with that name"); return; }

            if (givetoall)
            {
                foreach( var u in UserManager.Users)
                {
                    var boxCopy = Item.Create(typeof(CustomisableGiftBoxItem)) as CustomisableGiftBoxItem;
                    boxCopy.Box = gift;

                    if (!u.Inventory.TryAddItem(boxCopy, u))
                    {
                        GameData.Obj.VoidStorageManager.FillNewVoidStorage(
                            new ItemStack(boxCopy, 1).SingleItemAsEnumerable(),
                            Localizer.DoStr("Rewards for Donating"),
                            u,
                            Vector3i.NegOne);
                        u.MsgLocStr(string.Format("You recieved a gift from {0}, check your void inventory as your inventroy was too full", user.Name));
                    }
                    else
                        u.MsgLocStr(string.Format("You recieved a gift from {0}", user.Name));
                }
                user.MsgLocStr(string.Format("Everyone has been sent their gift"));
                return;
            }

            var newbox = Item.Create(typeof(CustomisableGiftBoxItem)) as CustomisableGiftBoxItem;
            newbox.Box = gift;

            var result = target.Inventory.TryAddItem(newbox);

            if (result.Success)
            {
                user.MsgLocStr(string.Format("{0} has been sent their gift", target.Name));
                target.MsgLocStr(string.Format("You recieved a gift from {0}", user.Name));
            }
            else
            {
                user.MsgLocStr(string.Format("{0} does not have enough room in their inventory", target.Name));
                target.MsgLocStr(string.Format("{0} attempted to give you a gift box, but your inventroy is too full", user.Name));
            }
        }
    }

    [Serialized]
    public interface IGiftBox
    {
        public Dictionary<Type, int> Contents { get; }
        public int LevelUps { get; }
        public string CustomMessage { get; }
        public bool UsePopUp { get; }
    }
}
