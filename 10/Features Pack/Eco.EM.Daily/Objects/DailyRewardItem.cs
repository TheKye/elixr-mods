using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.ComponentModel;

namespace Eco.EM.Daily
{
    [Serialized]
    [Category("Hidden")]
    [LocDisplayName("A Reward Pack")]
    [MaxStackSize(100)]
    public partial class DailyRewardItem : Item
    {     

        public string ControlsTooltip => Shared.Utils.Text.Style(Shared.Utils.Text.Styles.Controls, Localizer.Do($"[Right-click to open]"));

        protected bool Open(Player player, out string message)
        {
            bool success = false;
            using (var changes = InventoryChangeSet.New(player.User.Inventory, player.User))
            {
                // retrieve a random valid pack for this user
                RewardPack pack = DailyManager.PackData.GetRewardPack(player.User);

                // if no valid pack was found provide message
                if (pack == null)
                {
                    player.User.MsgLocStr($"No pack was found to open. Contact Admin");
                    message = string.Empty;
                    return false;
                }

                // attempt to add inventory
                foreach (var item in pack.Contents)
                {
                    changes.AddItemsNonUnique(Item.Get(item.PackItemType).Type, (int)item.Amount);
                }

                if (changes.CanApplyNonDisposing())
                {
                    success = true;
                    changes.Apply();
                }
            }

            // Msg to player regarding no space
            if (!success)
            {
                message = "Unable to open the gift box as there is not enough room in your inventory.";
                player.User.MsgLocStr($"Unable to open the gift box as there is not enough room in your inventory.");
                return false;
            }
            message = "You Opened Your Gift Box!";
            return success;        
        }

        public override string OnUsed(Player player, ItemStack itemStack)
        {
            string message = "";
            itemStack.TryModifyStack(player.User, -1, () => Open(player, out message));
            return message;
            
        }
    }
}