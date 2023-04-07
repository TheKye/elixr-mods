using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Food.FoodSmoking
{
    [Serialized]
    [Weight(300)]
    [MaxStackSize(100)]
    [LocDisplayName("Turkey Jerky")]
    public partial class TurkeyJerkyItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Rich, salty and dry.");

        private static readonly FoodItemModel defaults = new(typeof(TurkeyJerkyItem), "Turkey Jerky", shelflife: 24, calories: 500, carbs: 5, fat: 10, protein: 10, vitamins: 5);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static TurkeyJerkyItem()                       => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 3)]
    public partial class TurkeyJerkyRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TurkeyJerkyRecipe).Name,
            Assembly = typeof(TurkeyJerkyRecipe).AssemblyQualifiedName,
            HiddenName = "Turkey Jerky",
            LocalizableName = Localizer.DoStr("Turkey Jerky"),
            IngredientList = new()
            {
                new EMIngredient("TurkeyCarcassItem", false, 1),
                new EMIngredient("CamasPasteItem", false, 10),
            },
            ProductList = new()
            {
                new EMCraftable("TurkeyJerkyItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "SmokehouseItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static TurkeyJerkyRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TurkeyJerkyRecipe()
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
