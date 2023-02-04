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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Chicken In Bannock")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ChickenInBannockItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Deliciously Cooked Chicken Wrapped in a Bannock with some honey and Vegetables!");

        private static readonly FoodItemModel defaults = new(typeof(ChickenInBannockItem), "Chicken In Bannock", calories: 1200, carbs: 14, fat: 9, protein: 15, vitamins: 5);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static ChickenInBannockItem() => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 2)]
    public partial class ChickenAndBannockRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ChickenAndBannockRecipe).Name,
            Assembly = typeof(ChickenAndBannockRecipe).AssemblyQualifiedName,
            HiddenName = "Chicken In Bannock",
            LocalizableName = Localizer.DoStr("Chicken In Bannock"),
            IngredientList = new()
            {
                new EMIngredient("Chicken", true, 4),
                new EMIngredient("HoneyItem", false, 2, true),
                new EMIngredient("BannockItem", false, 2, true),
                new EMIngredient("Vegetable", true, 5)
            },
            ProductList = new()
            {
                new EMCraftable("ChickenInBannockItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 100,
            LaborIsStatic = false,
            BaseCraftTime = 5f,
            CraftTimeIsStatic = false,
            CraftingStation = "CampfireItem",
            RequiredSkillType = typeof(CampfireCookingSkill),
            RequiredSkillLevel = 2,
            SpeedImprovementTalents = new Type[] { typeof(CampfireCookingParallelSpeedTalent), typeof(CampfireCookingFocusedSpeedTalent) },
        };

        static ChickenAndBannockRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ChickenAndBannockRecipe()
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
