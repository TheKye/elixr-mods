using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.World.Blocks;

namespace Eco.EM.Mods.Smelting
{
    [RequiresSkill(typeof(SmeltingSkill), 1)]              // The skill and level of skill that will be required to create this recipe
    public partial class IronBarFromWetTailingsRecipe :    // The class name, important this is unique
        RecipeFamily                                       // The inherited class, Recipe Families can hold more than 1 recipe but this is advanced to do.
    {
        public IronBarFromWetTailingsRecipe()              // Constructor, same as class name.
        {
            this.Initialize(Localizer.DoStr("Iron Bar"), typeof(IronBarFromWetTailingsRecipe));   // Initialize the recipe family to be populated
            this.Recipes = new List<Recipe>                                                       // Add a new recipe to the Recipe Family's Recipe Property.
            {
                new Recipe(
                    "IronBarFromWetTailings",                                                     // A lookup name for the game
                    Localizer.DoStr("Iron Bar From Wet Tailings"),                                // What displays in game as the recipe name
                    new IngredientElement[]                                                       // Create a array of ingredients
                    {
                        new IngredientElement(typeof(WetTailingsBlock), 2, true),                 // each ingredient is added here inside the curly braces
                    },
                        new CraftingElement[]                                                     // Create a array of products
                    {
                        new CraftingElement<IronBarItem>(1),                                      // Each product is added in here inside the curly braces                 
                        new CraftingElement<SlagItem>(1)
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(SmeltingSkill), typeof(IronBarFromWetTailingsRecipe), this.UILink()); // The frist number is the calories required for crafting the recipe
            this.ExperienceOnCraft = 2;                                                                                                         // The number here is the experience gained for crafting the recipe
                                                                                                                                                // The craft time is in minutes (0.25f is a quarter of a minute or 15 seconds)
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronBarFromWetTailingsRecipe), this.UILink(), 0.25f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent)); 
            this.Initialize(Localizer.DoStr("Iron Bar"), typeof(IronBarFromWetTailingsRecipe));                                                 // Initialize again to ensure all data is set

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);                                                                      // Make sure the recipe is added to the specific crafting table
        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class CopperBarFromWetTailingsRecipe : 
        RecipeFamily
    {
        public CopperBarFromWetTailingsRecipe()
        {
            this.Initialize(Localizer.DoStr("Copper Bar"), typeof(CopperBarFromWetTailingsRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CopperBar",
                    Localizer.DoStr("Copper Bar"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(WetTailingsBlock), 2, true),
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<CopperBarItem>(1),
                    new CraftingElement<SlagItem>(1)
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(SmeltingSkill), typeof(CopperBarFromWetTailingsRecipe), this.UILink());
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperBarFromWetTailingsRecipe), this.UILink(), 0.25f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Copper Bar"), typeof(CopperBarFromWetTailingsRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}
