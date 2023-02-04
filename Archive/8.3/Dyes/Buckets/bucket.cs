namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Items;
    using Eco.Shared.Localization;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Serialization;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.DynamicValues;

    [Serialized, Weight(5000), MaxStackSize(10)]
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
            this.CraftMinutes = new ConstantValue(2);
            this.Initialize(Localizer.DoStr("Bucket Of Water"), typeof(WaterBucketRecipe));
            CraftingComponent.AddRecipe(typeof(HandWaterPumpObject), this);
        }
    }

    public class fWaterBucketRecipe : Recipe
    {
        public fWaterBucketRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<BucketOfWaterItem>()
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<BucketItem>(1)
            };
            this.CraftMinutes = new ConstantValue(0.10f);
            this.Initialize(Localizer.DoStr("Bucket Of Water"), typeof(WaterBucketRecipe));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceItem), this);
        }
    }

    [Serialized, Weight(1000), MaxStackSize(10)]
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
            this.CraftMinutes = CreateCraftTimeValue(typeof(BucketRecipe), Item.Get<BucketItem>().UILink(), 5, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Bucket"), typeof(BucketRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }

}
