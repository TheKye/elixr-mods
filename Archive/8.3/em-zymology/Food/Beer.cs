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
    public partial class BeerItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Beer"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Organic Eco Friendly Fuel"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 9, Fat = 10, Protein = 13, Vitamins = 6};
        public override float Calories                          { get { return 1350; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(ZymologySkill), 4)]
    public partial class BeerRecipe : Recipe
    {
        public BeerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BeerItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WortItem>(typeof(ZymologySkill), 10, ZymologySkill.MultiplicativeStrategy),
                new CraftingElement<YeastItem>(typeof(ZymologySkill), 5, ZymologySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeerRecipe), Item.Get<BeerItem>().UILink(), 8, typeof(ZymologySkill));
            this.Initialize(Localizer.DoStr("Beer"), typeof(BeerRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}