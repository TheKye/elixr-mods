namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(MechanicsSkill), 0)]
    public partial class RecycleStoneRoadUpgradeRecipe : Recipe
    {
        public RecycleStoneRoadUpgradeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AsphaltRoadItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(typeof(MechanicsSkill), 1, MechanicsSkill.MultiplicativeStrategy),
                new CraftingElement<StoneRoadItem>(typeof(MechanicsSkill), 1, MechanicsSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleStoneRoadUpgradeRecipe), Item.Get<AsphaltRoadItem>().UILink(), 1, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Asphalt Road"), typeof(RecycleStoneRoadUpgradeRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }
}