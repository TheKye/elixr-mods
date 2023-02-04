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
    public partial class ChickenWingsItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Chicken Wings"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Chicken Wings"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 6, Protein = 9, Vitamins = 3};
        public override float Calories                          { get { return 700; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class ChickenWingsRecipe : Recipe
    {
        public ChickenWingsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ChickenWingsItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
            new CraftingElement<RawChickenWingsItem>(2)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenWingsRecipe), Item.Get<ChickenWingsItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Chicken Wings"), typeof(ChickenWingsRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltChickenWingsRecipe : Recipe
    {
        public AltChickenWingsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ChickenWingsItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawChickenWingsItem>(4)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltChickenWingsRecipe), Item.Get<ChickenWingsItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Chicken Wings"), typeof(AltChickenWingsRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }

    [Serialized]
    [Weight(500)]
    public partial class RawChickenWingsItem :
       FoodItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Raw Chicken Wings"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Raw Chicken Wings"); } }

        private static Nutrients nutrition = new Nutrients() { Carbs = 4, Fat = 6, Protein = 9, Vitamins = 3 };
        public override float Calories { get { return -40; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }

    [RequiresSkill(typeof(ButcherySkill), 2)]
    public partial class RawChickenWingsRecipe : Recipe
    {
        public RawChickenWingsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RawChickenWingsItem>(2),
                new CraftingElement<ScrapMeatItem>(2)

            };
            this.Ingredients = new CraftingElement[]
            {
               new CraftingElement<RawChickenItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenWingsRecipe), Item.Get<ChickenWingsItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Raw Chicken Wings"), typeof(ChickenWingsRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}