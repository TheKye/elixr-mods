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
    public partial class WashedIronOreItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Washed Iron Ore"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Iron Ore that has had the tailings washed out."); } }

    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class WashedIronOreRecipe : Recipe
    {
        public WashedIronOreRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WashedIronOreItem>(),
                new CraftingElement<TailingsItem>(typeof(SmeltingSkill), 2, SmeltingSkill.MultiplicativeStrategy)
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronOreItem>(typeof(SmeltingSkill), 20, SmeltingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WashedIronOreRecipe), Item.Get<WashedIronOreItem>().UILink(), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Washed Iron Ore"), typeof(WashedIronOreRecipe));
            CraftingComponent.AddRecipe(typeof(OreWasherObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public class SmeltWashedIronRecipe : Recipe
    {
        public SmeltWashedIronRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<IronIngotItem>(1f),
               new CraftingElement<SlagItem>(typeof(SmeltingSkill), 2f, SmeltingSkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WashedIronOreItem>(0.25f)
            };
            this.Initialize(Localizer.DoStr("Smelt Washed Iron"), typeof(SmeltWashedIronRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmeltWashedIronRecipe), this.UILink(), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class WashedIronIngotRecipe : Recipe
    {
        public WashedIronIngotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(1),
                new CraftingElement<SlagItem>(typeof(SmeltingSkill), 2f, SmeltingSkill.MultiplicativeStrategy),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WashedIronOreItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WashedIronIngotRecipe), Item.Get<IronIngotItem>().UILink(), 3, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Iron Ingot"), typeof(WashedIronIngotRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }
}