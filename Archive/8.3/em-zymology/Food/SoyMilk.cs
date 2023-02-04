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
    public partial class SoyMilkItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Soy Milk"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Soy Milk Made From Beans."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 4, Protein = 5, Vitamins = 2};
        public override float Calories                          { get { return 55; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

	
	[RequiresSkill(typeof(ZymologySkill), 3)]   
    public partial class SoyMilkRecipe : Recipe
    {
        public SoyMilkRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SoyMilkItem>(3),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeansItem>(typeof(MillingSkill), 6, MillingSkill.MultiplicativeStrategy),
				new CraftingElement<CornSyrupItem>(typeof(ZymologySkill), 6, ZymologySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SoyMilkRecipe), Item.Get<SoyMilkItem>().UILink(), 8, typeof(CookingSkill)); 
            this.Initialize(Localizer.DoStr("Soy Milk"), typeof(SoyMilkRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}