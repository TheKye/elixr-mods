using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Urchin Oil")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Cooking Oils")]
    public partial class UrchinOilItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Urchinest Urchin Oil");  

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 7, Protein = 4, Vitamins = 3 };
        public override float Calories                          => 65;  
        public override Nutrients Nutrition                     => nutrition;  
    }

    [RequiresSkill(typeof(ZymologySkill), 1)]   
    public partial class UrchinOilRecipe : RecipeFamily
    {
        public UrchinOilRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Urchin Oil",
                    Localizer.DoStr("Urchin Oil"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(UrchinItem), 5, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                    },
                    new CraftingElement<UrchinOilItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ZymologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(UrchinOilRecipe), 8, typeof(ZymologySkill), typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Urchin Oil"), typeof(UrchinOilRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}