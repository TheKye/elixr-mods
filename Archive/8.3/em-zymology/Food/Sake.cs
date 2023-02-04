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
    public partial class SakeItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Sake"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Body And Mind Original Sake"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 2, Protein = 7, Vitamins = 6};
        public override float Calories                          { get { return 850; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(ZymologySkill), 2)]   
    public partial class SakeRecipe : Recipe
    {
        public SakeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SakeItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            { 
				new CraftingElement<RiceItem>(4),
				new CraftingElement<CornItem>(4),	
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SakeRecipe), Item.Get<SakeItem>().UILink(), 26, typeof(ZymologySkill)); 
            this.Initialize(Localizer.DoStr("Sake"), typeof(VietnameseSoupRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}