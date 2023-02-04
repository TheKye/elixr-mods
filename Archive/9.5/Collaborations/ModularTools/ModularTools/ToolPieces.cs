using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [LocDisplayName("Ignore Me")]
    [Category("Hidden")]
    [Weight(1)]
    [MaxStackSize(1)]
    public partial class ToolPieceItem : Item
    {
        protected virtual Item RepairItem { get; set; }
        public override string OnUsed(Player player, ItemStack itemStack)
        {
            var selectedItem = player.User.Inventory.Toolbar.SelectedItem as DurabilityItem;

            if (RepairItem == null || selectedItem == null) return "";

            if (selectedItem.DisplayName.ToLower().Trim() != RepairItem.DisplayName.ToLower().Trim()) return string.Format(Text.Error($"You can only use this to repair a {RepairItem.DisplayName}, make sure to have the {RepairItem.DisplayName} selected then right-click this item to perform an emergency repair"));
            
            if (selectedItem.Durability == 100) return $"You don't need to repair your {selectedItem.DisplayName}, it is fully repaired.";

            itemStack.TryModifyStack(player.User, -1, null, () =>
            {
                var chance = RandomUtil.Range(player.User.Skillset.GetSkill(typeof(SelfImprovementSkill)).Level, 11);
                selectedItem.Durability = chance == 10 ? 100 : 45 ;
                if (selectedItem.Durability == 100)
                    player.MsgLocStr($"You Managed to not damage your {DisplayName}! Your {selectedItem.DisplayName} has been fully repaired!");
                else
                    player.MsgLocStr($"While attempting to patch up your {selectedItem.DisplayName} you damaged your {DisplayName}.. as a result you lost 55% of it's durability.");
            });

            return base.OnUsed(player, itemStack);
        }
    }

    /* Axe Done*/
    #region Stone
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Stone Axe Head")]
    public partial class StoneAxeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<StoneAxeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Stone Axe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A stone axe head for making a stone axe");

    }

    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class StoneAxeHeadRecipe : RecipeFamily
    {
        public StoneAxeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Stone Axe Head",
                    Localizer.DoStr("Stone Axe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Rock", 2)
                    },
                    new CraftingElement<StoneAxeHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneAxeHeadRecipe), 0.5f, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Stone Axe Head"), typeof(StoneAxeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Iron
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Iron Axe Head")]
    public partial class IronAxeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<IronAxeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Iron Axe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Iron axe head for making an iron axe");
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class IronAxeHeadRecipe : RecipeFamily
    {
        public IronAxeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Iron Axe Head",
                    Localizer.DoStr("Iron Axe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<IronAxeHeadItem>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronAxeHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            Initialize(Localizer.DoStr("Iron Axe Head"), typeof(IronAxeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Steel
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Steel Axe Head")]
    public partial class SteelAxeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<SteelAxeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Steel Axe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Steel axe head for making a Steel axe");
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SteelAxeHeadRecipe : RecipeFamily
    {
        public SteelAxeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Steel Axe Head",
                    Localizer.DoStr("Steel Axe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<SteelAxeHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelAxeHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Steel Axe Head"), typeof(SteelAxeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Modern
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Modern Axe Head")]
    public partial class ModernAxeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<ModernAxeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Axe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern axe head for making a Modern axe");
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    public partial class ModernAxeHeadRecipe : RecipeFamily
    {
        public ModernAxeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Axe Head",
                    Localizer.DoStr("Modern Axe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(FiberglassItem), 6, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<ModernAxeHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernAxeHeadRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Axe Head"), typeof(ModernAxeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion

    /* Pick Done*/
    #region Stone
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Stone Pickaxe Head")]
    public partial class StonePickaxeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<StonePickaxeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Stone Pickaxe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A stone Pickaxe head for making a stone Pickaxe");
    }

    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class StonePickaxeHeadRecipe : RecipeFamily
    {
        public StonePickaxeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Stone Pickaxe Head",
                    Localizer.DoStr("Stone Pickaxe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Rock", 2)
                    },
                    new CraftingElement<StonePickaxeHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StonePickaxeHeadRecipe), 0.5f, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Stone Pickaxe Head"), typeof(StonePickaxeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Iron
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Iron Pickaxe Head")]
    public partial class IronPickaxeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<IronPickaxeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Iron Pickaxe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Iron Pickaxe head for making an iron Pickaxe");
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class IronPickaxeHeadRecipe : RecipeFamily
    {
        public IronPickaxeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Iron Pickaxe Head",
                    Localizer.DoStr("Iron Pickaxe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<IronPickaxeHeadItem>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronPickaxeHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            Initialize(Localizer.DoStr("Iron Pickaxe Head"), typeof(IronPickaxeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Steel
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Steel Pickaxe Head")]
    public partial class SteelPickaxeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<SteelPickaxeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Steel Pickaxe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Steel Pickaxe head for making a Steel Pickaxe");
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SteelPickaxeHeadRecipe : RecipeFamily
    {
        public SteelPickaxeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Steel Pickaxe Head",
                    Localizer.DoStr("Steel Pickaxe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<SteelPickaxeHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelPickaxeHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Steel Pickaxe Head"), typeof(SteelPickaxeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Modern
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Modern Pickaxe Head")]
    public partial class ModernPickaxeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<ModernPickaxeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Pickaxe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern Pickaxe head for making a Modern Pickaxe");
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    public partial class ModernPickaxeHeadRecipe : RecipeFamily
    {
        public ModernPickaxeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Pickaxe Head",
                    Localizer.DoStr("Modern Pickaxe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(FiberglassItem), 6, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<ModernPickaxeHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernPickaxeHeadRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Pickaxe Head"), typeof(ModernPickaxeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion

    /*Road Tool Done*/
    #region Stone
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Stone Road Tool Head")]
    public partial class StoneRoadToolHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<StoneRoadToolItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Stone Road Tool Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A stone Road Tool head for making a stone Road Tool");
    }

    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class StoneRoadToolHeadRecipe : RecipeFamily
    {
        public StoneRoadToolHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Stone Road Tool Head",
                    Localizer.DoStr("Stone Road Tool Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Rock", 2)
                    },
                    new CraftingElement<StoneRoadToolHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneRoadToolHeadRecipe), 0.5f, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Stone Road Tool Head"), typeof(StoneRoadToolHeadRecipe));

            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Steel
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Steel Road Tool Head")]
    public partial class SteelRoadToolHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<SteelRoadToolItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Steel Road Tool Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Steel Road Tool head for making a Steel Road Tool");
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SteelRoadToolHeadRecipe : RecipeFamily
    {
        public SteelRoadToolHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Steel Road Tool Head",
                    Localizer.DoStr("Steel Road Tool Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<SteelRoadToolHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelRoadToolHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Steel Road Tool Head"), typeof(SteelRoadToolHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion

    /* Shovel Done*/
    #region Iron
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Iron Shovel Head")]
    public partial class IronShovelHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<IronShovelItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Iron Shovel Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Iron Shovel head for making an iron Shovel");
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class IronShovelHeadRecipe : RecipeFamily
    {
        public IronShovelHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Iron Shovel Head",
                    Localizer.DoStr("Iron Shovel Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<IronShovelHeadItem>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronShovelHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            Initialize(Localizer.DoStr("Iron Shovel Head"), typeof(IronShovelHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Steel
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Steel Shovel Head")]
    public partial class SteelShovelHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<SteelShovelItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Steel Shovel Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Steel Shovel head for making a Steel Shovel");
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SteelShovelHeadRecipe : RecipeFamily
    {
        public SteelShovelHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Steel Shovel Head",
                    Localizer.DoStr("Steel Shovel Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<SteelShovelHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelShovelHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Steel Shovel Head"), typeof(SteelShovelHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Modern
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Modern Shovel Head")]
    public partial class ModernShovelHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<ModernShovelItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Shovel Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern Shovel head for making a Modern Shovel");
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    public partial class ModernShovelHeadRecipe : RecipeFamily
    {
        public ModernShovelHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Shovel Head",
                    Localizer.DoStr("Modern Shovel Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(FiberglassItem), 6, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<ModernShovelHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernShovelHeadRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Shovel Head"), typeof(ModernShovelHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion

    /* Hammer*/
    #region Stone
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Stone Hammer Head")]
    public partial class StoneHammerHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<StoneHammerItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Stone Hammer Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A stone Hammer head for making a stone Hammer");
    }

    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class StoneHammerHeadRecipe : RecipeFamily
    {
        public StoneHammerHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Stone Hammer Head",
                    Localizer.DoStr("Stone Hammer Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Rock", 2)
                    },
                    new CraftingElement<StoneHammerHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneHammerHeadRecipe), 0.5f, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Stone Hammer Head"), typeof(StoneHammerHeadRecipe));

            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Iron
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Iron Hammer Head")]
    public partial class IronHammerHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<IronHammerItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Iron Hammer Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Iron Hammer head for making an iron Hammer");
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class IronHammerHeadRecipe : RecipeFamily
    {
        public IronHammerHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Iron Hammer Head",
                    Localizer.DoStr("Iron Hammer Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<IronHammerHeadItem>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronHammerHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            Initialize(Localizer.DoStr("Iron Hammer Head"), typeof(IronHammerHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Steel
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Steel Hammer Head")]
    public partial class SteelHammerHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<SteelHammerItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Steel Hammer Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Steel Hammer head for making a Steel Hammer");
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SteelHammerHeadRecipe : RecipeFamily
    {
        public SteelHammerHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Steel Hammer Head",
                    Localizer.DoStr("Steel Hammer Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<SteelHammerHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelHammerHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Steel Hammer Head"), typeof(SteelHammerHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Modern
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Modern Hammer Head")]
    public partial class ModernHammerHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<ModernHammerItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Hammer Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern Hammer head for making a Modern Hammer");
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    public partial class ModernHammerHeadRecipe : RecipeFamily
    {
        public ModernHammerHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Hammer Head",
                    Localizer.DoStr("Modern Hammer Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(FiberglassItem), 6, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<ModernHammerHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernHammerHeadRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Hammer Head"), typeof(ModernHammerHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion

    /* Bow*/
    #region wood
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Wooden Bow Frame")]
    public partial class WoodBowFrameItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<WoodenBowItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Wooden Bow Frames");
        public override LocString DisplayDescription => Localizer.DoStr("A Roughly Carved Bow Frame");
    }

    [RequiresSkill(typeof(HuntingSkill), 1)]
    public partial class WoodBowFrameRecipe : RecipeFamily
    {
        public WoodBowFrameRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Wooden Bow Frame",
                    Localizer.DoStr("Wooden Bow Frame"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 2)
                    },
                    new CraftingElement<WoodBowFrameItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodBowFrameRecipe), 0.5f, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Wooden Bow Frame"), typeof(WoodBowFrameRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
    #endregion
    #region recurve
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Recurve Bow Frame")]
    public partial class RecurveBowFrameItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<RecurveBowItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Recurve Bow Frames");
        public override LocString DisplayDescription => Localizer.DoStr("A More Refined Bow Frame With Steel Support");
    }

    [RequiresSkill(typeof(CarpentrySkill), 6)]
    public partial class RecurveBowFrameRecipe : RecipeFamily
    {
        public RecurveBowFrameRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recurve Bow Frame",
                    Localizer.DoStr("Recurve Bow Frame"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 8, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                    new IngredientElement("Lumber", 5, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                    new IngredientElement(typeof(LeatherHideItem), 3)
                    },
                    new CraftingElement<RecurveBowFrameItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecurveBowFrameRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Recurve Bow Frame"), typeof(RecurveBowFrameRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
    #endregion
    #region composite
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Composite Bow Frame")]
    public partial class CompositeBowFrameItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<CompositeBowItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Composite Bow Frames");
        public override LocString DisplayDescription => Localizer.DoStr("An Even More Refined Bow Frame made from Fiberglass With Steel Reinforcement");
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 6)]
    public partial class CompositeBowFrameRecipe : RecipeFamily
    {
        public CompositeBowFrameRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Composite Bow Frame",
                    Localizer.DoStr("Composite Bow Frame"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 8, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                    new IngredientElement(typeof(FiberglassItem), 5, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                    new IngredientElement(typeof(LeatherHideItem), 3)
                    },
                    new CraftingElement<CompositeBowFrameItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CompositeBowFrameRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Composite Bow Frame"), typeof(CompositeBowFrameRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion

    /* Machete */
    #region Stone
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Stone Machete Head")]
    public partial class StoneMacheteHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<StoneMacheteItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Stone Machete Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A stone Machete head for making a stone Machete");
    }

    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class StoneMacheteHeadRecipe : RecipeFamily
    {
        public StoneMacheteHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Stone Machete Head",
                    Localizer.DoStr("Stone Machete Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Rock", 2)
                    },
                    new CraftingElement<StoneMacheteHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneMacheteHeadRecipe), 0.5f, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Stone Machete Head"), typeof(StoneMacheteHeadRecipe));

            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Iron
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Iron Machete Head")]
    public partial class IronMacheteHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<IronMacheteItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Iron Machete Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Iron Machete head for making an iron Machete");
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class IronMacheteHeadRecipe : RecipeFamily
    {
        public IronMacheteHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Iron Machete Head",
                    Localizer.DoStr("Iron Machete Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<IronMacheteHeadItem>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronMacheteHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            Initialize(Localizer.DoStr("Iron Machete Head"), typeof(IronMacheteHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Steel
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Steel Machete Head")]
    public partial class SteelMacheteHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<SteelMacheteItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Steel Machete Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Steel Machete head for making a Steel Machete");
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SteelMacheteHeadRecipe : RecipeFamily
    {
        public SteelMacheteHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Steel Machete Head",
                    Localizer.DoStr("Steel Machete Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<SteelMacheteHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelMacheteHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Steel Machete Head"), typeof(SteelMacheteHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Modern
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Modern Machete Head")]
    public partial class ModernMacheteHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<ModernMacheteItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Machete Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern Machete head for making a Modern Machete");
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    public partial class ModernMacheteHeadRecipe : RecipeFamily
    {
        public ModernMacheteHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Machete Head",
                    Localizer.DoStr("Modern Machete Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(FiberglassItem), 6, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<ModernMacheteHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernMacheteHeadRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Machete Head"), typeof(ModernMacheteHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion

    /* Sickle */
    #region Stone
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Stone Sickle Head")]
    public partial class StoneSickleHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<StoneSickleItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Stone Sickle Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A stone Sickle head for making a stone Sickle");
    }

    [RequiresSkill(typeof(MasonrySkill), 0)]
    public partial class StoneSickleHeadRecipe : RecipeFamily
    {
        public StoneSickleHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Stone Sickle Head",
                    Localizer.DoStr("Stone Sickle Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Rock", 2)
                    },
                    new CraftingElement<StoneSickleHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneSickleHeadRecipe), 0.5f, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Stone Sickle Head"), typeof(StoneSickleHeadRecipe));

            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Iron
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Iron Sickle Head")]
    public partial class IronSickleHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<IronSickleItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Iron Sickle Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Iron Sickle head for making an iron Sickle");
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class IronSickleHeadRecipe : RecipeFamily
    {
        public IronSickleHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Iron Sickle Head",
                    Localizer.DoStr("Iron Sickle Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<IronSickleHeadItem>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronSickleHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            Initialize(Localizer.DoStr("Iron Sickle Head"), typeof(IronSickleHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Steel
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Steel Sickle Head")]
    public partial class SteelSickleHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<SteelSickleItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Steel Sickle Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Steel Sickle head for making a Steel Sickle");
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SteelSickleHeadRecipe : RecipeFamily
    {
        public SteelSickleHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Steel Sickle Head",
                    Localizer.DoStr("Steel Sickle Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<SteelSickleHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelSickleHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Steel Sickle Head"), typeof(SteelSickleHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion

    /* Hoe */
    #region Iron
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Iron Hoe Head")]
    public partial class IronHoeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<IronHoeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Iron Hoe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Iron Hoe head for making an iron Hoe");
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class IronHoeHeadRecipe : RecipeFamily
    {
        public IronHoeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Iron Hoe Head",
                    Localizer.DoStr("Iron Hoe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<IronHoeHeadItem>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronHoeHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            Initialize(Localizer.DoStr("Iron Hoe Head"), typeof(IronHoeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Steel
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Steel Hoe Head")]
    public partial class SteelHoeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<SteelHoeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Steel Hoe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Steel Hoe head for making a Steel Hoe");
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public partial class SteelHoeHeadRecipe : RecipeFamily
    {
        public SteelHoeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Steel Hoe Head",
                    Localizer.DoStr("Steel Hoe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<SteelHoeHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelHoeHeadRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Steel Hoe Head"), typeof(SteelHoeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    #endregion
    #region Modern
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Modern Hoe Head")]
    public partial class ModernHoeHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<ModernHoeItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Hoe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern Hoe head for making a Modern Hoe");
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    public partial class ModernHoeHeadRecipe : RecipeFamily
    {
        public ModernHoeHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Hoe Head",
                    Localizer.DoStr("Modern Hoe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(FiberglassItem), 6, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<ModernHoeHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernHoeHeadRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Hoe Head"), typeof(ModernHoeHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion

    /* Scythe Done*/
    #region modern
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]    [Category("Tool")]
    [LocDisplayName("Modern Scythe Head")]
    public partial class ModernScytheHeadItem : ToolPieceItem
    {
        protected override Item RepairItem => Get<ModernScytheItem>();
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Scythe Heads");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern Scythe head for making a Modern Scythe");
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]
    public partial class ModernScytheHeadRecipe : RecipeFamily
    {
        public ModernScytheHeadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Scythe Head",
                    Localizer.DoStr("Modern Scythe Head"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(FiberglassItem), 6, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<ModernScytheHeadItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernScytheHeadRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Scythe Head"), typeof(ModernScytheHeadRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion
}