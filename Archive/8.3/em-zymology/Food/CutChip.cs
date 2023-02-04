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
    public partial class StraightCutChipsItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Straight Cut Chips"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Straight Cut Chips, Ready Cut for Cooking"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 4, Protein = 2, Vitamins = 2};
        public override float Calories                          { get { return 420; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class StraightCutChipsRecipe : Recipe
    {
        public StraightCutChipsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StraightCutChipsItem>(2),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CamasBulbItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(StraightCutChipsRecipe), Item.Get<StraightCutChipsItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Straight Cut Chips"), typeof(StraightCutChipsRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltStraightCutChipsRecipe : Recipe
    {
        public AltStraightCutChipsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StraightCutChipsItem>(2),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CamasBulbItem>(typeof(CookingSkill), 10, CookingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltStraightCutChipsRecipe), Item.Get<StraightCutChipsItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Straight Cut Chips"), typeof(AltStraightCutChipsRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}