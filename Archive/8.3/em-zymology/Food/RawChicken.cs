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
    public partial class RawChickenItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Raw Chicken"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("A Raw Chicken"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 6, Protein = 9, Vitamins = 3};
        public override float Calories                          { get { return -500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(FarmingSkill), 2)]    
    public partial class RawChickenRecipe : Recipe
    {
        public RawChickenRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RawChickenItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(FarmingSkill), 80, FarmingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RawChickenRecipe), Item.Get<RawChickenItem>().UILink(), 10, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Raw Chicken"), typeof(RawChickenRecipe));
            CraftingComponent.AddRecipe(typeof(ChickenCoopObject), this);
        }
    }
}