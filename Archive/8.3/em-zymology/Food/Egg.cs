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
    public partial class EggItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Egg"); } }
		public override LocString DisplayNamePlural               { get { return Localizer.DoStr("Egg's"); } } 
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Egg's Gathered From The Chicken Coop."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 5, Protein = 7, Vitamins = 1};
        public override float Calories                          { get { return 60; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }
	
    [RequiresSkill(typeof(FarmingSkill), 2)]    
    public partial class EggsRecipe : Recipe
    {
        public EggsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<EggItem>(12),
               
            };
            this.Ingredients = new CraftingElement[]
            { 
				new CraftingElement<WheatItem>(typeof(FarmingSkill), 60, FarmingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(EggsRecipe), Item.Get<EggItem>().UILink(), 60, typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));  
            this.Initialize(Localizer.DoStr("Dozen Egg's"), typeof(EggsRecipe));
            CraftingComponent.AddRecipe(typeof(ChickenCoopObject), this);
        }
    }
}