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
    public partial class MilkShakeItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("MilkShake"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Super Super Sweet, Flavored MilkShake"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 10, Protein = 9, Vitamins = 9};
        public override float Calories                          { get { return 1480; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

	[RequiresSkill(typeof(CookingSkill), 4)]   
    public partial class MilkShakeRecipe : Recipe
    {
        public MilkShakeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MilkShakeItem>(2),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HoneyItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy), 
				new CraftingElement<IceCreamItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy), 
				new CraftingElement<WholeMealMilkItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
				new CraftingElement<CornSyrupItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
				new CraftingElement<SugarItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MilkShakeRecipe), Item.Get<MilkShakeItem>().UILink(), 12, typeof(CookingSkill)); 
            this.Initialize(Localizer.DoStr("MilkShake"), typeof(MilkShakeRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
    [RequiresSkill(typeof(CookingSkill), 4)]
    public partial class AltMilkShakeRecipe : Recipe
    {
        public AltMilkShakeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MilkShakeItem>(2),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HoneyItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<IceCreamItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<WholeMealMilkItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<CornSyrupItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
                new CraftingElement<SugarItem>(typeof(CookingSkill), 4, CookingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltMilkShakeRecipe), Item.Get<MilkShakeItem>().UILink(), 20, typeof(CookingSkill));
            this.Initialize(Localizer.DoStr("MilkShake"), typeof(AltMilkShakeRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}