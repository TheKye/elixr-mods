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
    [LocDisplayName("Blue Dye")]
    public partial class BlueDyeItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Blue Dye Used for Dying Certain Items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class BlueDyeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlueDyeRecipe).Name,
            Assembly = typeof(BlueDyeRecipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Blue",
            LocalizableName = Localizer.DoStr("Dye Base - Blue"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("HuckleberriesItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("BlueDyeItem", 4),
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

        static BlueDyeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlueDyeRecipe()
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
    public partial class BlueDye2Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlueDye2Recipe).Name,
            Assembly = typeof(BlueDye2Recipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Blue Alt",
            LocalizableName = Localizer.DoStr("Dye Base - Blue Alt"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("CamasBulbItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("BlueDyeItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "DyeTableItem",
        };

        static BlueDye2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlueDye2Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(BlueDyeRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class BlueDye3Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlueDye3Recipe).Name,
            Assembly = typeof(BlueDye3Recipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Blue - Alt 2",
            LocalizableName = Localizer.DoStr("Dye Base - Blue - Alt 2"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("CrushedBasaltItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("BlueDyeItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "DyeTableItem",
        };

        static BlueDye3Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlueDye3Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(BlueDyeRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}
