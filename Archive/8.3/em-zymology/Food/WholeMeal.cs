namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [Weight(200)]                                          
    public partial class WholeMealItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("WholeMeal"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("WholeMeal Made From Wheat."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 2, Protein = 4, Vitamins = 1};
        public override float Calories                          { get { return 60; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillingSkill), 3)]    
    public partial class WholeMealRecipe : Recipe
    {
        public WholeMealRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WholeMealItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WheatItem>(typeof(MillingSkill), 5, MillingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WholeMealRecipe), Item.Get<WholeMealItem>().UILink(), 5, typeof(MillingSkill)); 
            this.Initialize(Localizer.DoStr("WholeMeal"), typeof(WholeMealRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}