namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleIronPickaxeRecipe : Recipe
    {
        public DismantleIronPickaxeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronPickaxeItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleIronPickaxeRecipe), Item.Get<IronToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Iron Pickaxe", typeof(DismantleIronPickaxeRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleIronAxeRecipe : Recipe
    {
        public DismantleIronAxeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronAxeItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleIronAxeRecipe), Item.Get<IronToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Iron Axe", typeof(DismantleIronAxeRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleIronShovelRecipe : Recipe
    {
        public DismantleIronShovelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronShovelItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleIronShovelRecipe), Item.Get<IronToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Iron Shovel", typeof(DismantleIronShovelRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleIronScytheRecipe : Recipe
    {
        public DismantleIronScytheRecipe()
        {
            this.Products = new CraftingElement[]
            {
                   new CraftingElement<IronToolHeadItem>(),
                   new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronScytheItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleIronScytheRecipe), Item.Get<IronToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Iron Scythe", typeof(DismantleIronScytheRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleIronHoeRecipe : Recipe
    {
        public DismantleIronHoeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronHoeItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleIronHoeRecipe), Item.Get<IronToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Iron Hoe", typeof(DismantleIronHoeRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleIronHammerRecipe : Recipe
    {
        public DismantleIronHammerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronHammerItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleIronHammerRecipe), Item.Get<IronToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Iron Hammer", typeof(DismantleIronHammerRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }


    [RequiresSkill(typeof(AlloySmeltingSkill), 4)]
    public partial class RecycleIronToolHeadRecipe : Recipe
    {
        public RecycleIronToolHeadRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<IronIngotItem>(4),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronToolHeadItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleIronToolHeadRecipe), Item.Get<IronIngotItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Recycle Iron Tool Head", typeof(RecycleIronToolHeadRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}