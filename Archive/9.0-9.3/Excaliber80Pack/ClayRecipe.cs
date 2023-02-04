using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;

// Collaboration with Excaliber80:
//
// .cs file conversion to library to allow for load order compatibility
namespace Eco.Mods.TechTree
{
    public class ClayRecipe : RecipeFamily
    {
        public ClayRecipe()
        {
            this.Initialize(Localizer.DoStr("Clay Recipe"), typeof(ClayRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Clay",
                    Localizer.DoStr("Clay"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(DirtItem), 3, true),
                        new IngredientElement(typeof(BucketOfWaterItem), 1, true),
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<ClayItem>(),
                        new CraftingElement<BucketItem>()
                    })
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(20);
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }
    }
}