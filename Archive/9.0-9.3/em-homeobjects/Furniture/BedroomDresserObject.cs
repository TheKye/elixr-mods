using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Furniture
{
    [Serialized, Weight(600), LocDisplayName("Bedroom Dresser")]
    [MaxStackSize(100)]
    public partial class BedroomDresserItem : WorldObjectItem<BedroomDresserObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Large Dresser for storing your clothes");

        [TooltipChildren] public HousingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() { Category = HousingValue.RoomCategory.Bedroom, Val = 5, TypeForRoomLimit = "Storage", DiminishingReturnPercent = 0.5f };
    }

    [RequiresSkill(typeof(TailoringSkill), 5)]
    public partial class BedroomDresserRecipe : RecipeFamily
    {
        public BedroomDresserRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Bedroom Dresser",
                    Localizer.DoStr("Bedroom Dresser"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Lumber", 40, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                        new IngredientElement(typeof(ClothItem), 20,typeof(TailoringSkill),typeof(TailoringLavishResourcesTalent))
                    },
                    new CraftingElement<BedroomDresserItem>()
                    )
                };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BedroomDresserRecipe), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Bedroom Dresser"), typeof(BedroomDresserRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class BedroomDresserObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Bedroom Dresser");
        public virtual Type RepresentedItemType => typeof(BedroomDresserItem);

        static BedroomDresserObject()
        {
            AddOccupancy<BedroomDresserObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),

            });
        }

        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(48);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            this.GetComponent<HousingComponent>().Set(BedroomDresserItem.HousingVal);

            base.PostInitialize();
        }

        public override void Destroy() => base.Destroy();
    }
}