using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [LocDisplayName("Fizzy Pineapple")]
    [Weight(300)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FizzyPineappleItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Fizzy Pineapple");
        public override LocString DisplayDescription => Localizer.DoStr("Sugary and fizzy pineapple drink.");

        private static readonly FoodItemModel defaults = new(typeof(FizzyPineappleItem), "Cheese", calories: 600, carbs: 20, fat: 0, protein: 0, vitamins: 0);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static FizzyPineappleItem() => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class FizzyPineappleRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(FizzyPineappleRecipe).Name,
            Assembly = typeof(FizzyPineappleRecipe).AssemblyQualifiedName,
            HiddenName = "Fizzy Pineapple",
            LocalizableName = Localizer.DoStr("Fizzy Pineapple"),
            IngredientList = new()
            {
                new EMIngredient("CO2CanisterItem", false, 1),
                new EMIngredient("PineappleJuiceItem", false, 10),
                new EMIngredient("Sugar", true, 2),
            },
            ProductList = new()
            {
                new EMCraftable("FizzyPineappleItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 0.5f,
            CraftTimeIsStatic = false,
            CraftingStation = "LaboratoryItem",
            RequiredSkillType = typeof(CookingSkill),
        };

        static FizzyPineappleRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public FizzyPineappleRecipe()
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
