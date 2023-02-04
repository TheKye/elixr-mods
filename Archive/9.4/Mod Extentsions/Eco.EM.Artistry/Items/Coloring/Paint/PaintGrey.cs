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

namespace Eco.EM.Artistry
{
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Grey Paint")]
    public partial class GreyPaintItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Grey Paint Used for Painting Certain Items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 3)]
    public partial class GreyPaintRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreyPaintRecipe).Name,
            Assembly = typeof(GreyPaintRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Mix - Grey",
            LocalizableName = Localizer.DoStr("Paint Mix - Grey"),
            IngredientList = new()
            {
                new EMIngredient("GreyDyeItem", false, 2, true),
                new EMIngredient("PaintBaseItem", false, 2, true),
            },
            ProductList = new()
            {
                new EMCraftable("GreyPaintItem", 4),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "DyeTableItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(PaintingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent) },
        };

        static GreyPaintRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreyPaintRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
