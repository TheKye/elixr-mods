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
    public partial class WholeMealMilkItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Full Cream Milk"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Full Cream Milk."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 1, Protein = 4, Vitamins = 2};
        public override float Calories                          { get { return 55; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(ZymologySkill), 3)]   
    public partial class WholeMealMilkRecipe : Recipe
    {
        public WholeMealMilkRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WholeMealMilkItem>(3),
                new CraftingElement<CreamItem>(3),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WholeMealItem>(typeof(ZymologySkill), 5, ZymologySkill.MultiplicativeStrategy),
                new CraftingElement<CornSyrupItem>(typeof(ZymologySkill), 5, ZymologySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WholeMealMilkRecipe), Item.Get<WholeMealMilkItem>().UILink(), 30, typeof(ZymologySkill)); 
            this.Initialize(Localizer.DoStr("Full Cream Milk"), typeof(WholeMealMilkRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}