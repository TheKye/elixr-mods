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
    public partial class UrchinOilItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Urchin Oil"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Urchinest Urchin Oil"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 7, Protein = 4, Vitamins = 3};
        public override float Calories                          { get { return 65; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(ZymologySkill), 1)]   
    public partial class UrchinOilRecipe : Recipe
    {
        public UrchinOilRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<UrchinOilItem>(2),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(typeof(ZymologySkill), 5, ZymologySkill.MultiplicativeStrategy),  					
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(UrchinOilRecipe), Item.Get<UrchinOilItem>().UILink(), 8, typeof(ZymologySkill));
            this.Initialize(Localizer.DoStr("Urchin Oil"), typeof(UrchinOilRecipe));
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }
    }
}