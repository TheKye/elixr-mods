using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Items;
using Eco.Mods.TechTree;
using Eco.Gameplay.Housing.PropertyValues;
using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]
    [RequireRoomMaterialTier(0.2f, typeof(CarpentryLavishReqTalent), typeof(CarpentryFrugalReqTalent))]
    public partial class DeepFryerObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Deep Fryer");

        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        //This is the item that represent the block
        public virtual Type RepresentedItemType => typeof(DeepFryerItem);

        private static string[] fuelTagList = new string[]
        {
            "Fat",
        };

        protected override void Initialize()
        {
            this.GetComponent<PowerConsumptionComponent>().Initialize(100);
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));
            this.GetComponent<HousingComponent>().HomeValue = DeepFryerItem.HousingVal;
        }


    }

    [Serialized]
    [LocDisplayName("Deep Fryer")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true)]
    [AllowPluginModules(Tags = new[] { "BasicUpgrade", "AdvancedUpgrade"}, ItemTypes = new[] { typeof(CookingUpgradeItem)})]
    public partial class DeepFryerItem : WorldObjectItem<DeepFryerObject>, IPersistentData
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Deep Fryer.");

        static DeepFryerItem() { }

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => new ()
        {
            Category = RoomCategory.Kitchen,
            TypeForRoomLimit = Localizer.DoStr(""),
        };

        [Serialized, TooltipChildren] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(MechanicsSkill), 3)]
    public partial class DeepFryerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(DeepFryerRecipe).Name,
            Assembly = typeof(DeepFryerRecipe).AssemblyQualifiedName,
            HiddenName = "Deep Fryer",
            LocalizableName = Localizer.DoStr("Deep Fryer"),
            IngredientList = new()
            {
                new EMIngredient("IronPlateItem", false, 4),
                new EMIngredient("ScrewsItem", false, 16),
                new EMIngredient("BoilerItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("DeepFryerItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 500,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "MachinistTableItem",
            RequiredSkillType = typeof(MechanicsSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(MechanicsLavishResourcesTalent),
        };

        static DeepFryerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DeepFryerRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
