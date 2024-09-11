using Eco.Core.Controller;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Energy.GreenEnergy.Components
{
    [Serialized]
    [RequireComponent(typeof(StatusComponent))]
    public class PowerConverterElecComponent : PowerGridComponent { }

    [Serialized]
    [RequireComponent(typeof(PowerConverterElecComponent))]
    public class PowerConsumptionElecComponent : WorldObjectComponent
    {
        [SyncToView]
        public float JoulesPerSecond { get; private set; }

        public PowerConsumptionElecComponent() { }
        public PowerConsumptionElecComponent(float joulesPerSecond)
        {
            this.Initialize(joulesPerSecond);
        }

        public void Initialize(float watts) => this.JoulesPerSecond = watts;
        public override void Initialize() => this.Parent.GetComponents<PowerConverterElecComponent>().ForEach(component =>
        {
            if (component.EnergyType.Name == "Electric")
            {
                component.EnergyDemand += this.JoulesPerSecond;
            }
        });
    }

    [Serialized]
    public class PowerConverterComponent : PowerGridComponent { }

    [Serialized]
    [RequireComponent(typeof(PowerConverterComponent))]
    public class MechPowerConsumptionComponent : WorldObjectComponent
    {
        [SyncToView]
        public float JoulesPerSecond { get; private set; }

        public MechPowerConsumptionComponent() { }
        public MechPowerConsumptionComponent(float joulesPerSecond)
        {
            this.Initialize(joulesPerSecond);
        }

        public void Initialize(float watts) => this.JoulesPerSecond = watts;
        public override void Initialize() => this.Parent.GetComponents<PowerConverterComponent>().ForEach(component =>
        {
            if (component.EnergyType.Name == "Mechanical")
                component.EnergyDemand += this.JoulesPerSecond;
        });
    }
}
