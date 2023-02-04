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
    public partial class RightSignObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Keep Right Sign"); } }
        public virtual Type RepresentedItemType { get { return typeof(RightSignItem); } }
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
    public partial class RightSignItem :
 
        WorldObjectItem<RightSignObject>

    {
        public override LocString DisplayName { get { return Localizer.DoStr("Keep Right Sign"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Keep right Sight"); } }

        static RightSignItem()
        {

        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public class RightSignRecipe : Recipe
    {
        public RightSignRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<RightSignItem>()
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(SmeltingSkill), 8, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
                new CraftingElement<BlueDyeItem>(2)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(RightSignRecipe), Item.Get<RightSignItem>().UILink(), 5, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Keep Right Sign"), typeof(RightSignRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}