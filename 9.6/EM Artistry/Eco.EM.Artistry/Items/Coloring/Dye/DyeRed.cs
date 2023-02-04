using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System;
using System.Linq;

namespace Eco.EM.Artistry
{
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Red Dye")]
    public partial class RedDyeItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Red Dye Used for Dying Certain Items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class RedDyeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RedDyeRecipe).Name,
            Assembly = typeof(RedDyeRecipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Red",
            LocalizableName = Localizer.DoStr("Dye Base - Red"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("TomatoItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("RedDyeItem", 4),
                new EMCraftable("BucketItem")
            },
            BaseExperienceOnCraft = 2,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "DyeTableItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent) },
        };

        static RedDyeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RedDyeRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class RedDye2Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RedDye2Recipe).Name,
            Assembly = typeof(RedDye2Recipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Red - Alt",
            LocalizableName = Localizer.DoStr("Dye Base - Red - Alt"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("BeetItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("RedDyeItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "DyeTableItem",
        };

        static RedDye2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RedDye2Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(RedDyeRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class RedDye3Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RedDye3Recipe).Name,
            Assembly = typeof(RedDye3Recipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Red - Alt 2",
            LocalizableName = Localizer.DoStr("Dye Base - Red - Alt 2"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("CrushedSandstoneItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("RedDyeItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "DyeTableItem",
        };

        static RedDye3Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RedDye3Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(RedDyeRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}
