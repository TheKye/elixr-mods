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
    [RequireComponent(typeof(HousingComponent))]
    public partial class CloudsPaintingObject :
        WorldObject,
        IRepresentsItem
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Painting of Clouds"); } }

        public virtual Type RepresentedItemType { get { return typeof(CloudsPaintingItem); } }
        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(CloudsPaintingItem.HousingVal);
        }

        public override void Destroy()

        {
            base.Destroy();
        }
    }
    [Serialized]
    [Weight(600)]
    public partial class CloudsPaintingItem :
        WorldObjectItem<CloudsPaintingObject>
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Painting of Clouds"); } }

        public override LocString DisplayDescription { get { return Localizer.DoStr("A Beautiful Painting of the clouds."); } }

        static CloudsPaintingItem()
        {

        }
        [TooltipChildren]
        public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = "Bedroom",
                    Val = 5,
                    TypeForRoomLimit = "Decorations",
                    DiminishingReturnPercent = 0.75f
                };
            }
        }
    }
    [RequiresSkill(typeof(TailoringSkill), 1)]
    public class CloudsPaintingRecipe : Recipe
    {
        public CloudsPaintingRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CloudsPaintingItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(TailoringSkill), 2, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 20, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
                new CraftingElement<BlueDyeItem>(2),
                new CraftingElement<GreyDyeItem>(2),
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(CloudsPaintingRecipe), Item.Get<CloudsPaintingItem>().UILink(), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Paninting of Clouds"), typeof(CloudsPaintingRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);

        }
    }
}