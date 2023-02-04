using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Food
{
    [Serialized]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]
    [RequireRoomMaterialTier(2)]
    public partial class SmokehouseObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Smokehouse");

        private static string[] fuelTagList = new string[]
        {
            "Burnable Fuel"
        };

        static SmokehouseObject()
        {
            WorldObject.AddOccupancy<SmokehouseObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 1, 0)),
                });
        }

        protected override void Initialize()
        {
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(50);
            this.GetComponent<HousingComponent>().Set(SmokehouseItem.HousingVal);

            base.PostInitialize();
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [MaxStackSize(10)]
    [LocDisplayName("Smokehouse")]
    [AllowPluginModules(Tags = new[] { "BasicUpgrade", }, ItemTypes = new[] { typeof(CookingUpgradeItem),
 typeof(AdvancedCookingUpgradeItem),})]
    public partial class SmokehouseItem : WorldObjectItem<SmokehouseObject>, IRepresentsItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Useful for smoking & drying meat.");

        public Type RepresentedItemType => typeof(SmokehouseObject);

        [TooltipChildren] public HousingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HousingValue HousingVal => new HousingValue() { Category = HousingValue.RoomCategory.Kitchen, Val = 2, TypeForRoomLimit = "Storage", DiminishingReturnPercent = 0.5f };

        static SmokehouseItem() { }
    }

    [RequiresSkill(typeof(MasonrySkill), 3)]
    public partial class SmokehouseRecipe : RecipeFamily
    {
        private string rName = "Smokehouse";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public SmokehouseRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(IronBarItem), 20, skillBase, ingTalent),
                    new IngredientElement(typeof(BrickItem), 40, skillBase, ingTalent),
                },
                 new CraftingElement<SmokehouseItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(50f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 30f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KilnObject), this);      
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
