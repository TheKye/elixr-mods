using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Boiled Egg")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class BoiledEggItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Boiled Egg");
        public override LocString DisplayDescription => Localizer.DoStr("Boiled Egg, Good for your tummy!");

        private static readonly FoodItemModel defaults = new(typeof(BoiledEggItem), "Boiled Egg", shelflife: 12, calories: 300, carbs: 2, fat: 5, protein: 7, vitamins: 1);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static BoiledEggItem() => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]
    public partial class BoiledEggRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BoiledEggRecipe).Name,
            Assembly = typeof(BoiledEggRecipe).AssemblyQualifiedName,
            HiddenName = "Boiled Eggs",
            LocalizableName = Localizer.DoStr("Boiled Eggs"),
            IngredientList = new()
            {
                new EMIngredient("EggItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BoiledEggItem", 1),
            },
            BaseExperienceOnCraft = 2,
            BaseLabor = 20,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CampfireItem",
            RequiredSkillType = typeof(CampfireCookingSkill),
            RequiredSkillLevel = 1,
            SpeedImprovementTalents = new Type[] { typeof(CampfireCookingParallelSpeedTalent), typeof(CampfireCookingFocusedSpeedTalent) },
        };

        static BoiledEggRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BoiledEggRecipe()
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
