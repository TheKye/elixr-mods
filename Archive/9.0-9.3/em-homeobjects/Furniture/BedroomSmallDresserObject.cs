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
    [Serialized, Weight(600), LocDisplayName("Bedroom Small Dresser"), MaxStackSize(100)]
    public partial class BedroomSmallDresserItem : WorldObjectItem<BedroomSmallDresserObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Small Dresser for Storing your Clothes");

        [TooltipChildren] public HousingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() { Category = HousingValue.RoomCategory.Bedroom, Val = 3, TypeForRoomLimit = "Storage", DiminishingReturnPercent = 0.5f };
    }

    [RequiresSkill(typeof(TailoringSkill), 2)]
    public partial class BedroomSmallDresserRecipe : RecipeFamily
    {
        public BedroomSmallDresserRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Bedroom Small Dresser",
                    Localizer.DoStr("Bedroom Small Dresser"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Lumber", 25, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                        new IngredientElement(typeof(ClothItem), 20,typeof(TailoringSkill),typeof(TailoringLavishResourcesTalent))
                    },
                    new CraftingElement<BedroomSmallDresserItem>()
                    )
                };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BedroomSmallDresserRecipe), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Bedroom Small Dresser"), typeof(BedroomSmallDresserRecipe));
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
    public partial class BedroomSmallDresserObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Bedroom Small Dresser");
        public virtual Type RepresentedItemType => typeof(BedroomSmallDresserItem);

        static BedroomSmallDresserObject()
        {
            AddOccupancy<BedroomSmallDresserObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i( 0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(32);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            this.GetComponent<HousingComponent>().Set(BedroomSmallDresserItem.HousingVal);

            base.PostInitialize();
        }

        public override void Destroy() => base.Destroy();
    }
}