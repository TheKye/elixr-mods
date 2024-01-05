using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;

namespace Eco.EM.Building.Greenhousing
{
    [RequiresSkill(typeof(FertilizersSkill), 0)]      
    public partial class GreenhouseKitRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreenhouseKitRecipe).Name,
            Assembly = typeof(GreenhouseKitRecipe).AssemblyQualifiedName,
            HiddenName = "Greenhouse Kit",
            LocalizableName = Localizer.DoStr("Greenhouse Kit"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 2),
                new EMIngredient("WoodBoard", true, 2),
                new EMIngredient("FiberFillerItem", false, 2),

            },
            ProductList = new()
            {
                new EMCraftable("GreenhouseKitItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 4,
            CraftTimeIsStatic = false,
            CraftingStation = "FarmersTableItem",
            RequiredSkillType = typeof(FertilizersSkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(FertilizersLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(FertilizersParallelSpeedTalent), typeof(FertilizersFocusedSpeedTalent) },
        };

        static GreenhouseKitRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreenhouseKitRecipe()
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
