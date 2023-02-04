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
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class SlidingWindowObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Wooden Sliding Window"); } }
        public virtual Type RepresentedItemType { get { return typeof(SlidingWindowItem); } }
        protected override void Initialize()
        {
        }
        public override void Destroy()
        {
            base.Destroy();
        }
    }
    [Serialized]
    [ItemTier(2)]
    [Weight(600)]
    public partial class SlidingWindowItem :
    WorldObjectItem<SlidingWindowObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Wooden Sliding Window"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A vertical sliding window made out of wood and glass. Could be used as a shop window?"); } }
        static SlidingWindowItem()
        {

        }

    }
    [RequiresSkill(typeof(HewingSkill), 3)]
    public class SlidingWindowRecipe : Recipe
    {
        public SlidingWindowRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<SlidingWindowItem>(1),
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(HewingSkill), 8, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent)),
                new CraftingElement<GlassItem>(typeof(HewingSkill), 4, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent)),
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(SlidingWindowRecipe), Item.Get<SlidingWindowItem>().UILink(), 10, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Wooden Sliding Window"), typeof(SlidingWindowRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);

        }
    }

    [Serialized]
    [Wall, Solid]
    public class SlidingWindowObjectBlock : BuildingWorldObjectBlock
    {
        public SlidingWindowObjectBlock(WorldObject obj)
            : base(obj)
        { }

        protected SlidingWindowObjectBlock()
        { }
    }
}