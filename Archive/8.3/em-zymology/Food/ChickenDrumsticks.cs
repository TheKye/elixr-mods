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
    public partial class ChickenDrumsticksItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Chicken Drumsticks"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Chicken Drumsticks"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 8, Protein = 9, Vitamins = 3};
        public override float Calories                          { get { return 700; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class ChickenDrumsticksRecipe : Recipe
    {
        public ChickenDrumsticksRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ChickenDrumsticksItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
            new CraftingElement<RawChickenDrumsticksItem>(2)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenDrumsticksRecipe), Item.Get<ChickenDrumsticksItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Chicken Drumsticks"), typeof(ChickenDrumsticksRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }

    [RequiresSkill(typeof(CookingSkill), 2)]
    public partial class AltChickenDrumsticksRecipe : Recipe
    {
        public AltChickenDrumsticksRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ChickenDrumsticksItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawChickenDrumsticksItem>(4)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltChickenDrumsticksRecipe), Item.Get<ChickenDrumsticksItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Chicken Drumsticks"), typeof(AltChickenDrumsticksRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }

    [Serialized]
    [Weight(500)]
    public partial class RawChickenDrumsticksItem :
       FoodItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Raw Chicken Drumsticks"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Raw Chicken Drumsticks"); } }

        private static Nutrients nutrition = new Nutrients() { Carbs = 4, Fat = 12, Protein = 9, Vitamins = 3 };
        public override float Calories { get { return -50; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }

    [RequiresSkill(typeof(ButcherySkill), 2)]
    public partial class RawChickenDrumsticksRecipe : Recipe
    {
        public RawChickenDrumsticksRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RawChickenDrumsticksItem>(2),
                new CraftingElement<ScrapMeatItem>(2)

            };
            this.Ingredients = new CraftingElement[]
            {
               new CraftingElement<RawChickenItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenDrumsticksRecipe), Item.Get<ChickenDrumsticksItem>().UILink(), 8, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("Raw Chicken Drumsticks"), typeof(ChickenDrumsticksRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}