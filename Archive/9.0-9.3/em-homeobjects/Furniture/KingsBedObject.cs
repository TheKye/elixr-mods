using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Core.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Math;

namespace Eco.EM.Furniture
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class KingsBedObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Kings Bed");
        public virtual Type RepresentedItemType => typeof(KingsBedItem); 

        static KingsBedObject()
        {
            AddOccupancy<KingsBedObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i( 0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i( 0, 0, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i( 0, 0, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 0, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i( 0, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i( 0, 1, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i( 0, 1, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 1, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 1, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i( 0, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i( 0, 2, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i( 0, 2, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 2, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(-1, 2, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(KingsBedItem.HousingVal);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(600), MaxStackSize(10), LocDisplayName("Kings Bed")] 
    [Tag("Housing", 1)] 
    public partial class KingsBedItem : WorldObjectItem<KingsBedObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A big beautiful king sized bed fit for a king."); 

        [TooltipChildren] public HousingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() {Category = HousingValue.RoomCategory.Bedroom, Val = 6, TypeForRoomLimit = "Bedroom", DiminishingReturnPercent = 0.8f};
    }

    [RequiresSkill(typeof(TailoringSkill), 6)]
    public partial class KingsBedRecipe : RecipeFamily
    {
        public KingsBedRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Kings Bed",
                    Localizer.DoStr("Kings Bed"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BedFrameItem), 1, true),
                        new IngredientElement(typeof(IronBarItem), 50, typeof(TailoringSkill),typeof(TailoringLavishResourcesTalent)),
                        new IngredientElement(typeof(ClothItem), 50, typeof(TailoringSkill),typeof(TailoringLavishResourcesTalent))
                    },
                    new CraftingElement<KingsBedItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(KingsBedRecipe), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Kings Bed"), typeof(KingsBedRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}