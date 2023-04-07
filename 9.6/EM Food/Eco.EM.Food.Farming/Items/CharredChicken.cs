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

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Charred Chicken")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class CharredChickenItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Charred Chicken, I'm Hungry!");

        private static readonly FoodItemModel defaults = new(typeof(CharredChickenItem), "Charred Chicken", shelflife: 12, calories: 900, carbs: 0, fat: 8, protein: 15, vitamins: 0);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static CharredChickenItem() => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 2)]
    public partial class CharredChickenRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CharredChickenRecipe).Name,
            Assembly = typeof(CharredChickenRecipe).AssemblyQualifiedName,
            HiddenName = "Charred Chicken",
            LocalizableName = Localizer.DoStr("Charred Chicken"),
            IngredientList = new()
            {
                new EMIngredient("RawChickenItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("CharredChickenItem", 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 20,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CampfireItem",
            RequiredSkillType = typeof(CampfireCookingSkill),
            RequiredSkillLevel = 2,
            SpeedImprovementTalents = new Type[] { typeof(CampfireCookingParallelSpeedTalent), typeof(CampfireCookingFocusedSpeedTalent) },
        };

        static CharredChickenRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CharredChickenRecipe()
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
