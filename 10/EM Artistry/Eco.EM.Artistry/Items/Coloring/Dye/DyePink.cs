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
    [LocDisplayName("Pink Dye")]
    public partial class PinkDyeItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Pink Dye Used for Dying Certain Items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class PinkDyeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PinkDyeRecipe).Name,
            Assembly = typeof(PinkDyeRecipe).AssemblyQualifiedName,
            HiddenName = "Dye Mix - Pink",
            LocalizableName = Localizer.DoStr("Dye Mix - Pink"),
            IngredientList = new()
            {
                new EMIngredient("RedDyeItem", false, 1, true),
                new EMIngredient("WhiteDyeItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("PinkDyeItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "DyeTableItem",
            RequiredSkillType = typeof(PaintingSkill),
            RequiredSkillLevel = 2,
            SpeedImprovementTalents = new Type[] { typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent) },
        };

        static PinkDyeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PinkDyeRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Localizer.DoStr(Defaults.LocalizableName), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
