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
    public partial class CustomerParkingSignObject :
        WorldObject,
        IRepresentsItem
    {
 
        public override LocString DisplayName { get { return Localizer.DoStr("Customer Parking Sign"); } }
        public virtual Type RepresentedItemType { get { return typeof(CustomerParkingSignItem); } }
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
    public partial class CustomerParkingSignItem :
        WorldObjectItem<CustomerParkingSignObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Customer Parking Sign"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Customer Parking Sign."); } }

        static CustomerParkingSignItem()
        {

        }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public class CustomerParkingSignRecipe : Recipe
    {
        public CustomerParkingSignRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<CustomerParkingSignItem>()
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(SmeltingSkill), 8, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
                new CraftingElement<BlueDyeItem>(2)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(CustomerParkingSignRecipe), Item.Get<CustomerParkingSignItem>().UILink(), 5, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Customer Parking Sign"), typeof(CustomerParkingSignRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}