using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.Gameplay.Skills;
using Eco.Core.Controller;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Shared.Items;

namespace Eco.EM.Machines.Trucking.Trucks
{
    [Serialized]
    [LocDisplayName("Bus")]
    [Weight(25000)]
    [AirPollution(0.9f)]
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true)]
    public partial class BusItem : WorldObjectItem<BusObject>, IPersistentData
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern Bus, How many people can it hold...");
        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren(CacheAs.Instance)] public object PersistentData { get; set; }
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
    public partial class BusObject : PhysicsWorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Bus");
        public Type RepresentedItemType => typeof(BusItem);

        static BusObject()
        {
            AddOccupancy<BusObject>(new List<BlockOccupancy>(0));
        }

        private static readonly string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private BusObject() { }

        protected override void Initialize()
        {
            base.Initialize();
            GetComponent<CustomTextComponent>().Initialize(200);
            GetComponent<PublicStorageComponent>().Initialize(0);
            GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            GetComponent<FuelConsumptionComponent>().Initialize(40);
            GetComponent<AirPollutionComponent>().Initialize(0.5f);
            GetComponent<MinimapComponent>().InitAsMovable();
            GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Vehicles"));
            GetComponent<VehicleComponent>().Initialize(18, 1.8f, 13);
        }
    }
}
