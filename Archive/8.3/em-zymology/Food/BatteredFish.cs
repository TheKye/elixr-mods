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
    public partial class BatteredFishItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Battered Fish"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Fresh Battered Fish"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 6, Protein = 9, Vitamins = 8};
        public override float Calories                          { get { return 1100; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 4)] 
    public class BatteredFishRecipe : Recipe
    {
        public BatteredFishRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<BatteredFishItem>(5),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(5),
                new CraftingElement<BatterItem>(5), 
            };
            this.Initialize(Localizer.DoStr("Battered Fish"), typeof(BatteredFishRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BatteredFishRecipe), this.UILink(), 2, typeof(CookingSkill));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 4)]
    public class AltBatteredFishRecipe : Recipe
    {
        public AltBatteredFishRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<BatteredFishItem>(5),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(8),
                new CraftingElement<BatterItem>(8),
            };
            this.Initialize(Localizer.DoStr("Battered Fish"), typeof(AltBatteredFishRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltBatteredFishRecipe), this.UILink(), 2, typeof(CookingSkill));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}