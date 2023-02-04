using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Tooltip;
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
        public override LocString DisplayDescription => Localizer.DoStr("Open to reveal a surprise!"); 

        [Tooltip(500, typeof(Controls))]
        public string ControlsTooltip => Shared.Utils.Text.Style(Shared.Utils.Text.Styles.Controls, Localizer.Do($"[Right-click to open]"));

        protected bool Open(Player player)
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
                    return false;
                }

                // attempt to add inventory
                foreach (var item in pack.Contents)
                {
                    changes.AddItems(Item.Get(item.PackItemType).Type, (int)item.Amount);
                }

                if (changes.CanApplyNonDisposing())
                {
                    success = true;
                    changes.Apply();
                }
            }

            // Msg to player regarding no space
            if (!success)
                player.User.MsgLocStr($"Unable to open the gift box as there is not enough room in your inventory.");

            return success;        
        }

        public override void OnUsed(Player player, ItemStack itemStack)
        {
            itemStack.TryModifyStack(player.User, -1, () => Open(player));
        }
    }
}