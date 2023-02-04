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
    public partial class WashedCopperOreItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Washed Copper Ore"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Copper Ore that has had the tailings washed out."); } }

    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class WashedCopperOreRecipe : Recipe
    {
        public WashedCopperOreRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WashedCopperOreItem>(),
                new CraftingElement<TailingsItem>(typeof(SmeltingSkill), 2, SmeltingSkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperOreItem>(typeof(SmeltingSkill), 20, SmeltingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WashedCopperOreRecipe), Item.Get<WashedCopperOreItem>().UILink(), 2, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Washed Copper Ore"), typeof(WashedCopperOreRecipe));
            CraftingComponent.AddRecipe(typeof(OreWasherObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public class SmeltWashedCopperRecipe : Recipe
    {
        public SmeltWashedCopperRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CopperIngotItem>(1f),
               new CraftingElement<SlagItem>(typeof(SmeltingSkill), 2f, SmeltingSkill.MultiplicativeStrategy),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WashedCopperOreItem>(0.25f)
            };
            this.Initialize(Localizer.DoStr("Smelt Washed Copper"), typeof(SmeltWashedCopperRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmeltWashedCopperRecipe), this.UILink(), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class WashedCopperIngotRecipe : Recipe
    {
        public WashedCopperIngotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CopperIngotItem>(),
                new CraftingElement<SlagItem>(typeof(SmeltingSkill), 2, SmeltingSkill.MultiplicativeStrategy),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WashedCopperOreItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WashedCopperIngotRecipe), Item.Get<CopperIngotItem>().UILink(), 4, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Copper Ingot"), typeof(WashedCopperIngotRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }
}