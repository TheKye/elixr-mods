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
    using Eco.Shared.Serialization;
    using Eco.Shared.Localization;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class AheadSignObject :
        WorldObject,
        IRepresentsItem
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Ahead Sign"); } }

        public virtual Type RepresentedItemType { get { return typeof(AheadSignItem); } }

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
    public partial class AheadSignItem :
        WorldObjectItem<AheadSignObject>
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Ahead Sign"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Sign For Something Ahead."); } }

        static AheadSignItem()
        {

        }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public class AheadSignRecipe : Recipe
    {
        public AheadSignRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<AheadSignItem>()
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(SmeltingSkill), 8, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
                new CraftingElement<BlueDyeItem>(2)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(AheadSignRecipe), Item.Get<AheadSignItem>().UILink(), 5, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Ahead Sign"), typeof(AheadSignRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}