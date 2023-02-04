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
    [LocDisplayName("Milkshake")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class MilkShakeItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Super Super Sweet, Flavored MilkShake");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 10, Protein = 9, Vitamins = 9};
        public override float Calories                          => 1480;
        public override Nutrients Nutrition                     => nutrition;
    }

	[RequiresSkill(typeof(CookingSkill), 4)]   
    public partial class MilkShakeRecipe : RecipeFamily
    {
        public MilkShakeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Milkshake",
                    Localizer.DoStr("Milkshake"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(HoneyItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(IceCreamItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(FullCreamMilkItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(CornSyrupItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(SugarItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<MilkShakeItem>(4)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MilkShakeRecipe), 12, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Milkshake"), typeof(MilkShakeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class AltMilkShakeRecipe : RecipeFamily
    {
        public AltMilkShakeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Milkshake",
                    Localizer.DoStr("Milkshake"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(HoneyItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(IceCreamItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(FullCreamMilkItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(CornSyrupItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(SugarItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<MilkShakeItem>(3)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltMilkShakeRecipe), 20, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("MilkShake"), typeof(AltMilkShakeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}