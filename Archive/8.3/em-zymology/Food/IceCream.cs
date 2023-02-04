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
    public partial class IceCreamItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("IceCream"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Olden Day IceCream"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 9, Protein = 9, Vitamins = 5};
        public override float Calories                          { get { return 1250; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

	[RequiresSkill(typeof(CookingSkill), 4)]   
    public partial class IceCreamRecipe : Recipe
    {
        public IceCreamRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IceCreamItem>(4),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<EggItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy), 
				new CraftingElement<CreamItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy), 
				new CraftingElement<WholeMealMilkItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy),
				new CraftingElement<BeanPasteItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy),
				new CraftingElement<SugarItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IceCreamRecipe), Item.Get<IceCreamItem>().UILink(), 11, typeof(CookingSkill)); 
            this.Initialize(Localizer.DoStr("IceCream"), typeof(IceCreamRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class AltIceCreamRecipe : Recipe
    {
        public AltIceCreamRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IceCreamItem>(4),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<EggItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<CreamItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<WholeMealMilkItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<BeanPasteItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<SugarItem>(typeof(CookingSkill), 8, CookingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltIceCreamRecipe), Item.Get<IceCreamItem>().UILink(), 15, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("IceCream"), typeof(AltIceCreamRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}