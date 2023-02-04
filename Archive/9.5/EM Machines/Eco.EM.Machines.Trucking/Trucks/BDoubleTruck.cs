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
    [LocDisplayName("B-Double Truck")]
    [Weight(25000)]
    [AirPollution(0.9f)]
    public partial class BDoubleTruckItem : WorldObjectItem<BDoubleTruckObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern B-Double Truck");
    }

    public class BDoubleTruckRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BDoubleTruckRecipe).Name,
            Assembly = typeof(BDoubleTruckRecipe).AssemblyQualifiedName,
            HiddenName = "B-Double Truck",
            LocalizableName = Localizer.DoStr("B-Double Truck"),
            IngredientList = new()
            {
                new EMIngredient("BDoubleTrailerItem", false, 1, true),
                new EMIngredient("PrimeMoverItem", false, 1, true),
                
            },
            ProductList = new()
            {
                new EMCraftable("BDoubleTruckItem"),
            },
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static BDoubleTruckRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BDoubleTruckRecipe()
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
    public partial class BDoubleTruckObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("BDoubleTruck");
        public Type RepresentedItemType => typeof(BDoubleTruckItem);

        private readonly static VehicleModel defaults = new(
            typeof(BDoubleTruckObject),
            displayName: "B-Double Truck",
            fuelTagList: fuelTagList,
            fuelSlots: 2,
            fuelConsumption: 45,
            airPollution: 0.5f,
            maxSpeed: 20,
            efficencyMultiplier: 1.5f,
            storageSlots: 128,
            maxWeight: 200000000,
            seats: 1
        );

        static BDoubleTruckObject()
        {
            WorldObject.AddOccupancy<BDoubleTruckObject>(new List<BlockOccupancy>(0));
            EMVehicleResolver.AddDefaults(defaults);
        }

        private static readonly string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private BDoubleTruckObject() { }

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
