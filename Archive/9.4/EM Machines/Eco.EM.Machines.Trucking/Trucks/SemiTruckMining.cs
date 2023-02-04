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
using Eco.World.Blocks;
using Eco.Shared.Utils;
using Eco.EM.Framework.Utils;

namespace Eco.EM.Machines.Trucking
{
    [Serialized]
    [LocDisplayName("Semi Truck Mining")]
    [Weight(25000)]
    [AirPollution(0.9f)]
    public partial class SemiTruckMiningItem : WorldObjectItem<SemiTruckMiningObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern Semi Truck Mining");
    }

    public class SemiTruckMiningRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SemiTruckMiningRecipe).Name,
            Assembly = typeof(SemiTruckMiningRecipe).AssemblyQualifiedName,
            HiddenName = "Semi Truck Mining",
            LocalizableName = Localizer.DoStr("Semi Truck Mining"),
            IngredientList = new()
            {
                new EMIngredient("MiningTrailerItem", false, 1, true),
                new EMIngredient("PrimeMoverItem", false, 1, true),

            },
            ProductList = new()
            {
                new EMCraftable("SemiTruckMiningItem"),
            },
            CraftingStation = "RoboticAssemblyLineItem",
        };

        static SemiTruckMiningRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SemiTruckMiningRecipe()
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
    public partial class SemiTruckMiningObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("SemiTruckMining");
        public Type RepresentedItemType => typeof(SemiTruckMiningItem);

        private readonly static VehicleModel defaults = new(
            typeof(SemiTruckMiningObject),
            displayName: "Semi Truck Mining",
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

        static SemiTruckMiningObject()
        {
            EMVehicleResolver.AddDefaults(defaults);
        }

        private static readonly string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private SemiTruckMiningObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<PublicStorageComponent>().Initialize(EMVehicleResolver.Obj.ResolveStorageSlots(this), EMVehicleResolver.Obj.ResolveMaxWeight(this), new MiningItemsStackRestriction());
            this.GetComponent<FuelSupplyComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelSlots(this), fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelConsumption(this));
            this.GetComponent<AirPollutionComponent>().Initialize(EMVehicleResolver.Obj.ResolveAirPollution(this));
            this.GetComponent<VehicleComponent>().Initialize(EMVehicleResolver.Obj.ResolveMaxSpeed(this), EMVehicleResolver.Obj.ResolveEfficiencyMultiplier(this), EMVehicleResolver.Obj.ResolveSeats(this));
        }
    }

    public class MiningItemsStackRestriction : InventoryRestriction
    {
        private HashSet<Type> allowedItemTypes = new(new Type[] { typeof(SandItem), typeof(DirtItem), typeof(ClayItem), typeof(CrushedIronOreItem), typeof(CrushedCopperOreItem), typeof(CrushedGoldOreItem) });
        public override LocString Message => Localizer.DoStr("This Inventory only accepts Minable or Diggable Items");
        public string[] allowedTags = { "CrushedRock", "Rock", "Ore", "ConcentraredOre" };
        public MiningItemsStackRestriction() { }

        public override int MaxAccepted(Item item, int currentQuantity)
        {
            if (item.Tags().Any(x => this.allowedTags.Contains(x.Name))) return -1;
            if (this.allowedItemTypes.Contains(item.Type)) return -1;
            else
                return 0;
        }
    }
}