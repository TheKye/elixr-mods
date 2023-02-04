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
    public partial class BatterItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Batter"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Batter"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 6, Protein = 9, Vitamins = 3};
        public override float Calories                          { get { return 450; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class BatterRecipe : Recipe
    {
        public BatterRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BatterItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(2),
                new CraftingElement<WholeMealMilkItem>(1),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BatterRecipe), Item.Get<BatterItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Batter"), typeof(BatterRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltBatterRecipe : Recipe
    {
        public AltBatterRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BatterItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(4),
                new CraftingElement<WholeMealMilkItem>(2),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltBatterRecipe), Item.Get<BatterItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Batter"), typeof(AltBatterRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}