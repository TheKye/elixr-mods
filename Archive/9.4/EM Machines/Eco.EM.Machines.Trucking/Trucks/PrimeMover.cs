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
    [LocDisplayName("Prime Mover")]
    [Weight(25000)]
    [AirPollution(0.9f)]
    public partial class PrimeMoverItem : WorldObjectItem<PrimeMoverObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern Prime Mover, Can be driven as is or combined with a trailer?");
    }

    [RequiresSkill(typeof(IndustrySkill), 7)]
    public class PrimeMoverRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PrimeMoverRecipe).Name,
            Assembly = typeof(PrimeMoverRecipe).AssemblyQualifiedName,
            HiddenName = "Prime Mover",
            LocalizableName = Localizer.DoStr("Prime Mover"),
            IngredientList = new()
            {
                new EMIngredient("GearboxItem", false, 6),
                new EMIngredient("SteelPlateItem", false, 80),
                new EMIngredient("NylonFabricItem", false, 60),
                new EMIngredient("AdvancedCombustionEngineItem", false, 1, true),
                new EMIngredient("RubberWheelItem", false, 10, true),
                new EMIngredient("RadiatorItem", false, 2, true),
                new EMIngredient("SteelAxleItem", false, 3, true),
                
            },
            ProductList = new()
            {
                new EMCraftable("PrimeMoverItem"),
            },
            BaseExperienceOnCraft = 1f,
            BaseLabor = 5000,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
            RequiredSkillType = typeof(IndustrySkill),
            RequiredSkillLevel = 7,
            SpeedImprovementTalents = new Type[] { typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent) }
        };

        static PrimeMoverRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PrimeMoverRecipe()
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
    public partial class PrimeMoverObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("PrimeMover");
        public Type RepresentedItemType => typeof(PrimeMoverItem);

        private readonly static VehicleModel defaults = new(
            typeof(PrimeMoverObject),
            displayName: "Prime Mover",
            fuelTagList: fuelTagList,
            fuelSlots: 2,
            fuelConsumption: 40,
            airPollution: 0.5f,
            maxSpeed: 20,
            efficencyMultiplier: 1.8f,
            storageSlots: 0,
            maxWeight: 0,
            seats: 1
        );

        static PrimeMoverObject()
        {
            WorldObject.AddOccupancy<PrimeMoverObject>(new List<BlockOccupancy>(0));
            EMVehicleResolver.AddDefaults(defaults);
        }

        private static readonly string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private PrimeMoverObject() { }

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
