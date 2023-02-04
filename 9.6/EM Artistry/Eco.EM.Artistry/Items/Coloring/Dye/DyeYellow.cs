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
    [LocDisplayName("Yellow Dye")]
    public partial class YellowDyeItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Yellow Dye Used for Dying Certain Items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class YellowDyeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(YellowDyeRecipe).Name,
            Assembly = typeof(YellowDyeRecipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Yellow",
            LocalizableName = Localizer.DoStr("Dye Base - Yellow"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("PineappleItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("YellowDyeItem", 4),
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

        static YellowDyeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public YellowDyeRecipe()
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
    public partial class YellowDye2Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(YellowDye2Recipe).Name,
            Assembly = typeof(YellowDye2Recipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Yellow - Alt",
            LocalizableName = Localizer.DoStr("Dye Base - Yellow - Alt"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("CornItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("YellowDyeItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "DyeTableItem",
        };

        static YellowDye2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public YellowDye2Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(YellowDyeRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class YellowDye3Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(YellowDye3Recipe).Name,
            Assembly = typeof(YellowDye3Recipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Yellow - Alt 2",
            LocalizableName = Localizer.DoStr("Dye Base - Yellow - Alt 2"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("SandItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("YellowDyeItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "DyeTableItem",
        };

        static YellowDye3Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public YellowDye3Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(YellowDyeRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}
