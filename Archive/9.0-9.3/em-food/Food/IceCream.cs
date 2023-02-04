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
    [LocDisplayName("Ice-Cream")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class IceCreamItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Olden Day Ice-Cream");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 9, Protein = 9, Vitamins = 5};
        public override float Calories                          => 1250;
        public override Nutrients Nutrition                     => nutrition;
    }

	[RequiresSkill(typeof(CookingSkill), 4)]   
    public partial class IceCreamRecipe : RecipeFamily
    {
        public IceCreamRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Ice-Cream",
                    Localizer.DoStr("Ice-Cream"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(EggItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(CreamItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(FullCreamMilkItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(BeanPasteItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(SugarItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<IceCreamItem>(4)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(IceCreamRecipe), 11, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("IceCream"), typeof(IceCreamRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class AltIceCreamRecipe : RecipeFamily
    {
        public AltIceCreamRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Ice-Cream",
                    Localizer.DoStr("Ice-Cream"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(EggItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(CreamItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(FullCreamMilkItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(BeanPasteItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(SugarItem), 8, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<IceCreamItem>(4)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltIceCreamRecipe), 15, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("IceCream"), typeof(AltIceCreamRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}