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
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(AttachmentComponent))]

    public partial class HandWaterPumpObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Hand Water Pump"); } }

        public virtual Type RepresentedItemType { get { return typeof(HandWaterPumpItem); } }


        protected override void Initialize()
        {
            this.GetComponent<PublicStorageComponent>().Initialize(4);
            this.GetComponent<PublicStorageComponent>().Inventory.AddInvRestriction(new SpecificItemTypesRestriction(new System.Type[] { typeof(BucketItem), typeof(BucketOfWaterItem) }));
        }


        static HandWaterPumpObject()
        {

            AddOccupancy<HandWaterPumpObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock)),
            new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)),
            });
        }



        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    public partial class HandWaterPumpItem : WorldObjectItem<HandWaterPumpObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Hand Water Pump"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Hand pump used for gathering water."); } }

        static HandWaterPumpItem()
        {

        }

    }


    [RequiresSkill(typeof(MortaringSkill), 5)]
    public partial class WoodWaterPumpRecipe : Recipe
    {
        public WoodWaterPumpRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<HandWaterPumpItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(20),
                new CraftingElement<MortaredStoneItem>(30),
            };
            this.ExperienceOnCraft = 25;
            this.CraftMinutes = new ConstantValue(25f);
            this.Initialize(Localizer.DoStr("Hand Water Pump"), typeof(WoodWaterPumpRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }

}