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
using Eco.Gameplay.Systems.Tooltip;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.EM.Framework.Utils;
using Eco.Shared.Items;

namespace Eco.EM.Machines.Trucking.Trucks
{
    [Serialized]
    [LocDisplayName("Logging Truck")]
    [Weight(25000)]
    [AirPollution(0.9f)]
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true)]
    public partial class SemiTruckLoggingItem : WorldObjectItem<SemiTruckLoggingObject>, IPersistentData
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern Truck With a Semi Trailer attached for transporting Logs");
        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren(CacheAs.Instance)] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(IndustrySkill), 4)]
    public class SemiTruckLoggingRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SemiTruckLoggingRecipe).Name,
            Assembly = typeof(SemiTruckLoggingRecipe).AssemblyQualifiedName,
            HiddenName = "Logging Truck",
            LocalizableName = Localizer.DoStr("Logging Truck"),
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
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    public partial class SemiTruckLoggingObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("Logging Truck");
        public Type RepresentedItemType => typeof(SemiTruckLoggingItem);
        public override TableTextureMode TableTexture => TableTextureMode.Metal;

        public override float InteractDistance => 16f;

        private readonly static VehicleModel defaults = new(
            typeof(SemiTruckLoggingObject),
            displayName: "Logging Truck",
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
            AddOccupancy<SemiTruckLoggingObject>(new List<BlockOccupancy>(0));
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
            GetComponent<MinimapComponent>().InitAsMovable();
            GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Vehicles"));
            GetComponent<CustomTextComponent>().Initialize(200);
            GetComponent<PublicStorageComponent>().Initialize(EMVehicleResolver.Obj.ResolveStorageSlots(this), EMVehicleResolver.Obj.ResolveMaxWeight(this), new TagStackRestriction(2, "Wood", "Lumber", "Hewn", "Composites"));
            GetComponent<FuelSupplyComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelSlots(this), fuelTagList);
            GetComponent<FuelConsumptionComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelConsumption(this));
            GetComponent<AirPollutionComponent>().Initialize(EMVehicleResolver.Obj.ResolveAirPollution(this));
            GetComponent<VehicleComponent>().Initialize(EMVehicleResolver.Obj.ResolveMaxSpeed(this), EMVehicleResolver.Obj.ResolveEfficiencyMultiplier(this), EMVehicleResolver.Obj.ResolveSeats(this));
            GetComponent<StockpileComponent>().Initialize(new Vector3i(3, 3, 10));
        }
    }
}