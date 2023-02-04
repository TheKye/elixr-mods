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
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class BedroomChestObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Bedroom Chest"); } }

        public virtual Type RepresentedItemType { get { return typeof(BedroomChestItem); } }


        protected override void Initialize()
        {
            base.PostInitialize();

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(32);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            this.GetComponent<HousingComponent>().Set(BedroomChestItem.HousingVal);
            this.GetComponent<LinkComponent>().Initialize(1);
        }


        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [Weight(600)]
    public partial class BedroomChestItem :
        WorldObjectItem<BedroomChestObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Bedroom Chest"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Chest For Storing your personal items."); } }

        static BedroomChestItem()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = "Bedroom",
                    Val = 2,
                    TypeForRoomLimit = "Storage",
                    DiminishingReturnPercent = 0.5f
                };
            }
        }

        [RequiresSkill(typeof(TailoringSkill), 2)]
        public partial class BedroomChestRecipe : Recipe
        {
            public BedroomChestRecipe()
            {
                this.Products = new CraftingElement[]
                {
                new CraftingElement<BedroomChestItem>(),
                };

                this.Ingredients = new CraftingElement[]
                {
                new CraftingElement<LumberItem>(typeof(TailoringSkill), 25, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 20, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<LeatherHideItem>(typeof(TailoringSkill), 10, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent))
                };
                this.ExperienceOnCraft = 2;
                this.CraftMinutes = CreateCraftTimeValue(typeof(BedroomChestRecipe), Item.Get<BedroomChestItem>().UILink(), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
                this.Initialize(Localizer.DoStr("Bedroom Chest"), typeof(BedroomChestRecipe));
                CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
            }
        }
    }
}