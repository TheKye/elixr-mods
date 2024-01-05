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
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Milkshake")]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class MilkShakeItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Super Super Sweet, Flavored MilkShake");

        private static readonly FoodItemModel defaults = new(typeof(MilkShakeItem), "Milkshake", calories: 1200, carbs: 8, fat: 10, protein: 9, shelflife:12, vitamins: 9);

        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static MilkShakeItem()                         => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class MilkShakeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(MilkShakeRecipe).Name,
            Assembly = typeof(MilkShakeRecipe).AssemblyQualifiedName,
            HiddenName = "Milkshake",
            LocalizableName = Localizer.DoStr("Milkshake"),
            IngredientList = new()
            {
                new EMIngredient("IceCreamItem", false, 4),
                new EMIngredient("Milk", true, 4),
                new EMIngredient("Sugar", true, 4)
            },
            ProductList = new()
            {
                new EMCraftable("MilkShakeItem", 4),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 20,
            CraftTimeIsStatic = false,
            CraftingStation = "CastIronStoveItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static MilkShakeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public MilkShakeRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}