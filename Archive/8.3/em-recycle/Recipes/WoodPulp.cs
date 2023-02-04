namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class RecycleWoodenShovelRecipe : Recipe
    {
        public RecycleWoodenShovelRecipe()
        {
            this.Products = new CraftingElement[] {
                new CraftingElement<WoodPulpItem>(10)
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement <WoodenShovelItem>(1),
            };
            this.CraftMinutes = new ConstantValue(1);
            this.Initialize(Localizer.DoStr("Recycle Wooden Shovel"), typeof(RecycleWoodenShovelRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class RecycleWoodenHoeRecipe : Recipe
    {
        public RecycleWoodenHoeRecipe()
        {
            this.Products = new CraftingElement[] {
                new CraftingElement<WoodPulpItem>(10)
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodenHoeItem>(1),
            };
            this.CraftMinutes = new ConstantValue(1);
            this.Initialize(Localizer.DoStr("Recycle Wooden Hoe"), typeof(RecycleWoodenHoeRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class RecycleBoardsRecipe : Recipe
    {
        public RecycleBoardsRecipe()
        {
            this.Products = new CraftingElement[] {
                new CraftingElement<BoardItem>(1)
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(SmeltingSkill), 15, SmeltingSkill.MultiplicativeStrategy),
                new CraftingElement<TallowItem>(typeof(SmeltingSkill), 1, SmeltingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleBoardsRecipe), Item.Get<BoardItem>().UILink(), 1f, typeof(SmeltingSkill));
            this.Initialize(Localizer.DoStr("Board"), typeof(RecycleBoardsRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
