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
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    [LocDisplayName("Chicken Carcass")]
    public partial class RawChickenItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription            => Localizer.DoStr("A Chicken Carcass");

        private static readonly FoodItemModel defaults          = new(typeof(RawChickenItem), "Chicken Carcass", shelflife: 24, calories: -500, carbs: 4, fat: 6, protein: 9, vitamins: 3);

        public override float Calories                          => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static RawChickenItem()                                 => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(ButcherySkill), 2)]
    public partial class ProcessChickenRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType                    = typeof(ProcessChickenRecipe).Name,
            Assembly                     = typeof(ProcessChickenRecipe).AssemblyQualifiedName,
            HiddenName                   = "Process Chicken",
            LocalizableName              = Localizer.DoStr("Process Chicken"),
            IngredientList               = new()
            {
                new EMIngredient("RawChickenItem", false, 1, true),
            },
            ProductList                  = new()
            {
                new EMCraftable(item: "RawChickenWingsItem", amount: 2),
                new EMCraftable(item: "RawChickenDrumsticksItem", amount: 2),
                new EMCraftable(item: "RawChickenBreastItem", amount: 2),
                new EMCraftable(item: "RawChickenThighItem", amount: 2),
                new EMCraftable(item: "WishBoneItem", amount: 1),
            },
            BaseExperienceOnCraft        = 1,
            BaseLabor                    = 50,
            LaborIsStatic                = false,
            BaseCraftTime                = 6,
            CraftTimeIsStatic            = false,
            CraftingStation              = "ButcheryTableItem",
            RequiredSkillType            = typeof(ButcherySkill),
            RequiredSkillLevel           = 2,
            IngredientImprovementTalents = typeof(ButcheryLavishResourcesTalent),
            SpeedImprovementTalents      = new Type[] { typeof(ButcheryFocusedSpeedTalent), typeof(ButcheryParallelSpeedTalent) },
        };

        static ProcessChickenRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ProcessChickenRecipe()
        {
            this.Recipes           = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories   = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes      = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}