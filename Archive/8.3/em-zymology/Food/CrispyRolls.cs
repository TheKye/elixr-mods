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
    public partial class CrispyRollsItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Crispy Rolls"); } }
        public override LocString DisplayNamePlural               { get { return Localizer.DoStr("Crispy Rolls"); } } 
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Crispy Rolls Baked With Heat."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 11, Fat = 6, Protein = 7, Vitamins = 4};
        public override float Calories                          { get { return 680; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BakingSkill), 2)]    
    public partial class CrispyRollsRecipe : Recipe
    {
        public CrispyRollsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CrispyRollsItem>(3),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(BakingSkill), 5, BakingSkill.MultiplicativeStrategy),
                new CraftingElement<YeastItem>(typeof(BakingSkill), 2, BakingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrispyRollsRecipe), Item.Get<CrispyRollsItem>().UILink(), 8, typeof(BakingSkill)); 
            this.Initialize(Localizer.DoStr("CrispyRolls"), typeof(CrispyRollsRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}