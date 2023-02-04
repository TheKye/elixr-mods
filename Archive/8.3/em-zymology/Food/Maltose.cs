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
    public partial class MaltoseItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Maltose"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Also known as maltobiose or malt sugar."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 4, Protein = 5, Vitamins = 2};
        public override float Calories                          { get { return 55; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

	
	[RequiresSkill(typeof(ZymologySkill), 3)]   
    public partial class MaltoseRecipe : Recipe
    {
        public MaltoseRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MaltoseItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WheatItem>(typeof(ZymologySkill), 4, ZymologySkill.MultiplicativeStrategy), 
				new CraftingElement<SugarItem>(typeof(ZymologySkill), 4, ZymologySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MaltoseRecipe), Item.Get<MaltoseItem>().UILink(), 8, typeof(ZymologySkill)); 
            this.Initialize(Localizer.DoStr("Maltose"), typeof(MaltoseRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}