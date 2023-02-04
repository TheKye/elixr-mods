namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(SmeltingSkill), 0)] 
    public class SiftGoldRecipe : Recipe
    {
        public SiftGoldRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<GoldOreItem>(1f)
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(SmeltingSkill), 100, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)), 
            };
            this.Initialize(Localizer.DoStr("Sift for Gold"), typeof(SiftGoldRecipe));
            this.ExperienceOnCraft = 2;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(SiftGoldRecipe), this.UILink(), 1f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));    
            CraftingComponent.AddRecipe(typeof(OreWasherObject), this);
        }
    }
}