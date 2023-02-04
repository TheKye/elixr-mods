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
    public partial class RightArrowObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Right Arrow"); } }
        public virtual Type RepresentedItemType { get { return typeof(RightArrowItem); } }

        protected override void Initialize()
        {

        }

        public override void Destroy()

        {
            base.Destroy();
        }
    }
    [Serialized, Weight(10), MaxStackSize(500)]
    public partial class RightArrowItem :
        WorldObjectItem<RightArrowObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Right Arrow"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("An arrow for directing traffic."); } }
        static RightArrowItem()
        {

        }
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public class RightArrowRecipe : Recipe
    {
        public RightArrowRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<RightArrowItem>(10)
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 5, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<GreyDyeItem>(1)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(RightArrowRecipe), Item.Get<RightArrowItem>().UILink(), 5, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Road Arrow - Right"), typeof(RightArrowRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}