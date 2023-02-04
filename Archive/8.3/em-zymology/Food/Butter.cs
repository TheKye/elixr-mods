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
    public partial class ButterItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Butter"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Turning Butter."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 7, Protein = 1, Vitamins = 4};
        public override float Calories                          { get { return 65; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(ZymologySkill), 1)]   
    public partial class ButterRecipe : Recipe
    {
        public ButterRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ButterItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CreamItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy), 									
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ButterRecipe), Item.Get<ButterItem>().UILink(), 20, typeof(ZymologySkill)); 
            this.Initialize(Localizer.DoStr("Butter"), typeof(ButterRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}