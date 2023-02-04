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

namespace Eco.EM.Machines.Vehicles
{
    [Serialized]
    [LocDisplayName("Wagon")]
    [Weight(25000)]
    [AirPollution(0.5f)]
    public partial class WagonItem : WorldObjectItem<WagonObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern Wagon");
    }

    [RequiresSkill(typeof(IndustrySkill), 2)]
    public class WagonRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WagonRecipe).Name,
            Assembly = typeof(WagonRecipe).AssemblyQualifiedName,
            HiddenName = "Wagon",
            LocalizableName = Localizer.DoStr("Wagon"),
            IngredientList = new()
            {
                new EMIngredient("GearboxItem", false, 3),
                new EMIngredient("SteelPlateItem", false, 30),
                new EMIngredient("NylonFabricItem", false, 20),
                new EMIngredient("CombustionEngineItem", false, 1, true),
                new EMIngredient("RubberWheelItem", false, 4, true),
                new EMIngredient("RadiatorItem", false, 1, true),
                new EMIngredient("SteelAxleItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("WagonItem"),
            },
            BaseExperienceOnCraft = 1f,
            BaseLabor = 1500,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
            RequiredSkillType = typeof(IndustrySkill),
            RequiredSkillLevel = 2,
            SpeedImprovementTalents = new Type[] { typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent) }
        };

        static WagonRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WagonRecipe()
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
    public partial class WagonObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("Wagon");
        public Type RepresentedItemType => typeof(WagonItem);

        private readonly static VehicleModel defaults = new(
            typeof(WagonObject),
            displayName: "Wagon",
            fuelTagList: fuelTagList,
            fuelSlots: 2,
            fuelConsumption: 18,
            airPollution: 0.5f,
            maxSpeed: 20,
            efficencyMultiplier: 2,
            storageSlots: 8,
            maxWeight: 10000000,
            seats: 4
        );

        static WagonObject()
        {
            WorldObject.AddOccupancy<WagonObject>(new List<BlockOccupancy>(0));
            EMVehicleResolver.AddDefaults(defaults);
        }

        private static readonly string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private WagonObject() { }

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
}
