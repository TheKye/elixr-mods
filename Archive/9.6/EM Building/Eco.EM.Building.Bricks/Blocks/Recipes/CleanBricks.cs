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
 
namespace Eco.EM.Building.Bricks
{
    public class CleanBricksRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CleanBricksRecipe).Name,
            Assembly = typeof(CleanBricksRecipe).AssemblyQualifiedName,
            HiddenName = "Clean Bricks",
            LocalizableName = Localizer.DoStr("Clean Bricks"),
            IngredientList = new()
            {
                new EMIngredient("Colored Bricks", true, 4, true),

            },
            ProductList = new()
            {
                new EMCraftable("BrickItem", 4),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 40,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "KilnItem",
        };

        static CleanBricksRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CleanBricksRecipe()
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
