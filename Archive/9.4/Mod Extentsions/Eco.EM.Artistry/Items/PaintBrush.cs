using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Artistry
{
    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class PaintBrushRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintBrushRecipe).Name,
            Assembly = typeof(PaintBrushRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Brush",
            LocalizableName = Localizer.DoStr("Paint Brush"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 2),
                new EMIngredient("FurPeltItem", false, 2),
            },
            ProductList = new()
            {
                new EMCraftable("PaintBrushItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 25,
            LaborIsStatic = false,
            BaseCraftTime = .5f,
            CraftTimeIsStatic = false,
            CraftingStation = "WorkbenchItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) },
        };

        static PaintBrushRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintBrushRecipe()
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
    public partial class AltPaintBrushRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AltPaintBrushRecipe).Name,
            Assembly = typeof(AltPaintBrushRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Brush",
            LocalizableName = Localizer.DoStr("Paint Brush"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 2),
                new EMIngredient("FurPeltItem", false, 2),
            },
            ProductList = new()
            {
                new EMCraftable("PaintBrushItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 25,
            LaborIsStatic = false,
            BaseCraftTime = .5f,
            CraftTimeIsStatic = false,
            CraftingStation = "ArtStationItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) },
        };

        static AltPaintBrushRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltPaintBrushRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [Weight(50)]
    [MaxStackSize(10)]
    [LocDisplayName("Paint Brush")]
    public partial class PaintBrushItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Can be used in simple art.");
    }
}
