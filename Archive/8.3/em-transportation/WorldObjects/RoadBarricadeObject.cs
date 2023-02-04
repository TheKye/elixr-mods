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
    public partial class RoadBarricadeObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Road Barricade"); } }
        public virtual Type RepresentedItemType { get { return typeof(RoadBarricadeItem); } }

        protected override void Initialize()
        {

        }

        public override void Destroy()

        {
            base.Destroy();
        }
    }
    [Serialized, Weight(5000), MaxStackSize(20)]
    public partial class RoadBarricadeItem :
        WorldObjectItem<RoadBarricadeObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Road Barricade"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Barricade for blocking off roads."); } }
        static RoadBarricadeItem()
        {

        }
    }

    [RequiresSkill(typeof(LumberSkill), 1)]
    public class RoadBarricadeRecipe : Recipe
    {
        public RoadBarricadeRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<RoadBarricadeItem>(10)
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberSkill), 5, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),
                new CraftingElement<BlackDyeItem>(2),
                new CraftingElement<YellowDyeItem>(2)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(RoadBarricadeRecipe), Item.Get<RoadBarricadeItem>().UILink(), 5, typeof(LumberSkill), typeof(LumberFocusedSpeedTalent), typeof(LumberParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Road Barricade"), typeof(RoadBarricadeRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}