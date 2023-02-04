namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 0)]      
    public partial class LogsCharcoalRecipe : Recipe
    {
        public LogsCharcoalRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharcoalItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(AdvancedSmeltingSkill), 45, AdvancedSmeltingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LogsCharcoalRecipe), Item.Get<CharcoalItem>().UILink(), 1, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent));    
            this.Initialize(Localizer.DoStr("Charcoal"), typeof(LogsCharcoalRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}