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
    [LocDisplayName("Semi Truck Plant")]
    [Weight(25000)]
    [AirPollution(0.5f)]
    public partial class SemiTruckPlantItem : WorldObjectItem<SemiTruckPlantObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern Semi Truck Plant");
    }

    public class SemiTruckPlantRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SemiTruckPlantRecipe).Name,
            Assembly = typeof(SemiTruckPlantRecipe).AssemblyQualifiedName,
            HiddenName = "Semi Truck Plant",
            LocalizableName = Localizer.DoStr("Semi Truck Plant"),
            IngredientList = new()
            {
                new EMIngredient("PlantTrailerItem", false, 1, true),
                new EMIngredient("PrimeMoverItem", false, 1, true),

            },
            ProductList = new()
            {
                new EMCraftable("SemiTruckItem"),
            },
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static SemiTruckPlantRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SemiTruckPlantRecipe()
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
    public partial class SemiTruckPlantObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("SemiTruckPlant");
        public Type RepresentedItemType => typeof(SemiTruckPlantItem);

        private readonly static VehicleModel defaults = new(
            typeof(SemiTruckPlantObject),
            displayName: "Semi Truck Plant",
            fuelTagList: fuelTagList,
            fuelSlots: 2,
            fuelConsumption: 40,
            airPollution: 0.5f,
            maxSpeed: 20,
            efficencyMultiplier: 1.8f,
            storageSlots: 6,
            maxWeight: 2500000,
            seats: 1
        );

        static SemiTruckPlantObject()
        {
            WorldObject.AddOccupancy<SemiTruckPlantObject>(new List<BlockOccupancy>(0));
            EMVehicleResolver.AddDefaults(defaults);
        }

        private static readonly string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private SemiTruckPlantObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<PublicStorageComponent>().Initialize(EMVehicleResolver.Obj.ResolveStorageSlots(this), EMVehicleResolver.Obj.ResolveMaxWeight(this));
            this.GetComponent<FuelSupplyComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelSlots(this), fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelConsumption(this));
            this.GetComponent<AirPollutionComponent>().Initialize(EMVehicleResolver.Obj.ResolveAirPollution(this));
            this.GetComponent<VehicleComponent>().Initialize(EMVehicleResolver.Obj.ResolveMaxSpeed(this), EMVehicleResolver.Obj.ResolveEfficiencyMultiplier(this), EMVehicleResolver.Obj.ResolveSeats(this));
            this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2, 2, 3));
        }
    }

    public class VehicleItemsStackRestriction : InventoryRestriction
    {
        private HashSet<Type> allowedItemTypes = new(new Type[] { typeof(SkidSteerItem), typeof(ExcavatorItem), typeof(SteamTruckItem), typeof(SteamTractorItem), typeof(TruckItem) });
        public VehicleItemsStackRestriction() { }

        public override LocString Message => Localizer.DoStr("Plant Trailer can only Store Small Vehicles");

        public override int MaxAccepted(Item item, int currentQuantity)
        {
            if (this.allowedItemTypes.Contains(item.GetType())) return -1;
            else
                return 0;
        }
    }
}
