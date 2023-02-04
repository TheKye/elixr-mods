namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Shared.Localization;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGeneratorComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    [RequireComponent(typeof(MeterComponent))]
    public partial class CTKBatteryObject : WorldObject
    {
        int MaxCapacity = 10000; // J
        int MAxInput = 50; // J/s
        int MaxOutput = 100; // J/s

        double Capacity = 0; // J

        DateTime lastTick;

        public override LocString DisplayName { get { return Localizer.DoStr("Battery Pack"); } }

        protected override void Initialize()
        {
            var meterComponent = GetComponent<MeterComponent>();

            if (meterComponent != null)
            {
                meterComponent.Initialize(10);
                meterComponent.Percentage = 50;
            }

            GetComponent<PowerGridComponent>().Initialize(30, new ElectricPower());
            GetComponent<PowerGeneratorComponent>().Initialize(MaxOutput);
            GetComponent<PowerConsumptionComponent>().Initialize(MAxInput);

            lastTick = DateTime.Now;
        }

        public override void ReceiveUpdate(BSONObject bsonObj)
        {
            var timeNow = DateTime.Now;
            var difference = timeNow - lastTick;

            var meterComponent = GetComponent<MeterComponent>();

            if (difference.TotalMilliseconds > 0)
            {
                Capacity += (MAxInput / 1000) * difference.TotalMilliseconds;
                if (Capacity > MaxCapacity)
                    Capacity = MaxCapacity;

                var powerGeneratorComponent = GetComponent<PowerGeneratorComponent>();
                var powerConsumptionComponent = GetComponent<PowerConsumptionComponent>();

                if (Capacity == MaxCapacity)
                    powerConsumptionComponent.Initialize(0);
                else
                    powerConsumptionComponent.Initialize(MAxInput);

                if (Capacity == 0)
                    powerGeneratorComponent.Initialize(0);
                else
                    powerGeneratorComponent.Initialize(MaxOutput);

                if (meterComponent != null)
                    meterComponent.Percentage = int.Parse(Math.Round((Capacity / MaxCapacity) * 100).ToString());
            }

            lastTick = timeNow;

            base.ReceiveUpdate(bsonObj);
        }

        public override InteractResult OnActInteract(InteractionContext context)
        {
            base.OnActInteract(context);
            return InteractResult.Success;
        }

        public override void Destroy()
        {
            base.Destroy();
        }       
    }

    [Serialized]
    public partial class CTKBatteryItem : WorldObjectItem<CTKBatteryObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Battery Pack"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Bttery Pack to be used with Solar Panel by CTK"); } }

        static CTKBatteryItem()
        {
            
        }
	}
}