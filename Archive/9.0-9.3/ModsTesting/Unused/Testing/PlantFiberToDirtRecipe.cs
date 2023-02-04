using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;

namespace Eco.EM.CustomisedRequests
{
    public partial class PlantFiberToDirtRecipe : RecipeFamily
    {
        public PlantFiberToDirtRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "PackDirt",
                    Localizer.DoStr("Pack Dirt"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PlantFibersItem), 20, true),
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<DirtItem>(1),
                    })
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Pack Dirt"), typeof(PlantFiberToDirtRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
