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
    public partial class WortItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Wort"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Boot Runners Wort."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 7, Protein = 9, Vitamins = 2};
        public override float Calories                          { get { return 400; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class WortRecipe : Recipe
    {
        public WortRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WortItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SpecialtyGrainsItem>(typeof(CookingSkill), 5, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<MaltoseItem>(typeof(ZymologySkill), 5, ZymologySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WortRecipe), Item.Get<WortItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Wort"), typeof(WortRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}