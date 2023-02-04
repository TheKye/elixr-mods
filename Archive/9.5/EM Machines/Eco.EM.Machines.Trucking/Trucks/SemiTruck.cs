using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.Gameplay.Skills;

namespace Eco.EM.Machines.Trucking
{
    [Serialized]
    [LocDisplayName("Semi Truck")]
    [Weight(25000)]
    [AirPollution(0.5f)]
    public partial class SemiTruckItem : WorldObjectItem<SemiTruckObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern Semi Truck");
    }

    public class SemiTruckRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SemiTruckRecipe).Name,
            Assembly = typeof(SemiTruckRecipe).AssemblyQualifiedName,
            HiddenName = "Semi Truck",
            LocalizableName = Localizer.DoStr("Semi Truck"),
            IngredientList = new()
            {
                new EMIngredient("SemiTrailerItem", false, 1, true),
                new EMIngredient("PrimeMoverItem", false, 1, true),

            },
            ProductList = new()
            {
                new EMCraftable("SemiTruckItem"),
            },
            BaseExperienceOnCraft = 0f,
            BaseLabor = 0,
            LaborIsStatic = false,
            BaseCraftTime = 0,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static SemiTruckRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SemiTruckRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    public partial class SemiTruckObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("SemiTruck");
        public Type RepresentedItemType => typeof(SemiTruckItem);

        private readonly static VehicleModel defaults = new(
            typeof(SemiTruckObject),
            displayName: "Semi Truck",
            fuelTagList: fuelTagList,
            fuelSlots: 2,
            fuelConsumption: 40,
            airPollution: 0.5f,
            maxSpeed: 20,
            efficencyMultiplier: 1.8f,
            storageSlots: 70,
            maxWeight: 100000000,
            seats: 1
        );

        static SemiTruckObject()
        {
            WorldObject.AddOccupancy<SemiTruckObject>(new List<BlockOccupancy>(0));
            EMVehicleResolver.AddDefaults(defaults);
        }

        private static readonly string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private SemiTruckObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<PublicStorageComponent>().Initialize(EMVehicleResolver.Obj.ResolveStorageSlots(this), EMVehicleResolver.Obj.ResolveMaxWeight(this));
            this.GetComponent<FuelSupplyComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelSlots(this), fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelConsumption(this));
            this.GetComponent<AirPollutionComponent>().Initialize(EMVehicleResolver.Obj.ResolveAirPollution(this));
            this.GetComponent<VehicleComponent>().Initialize(EMVehicleResolver.Obj.ResolveMaxSpeed(this), EMVehicleResolver.Obj.ResolveEfficiencyMultiplier(this), EMVehicleResolver.Obj.ResolveSeats(this));
        }
    }
}
