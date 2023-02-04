using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;

namespace Eco.EM.Greenhousing
{
    [RequiresSkill(typeof(FertilizersSkill), 0)]      
    public partial class GreenhouseKitRecipe :
        RecipeFamily
    {
        public GreenhouseKitRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GreenhouseKit",
                    Localizer.DoStr("Greenhouse Kit"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 2, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)), 
                    new IngredientElement("WoodBoard", 2, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<GreenhouseKitItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 1;  

            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(FertilizersSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreenhouseKitRecipe), 4, typeof(FertilizersSkill), typeof(FertilizersFocusedSpeedTalent), typeof(FertilizersParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Greenhouse Kit"), typeof(GreenhouseKitRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

}
