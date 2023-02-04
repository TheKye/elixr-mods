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
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]
    [RequireRoomMaterialTier(0.2f, typeof(CarpentryLavishReqTalent), typeof(CarpentryFrugalReqTalent))]
    public partial class BlenderObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Blender");

        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        public virtual Type RepresentedItemType => typeof(BlenderItem);

        protected override void Initialize()
        {
            this.GetComponent<PowerConsumptionComponent>().Initialize(100);
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));
            this.GetComponent<HousingComponent>().HomeValue = BlenderItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Blender")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [AllowPluginModules(Tags = new[] { "BasicUpgrade", "AdvancedUpgrade" }, ItemTypes = new[] { typeof(CookingUpgradeItem)})]
    public partial class BlenderItem : WorldObjectItem<BlenderObject>, IPersistentData
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Blender.");

        static BlenderItem() { }

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => new ()
        {
            Category = RoomCategory.Kitchen,
            TypeForRoomLimit = Localizer.DoStr(""),
        };

        [Serialized, TooltipChildren] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 3)]
    public partial class BlenderRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlenderRecipe).Name,
            Assembly = typeof(BlenderRecipe).AssemblyQualifiedName,
            HiddenName = "Blender",
            LocalizableName = Localizer.DoStr("Blender"),
            IngredientList = new()
            {
                new EMIngredient("SteelPlateItem", false, 2),
                new EMIngredient("ScrewsItem", false, 8),
                new EMIngredient("BasicCircuitItem", false, 1),
                new EMIngredient("GlassItem", false, 2),
                new EMIngredient("IronSawBladeItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BlenderItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 1000,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "ElectricMachinistTableItem",
        };

        static BlenderRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlenderRecipe()
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
