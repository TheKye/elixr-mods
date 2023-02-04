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
    public partial class SweetPicklePearItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Pickle Pear"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Pickle Pear With Bitter Beats."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 4, Protein = 7, Vitamins = 7};
        public override float Calories                          { get { return 750; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(ZymologySkill), 1)]   
    public partial class SweetPicklePearRecipe : Recipe
    {
        public SweetPicklePearRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SweetPicklePearItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            { 
				new CraftingElement<BeetItem>(2),
				new CraftingElement<PricklyPearFruitItem>(2),	
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SweetPicklePearRecipe), Item.Get<SweetPicklePearItem>().UILink(), 15, typeof(ZymologySkill)); 
            this.Initialize(Localizer.DoStr("Sweet Pickle Pear"), typeof(SweetPicklePearRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}