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
    public partial class MetalSlidingWindowObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Metal Sliding Window"); } }
        public virtual Type RepresentedItemType { get { return typeof(MetalSlidingWindowItem); } }
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
    public partial class MetalSlidingWindowItem :
        WorldObjectItem<MetalSlidingWindowObject>
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Metal Sliding Window"); } }

        public override LocString DisplayDescription { get { return Localizer.DoStr("A horizontal sliding window made out of metal and glass."); } }
        static MetalSlidingWindowItem()
        {
        }
    }
    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public class MetalSlidingWindowRecipe : Recipe
    {
        public MetalSlidingWindowRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MetalSlidingWindowItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 10, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
                new CraftingElement<GlassItem>(typeof(SmeltingSkill), 4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(MetalSlidingWindowRecipe), Item.Get<MetalSlidingWindowItem>().UILink(), 10, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Metal Sliding Window"), typeof(MetalSlidingWindowRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);

        }
    }
}