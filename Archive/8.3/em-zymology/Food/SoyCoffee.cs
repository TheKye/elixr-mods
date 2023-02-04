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
    public partial class SoyCoffeeItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Soy Coffee"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Soy Coffee Yummmm Yummmmm"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 7, Protein = 6, Vitamins = 3};
        public override float Calories                          { get { return 880; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

	
	[RequiresSkill(typeof(CookingSkill), 2)]   
    public partial class SoyCoffeeRecipe : Recipe
    {
        public SoyCoffeeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SoyCoffeeItem>(2),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GroundBeanItem>(2), 
				new CraftingElement<MaltoseItem>(2), 
				new CraftingElement<SoyMilkItem>(2),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SoyCoffeeRecipe), Item.Get<SoyCoffeeItem>().UILink(), 8, typeof(CookingSkill)); 
            this.Initialize(Localizer.DoStr("Soy Coffee"), typeof(SoyCoffeeRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltSoyCoffeeRecipe : Recipe
    {
        public AltSoyCoffeeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SoyCoffeeItem>(2),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GroundBeanItem>(2),
                new CraftingElement<MaltoseItem>(2),
                new CraftingElement<SoyMilkItem>(2),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltSoyCoffeeRecipe), Item.Get<SoyCoffeeItem>().UILink(), 12, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Soy Coffee"), typeof(AltSoyCoffeeRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}