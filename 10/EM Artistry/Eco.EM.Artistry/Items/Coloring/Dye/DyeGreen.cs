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
    [LocDisplayName("Green Dye")]
    public partial class GreenDyeItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Green Dye Used for Dying Certain Items.");
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class GreenDyeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreenDyeRecipe).Name,
            Assembly = typeof(GreenDyeRecipe).AssemblyQualifiedName,
            HiddenName = "Dye Mix - Green",
            LocalizableName = Localizer.DoStr("Dye Mix - Green"),
            IngredientList = new()
            {
                new EMIngredient("YellowDyeItem", false, 1, true),
                new EMIngredient("BlueDyeItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GreenDyeItem", 2),
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

        static GreenDyeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreenDyeRecipe()
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
