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

namespace Eco.PlanetChefMod
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]
    [RequireRoomMaterialTier(0.2f, typeof(CarpentryLavishReqTalent), typeof(CarpentryFrugalReqTalent))]
    public partial class AgingBarrelObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Aging Barrel");

        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        //This is the item that represent the block
        public virtual Type RepresentedItemType => typeof(AgingBarrelItem);

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));
            this.GetComponent<HousingComponent>().HomeValue = AgingBarrelItem.HousingVal;
        }

        public override void Destroy() => base.Destroy();

    }

    [Serialized]
    [LocDisplayName("Aging Barrel")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [AllowPluginModules(Tags = new[] { "BasicUpgrade" })]
    public partial class AgingBarrelItem : WorldObjectItem<AgingBarrelObject>, IPersistentData
    {
        public override LocString DisplayDescription => Localizer.DoStr("An Aging Barrel.");

        static AgingBarrelItem()
        {

        }

        [TooltipChildren] public HomeFurnishingValue HousingTooltip => HousingVal;
        [TooltipChildren]
        public static HomeFurnishingValue HousingVal => new ()
        {
            Category = RoomCategory.Kitchen,
            TypeForRoomLimit = Localizer.DoStr(""),
        };


        [Serialized, TooltipChildren] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class AgingBarrelRecipe : RecipeFamily
    {
        public AgingBarrelRecipe()
        {
            var product = new Recipe(
                "Aging Barrel",
                Localizer.DoStr("Aging Barrel"),
                new IngredientElement[]
                {
                   new IngredientElement("Wood", 6),
                   new IngredientElement(typeof(NailItem), 12),
                   new IngredientElement(typeof(IronBarItem), 12),
                },
               new CraftingElement<AgingBarrelItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100);
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.Initialize(Localizer.DoStr("Aging Barrel"), typeof(AgingBarrelRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
