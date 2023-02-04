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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class TrafficConeObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Traffic Cone"); } }
        public virtual Type RepresentedItemType { get { return typeof(TrafficConeItem); } }

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
    public partial class TrafficConeItem :
        WorldObjectItem<TrafficConeObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Traffic Cone"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Traffic Cone."); } }
        static TrafficConeItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public class TrafficConeRecipe : Recipe
    {
        public TrafficConeRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<TrafficConeItem>()
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 15, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<CelluloseFiberItem>(typeof(TailoringSkill), 10, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<OrangeDyeItem>(2)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(TrafficConeRecipe), Item.Get<TrafficConeItem>().UILink(), 5, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Traffic Cone"), typeof(TrafficConeRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}