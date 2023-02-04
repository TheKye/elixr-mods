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

    [RequiresSkill(typeof(FarmingSkill), 1)]   
    public partial class EggRecipe : Recipe
    {
        public EggRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<EggItem>(6),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(FarmingSkill), 30, FarmingSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(EggsRecipe), Item.Get<EggItem>().UILink(), 30, typeof(FarmingSkill));    
            this.Initialize(Localizer.DoStr("1/2 Dozen Egg's"), typeof(EggRecipe));
            CraftingComponent.AddRecipe(typeof(ChickenCoopObject), this);
        }
    }
}