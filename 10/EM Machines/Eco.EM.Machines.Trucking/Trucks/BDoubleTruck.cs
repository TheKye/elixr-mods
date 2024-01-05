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
using Eco.Core.Controller;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Shared.Items;
using Eco.Gameplay.Interactions;
using System.Numerics;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Occupancy;

namespace Eco.EM.Machines.Trucking.Trucks
{
    [Serialized]
    [LocDisplayName("18 Wheeler")]
    [Weight(25000)]
    [AirPollution(0.9f)]
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true)]
    [LocDescription("Modern Truck With a B-Double Trailer attached for Big Logistics transporting also known as an \"18 Wheeler\"")]
    public partial class BDoubleTruckItem : WorldObjectItem<BDoubleTruckObject>, IPersistentData
    {
        [Serialized, SyncToView, NewTooltipChildren(CacheAs.Instance, flags: TTFlags.AllowNonControllerTypeForChildren)] public object PersistentData { get; set; }
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
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    public partial class BDoubleTruckObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("BDoubleTruck");
        public Type RepresentedItemType => typeof(BDoubleTruckItem);
        public override TableTextureMode TableTexture => TableTextureMode.Metal;
        public override float InteractDistance => 20f;

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
            AddOccupancy<BDoubleTruckObject>(new List<BlockOccupancy>(0));
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
            GetComponent<CustomTextComponent>().Initialize(200);
            GetComponent<PublicStorageComponent>().Initialize(EMVehicleResolver.Obj.ResolveStorageSlots(this), EMVehicleResolver.Obj.ResolveMaxWeight(this));
            GetComponent<FuelSupplyComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelSlots(this), fuelTagList);
            GetComponent<FuelConsumptionComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelConsumption(this));
            GetComponent<AirPollutionComponent>().Initialize(EMVehicleResolver.Obj.ResolveAirPollution(this));
            GetComponent<MinimapComponent>().InitAsMovable();
            GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Vehicles"));
            GetComponent<VehicleComponent>().Initialize(EMVehicleResolver.Obj.ResolveMaxSpeed(this), EMVehicleResolver.Obj.ResolveEfficiencyMultiplier(this), EMVehicleResolver.Obj.ResolveSeats(this));
        }
    }
}
