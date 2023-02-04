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

    [RequiresSkill(typeof(IndustrySkill), 0)]
    public partial class PropaneTankRecipe : Recipe
    {
        public PropaneTankRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PropaneTankItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(IndustrySkill), 10, IndustrySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PropaneTankRecipe), Item.Get<PropaneTankItem>().UILink(), 3, typeof(IndustrySkill));
            this.Initialize(Localizer.DoStr("Propane Tank"), typeof(PropaneTankRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(IndustrySkill), 1)]
    public partial class PropaneTankBlock : PickupableBlock { }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(20000)]
    [Currency]
    public partial class PropaneTankItem : BlockItem<PropaneTankBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Propane Tank"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Propane Tanks"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("An empty propane tank ready to hold natural gas."); } }

    }

}