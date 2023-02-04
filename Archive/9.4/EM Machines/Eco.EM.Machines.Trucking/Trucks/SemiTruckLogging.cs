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
using System.Linq;

namespace Eco.EM.Machines.Trucking
{
    [Serialized]
    [LocDisplayName("Semi Truck Logging")]
    [Weight(25000)]
    [AirPollution(0.9f)]
    public partial class SemiTruckLoggingItem : WorldObjectItem<SemiTruckLoggingObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern Semi Truck Logging");
    }

    [RequiresSkill(typeof(IndustrySkill), 4)]
    public class SemiTruckLoggingRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SemiTruckLoggingRecipe).Name,
            Assembly = typeof(SemiTruckLoggingRecipe).AssemblyQualifiedName,
            HiddenName = "Semi Truck Logging",
            LocalizableName = Localizer.DoStr("Semi Truck Logging"),
            IngredientList = new()
            {
                new EMIngredient("LoggingTrailerItem", false, 1, true),
                new EMIngredient("PrimeMoverItem", false, 1, true),

            },
            ProductList = new()
            {
                new EMCraftable("SemiTruckLoggingItem"),
            },
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static SemiTruckLoggingRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SemiTruckLoggingRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(SemiTruckRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
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
    public partial class SemiTruckLoggingObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("SemiTruckLogging");
        public Type RepresentedItemType => typeof(SemiTruckLoggingItem);

        private readonly static VehicleModel defaults = new(
            typeof(SemiTruckLoggingObject),
            displayName: "Semi Truck Logging",
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

        static SemiTruckLoggingObject()
        {
            WorldObject.AddOccupancy<SemiTruckLoggingObject>(new List<BlockOccupancy>(0));
            EMVehicleResolver.AddDefaults(defaults);
        }

        private static readonly string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private SemiTruckLoggingObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<PublicStorageComponent>().Initialize(EMVehicleResolver.Obj.ResolveStorageSlots(this), EMVehicleResolver.Obj.ResolveMaxWeight(this), new TagRestriction("Wood"));
            this.GetComponent<FuelSupplyComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelSlots(this), fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelConsumption(this));
            this.GetComponent<AirPollutionComponent>().Initialize(EMVehicleResolver.Obj.ResolveAirPollution(this));
            this.GetComponent<VehicleComponent>().Initialize(EMVehicleResolver.Obj.ResolveMaxSpeed(this), EMVehicleResolver.Obj.ResolveEfficiencyMultiplier(this), EMVehicleResolver.Obj.ResolveSeats(this));
        }
    }
}
