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
    public partial class GroundBeanItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Ground Bean"); } }
        public override LocString DisplayNamePlural               { get { return Localizer.DoStr("Ground Beans"); } } 
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Ground beans To Perfection For the Perfect Cup"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 6, Protein = 5, Vitamins = 0};
        public override float Calories                          { get { return 40; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillingSkill), 3)]    
    public partial class GroundBeanRecipe : Recipe
    {
        public GroundBeanRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GroundBeanItem>(3),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeansItem>(typeof(MillingSkill), 15, MillingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GroundBeanRecipe), Item.Get<GroundBeanItem>().UILink(), 5, typeof(MillingSkill)); 
            this.Initialize(Localizer.DoStr("Ground Bean"), typeof(GroundBeanRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}