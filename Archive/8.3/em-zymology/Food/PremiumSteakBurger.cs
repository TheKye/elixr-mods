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
    [Weight(500)]                                          
    public partial class SteakBurgerItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Steak Burgr"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Premium Steak Burger."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 9, Protein = 11, Vitamins = 10};
        public override float Calories                          { get { return 1450; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 4)]    
    public partial class SteakBurgerRecipe : Recipe
    {
        public SteakBurgerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteakBurgerItem>(4),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WildMixItem>(5),
                new CraftingElement<BriocheItem>(5),
                new CraftingElement<PrimeCutItem>(5),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteakBurgerRecipe), Item.Get<SteakBurgerItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Premium Steak Burger"), typeof(SteakBurgerRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}