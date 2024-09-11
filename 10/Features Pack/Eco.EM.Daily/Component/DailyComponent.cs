using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Utils;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Daily.Component
{
    [Serialized, AutogenClass, LocDisplayName("Reward pack creator"), NoIcon]
    public partial class RewardPackCreatorComponent : WorldObjectComponent, IHasClientControlledContainers
    {
        public RewardPackCreatorComponent()
        {
            this.PackItems ??= new ControllerList<RewardPackViewItem>(this, nameof(PackItems));
        }

        float tier { get; set; }
        [Eco(AccessType.Admin), ClientInterfaceProperty, GuestHidden, LocDescription("Whole number value. Lower tiers are more likely to be selected")]
        public float Tier
        {
            get => tier;
            set
            {
                if (value == tier) return;
                tier = value;
                this.Changed(nameof(Tier));
            }
        }

        float selectionValue { get; set; }
        [Eco(AccessType.Admin), ClientInterfaceProperty, GuestHidden, LocDescription("Whole number value. Higher values are more likely to be selected inside a Tier")]
        public float SelectionValue
        {
            get => selectionValue;
            set
            {
                if (value == selectionValue) return;
                selectionValue = value;
                this.Changed(nameof(SelectionValue));
            }
        }

        [Eco(AccessType.Admin), ClientInterfaceProperty, GuestHidden] public string PackName { get; set; }


        ControllerList<RewardPackViewItem> packItems { get; set; }
        [Eco(AccessType.Admin), ClientInterfaceProperty, GuestHidden]
        public ControllerList<RewardPackViewItem> PackItems
        {
            get => packItems;
            set
            {
                if (value == packItems) return;
                packItems = value;
                this.Changed(nameof(PackItems));
            }
        }

        [RPC, Autogen, GuestHidden]
        public void ClearList(Player player) { PackItems.Clear(); }

        [RPC, Autogen, GuestHidden]
        public void CreatePack(Player player)
        {
            if (PackName == null || PackName == "")
            {
                player.InfoBox(Localizer.DoStr("Please ensure pack has a valid name"));
                return;
            }

            if (DailyManager.PackData.Packs.ContainsKey(PackName))
            {
                player.InfoBox(Localizer.DoStr("Pack name exists, try another"));
                return;
            }


            // Build the pack from the info         
            List<RewardPackItem> itemsToAdd = new();
            if (PackItems.Count == 0)
            {
                player.ErrorLocStr("You need to add items to the pack before you can create it");
                return;
            }

            for (int i1 = 0; i1 < PackItems.Count; i1++)
            {

                RewardPackViewItem vi = PackItems[i1];
                if (vi.PackItem is null)
                {
                    player.ErrorLocStr("You need to complete the setup before you can make the pack.");
                    return;
                }
                if (vi.PackItem is Skill)
                {
                    player.InfoBox(Localizer.DoStr(string.Format("You can not add a skill as a pack reward. Please remove {0}.", vi.PackItem.DisplayName)));
                    return;
                }

                RewardPackItem i = new();
                i.Amount = (int)vi.Amount;
                i.PackItemType = vi.PackItem.Type.Name;
                itemsToAdd.Add(i);
            }

            RewardPack toAdd = new((int)Tier, (int)SelectionValue, itemsToAdd);
            DailyManager.PackData.Packs.Add(PackName, toAdd);
            DailyManager.SavePacks();

            player.InfoBox(Localizer.DoStr($"{PackName} Has been Created."));

            // Reset Data 
            PackName = "";
            Tier = 0;
            SelectionValue = 0;
            PackItems.Clear();
        }

        [RPC, Autogen, GuestHidden]
        public void RemovePack(Player player)
        {
            if (PackName == null || PackName == "")
            {
                player.InfoBox(Localizer.DoStr("Please ensure pack has a valid name"));
                return;
            }

            if (!DailyManager.PackData.Packs.ContainsKey(PackName))
            {
                player.InfoBox(Localizer.DoStr("Pack name does not exist, check name"));
                return;
            }

            player.InfoBox(Localizer.DoStr(string.Format("{0} has been removed", PackName)));
            DailyManager.PackData.Packs.Remove(PackName);
            DailyManager.SavePacks();

            // Reset Data 
            PackName = "";
            Tier = 0;
            SelectionValue = 0;
            PackItems.Clear();
        }

        [RPC, Autogen, GuestHidden]
        public void ViewPacksByTier(Player player)
        {
            var OrderderedPacks = DailyManager.PackData.Packs.OrderBy(kvp => kvp.Value.Tier).ThenByDescending(kvp => kvp.Value.SelectionValue);

            StringBuilder sb = new();
            foreach (var pack in OrderderedPacks)
            {
                sb.AppendLine($"{pack.Key}");
            }

            player.OkBox(Localizer.DoStr(sb.ToString()));
        }
    }
}
