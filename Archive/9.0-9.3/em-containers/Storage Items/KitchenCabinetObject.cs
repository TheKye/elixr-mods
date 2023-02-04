using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Storage
{
    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class KitchenCabinetObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Kitchen Cabinet"); } }

        public virtual Type RepresentedItemType { get { return typeof(KitchenCabinetItem); } }

        static KitchenCabinetObject()
        {
            WorldObject.AddOccupancy<KitchenCabinetObject>(new List<BlockOccupancy>()
            {
                    new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i( 0, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i( 0, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(40);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            this.GetComponent<HousingComponent>().Set(KitchenCabinetItem.HousingVal);
            this.GetComponent<LinkComponent>().Initialize(9);

            base.PostInitialize();
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(600)]
    [LocDisplayName("Kitchen Cabinet")]
    public partial class KitchenCabinetItem : WorldObjectItem<KitchenCabinetObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Cabinet for storing food in in your kitchen."); } }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.Kitchen,
                    Val = 6,
                    TypeForRoomLimit = "Food Storage",
                    DiminishingReturnPercent = 0.5f
                };
            }
        }
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class KitchenCabinetRecipe : RecipeFamily
    {
        public KitchenCabinetRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Kitchen Cabinet",
                    Localizer.DoStr("Kitchen Cabinet"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Lumber", 30, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement(typeof(ClothItem), 10,typeof(CarpentrySkill),typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement(typeof(LeatherHideItem), 5, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent))
                    },
                    new CraftingElement<KitchenCabinetItem>()
                    )
                };
            this.ExperienceOnCraft = 10;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(KitchenCabinetRecipe), 10, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Kitchen Cabinet"), typeof(KitchenCabinetRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}