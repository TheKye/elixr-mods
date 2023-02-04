namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class RecycleHewnLogsRecipe : Recipe
    {
        public RecycleHewnLogsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LogItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(4),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleHewnLogsRecipe), Item.Get<HewnLogItem>().UILink(), 2, typeof(RecycleSkill)); ;
            this.Initialize(Localizer.DoStr("Recycle Hewn Logs"), typeof(RecycleHewnLogsRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}