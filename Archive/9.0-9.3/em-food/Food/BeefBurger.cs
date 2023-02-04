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
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Beef Burger")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeefBurgerItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Charred Beef Burger.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 12, Protein = 8, Vitamins = 4};
        public override float Calories                          => 1350;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 4)]    
    public partial class BeefBurgerRecipe : RecipeFamily
    {
        public BeefBurgerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Beef Burger",
                    Localizer.DoStr("Beef Burger"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BasicSaladItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(CrispyRollsItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(CharredMeatItem), 2, typeof(CookingSkill)),
                        new IngredientElement(typeof(EggItem), 2, typeof(CookingSkill))
                    },
                    new CraftingElement<BeefBurgerItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeefBurgerRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Beef Burger"), typeof(BeefBurgerRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class AltBeefBurgerRecipe : RecipeFamily
    {
        public AltBeefBurgerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Beef Burger",
                    Localizer.DoStr("Beef Burger"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BasicSaladItem), 2, typeof(CookingSkill)),
                        new IngredientElement(typeof(CrispyRollsItem), 4, typeof(CookingSkill)),
                        new IngredientElement(typeof(CharredMeatItem), 2, typeof(CookingSkill)),
                        new IngredientElement(typeof(EggItem), 2, typeof(CookingSkill))
                    },
                    new CraftingElement<BeefBurgerItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltBeefBurgerRecipe), 8, typeof(CookingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Beef Burger"), typeof(AltBeefBurgerRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}