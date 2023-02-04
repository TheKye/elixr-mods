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
    public partial class CoffeeItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Coffee"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("100% Real Coffee"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 7, Fat = 6, Protein = 5, Vitamins = 4};
        public override float Calories                          { get { return 850; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

	
	[RequiresSkill(typeof(CookingSkill), 2)]   
    public partial class CoffeeRecipe : Recipe
    {
        public CoffeeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CoffeeItem>(2),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GroundBeanItem>(typeof(CookingSkill), 5, CookingSkill.MultiplicativeStrategy), 
				new CraftingElement<SugarItem>(typeof(CookingSkill), 2, CookingSkill.MultiplicativeStrategy), 
				new CraftingElement<WholeMealMilkItem>(typeof(CookingSkill), 1, CookingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CoffeeRecipe), Item.Get<CoffeeItem>().UILink(), 8, typeof(CookingSkill)); 
            this.Initialize(Localizer.DoStr("Coffee"), typeof(CoffeeRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltCoffeeRecipe : Recipe
    {
        public AltCoffeeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CoffeeItem>(2),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GroundBeanItem>(typeof(CookingSkill), 5, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<SugarItem>(typeof(CookingSkill), 2, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<WholeMealMilkItem>(typeof(CookingSkill), 1, CookingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltCoffeeRecipe), Item.Get<CoffeeItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Coffee"), typeof(AltCoffeeRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}