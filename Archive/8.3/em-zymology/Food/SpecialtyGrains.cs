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
    public partial class SpecialtyGrainsItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Specialty Grains"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Specialty grains, Ground With love."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 6, Protein = 6, Vitamins = 3};
        public override float Calories                          { get { return 250; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillingSkill), 3)]
    public class SpecialtyGrainsRecipe : Recipe
    {
        public SpecialtyGrainsRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<SpecialtyGrainsItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(MillingSkill), 4, MillingSkill.MultiplicativeStrategy), 
				new CraftingElement<WheatItem>(typeof(MillingSkill), 4, MillingSkill.MultiplicativeStrategy),
            };
            this.Initialize(Localizer.DoStr("Specialty Grains"), typeof(SpecialtyGrainsRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SpecialtyGrainsRecipe), this.UILink(), 5, typeof(MillingSkill));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}