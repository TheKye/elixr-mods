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
    public partial class DismantleSteelPickaxeRecipe : Recipe
    {
        public DismantleSteelPickaxeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteelToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelPickaxeItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleSteelPickaxeRecipe), Item.Get<SteelToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Steel Pickaxe", typeof(DismantleSteelPickaxeRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleSteelAxeRecipe : Recipe
    {
        public DismantleSteelAxeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteelToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelAxeItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleSteelAxeRecipe), Item.Get<SteelToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Steel Axe", typeof(DismantleSteelAxeRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleSteelShovelRecipe : Recipe
    {
        public DismantleSteelShovelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteelToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelShovelItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleSteelShovelRecipe), Item.Get<SteelToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Steel Shovel", typeof(DismantleSteelShovelRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleSteelScytheRecipe : Recipe
    {
        public DismantleSteelScytheRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteelToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelScytheItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleSteelScytheRecipe), Item.Get<SteelToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Steel Scythe", typeof(DismantleSteelScytheRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleSteelHoeRecipe : Recipe
    {
        public DismantleSteelHoeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteelToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelHoeItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleSteelHoeRecipe), Item.Get<SteelToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Steel Hoe", typeof(DismantleSteelHoeRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class DismantleSteelHammerRecipe : Recipe
    {
        public DismantleSteelHammerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteelToolHeadItem>(),
                new CraftingElement<WoodHandleItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelHammerItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DismantleSteelHammerRecipe), Item.Get<SteelToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Dismantle Steel Hammer", typeof(DismantleSteelHammerRecipe));
        }
    }

    [RequiresSkill(typeof(AlloySmeltingSkill), 4)]
    public partial class RecycleSteelToolHeadRecipe : Recipe
    {
        public RecycleSteelToolHeadRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<SteelItem>(4),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelToolHeadItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleSteelToolHeadRecipe), Item.Get<SteelToolHeadItem>().UILink(), 2, typeof(SmeltingSkill));
            this.Initialize("Recycle Steel Tool Head", typeof(RecycleSteelToolHeadRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}