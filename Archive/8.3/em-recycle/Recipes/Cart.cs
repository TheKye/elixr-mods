namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class RecycleWoodCartRecipe : Recipe
    {
        public RecycleWoodCartRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(6),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodCartItem>(),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleWoodCartRecipe), Item.Get<BoardItem>().UILink(), 2, typeof(RecycleSkill));

            this.Initialize(Localizer.DoStr("Recycle Wood Cart"), typeof(RecycleWoodCartRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
