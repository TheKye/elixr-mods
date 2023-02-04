namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class WaterTankWhiteBarrierObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("White Water Tank Barrier"); } }
        public virtual Type RepresentedItemType { get { return typeof(WaterTankWhiteBarrierItem); } }
        protected override void Initialize()
        {

        }
        public override void Destroy()
        {
            base.Destroy();
        }
    }
    [Serialized]
    [Weight(600)]
    public partial class WaterTankWhiteBarrierItem :
        WorldObjectItem<WaterTankWhiteBarrierObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("White Water Tank Barrier"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A White Water Tank Type Barrier."); } }
        static WaterTankWhiteBarrierItem()
        {

        }
    }

    [RequiresSkill(typeof(CementSkill), 0)]
    public partial class WaterTankWhiteBarrierRecipe : Recipe
    {
        public WaterTankWhiteBarrierRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WaterTankWhiteBarrierItem>(),
                new CraftingElement<BucketItem>(5)
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(5),
                new CraftingElement<GreyDyeItem>(5),
                new CraftingElement<BucketOfWaterItem>(5)
            };
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(WaterTankWhiteBarrierRecipe), Item.Get<WaterTankWhiteBarrierItem>().UILink(), 2, typeof(CementSkill), typeof(CementFocusedSpeedTalent), typeof(CementParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Water Tank Barrier - White"), typeof(WaterTankWhiteBarrierRecipe));
            CraftingComponent.AddRecipe(typeof(CementKilnObject), this);
        }
    }
}