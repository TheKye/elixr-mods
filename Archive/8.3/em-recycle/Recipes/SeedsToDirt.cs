namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Gameplay.Systems.Tooltip;

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class ForestForagerSeedsToDirtRecipe : Recipe
    {
        public ForestForagerSeedsToDirtRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DirtItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FernSporeItem>(12),
                new CraftingElement<HuckleberrySeedItem>(18),
                new CraftingElement<TomatoSeedItem>(6),
                new CraftingElement<FiddleheadsItem>(5)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ForestForagerSeedsToDirtRecipe), Item.Get<DirtItem>().UILink(), 90, typeof(SmeltingSkill));
            this.Initialize(Localizer.DoStr("Forest Seeds to Dirt"), typeof(ForestForagerSeedsToDirtRecipe));

            CraftingComponent.AddRecipe(typeof(CompostBinObject), this);
        }
    }

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class WetlandsWandererSeedsToDirtRecipe : Recipe
    {
        public WetlandsWandererSeedsToDirtRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DirtItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<AmanitaMushroomsItem>(6),
                new CraftingElement<CriminiMushroomSporesItem>(6),
                new CraftingElement<RiceItem>(10)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WetlandsWandererSeedsToDirtRecipe), Item.Get<DirtItem>().UILink(), 90, typeof(RecycleSkill));
            this.Initialize(Localizer.DoStr("Wetlands Seeds to Dirt"), typeof(WetlandsWandererSeedsToDirtRecipe));

            CraftingComponent.AddRecipe(typeof(CompostBinObject), this);
        }
    }

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class TundraTravellerSeedsToDirtRecipe : Recipe
    {
        public TundraTravellerSeedsToDirtRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DirtItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FireweedSeedItem>(25),
                new CraftingElement<FireweedShootsItem>(6)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TundraTravellerSeedsToDirtRecipe), Item.Get<DirtItem>().UILink(), 90, typeof(RecycleSkill));
            this.Initialize(Localizer.DoStr("Tundra Seeds to Dirt"), typeof(TundraTravellerSeedsToDirtRecipe));

            CraftingComponent.AddRecipe(typeof(CompostBinObject), this);
        }
    }

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class GrasslandGathererSeedsToDirtRecipe : Recipe
    {
        public GrasslandGathererSeedsToDirtRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DirtItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeetSeedItem>(8),
                new CraftingElement<BunchgrassSeedItem>(20),
                new CraftingElement<SagebrushSeedItem>(20),
                new CraftingElement<CornSeedItem>(10),
                new CraftingElement<WheatSeedItem>(10)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GrasslandGathererSeedsToDirtRecipe), Item.Get<DirtItem>().UILink(), 90, typeof(RecycleSkill));
            this.Initialize(Localizer.DoStr("Grassland Seeds to Dirt"), typeof(GrasslandGathererSeedsToDirtRecipe));

            CraftingComponent.AddRecipe(typeof(CompostBinObject), this);
        }
    }

    [RequiresSkill(typeof(RecycleSkill), 0)]
    public partial class DesertDrifterSeedsToDirtRecipe : Recipe
    {
        public DesertDrifterSeedsToDirtRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DirtItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CreosoteBushSeedItem>(18),
                new CraftingElement<PricklyPearSeedItem>(22),
                new CraftingElement<PricklyPearFruitItem>(5)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DesertDrifterSeedsToDirtRecipe), Item.Get<DirtItem>().UILink(), 90, typeof(RecycleSkill));
            this.Initialize(Localizer.DoStr("Desert Seeds to Dirt"), typeof(DesertDrifterSeedsToDirtRecipe));

            CraftingComponent.AddRecipe(typeof(CompostBinObject), this);
        }
    }
}