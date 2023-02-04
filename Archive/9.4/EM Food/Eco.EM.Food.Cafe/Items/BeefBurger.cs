using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Beef Burger")]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeefBurgerItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Charred Beef Burger.");

        private static readonly FoodItemModel defaults = new(typeof(BeefBurgerItem), "Beef Burger", calories: 1350, carbs: 6, fat: 12, protein: 8, vitamins: 4);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static BeefBurgerItem()                        => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 3)]    
    public partial class BeefBurgerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BeefBurgerRecipe).Name,
            Assembly = typeof(BeefBurgerRecipe).AssemblyQualifiedName,
            HiddenName = "Beef Burger",
            LocalizableName = Localizer.DoStr("Beef Burger"),
            IngredientList = new()
            {
                new EMIngredient("Greens", true, 2),
                new EMIngredient("CrispyRollsItem", false, 4, true),
                new EMIngredient("CharredMeatItem", false, 2),
                new EMIngredient("TomatoItem", false, 2)
            },
            ProductList = new()
            {
                new EMCraftable("BeefBurgerItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 8,
            CraftTimeIsStatic = false,
            CraftingStation = "CastIronStoveItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static BeefBurgerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BeefBurgerRecipe()
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