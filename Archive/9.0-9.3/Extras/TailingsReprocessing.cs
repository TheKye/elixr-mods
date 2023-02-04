namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
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
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using NyElectrics;

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class RecycleForGoldRecipe : RecipeFamily
    {
        public RecycleForGoldRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycled Tailings: Gold",
                    Localizer.DoStr("Recycled Tailings: Gold"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(TailingsItem), 10, true)
                    },
                    new CraftingElement<GoldConcentrateItem>(1),
                    new CraftingElement<WetTailingsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleForGoldRecipe), 40, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Recycled Tailings: Gold"), typeof(RecycleForGoldRecipe));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class RecycleForGold2Recipe : RecipeFamily
    {
        public RecycleForGold2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycled Tailings: Gold",
                    Localizer.DoStr("Recycled Tailings: Gold"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(TailingsItem), 10, true)
                    },
                    new CraftingElement<GoldConcentrateItem>(1),
                    new CraftingElement<WetTailingsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleForGold2Recipe), 40, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Recycled Tailings: Gold"), typeof(RecycleForGold2Recipe));
            CraftingComponent.AddRecipe(typeof(NyElectricBlastFurnaceObject), this);
        }
    }


    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class RecycleForCopperRecipe : RecipeFamily
    {
        public RecycleForCopperRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycled Tailings: Copper",
                    Localizer.DoStr("Recycled Tailings: Copper"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(TailingsItem), 10, true)
                    },
                    new CraftingElement<CopperConcentrateItem>(1),
                    new CraftingElement<WetTailingsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleForCopperRecipe), 40, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Recycled Tailings: Copper"), typeof(RecycleForCopperRecipe));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class RecycleForCopper2Recipe : RecipeFamily
    {
        public RecycleForCopper2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycled Tailings: Copper",
                    Localizer.DoStr("Recycled Tailings: Copper"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(TailingsItem), 10, true)
                    },
                    new CraftingElement<CopperConcentrateItem>(1),
                    new CraftingElement<WetTailingsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleForCopper2Recipe), 40, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Recycled Tailings: Copper"), typeof(RecycleForCopper2Recipe));
            CraftingComponent.AddRecipe(typeof(NyElectricBlastFurnaceObject), this);
        }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class RecycleForIronRecipe : RecipeFamily
    {
        public RecycleForIronRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycled Tailings: Iron",
                    Localizer.DoStr("Recycled Tailings: Iron"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(TailingsItem), 10, true)
                    },
                    new CraftingElement<IronConcentrateItem>(1),
                    new CraftingElement<WetTailingsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleForIronRecipe), 40, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Recycled Tailings: Iron"), typeof(RecycleForIronRecipe));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class RecycleForIron2Recipe : RecipeFamily
    {
        public RecycleForIron2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Recycled Tailings: Iron",
                    Localizer.DoStr("Recycled Tailings: Iron"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(TailingsItem), 10, true)
                    },
                    new CraftingElement<IronConcentrateItem>(1),
                    new CraftingElement<WetTailingsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleForIron2Recipe), 40, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Recycled Tailings: Iron"), typeof(RecycleForIron2Recipe));
            CraftingComponent.AddRecipe(typeof(NyElectricBlastFurnaceObject), this);
        }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class DryTailingsRecipe : RecipeFamily
    {
        public DryTailingsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dry Out Tailings",
                    Localizer.DoStr("Dry Out Tailings"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WetTailingsItem), 10, true),
                        new IngredientElement(typeof(DirtItem), 10, true)
                    },
                    new CraftingElement<TailingsItem>(20)
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(DryTailingsRecipe), 12.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dry Out Tailings"), typeof(DryTailingsRecipe));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class DryTailings2Recipe : RecipeFamily
    {
        public DryTailings2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dry Out Tailings",
                    Localizer.DoStr("Dry Out Tailings"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WetTailingsItem), 10, true),
                        new IngredientElement(typeof(DirtItem), 10, true)
                    },
                    new CraftingElement<TailingsItem>(20)
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(DryTailings2Recipe), 12.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Dry Out Tailings"), typeof(DryTailings2Recipe));
            CraftingComponent.AddRecipe(typeof(NyElectricBlastFurnaceObject), this);
        }
    }
}
