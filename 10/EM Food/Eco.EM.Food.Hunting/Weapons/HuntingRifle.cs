using Eco.Core.Items;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Food.Hunting.Weapons
{
    [Serialized]
    [LocDisplayName("Hunting Rifle")]
    [Tier(3)]
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 0)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    public partial class HuntingRifleItem : BowItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(HuntingRifleItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(10, typeof(HuntingSkill), typeof(HuntingRifleItem), new HuntingRifleItem().UILink()));
        private static IDynamicValue damage = CreateDamageValue(10f, typeof(HuntingSkill), typeof(HuntingRifleItem), new HuntingRifleItem().UILink());
        private static IDynamicValue exp = new ConstantValue(1);
        private static IDynamicValue tier = new ConstantValue(3);
        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(8, AdvancedSmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);

        // Tool overrides

        public override LocString DisplayDescription => Localizer.DoStr("A Hunting Rife that shoots faster than any bow.");
        public override IDynamicValue CaloriesBurn => caloriesBurn;
        public override IDynamicValue Damage => damage;
        public override Type ExperienceSkill => typeof(HuntingSkill);
        public override IDynamicValue ExperienceRate => exp;
        public override IDynamicValue Tier => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate => DurabilityMax / 1000f;
        public override Item RepairItem => Item.Get<SteelBarItem>();
        public override int FullRepairAmount => 8;

        [RPC]
        public new int FireArrow(Player player, Vector3 position, Vector3 velocity)
        {
            // If the player has an arrow to fire then use the bow, but do not gain any experience from using the tool. Experience is ONLY gained if the Arrow hits an animal.
            if (player.User.Inventory.TryRemoveItem<BulletItem>(player.User) && AtomicActions.UseToolNow(this.CreateMultiblockContext(player, false)))
            {
                var arrow = new BulletEntity
                {
                    Damage = this.Damage.GetCurrentValue(player.User),                  // Set the Damage so that Experience Points are gained if the arrow hits an animal.
                    Controller = player,
                    Position = position,
                    Velocity = velocity,
                    BowItem = this
                };
                arrow.SetActiveAndCreate();
                return arrow.ID;
            }
            return -1;
        }
    }

    public partial class HuntingRifleItemView : GunItemView
    {
        protected HuntingRifleItemView(ViewData data) : base(data) { }
        public new class ViewData : GunItemView.ViewData
        {
            public override View CreateView() => new HuntingRifleItemView(this);
        }
    }

    public partial class GunItemView : RangeWeaponItemView
    {
        protected GunItemView(ViewData data) : base(data) { }

        // RPCs
        public void FireArrow(Vector3 position, Vector3 velocity, Action<int> onFinished = null) { this.RPC<int>(RPCManager.GetMethodId("Int32 Eco.EM.Food.Hunting.Weapons.HuntingRifleItem.FireArrow(Eco.Gameplay.Players.Player,Eco.Shared.Math.Vector3,Eco.Shared.Math.Vector3)").ToString(), onFinished, position, velocity); }
        public new class ViewData : RangeWeaponItemView.ViewData
        {
            public override View CreateView() => new GunItemView(this);
        }
    }
    public partial class RangeWeaponItemView : WeaponItemView
    {
        protected RangeWeaponItemView(ViewData data) : base(data) { }
        public new class ViewData : WeaponItemView.ViewData
        {
            public override View CreateView() => new RangeWeaponItemView(this);
        }
    }

    public partial class WeaponItemView : ToolItemView
    {
        protected WeaponItemView(ViewData data) : base(data) { }
        public new class ViewData : ToolItemView.ViewData
        {
            public override View CreateView() => new WeaponItemView(this);
        }
    }

    public partial class ToolItemView : DurabilityItemView
    {
        protected ToolItemView(ViewData data) : base(data) { }

        // RPCs
        public void UseToolRPC() { this.RPC(RPCManager.GetMethodId("Void Eco.Gameplay.Items.ToolItem.UseToolRPC(Eco.Gameplay.Players.Player)").ToString()); }
        public new class ViewData : DurabilityItemView.ViewData
        {
            public override View CreateView() => new ToolItemView(this);
        }
    }

    public partial class DurabilityItemView : ItemView
    {
        protected DurabilityItemView(ViewData data) : base(data) { }
        // PROPERTIES
        public float Durability { get { return ((ViewData)this.Data).Durability; } protected set => ((ViewData)this.Data).Durability = value; }
        public float DurabilityRate { get { return ((ViewData)this.Data).DurabilityRate; } protected set => ((ViewData)this.Data).DurabilityRate = value; }
        public new class ViewData : ItemView.ViewData
        {
            public override View CreateView() => new DurabilityItemView(this);
            public float Durability;
            public float DurabilityRate;
        }
    }

    public partial class ItemView : StackableView
    {
        protected ItemView(ViewData data) : base(data) { }
        // PROPERTIES
        public bool IsTool { get { return ((ViewData)this.Data).IsTool; } protected set => ((ViewData)this.Data).IsTool = value; }
        public int TypeID { get { return ((ViewData)this.Data).TypeID; } protected set => ((ViewData)this.Data).TypeID = value; }
        public new class ViewData : StackableView.ViewData
        {
            public override View CreateView() => new ItemView(this);
            public bool IsTool;
            public int TypeID;
        }
    }

    public partial class StackableView : View
    {
        protected StackableView(ViewData data) : base(data) { }
        // PROPERTIES
        public string MarkedUpName { get { return ((ViewData)this.Data).MarkedUpName; } protected set => ((ViewData)this.Data).MarkedUpName = value; }

        // RPCs
        public void UILink(Action<LocString> onFinished = null) { this.RPC<LocString>(RPCManager.GetMethodId("Eco.Shared.Localization.LocString Eco.Gameplay.Systems.TextLinks.UILinkExtensions.UILink(Eco.Gameplay.Systems.TextLinks.ILinkable)").ToString(), onFinished); }
        public new class ViewData : View.ViewData
        {
            public override View CreateView() => new StackableView(this);
            public string MarkedUpName;
        }
    }
}
