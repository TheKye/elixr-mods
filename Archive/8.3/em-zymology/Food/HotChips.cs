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
    public partial class BatteredHotChipsItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Battered Hot Chips"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Battered Hot Chips"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 12, Protein = 10, Vitamins = 10};
        public override float Calories                          { get { return 1100; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 3)]    
    public partial class BatteredHotChipsRecipe : Recipe
    {
        public BatteredHotChipsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BatteredHotChipsItem>(4),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BatterItem>(4),
                new CraftingElement<StraightCutChipsItem>(4),
                new CraftingElement<UrchinOilItem>(2)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BatteredHotChipsRecipe), Item.Get<BatteredHotChipsItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Battered Hot Chips"), typeof(BatteredHotChipsRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
    [RequiresSkill(typeof(CookingSkill), 3)]
    public partial class AltBatteredHotChipsRecipe : Recipe
    {
        public AltBatteredHotChipsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BatteredHotChipsItem>(4),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BatterItem>(4),
                new CraftingElement<StraightCutChipsItem>(4),
                new CraftingElement<UrchinOilItem>(2)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltBatteredHotChipsRecipe), Item.Get<BatteredHotChipsItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Battered Hot Chips"), typeof(AltBatteredHotChipsRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}