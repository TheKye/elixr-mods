using System.Linq;
using Eco.Core.Utils;
using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Gameplay.Economy;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.UI;
using Eco.Gameplay.Components;
using System;

namespace Eco.EM.Disposals.Salvage
{
    [Serialized, Priority(-2)]
    [RequireComponent(typeof(CreditComponent))]
    [RequireComponent(typeof(StatusComponent))]
    [Ecopedia(display: InPageTooltip.CachedTooltip)]
    public class DismantleComponent : WorldObjectComponent, IInventoryWorldObjectComponent
    {
        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;
        public Inventory Inventory => this.ToDismantle;

        [Serialized, SyncToView] public LimitedInventory ToDismantle { get; set; } = new LimitedInventory(1);
        [SyncToView] TagStack MaterialsReturned(Player player) => this.MaterialsReturned(player);

        ItemStack Stack => this.ToDismantle.Stacks.FirstOrDefault();
        RepairRequiresSkillAttribute[] SkillReqs => (this.Stack.Item as DurabilityItem)?.SkillReqs;

        public DismantleComponent()
        {
            Skill.OnSkillsChanged.Add(this.UpdateSkills);
        }

        ~DismantleComponent()
        {
            Skill.OnSkillsChanged.Remove(this.UpdateSkills);
        }

        public override void Initialize()
        {
            this.ToDismantle.OnChanged.Add(this.RepairSlotChanged);
            this.RepairSlotChanged(null);
        }

        public override void Destroy()
        {
            this.ToDismantle.Destroy();
        }

        private void UpdateSkills()
        {
            this.Changed(nameof(this.MaterialsReturned));
        }

        private void RepairSlotChanged(User user = null)
        {
            this.UpdateSkills();
            this.Parent.SetDirty();
        }

        internal Result TryPickup(Player player, InventoryChangeSet invChanges, Inventory targetInventory, bool force)
        {
            if (!this.Stack.Empty())
                invChanges.MoveItems(this.Stack.Item.GetType(), this.Stack.Quantity, this.ToDismantle, targetInventory);
            return Result.Succeeded;
        }
    }

}
