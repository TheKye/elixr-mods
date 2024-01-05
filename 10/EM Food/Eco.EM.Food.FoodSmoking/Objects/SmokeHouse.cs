using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Housing.PropertyValues;
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

namespace Eco.EM.Food.FoodSmoking
{
    [Serialized]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]

    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]
    [RequireRoomMaterialTier(2)]
    public partial class SmokehouseObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Smokehouse");

        private static readonly string[] fuelTagList = new string[]
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
            this.GetComponent<HousingComponent>().HomeValue = SmokehouseItem.HousingVal;

            base.PostInitialize();
        }


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

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren] public static HomeFurnishingValue HousingVal => new(){ Category = RoomCategory.Kitchen, HouseValue = 2, TypeForRoomLimit = Localizer.DoStr("Storage"), DiminishingReturnPercent = 0.5f };

        static SmokehouseItem() { }
    }

    [RequiresSkill(typeof(MasonrySkill), 3)]
    public partial class SmokehouseRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SmokehouseRecipe).Name,
            Assembly = typeof(SmokehouseRecipe).AssemblyQualifiedName,
            HiddenName = "Smokehouse",
            LocalizableName = Localizer.DoStr("Smokehouse"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 20),
                new EMIngredient("BrickItem", false, 40),
            },
            ProductList = new()
            {
                new EMCraftable("SmokehouseItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 25,
            CraftTimeIsStatic = false,
            CraftingStation = "KilnItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent) },
        };

        static SmokehouseRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SmokehouseRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
