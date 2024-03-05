using Eco.Core.Controller;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.View;
using System;

namespace RD.Framework.API.Helpers
{
    public partial class LivingItem : DurabilityItem, IStackableMergable
    {
        public LivingItem() { }
        public override LocString Label => Localizer.DoStr("Time Until Death");
        public override bool CanBeHeld => true;
        [Serialized]
        [SyncToView(null, true, Flags = SyncFlags.MustRequest)]
        public ImmutableCountdown DeathTimer { get; set; }
        protected virtual float BaseLivingTime { get; }
        public override LocString TooltipMaximumDurability()
        {
            return LocString.Empty;
        }
        float AdjustedLivingTime => BaseLivingTime * LivingTimeMulti * 0.5f; //(Pasture.obj?.livingTimeMulti ?? 1);
        float LivingTimeMulti = 1;

        bool HasImortality => float.IsInfinity(AdjustedLivingTime);

        public int StackableQualityGroup() => (int)(GetDurability() / 34);
        public override float GetDurability()
        {
            if (this.DeathTimer.Duration() == 0) return DurabilityMax;
            return this.GetDeathTimeBasedOnDurability(this.DeathTimer);
        }
        public Item Merge(Item item, int first, int second)
        {
            if (second <= 0 || item == null) return this;
            if (item.Type != Type) return null;
            var livingItem = (LivingItem)Clone;
            var FirstAgeTime = GetDurability() * first;
            var SecondAgeTime = ((LivingItem)item).GetDurability() * second;
            var AverageAgeTime = (FirstAgeTime + SecondAgeTime) / (first + second);
            livingItem.DeathTimer = GetDeathTimeBasedOnDurability(AverageAgeTime);
            return livingItem;
        }
        public override Item Clone
        {
            get
            {
                var copy = (LivingItem)base.Clone;
                copy.DeathTimer = DeathTimer;
                copy.LivingTimeMulti = LivingTimeMulti;
                return copy;
            }
        }
        public void SetDeathTimeBasedOnDurability(float durability) => DeathTimer = GetDeathTimeBasedOnDurability(durability);
        public void UpdateDeathTime()
        {
            float cachedDurability = DeathTimer.Duration() > 0 ? GetDeathTimeBasedOnDurability(DeathTimer) : DurabilityMax;
            DeathTimer = GetDeathTimeBasedOnDurability(cachedDurability);
        }
        public ImmutableCountdown GetDeathTimeBasedOnDurability(float durability, bool paused = false)
        {
            var duration = HasImortality ? float.MaxValue : AdjustedLivingTime;
            return ImmutableCountdown.Create(duration, duration * (durability / 100), paused || HasImortality);
        }

        private float GetDeathTimeBasedOnDurability(ImmutableCountdown DeathTimer) => DeathTimer.PercentLeft() * 100f;

        public bool CanStack(Item stackingOntoItem)
        {
            throw new NotImplementedException();
        }
    }
}