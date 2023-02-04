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
    public partial class BriocheItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Brioche"); } }
        public override LocString DisplayNamePlural               { get { return Localizer.DoStr("Brioche"); } } 
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("A Delicious, Honey Soft Roll."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 14, Fat = 8, Protein = 4, Vitamins = 4};
        public override float Calories                          { get { return 750; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BakingSkill), 3)]    
    public partial class BriocheRecipe : Recipe
    {
        public BriocheRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BriocheItem>(2),
               
            };
            this.Ingredients = new CraftingElement[]
            {
				new CraftingElement<HoneyItem>(typeof(BakingSkill), 6, BakingSkill.MultiplicativeStrategy),
                new CraftingElement<FlourItem>(typeof(BakingSkill), 6, BakingSkill.MultiplicativeStrategy),
                new CraftingElement<YeastItem>(typeof(BakingSkill), 3, BakingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BriocheRecipe), Item.Get<BriocheItem>().UILink(), 8, typeof(BakingSkill)); 
            this.Initialize(Localizer.DoStr("Brioche"), typeof(BriocheRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}