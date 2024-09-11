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
    [LocDisplayName("Black Dye")]
    public partial class BlackDyeItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Black Dye used for dying certain items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class BlackDyeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlackDyeRecipe).Name,
            Assembly = typeof(BlackDyeRecipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Black",
            LocalizableName = Localizer.DoStr("Dye Base - Black"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("CoalItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("BlackDyeItem",4),
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

        static BlackDyeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlackDyeRecipe()
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
    public partial class BlackDye2Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlackDye2Recipe).Name,
            Assembly = typeof(BlackDye2Recipe).AssemblyQualifiedName,
            HiddenName = "Dye Base - Black - Alt",
            LocalizableName = Localizer.DoStr("Dye Base - Black 2"),
            IngredientList = new()
            {
                new EMIngredient("ClothItem", false, 5),
                new EMIngredient("CrushedShaleItem", false, 5),
                new EMIngredient("PlantFibersItem", false, 25),
                new EMIngredient("PaperItem", false, 5),
                new EMIngredient("BucketOfWaterItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("BlackDyeItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "DyeTableItem",
        };

        static BlackDye2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlackDye2Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(BlackDyeRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}
