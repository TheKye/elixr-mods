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
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Gameplay.Pipes.LiquidComponents;

    [RequiresSkill(typeof(OilDrillingSkill), 0)]
    public partial class NaturalGasRecipe : Recipe
    {
        public NaturalGasRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<NaturalGasItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PropaneTankItem>(1),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(NaturalGasRecipe), Item.Get<NaturalGasItem>().UILink(), 4, typeof(OilDrillingSkill));
            this.Initialize(Localizer.DoStr("Natural Gas"), typeof(NaturalGasRecipe));

            CraftingComponent.AddRecipe(typeof(PumpJackObject), this);
        }
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(OilDrillingSkill), 3)]
    public partial class NaturalGasBlock : PickupableBlock { }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Fuel(60000)]
    [Currency]
    public partial class NaturalGasItem : BlockItem<NaturalGasBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Natural Gas Tank"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Natural Gas Tank"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Natural Gas which is pumped from deep within our planet to use as a cleaner fuel."); } }

    }

}