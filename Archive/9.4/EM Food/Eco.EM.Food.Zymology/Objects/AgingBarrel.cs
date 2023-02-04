using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Core.Items;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Housing;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Minimap;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Gameplay.Pipes.Gases;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.View;
using Eco.Shared.Items;
using Eco.Gameplay.Pipes;
using Eco.World.Blocks;
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
        public override LocString DisplayName { get { return Localizer.DoStr("Aging Barrel"); } }

        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        //This is the item that represent the block
        public virtual Type RepresentedItemType { get { return typeof(AgingBarrelItem); } }

        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));
            this.GetComponent<HousingComponent>().HomeValue = AgingBarrelItem.HousingVal;

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Aging Barrel")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [AllowPluginModules(Tags = new[] { "BasicUpgrade", }, ItemTypes = new[] { typeof(CarpentryBasicUpgradeItem),
    typeof(LoggingBasicUpgradeItem),
    typeof(BasicEngineeringUpgradeItem),
    typeof(PaperMillingUpgradeItem), })]
    public partial class AgingBarrelItem : WorldObjectItem<AgingBarrelObject>, IPersistentData
    {
        public override LocString DisplayDescription => Localizer.DoStr("An Aging Barrel.");

        static AgingBarrelItem()
        {

        }

        [TooltipChildren] public HomeFurnishingValue HousingTooltip { get { return HousingVal; } }
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
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Aging Barrel"), typeof(AgingBarrelRecipe));
            this.ModsPostInitialize();

            //Crafted at which station
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
