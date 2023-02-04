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
    public partial class VietnameseSoupItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Vietnamese Soup"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Vietnamese Soup"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 7, Fat = 3, Protein = 3, Vitamins = 6};
        public override float Calories                          { get { return 750; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]   
    public partial class VietnameseSoupRecipe : Recipe
    {
        public VietnameseSoupRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<VietnameseSoupItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<UrchinOilItem>(typeof(CookingSkill), 2, CookingSkill.MultiplicativeStrategy), 
				new CraftingElement<BeansItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
				new CraftingElement<CornItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),	
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(VietnameseSoupRecipe), Item.Get<VietnameseSoupItem>().UILink(), 13, typeof(CookingSkill)); 
            this.Initialize(Localizer.DoStr("Vietnamese Soup"), typeof(VietnameseSoupRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltVietnameseSoupRecipe : Recipe
    {
        public AltVietnameseSoupRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<VietnameseSoupItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<UrchinOilItem>(typeof(CookingSkill), 2, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<BeansItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<CornItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltVietnameseSoupRecipe), Item.Get<VietnameseSoupItem>().UILink(), 20, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Vietnamese Soup"), typeof(AltVietnameseSoupRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}