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
    [LocDisplayName("Brown Paint")]
    public partial class BrownPaintItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Brown Paint Used for Painting Certain Items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 3)]
    public partial class BrownPaintRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BrownPaintRecipe).Name,
            Assembly = typeof(BrownPaintRecipe).AssemblyQualifiedName,
            HiddenName = "Paint Mix - Brown",
            LocalizableName = Localizer.DoStr("Paint Mix - Brown"),
            IngredientList = new()
            {
                new EMIngredient("BrownDyeItem", false, 2, true),
                new EMIngredient("PaintBaseItem", false, 2, true),
            },
            ProductList = new()
            {
                new EMCraftable("BrownPaintItem", 4),
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

        static BrownPaintRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BrownPaintRecipe()
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
