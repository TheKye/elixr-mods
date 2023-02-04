using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
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
    /* Instructions:
     * You can:
     * Change the Class name to rename the giftbox.
     * Change the items inside the 'Contents' dictionary and/or their amounts. * You will need to find the correct 'Type Name' for the item you want, check the wiki or ask. *
     * Change the number of skill levels the pack adds (pay to win features yay! /s)
     * Change the custom on open message;
     * Change if the custom message should be in a popup (true) in just in chat (false)
     * 
     * NOTE:
     * It's perfectly ok to add additional boxes if you follow the format
     * Add a new class for each box with a 'Contents' dictionary as per the examples, ensure you implement the interface IGiftBox
     * Make sure each class is Serialized (its easiest just to copy one example completely and then edit it)
     * 
     * WARNING:
     * Making gifts that have contents that are too heavy for the recieving inventory will mean the gift can never be opened!
    */

    // Gift Box Recipes Go below

    // Starter Pack
    [Serialized]
    public class StarterPack : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(IronAxeItem)] = 1,
            [typeof(IronPickaxeItem)] = 1,
        };

        public int LevelUps => 2;
        public string CustomMessage => $"A welcome box for joining the server :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallAlpha1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 1,
            [typeof(MortarItem)] = 250,
            [typeof(IronBarItem)] = 50,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Alpha, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallAlpha2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 1,
            [typeof(MortarItem)] = 250,
            [typeof(CopperBarItem)] = 30,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Alpha, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallBravo1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 2,
            [typeof(IronBarItem)] = 50,
            [typeof(ClothItem)] = 50,
            [typeof(WindmillItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Bravo, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallBravo2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 2,
            [typeof(CopperBarItem)] = 30,
            [typeof(ClothItem)] = 50,
            [typeof(WindmillItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Bravo, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallCharlie1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 3,
            [typeof(IronBarItem)] = 30,
            [typeof(NailItem)] = 200,
            [typeof(WaterwheelItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Charlie, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallCharlie2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 3,
            [typeof(CopperBarItem)] = 60,
            [typeof(NailItem)] = 200,
            [typeof(WaterwheelItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Charlie, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallCharlie3 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 3,
            [typeof(LumberItem)] = 50,
            [typeof(NailItem)] = 200,
            [typeof(WaterwheelItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Charlie, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class MediumAlpha1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 5,
            [typeof(IronConcentrateItem)] = 100,
            [typeof(LargeLumberStockpileItem)] = 2,
            [typeof(MechanicalWaterPumpItem)] = 1,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Medium Donation Box Alpha, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class MediumAlpha2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 5,
            [typeof(CopperConcentrateItem)] = 50,
            [typeof(LargeLumberStockpileItem)] = 2,
            [typeof(MechanicalWaterPumpItem)] = 1,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Medium Donation Box Alpha, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class MediumBravo1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 8,
            [typeof(SteamTruckItem)] = 1,
            [typeof(ClothItem)] = 500,
            [typeof(FruitTartItem)] = 50,
            [typeof(SimmeredMeatItem)] = 50,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Medium Donation Box Bravo, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class MediumBravo2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 10,
            [typeof(GoldBarItem)] = 50,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Medium Donation Box Charlie, Say thanks to our donator, Whoever it may be :). Collect additional research papers from UltraFRS/Admin/Owner";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SpecialFoodPack : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(MacaroonsItem)] = 100,
            [typeof(FruitMuffinItem)] = 100,
            [typeof(SimmeredMeatItem)] = 100,
            [typeof(ToppedPorridgeItem)] = 100,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Special Food Box, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class GiveAll_Test : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(PropertyClaimItem)] = 1,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Special Food Box, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    // This is how the gift box works. Don't change this unless you are sure you know what you are doing.
    [Serialized]
    [Category("Hidden")]
    [LocDisplayName("A Gift Box")]
    public partial class CustomisableGiftBoxItem : Item, IChatCommandHandler
    {
        // Description displayed
        public override LocString DisplayDescription { get { return Localizer.DoStr($"Open to reveal a surprise!"); } }

        // Tooltip on hover
        [Tooltip(500, typeof(Controls))]
        public string ControlsTooltip => Text.Style(Text.Styles.Controls, Localizer.Do($"[Right-click to open]"));

        // Contents
        [Serialized] public IGiftBox Box { get; set; }

        // Opening the box and inventory checks.
        public override void OnUsed(Player player, ItemStack itemStack) { itemStack.TryModifyStack(player.User, -1, () => Open(player)); }

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
                    player.User.AddExperience(1 + (player.User.GetSpecialtyCost() - player.User.XP));
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
