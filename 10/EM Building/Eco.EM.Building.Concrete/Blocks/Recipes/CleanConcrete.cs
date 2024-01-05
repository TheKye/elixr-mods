using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Building.Concrete
{
    public class CleanConcreteRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CleanConcreteRecipe).Name,
            Assembly = typeof(CleanConcreteRecipe).AssemblyQualifiedName,
            HiddenName = "Clean Concrete",
            LocalizableName = Localizer.DoStr("Clean Concrete"),
            IngredientList = new()
            {
                new EMIngredient("Colored Concrete", true, 4, true),

            },
            ProductList = new()
            {
                new EMCraftable("ReinforcedConcreteItem", 4),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 40,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "CementKilnItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static CleanConcreteRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CleanConcreteRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
