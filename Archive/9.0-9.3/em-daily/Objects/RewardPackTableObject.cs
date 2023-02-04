using System;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Core.Controller;
using Eco.Shared.Networking;
using Eco.Gameplay.Players;
using Eco.Shared.Math;
using Eco.Core.Utils;
using Eco.Gameplay.Utils;
using System.Collections.Generic;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Interactions;
using System.Text;
using System.Linq;
using Eco.Gameplay.Civics.GameValues;

namespace Eco.EM.Daily
{
    [Serialized, Weight(1000), MaxStackSize(1), LocDisplayName("Reward pack table for EM daily plugin")]
    [ItemGroup("Hidden")]
    public partial class RewardPackTableItem : WorldObjectItem<RewardPackTableObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("ADMIN ONLY: Use this to assist in creating daily reward packs."); } }
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(RewardPackCreatorComponent))]
    public partial class RewardPackTableObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Reward pack table");

        public Type RepresentedItemType => typeof(RewardPackTableItem);

        static RewardPackTableObject() 
        { 
            AddOccupancyList(typeof(RewardPackTableObject), new BlockOccupancy(Vector3i.Zero, typeof(SolidWorldObjectBlock))); 
        }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (!context.Player.User.IsAdmin)
            {
                context.Player.ErrorLocStr("Only an admin may remove this object");
                return InteractResult.Fail;
            }
            return base.OnActLeft(context);
        }

        public override InteractResult OnActInteract(InteractionContext context)
        {
            if (!context.Player.User.IsAdmin)
            {
                context.Player.ErrorLocStr("Only an admin may use this object.");
                return InteractResult.Fail;
            }
            return base.OnActInteract(context);
        }

        public override void Destroy() { base.Destroy(); }
    }

    [Serialized, AutogenClass, LocDisplayName("Reward pack creator")]
    public partial class RewardPackCreatorComponent : WorldObjectComponent, IHasClientControlledContainers
    {
        [RPC, Autogen, GuestHidden]
        public void ClearList(Player player) { packItems.Clear(); }

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
            List<RewardPackItem> itemsToAdd = new List<RewardPackItem>();

            for (int i1 = 0; i1 < packItems.Count; i1++)
            {
                RewardPackViewItem vi = packItems[i1];
                if (vi.PackItem is Skill)
                {
                    player.InfoBox(Localizer.DoStr($"You can not add a skill as a pack reward. Please remove {vi.PackItem.DisplayName}."));
                    return;
                }
                
                RewardPackItem i = new RewardPackItem();
                i.Amount = (int)vi.Amount;
                i.PackItemType = vi.PackItem.Type.Name;
                itemsToAdd.Add(i);
            }

            RewardPack toAdd = new RewardPack((int)Tier, (int)SelectionValue, itemsToAdd);
            DailyManager.PackData.Packs.Add(PackName, toAdd);
            DailyManager.SavePacks();

            // Reset Data 
            PackName = "";
            packItems.Clear();
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

            player.InfoBox(Localizer.DoStr($"{PackName} has been removed"));
            DailyManager.PackData.Packs.Remove(PackName);
            DailyManager.SavePacks();

            // Reset Data 
            PackName = "";
            packItems.Clear();
        }

        [RPC, Autogen, GuestHidden]
        public void ViewPacksByTier(Player player)
        {
            var OrderderedPacks = DailyManager.PackData.Packs.OrderBy( kvp => kvp.Value.Tier).ThenByDescending(kvp => kvp.Value.SelectionValue);

            StringBuilder sb = new StringBuilder();
            foreach (var pack in OrderderedPacks)
            {
                sb.AppendLine($"{pack.Key}");
            }

            player.OkBox(Localizer.DoStr(sb.ToString()));
        }

        [Eco, GuestHidden, LocDescription("Whole number value. Lower tiers are more likely to be selected")] public float Tier { get; set; }
        [Eco, GuestHidden, LocDescription("Whole number value. Higher values are more likely to be selected inside a Tier")] public float SelectionValue { get; set; }
        [Eco, GuestHidden] public string PackName { get; set; }
        [Eco, GuestHidden] public ControllerList<RewardPackViewItem> packItems { get; set; }

        public RewardPackCreatorComponent()
        {
            this.packItems = new ControllerList<RewardPackViewItem>(this, nameof(this.packItems));
        }     
    }
}