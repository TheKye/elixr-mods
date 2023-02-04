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
    [LocDisplayName("Jerky")]
    public partial class JerkyItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Lean, salty and dry.");

        private static readonly FoodItemModel defaults = new(typeof(JerkyItem), "Jerky" ,calories: 700, carbs: 5, fat: 5, protein: 10, vitamins: 5);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => n;
        private Nutrients n                            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static JerkyItem()                             => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class JerkyRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType                      = typeof(JerkyRecipe).Name,
            Assembly                       = typeof(JerkyRecipe).AssemblyQualifiedName,
            HiddenName                     = "Jerky",
            LocalizableName                = Localizer.DoStr("Jerky"),
            IngredientList                 = new()
            {
               new EMIngredient("RawSausageItem", false, 5),
               new EMIngredient("CamasPasteItem", false, 5)
            },  
            ProductList                    = new()
            {
                new EMCraftable("JerkyItem"),
            },
            BaseExperienceOnCraft          = 1,
            BaseLabor                      = 50,
            LaborIsStatic                  = false,
            BaseCraftTime                  = 5,
            CraftTimeIsStatic              = false,
            CraftingStation                = "SmokehouseItem",
            RequiredSkillType              = typeof(CookingSkill),
            RequiredSkillLevel             = 2,
            IngredientImprovementTalents   = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents        = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static JerkyRecipe()               => EMRecipeResolver.AddDefaults(Defaults);

        public JerkyRecipe()
        {
            this.Recipes                   = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories           = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes              = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft         = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
