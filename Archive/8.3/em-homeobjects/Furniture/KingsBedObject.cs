namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Components.VehicleModules;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Math;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Networking;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Interactions;
    using Eco.Core.Controller;
    using Eco.Shared.Items;
    using Eco.Core.Tests;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Gameplay.Property;
    using System.Threading;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class KingsBedObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Kings Bed"); } }
        public virtual Type RepresentedItemType { get { return typeof(KingsBedItem); } }
        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(KingsBedItem.HousingVal);
        }
        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, AutogenClass, ViewDisplayNameAttribute("Bed")]
    [Weight(600)]
    public partial class KingsBedItem :
            WorldObjectItem<KingsBedObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Kings Bed"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Big Beautiful King Sized Bed Fit For a King."); } }
        static KingsBedItem()
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
                    Val = 10,
                    TypeForRoomLimit = "Bedroom",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }
    }

    [RequiresSkill(typeof(TailoringSkill), 6)]
    public partial class KingsBedRecipe : Recipe
    {
        public KingsBedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<KingsBedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BedFrameItem>(1),
                new CraftingElement<ClothItem>(typeof(TailoringSkill), 100, TailoringSkill.MultiplicativeStrategy, typeof(TailoringLavishResourcesTalent)),
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(KingsBedRecipe), Item.Get<KingsBedItem>().UILink(), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Kings Bed"), typeof(KingsBedRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}