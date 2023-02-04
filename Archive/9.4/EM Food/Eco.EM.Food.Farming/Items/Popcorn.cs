using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Zymology
{
    [Serialized]  
    [Weight(100)]
    [MaxStackSize(100)]
    [LocDisplayName("Popcorn")]
    public partial class PopcornItem : FoodItem, IConfigurableFoodItem
    {
		public override LocString DisplayNamePlural    => Localizer.DoStr("Popcorn");
        public override LocString DisplayDescription   => Localizer.DoStr("Everybody loves popcorn.");

        private static readonly FoodItemModel defaults = new(typeof(PopcornItem), "Popcorn", calories: 600, carbs: 12, fat: 8, protein: 0, vitamins: 3);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static PopcornItem()                           => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]    
    public partial class PopcornRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PopcornRecipe).Name,
            Assembly = typeof(PopcornRecipe).AssemblyQualifiedName,
            HiddenName = "Popcorn",
            LocalizableName = Localizer.DoStr("Popcorn"),
            IngredientList = new()
            {
                new EMIngredient("CornSeedItem", false, 10),
            },
            ProductList = new()
            {
                new EMCraftable("PopcornItem", 3),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 10,
            LaborIsStatic = false,
            BaseCraftTime = .5f,
            CraftTimeIsStatic = false,
            CraftingStation = "CampfireItem",
            RequiredSkillType = typeof(CampfireCookingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(CampfireCookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CampfireCookingParallelSpeedTalent), typeof(CampfireCookingFocusedSpeedTalent) },
        };

        static PopcornRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PopcornRecipe()
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