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
    [LocDisplayName("White Dye")]
    public partial class WhiteDyeItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("White Dye Used for Dying Certain Items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class WhiteDyeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WhiteDyeRecipe).Name,
            Assembly = typeof(WhiteDyeRecipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - White",
            LocalizableName = Localizer.DoStr("Dye Base - White"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("WhiteDyeItem", 4),
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

        static WhiteDyeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WhiteDyeRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Localizer.DoStr(Defaults.LocalizableName), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class WhiteDye2Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WhiteDye2Recipe).Name,
            Assembly = typeof(WhiteDye2Recipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - White - Alt",
            LocalizableName = Localizer.DoStr("Dye Base - White - Alt"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("CrushedLimestoneItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("WhiteDyeItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "DyeTableItem",
        };

        static WhiteDye2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WhiteDye2Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(WhiteDyeRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}
