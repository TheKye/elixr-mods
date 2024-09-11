using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Core.Items;

namespace Eco.Mods.TechTree
{
    /*
    Primitive Handle
    Use Wood for the Handle - no skill
    For Stone tools
    */
    #region Primitive Handle
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]
    [Currency]
    [LocDisplayName("Primitive Wooden Handle")]
    public partial class PrimitiveWoodHandleItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Primitive Wooden Handles");
        public override LocString DisplayDescription => Localizer.DoStr("A Primitive Wooden Handle used for making and repairing tools");
    }

    public partial class PrimitiveWoodHandleRecipe : RecipeFamily
    {
        public PrimitiveWoodHandleRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Wooden Handle",
                    Localizer.DoStr("Wooden Handle"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 5),
                    new IngredientElement(typeof(PlantFibersItem), 3)
                    },
                    new CraftingElement<PrimitiveWoodHandleItem>(),
                    new CraftingElement<WoodPulpItem>(5)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PrimitiveWoodHandleRecipe), 0.5f, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Wooden Handle"), typeof(PrimitiveWoodHandleRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
    #endregion

    /* 
    Basic Handle 
    Use Wood Board For Handle - Carpenter
    For Iron Tools
    */
    #region Basic Handle
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]
    [LocDisplayName("Wooden Handle")]
    public partial class BasicWoodHandleItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Wooden Handles");
        public override LocString DisplayDescription => Localizer.DoStr("A Wooden Handle used for making tools");
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class BasicWoodHandleRecipe : RecipeFamily
    {
        public BasicWoodHandleRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Wooden Handle",
                    Localizer.DoStr("Wooden Handle"),
                    new IngredientElement[]
                    {
                    new IngredientElement("WoodBoard", 5, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                    new IngredientElement(typeof(LeatherHideItem), 3)
                    },
                    new CraftingElement<BasicWoodHandleItem>(),
                    new CraftingElement<WoodPulpItem>(5)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BasicWoodHandleRecipe), 0.5f, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Wooden Handle"), typeof(BasicWoodHandleRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
    #endregion

    /* 
    Modern Handle 
    Use Lumber Board For Handle - Carpenter
    For Steel Tools
    */
    #region Modern Wood Handle
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]
    [LocDisplayName("Modern Wooden Handle")]
    public partial class ModernWoodHandleItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Wooden Handles");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern Wooden Handle used for making tools");
    }

    [RequiresSkill(typeof(CarpentrySkill), 6)]
    public partial class ModernWoodHandleRecipe : RecipeFamily
    {
        public ModernWoodHandleRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Wooden Handle",
                    Localizer.DoStr("Modern Wooden Handle"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Lumber", 3, true),
                    new IngredientElement(typeof(LeatherHideItem), 3)
                    },
                    new CraftingElement<ModernWoodHandleItem>(),
                    new CraftingElement<WoodPulpItem>(5)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernWoodHandleRecipe), 0.5f, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Wooden Handle"), typeof(ModernWoodHandleRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
    #endregion

    /* 
    Advanced Handle 
    Use Fiberglass for handle - Electronics
    For Modern Tools
    */
    #region Modern Handle
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]
    [LocDisplayName("Modern Handle")]
    public partial class ModernHandleItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Handles");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern Handle used for making tools");
    }

    [RequiresSkill(typeof(CompositesSkill), 2)]
    public partial class ModernHandleRecipe : RecipeFamily
    {
        public ModernHandleRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Handle",
                    Localizer.DoStr("Modern Handle"),
                    new IngredientElement[]
                    {
                    new IngredientElement("CompositeLumber", 6, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent))
                    },
                    new CraftingElement<ModernHandleItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernHandleRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Handle"), typeof(ModernHandleRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion

    /*
    Bow Strings
    Bow Strings will be used to make a bow
    Basic Bow String: Plant Fibers - Anyone Can Make
    Recurve Bow String: Celulose Fiber - Tailor
    Composite Bow String: Fiberglass - Tailor
    */
    #region Basic Bow String
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]
    [LocDisplayName("Basic Bow String")]
    public partial class BasicBowStringItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Basic Bow Strings");
        public override LocString DisplayDescription => Localizer.DoStr("A Basic Bow String used for stringing the wooden bow");
    }

    [RequiresSkill(typeof(HuntingSkill), 1)]
    public partial class BasicBowStringRecipe : RecipeFamily
    {
        public BasicBowStringRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Basic Bow String",
                    Localizer.DoStr("Basic Bow String"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PlantFibersItem), 50)
                    },
                    new CraftingElement<BasicBowStringItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250);
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            Initialize(Localizer.DoStr("Basic Bow String"), typeof(BasicBowStringRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
    #endregion
    #region Modern Bow String
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]
    [LocDisplayName("Modern Bow String")]
    public partial class ModernBowStringItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Modern Bow Strings");
        public override LocString DisplayDescription => Localizer.DoStr("A Modern Bow String used for stringing the Recurve bow");
    }
    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class ModernBowStringRecipe : RecipeFamily
    {
        public ModernBowStringRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Modern Bow String",
                    Localizer.DoStr("Modern Bow String"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(CelluloseFiberItem), 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent))
                    },
                    new CraftingElement<ModernBowStringItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernBowStringRecipe), 0.5f, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            Initialize(Localizer.DoStr("Modern Bow String"), typeof(ModernBowStringRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
    #endregion
    #region Advanced Bow String
    [Serialized]
    [MaxStackSize(50)]
    [Weight(200)]
    [LocDisplayName("Advanced Bow String")]
    public partial class AdvancedBowStringItem : Item
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Advanced Bow Strings");
        public override LocString DisplayDescription => Localizer.DoStr("An Advanced Bow String used for stringing the Composite bow");
    }
    [RequiresSkill(typeof(TailoringSkill), 7)]
    public partial class AdvancedBowStringRecipe : RecipeFamily
    {
        public AdvancedBowStringRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Advanced Bow String",
                    Localizer.DoStr("Advanced Bow String"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(FiberglassItem), 6, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent))
                    },
                    new CraftingElement<AdvancedBowStringItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AdvancedBowStringRecipe), 0.5f, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            Initialize(Localizer.DoStr("Advanced Bow String"), typeof(AdvancedBowStringRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    #endregion
}