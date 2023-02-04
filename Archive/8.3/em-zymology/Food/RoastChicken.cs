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
    public partial class RoastChickenItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Roast Chicken"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Roasted Chicken"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 12, Protein = 12, Vitamins = 3};
        public override float Calories                          { get { return 1500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class RoastChickenRecipe : Recipe
    {
        public RoastChickenRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RoastChickenItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawChickenItem>(),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RoastChickenRecipe), Item.Get<RoastChickenItem>().UILink(), 30, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Roast Chicken"), typeof(RoastChickenRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltRoastChickenRecipe : Recipe
    {
        public AltRoastChickenRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RoastChickenItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawChickenItem>()
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltRoastChickenRecipe), Item.Get<RoastChickenItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Roast Chicken"), typeof(AltRoastChickenRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}