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

    public partial class RoadMetalBarrierObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Metal Barrier"); } }
        public virtual Type RepresentedItemType { get { return typeof(RoadMetalBarrierItem); } }
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
    public partial class RoadMetalBarrierItem :
        WorldObjectItem<RoadMetalBarrierObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Metal Barrier"); } }
 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Metal Barrier To Work as A Boundry."); } }
        static RoadMetalBarrierItem()
        {

        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 3)]
    public class RoadMetalBarrierRecipe : Recipe
    {
        public RoadMetalBarrierRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<RoadMetalBarrierItem>()
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 20, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent))
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(RoadMetalBarrierRecipe), Item.Get<RoadMetalBarrierItem>().UILink(), 5, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Metal Barrier"), typeof(RoadMetalBarrierRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}