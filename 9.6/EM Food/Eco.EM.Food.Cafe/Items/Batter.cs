using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.ModKit.Internal;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Batter")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class BatterItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Batter, Useful for Coating certain foods and frying them up!");

        private static readonly FoodItemModel defaults = new(typeof(BatterItem), "Batter", calories: 450, carbs: 4, fat: 6, protein: 9, vitamins: 3, shelflife: 8);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife                  => EMFoodItemResolver.Obj.ResolveShelfLife(this);

        static BatterItem()                            => EMFoodItemResolver.AddDefaults(defaults);

        public string Consume(Player player)
        {
            var stomach = player.User.Stomach;
            stomach.ClearCalories(player.User.Player);
            stomach.Contents.RemoveAll(entry => true);
            stomach.RecalcAverageNutrients();

            player.MsgLocStr("Bad elk meat?");
            return "";
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class BatterRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BatterRecipe).Name,
            Assembly = typeof(BatterRecipe).AssemblyQualifiedName,
            HiddenName = "Batter",
            LocalizableName = Localizer.DoStr("Batter"),
            IngredientList = new()
            {
                new EMIngredient("FlourItem", false, 2),
                new EMIngredient("Egg", true, 1),
                new EMIngredient("CornStarchItem", false, 6)
            },
            ProductList = new()
            {
                new EMCraftable("BatterItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 7,
            CraftTimeIsStatic = false,
            CraftingStation = "KitchenItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CookingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) },
        };

        static BatterRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BatterRecipe()
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