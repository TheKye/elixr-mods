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
    public partial class BeefBurgerItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Beef Burgr"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Charred Beef Burger."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 12, Protein = 8, Vitamins = 4};
        public override float Calories                          { get { return 1350; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 4)]    
    public partial class BeefBurgerRecipe : Recipe
    {
        public BeefBurgerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BeefBurgerItem>(2),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BasicSaladItem>(2),
                new CraftingElement<CrispyRollsItem>(4),
                new CraftingElement<CharredMeatItem>(2),
                new CraftingElement<EggItem>(2)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeefBurgerRecipe), Item.Get<BeefBurgerItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Beef Burger"), typeof(BeefBurgerRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class AltBeefBurgerRecipe : Recipe
    {
        public AltBeefBurgerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BeefBurgerItem>(2),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BasicSaladItem>(2),
                new CraftingElement<CrispyRollsItem>(5),
                new CraftingElement<CharredMeatItem>(2),
                new CraftingElement<EggItem>(2)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltBeefBurgerRecipe), Item.Get<BeefBurgerItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Beef Burger"), typeof(AltBeefBurgerRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}