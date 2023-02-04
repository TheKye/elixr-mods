namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Gameplay.Systems.Tooltip;

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class RecycleDirtRampsRecipe : Recipe
    {
        public RecycleDirtRampsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DirtItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<DirtRampItem>(2),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleDirtRampsRecipe), Item.Get<DirtItem>().UILink(), 1, typeof(RecycleSkill));
            this.Initialize(Localizer.DoStr("Dirt"), typeof(RecycleDirtRampsRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }
}