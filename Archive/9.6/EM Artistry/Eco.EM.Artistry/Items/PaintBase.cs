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
    [LocDisplayName("Paint Base")]
    public partial class PaintBaseItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("This is the base used to make paint from dyes");
    }

    [RequiresSkill(typeof(CookingSkill), 0)]
    public partial class PaintBaseRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBaseRecipe).Name,
            Assembly = typeof(PaintBaseRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Base",
            LocalizableName = Localizer.DoStr("Paint Base"),
            IngredientList = new()
            {
                new EMIngredient("CerealGermItem", false, 10),
                new EMIngredient("BucketOfWaterItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("PaintBaseItem", 4),
                new EMCraftable("BucketItem")
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "CastIronStoveItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent) },
        };

        static PaintBaseRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBaseRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 0)]
    public partial class PaintBase2Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBase2Recipe).Name,
            Assembly = typeof(PaintBase2Recipe).AssemblyQualifiedName,
            HiddenName = "Paint Base - Bean Paste",
            LocalizableName = Localizer.DoStr("Paint Base - Bean Paste"),
            IngredientList = new()
            {
                new EMIngredient("BeanPasteItem", false, 10),
                new EMIngredient("BucketOfWaterItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("PaintBaseItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "CastIronStoveItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent) },
        };

        static PaintBase2Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBase2Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintBaseRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }


    [RequiresSkill(typeof(CookingSkill), 0)]
    public partial class PaintBase3Recipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBase3Recipe).Name,
            Assembly = typeof(PaintBase3Recipe).AssemblyQualifiedName,
            HiddenName = "Paint Base - Camas Paste",
            LocalizableName = Localizer.DoStr("Paint Base - Camas Paste"),
            IngredientList = new()
            {
                new EMIngredient("CamasPasteItem", false, 10),
                new EMIngredient("BucketOfWaterItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("PaintBaseItem", 4),
                new EMCraftable("BucketItem")
            },
            CraftingStation = "CastIronStoveItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent) },
        };

        static PaintBase3Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBase3Recipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PaintBaseRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}
