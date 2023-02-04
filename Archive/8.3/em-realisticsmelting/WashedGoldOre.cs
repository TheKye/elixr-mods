namespace Eco.Mods.Jagganot.CheesTableAndPrepWork
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]

    [Weight(1000)]
    public partial class WashedGoldOreItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Washed Gold Ore"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Gold Ore that has had the tailings washed out."); } }

    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class WashedGoldOreRecipe : Recipe
    {
        public WashedGoldOreRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WashedGoldOreItem>(),
                new CraftingElement<TailingsItem>(typeof(SmeltingSkill), 2, SmeltingSkill.MultiplicativeStrategy)
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GoldOreItem>(typeof(SmeltingSkill), 20, SmeltingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WashedGoldOreRecipe), Item.Get<WashedGoldOreItem>().UILink(), 2, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Washed Gold Ore"), typeof(WashedGoldOreRecipe));
            CraftingComponent.AddRecipe(typeof(OreWasherObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class WashedGoldIngotRecipe : Recipe
    {
        public WashedGoldIngotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GoldIngotItem>(1f),
                new CraftingElement<SlagItem>(typeof(SmeltingSkill), 4, SmeltingSkill.MultiplicativeStrategy)

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WashedGoldOreItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WashedGoldIngotRecipe), Item.Get<GoldIngotItem>().UILink(), 4, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Gold Ingot"), typeof(WashedGoldIngotRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public class SmeltWashedGoldRecipe : Recipe
    {
        public SmeltWashedGoldRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<GoldIngotItem>(1f),
               new CraftingElement<SlagItem>(typeof(SmeltingSkill), 2f, SmeltingSkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WashedGoldOreItem>(0.25f)
            };
            this.Initialize(Localizer.DoStr("Smelt Gold"), typeof(SmeltWashedGoldRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmeltWashedGoldRecipe), this.UILink(), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}