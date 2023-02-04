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

    [RequiresSkill(typeof(MechanicsSkill), 0)]
    public partial class RecycleStoneRampUpgradeRecipe : Recipe
    {
        public RecycleStoneRampUpgradeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AsphaltRampItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(typeof(MechanicsSkill), 3, MechanicsSkill.MultiplicativeStrategy),
                new CraftingElement<StoneRampItem>(typeof(MechanicsSkill), 1, MechanicsSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecycleStoneRampUpgradeRecipe), Item.Get<AsphaltRampItem>().UILink(), 5, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Asphalt Ramp"), typeof(RecycleStoneRampUpgradeRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }
    [Serialized]
    [Constructed]
    [Road(1.4f)]
    [RequiresSkill(typeof(MechanicsSkill), 0)]
    public partial class AsphaltRampBlock :
    Block
    {
    }
}