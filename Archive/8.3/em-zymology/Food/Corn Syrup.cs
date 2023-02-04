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
    public partial class CornSyrupItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Corn Syrup"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Corn syrup, also known as glucose syrup to confectioners"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 4, Protein = 5, Vitamins = 2};
        public override float Calories                          { get { return 55; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

	[RequiresSkill(typeof(ZymologySkill), 3)]   
    public partial class CornSyrupRecipe : Recipe
    {
        public CornSyrupRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CornSyrupItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(ZymologySkill), 4, ZymologySkill.MultiplicativeStrategy), 
				new CraftingElement<MaltoseItem>(typeof(ZymologySkill), 2, ZymologySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CornSyrupRecipe), Item.Get<CornSyrupItem>().UILink(), 8, typeof(CookingSkill)); 
            this.Initialize(Localizer.DoStr("Corn Syrup"), typeof(CornSyrupRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}