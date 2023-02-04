namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Plants;
    using Eco.Gameplay.Stats;
    using Eco.Shared.Localization;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Simulation;
    using Eco.Simulation.Types;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Players;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Gameplay.Auth;
    using Eco.Shared.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Skills;

    [Serialized, Weight(10), MaxStackSize(500)]
    public partial class BucketOfWaterItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Bucket Of Water"); } }

        public override LocString DisplayDescription { get { return Localizer.DoStr("A Bucket of water.."); } }

    }

    public class WaterBucketRecipe : Recipe
    {
        public WaterBucketRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<BucketOfWaterItem>()
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<BucketItem>(1)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = new ConstantValue(5);
            this.Initialize(Localizer.DoStr("Bucket Of Water"), typeof(BucketRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }

    [Serialized, Weight(5000), MaxStackSize(10)]
    public partial class BucketItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Bucket"); } }

        public override LocString DisplayDescription { get { return Localizer.DoStr("A Bucket for holding water in.."); } }

    }

    [RequiresSkill(typeof(HewingSkill), 0)]
    public class BucketRecipe : Recipe
    {
        public BucketRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<BucketItem>()
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(HewingSkill), 5, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent))
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(RoadlineRecipe), Item.Get<RoadlineItem>().UILink(), 15, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Bucket"), typeof(BucketRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }

}
