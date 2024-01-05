using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Items;
using Eco.Mods.TechTree;

namespace Eco.EM.Machines.Boating
{
    [Tag("Boat")]
    [WaterPlaceable]
    [Serialized, Category("Visible")]
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true)]
    [LocDisplayName("Hauler")]
    public partial class MediumBoatItem : WorldObjectItem<MediumBoatObject>
    {
        public float InteractDistance => DefaultInteractDistance.WaterPlacement;
        public override LocString DisplayDescription => Localizer.DoStr("A coal-powered compromise between the barge and canoe; good speed and storage.");
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    public partial class MediumBoatObject : PhysicsWorldObject, IRepresentsItem
    {
        static MediumBoatObject()
        {
            WorldObject.AddOccupancy<MediumBoatObject>(new List<BlockOccupancy>(0));
        }

        public override LocString DisplayName => Localizer.DoStr("Hauler");
        public Type RepresentedItemType => typeof(MediumBoatItem);

        private Player Driver => GetComponent<VehicleComponent>().Driver;

        private MediumBoatObject() { }	
        
        private static string[] fuelTagList = new[] { "Burnable Fuel" }; 
        
        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<PublicStorageComponent>().Initialize(60, 140000000);
            this.GetComponent<FuelSupplyComponent>().Initialize(6, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(25);
            this.GetComponent<VehicleComponent>().Initialize(65, 2, 4);
        }
    }

    [RequiresSkill(typeof(ShipwrightSkill), 1)]
    public partial class MediumWoodenBoatRecipe : RecipeFamily
    {
        public MediumWoodenBoatRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Hauler",  //noloc
                Localizer.DoStr("Hauler"),
                new List<IngredientElement>
                {
                    new IngredientElement("Lumber", 40),
                    new IngredientElement(typeof(ScrewsItem), 100),
                    new IngredientElement(typeof(StorageChestItem), 3, true),
                    new IngredientElement(typeof(LumberChairItem), 6),
                    new IngredientElement(typeof(IronWheelItem), 2),
                    new IngredientElement(typeof(IronPlateItem), 50),
                    new IngredientElement(typeof(PortableSteamEngineItem), 1, true),
                    new IngredientElement(typeof(AdvancedUpgradeLvl2Item), 2, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<MediumBoatItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 3;
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(ShipwrightSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MediumWoodenBoatRecipe), 30, typeof(ShipwrightSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Hauler"), typeof(MediumWoodenBoatRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(IronShipyardObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }


}