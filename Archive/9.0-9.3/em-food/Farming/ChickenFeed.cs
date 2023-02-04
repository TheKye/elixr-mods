using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Farming
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Chicken Feed")]
    [Tag("Feed")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ChickenFeedItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("Chicken Feed, used to feed your chickens");
    }

    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class ChickenFeedRecipe : RecipeFamily
    {
        public ChickenFeedRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ChickenFeed",
                    Localizer.DoStr("Chicken Feed"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CornItem), 5, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(PlantFibersItem), 20, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<ChickenFeedItem>()
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenFeedRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Chicken Feed"), typeof(ChickenFeedRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
