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
    public partial class HoneyItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Honey"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Eco Fresh, Reserve Honey."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 4, Protein = 5, Vitamins = 2};
        public override float Calories                          { get { return 55; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

	
	[RequiresSkill(typeof(ZymologySkill), 2)]   
    public partial class HoneyRecipe : Recipe
    {
        public HoneyRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<HoneyItem>(3),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HuckleberriesItem>(typeof(ZymologySkill), 10, ZymologySkill.MultiplicativeStrategy), 
				new CraftingElement<SimpleSyrupItem>(typeof(ZymologySkill), 10, ZymologySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(HoneyRecipe), Item.Get<HoneyItem>().UILink(), 8, typeof(CookingSkill)); 
            this.Initialize(Localizer.DoStr("Honey"), typeof(HoneyRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}