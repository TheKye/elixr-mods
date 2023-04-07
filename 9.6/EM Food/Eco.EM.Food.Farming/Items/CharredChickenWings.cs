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
    [LocDisplayName("Charred Chicken Wings")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class CharredChickenWingsItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Charred Chicken Wing, What a nice light snack");

        private static readonly FoodItemModel defaults = new(typeof(CharredChickenWingsItem), "Charred Chicken Wings", shelflife: 12, calories: 300, carbs: 0, fat: 5, protein: 6, vitamins: 0);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static CharredChickenWingsItem() => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 2)]
    public partial class CharredChickenWingsRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(CharredChickenWingsRecipe).Name,
            Assembly = typeof(CharredChickenWingsRecipe).AssemblyQualifiedName,
            HiddenName = "Charred Chicken Wings",
            LocalizableName = Localizer.DoStr("Charred Chicken Wings"),
            IngredientList = new()
            {
                new EMIngredient("RawChickenWingsItem", false, 2, true),
            },
            ProductList = new()
            {
                new EMCraftable("CharredChickenWingsItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 20,
            LaborIsStatic = false,
            BaseCraftTime = 1f,
            CraftTimeIsStatic = false,
            CraftingStation = "CampfireItem",
            RequiredSkillType = typeof(CampfireCookingSkill),
            RequiredSkillLevel = 2,
            SpeedImprovementTalents = new Type[] { typeof(CampfireCookingParallelSpeedTalent), typeof(CampfireCookingFocusedSpeedTalent) },
        };

        static CharredChickenWingsRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public CharredChickenWingsRecipe()
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
