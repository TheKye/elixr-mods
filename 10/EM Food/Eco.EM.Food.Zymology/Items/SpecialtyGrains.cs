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

namespace Eco.EM.Food.Zymology
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Specialty Grains")]
    [Tag("Grain")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class SpecialtyGrainsItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Specialty grains, Ground With love.");

        private static readonly FoodItemModel defaults = new(typeof(SpecialtyGrainsItem), "Specialty Grains", shelflife: 24, calories: 250, carbs: 8, fat: 6, protein: 6, vitamins: 9);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => n;
        private Nutrients n => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static SpecialtyGrainsItem() => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(MillingSkill), 3)]
    public partial class SpecialtyGrainsRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SpecialtyGrainsRecipe).Name,
            Assembly = typeof(SpecialtyGrainsRecipe).AssemblyQualifiedName,
            HiddenName = "Specialty Grains",
            LocalizableName = Localizer.DoStr("Specialty Grains"),
            IngredientList = new()
            {
                new EMIngredient("CornItem", false, 4),
                new EMIngredient("WheatItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("SpecialtyGrainsItem", 2),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "MillItem",
            RequiredSkillType = typeof(MillingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(MillingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MillingParallelSpeedTalent), typeof(MillingFocusedSpeedTalent) },
        };

        static SpecialtyGrainsRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SpecialtyGrainsRecipe()
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