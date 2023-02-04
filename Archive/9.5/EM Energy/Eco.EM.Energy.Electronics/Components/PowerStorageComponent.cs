using Eco.Core.Controller;
using Eco.Shared.IoC;
using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Reflection;
using Eco.Core.Systems;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Energy.Electronics.Components
{
    [Serialized]
    public class ChargeItemData : IController
    {
        [Serialized, SyncToView] public float Charge { get; set; } // The current charge of the cell (Joules)

        #region IController
        private int controllerID;
        ref int IHasUniversalID.ControllerID => ref this.controllerID;

        #endregion
    }

    [Serialized]
    [RequireComponent(typeof(StatusComponent))]
    public class PowerStorageComponent : WorldObjectComponent, IPersistentData
    {
        [Serialized] public float Capacity { get; private set; } // The amount of energy the cell stores. (Joules)
        [Serialized] public float Throughput { get; private set; } // The amount of energy transfer per second. (Watts)
        [Serialized] public ChargeItemData ChargeData { get; private set; } // Persistant data storage for being picked up.

        object IPersistentData.PersistentData { get => this.ChargeData; set => this.ChargeData = value as ChargeItemData; }

        public ThreadSafeAction OnStateChanged { get; set; } = new ThreadSafeAction();

        private PowerStorageGridInterface GridInterface { get; set; }
        private bool needsRelink = true;

        [Serialized] private bool attached = false;
        public bool Attached
        {
            get => this.attached;
            set
            {
                if (attached != value)
                {
                    attached = value;
                    Parent.SetAnimatedState("Attached", attached);
                    if (OnStateChanged != null)
                        OnStateChanged.Invoke();
                }
            }
        }

        [Serialized] private bool charging = false;
        public bool Charging
        {
            get => this.charging;
            set
            {
                if (this.charging != value)
                {
                    charging = value;
                    Parent.SetAnimatedState("Charging", charging);
                    if (OnStateChanged != null)
                        OnStateChanged.Invoke();
                }
            }
        }

        [Serialized] private float pips = 0;
        public float Pips
        {
            get => this.pips;
            set
            {
                if (this.pips != value)
                {
                    pips = value;
                    Parent.SetAnimatedState("Charge", pips);
                }
            }
        }
        private StatusElement status;

        public PowerStorageComponent() { }
        public PowerStorageComponent(float capacity, float watts) => this.Initialize(capacity, watts);

        public void Initialize(float capacity, float watts)
        {
            this.Capacity = capacity;
            this.Throughput = watts;
            this.status = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.needsRelink = true;

            // initialize new charge if no persistant storage.
            this.ChargeData ??= new ChargeItemData { Charge = 0.0f };
            Parent.SetAnimatedState("Attached", Attached);
            Parent.SetAnimatedState("Charging", Charging);
            Parent.SetAnimatedState("Charge", Pips);
        }

        public override void Initialize()
        {
            this.LinkOrCreateInterface();
        }

        public void UpdateStatus()
        {
            if (Attached)
            {
                if (Charging)
                    ChargeCell(Throughput * ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime);
                else
                    DischargeCell(Throughput * ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime);
            }
        }

        public float ChargeCell(float amount)
        {
            float unused = 0.0f;
            var deficit = Capacity - ChargeData.Charge;

            if (amount <= deficit) ChargeData.Charge += amount;
            else
            {
                unused = amount - deficit;
                ChargeData.Charge = Capacity;
                Attached = false;
            }
            return unused;
        }

        public float DischargeCell(float amount)
        {
            var deficit = amount - ChargeData.Charge;

            if (deficit <= 0.0f) { ChargeData.Charge -= amount; return 0.0f; }
            else { ChargeData.Charge = 0.0f; Attached = false; return Math.Abs(deficit); }
        }

        // Finds an interface to attach to or creates one if a powergrid is found.
        public void LinkOrCreateInterface()
        {
            PowerGrid powerGrid = GetNearestGrid(); // get the grid we will operate on

            if (powerGrid != null)
            {
                lock (PowerStorageGridInterface.GridInterfaceLinks)
                {
                    if (PowerStorageGridInterface.GridInterfaceLinks.ContainsKey(powerGrid))
                    {
                        GridInterface = PowerStorageGridInterface.GridInterfaceLinks[powerGrid];
                        GridInterface.ConnectCell(this);
                    }
                    else
                    {
                        GridInterface = new PowerStorageGridInterface();
                        GridInterface.GetType().BaseType.GetField("<EnergyType>k__BackingField", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(GridInterface, new ElectricPower());
                        GridInterface.GetType().BaseType.GetField("<OperatingPriority>k__BackingField", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(GridInterface, PriorityAttribute.VeryLow);
                        GridInterface.GetType().GetBaseAbstractType().GetField("<Parent>k__BackingField", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(GridInterface, this.Parent);
                        GridInterface.Init(powerGrid);
                        GridInterface.ConnectCell(this);
                    }
                }
                powerGrid.MarkChanged();
                this.needsRelink = false;
            }
        }

        public void Relink()
        {
            this.needsRelink = true;
            this.GridInterface = null;
        }

        public override void Tick()
        {
            if (this.needsRelink)
                this.LinkOrCreateInterface();

            if (GridInterface != null)
                GridInterface.Tick();
        }

        public override void LateTick()
        {
            if (GridInterface == null) { this.status.Message = Localizer.DoStr(string.Format(Localizer.DoStr("No Grid locally found, please relocate to a power grid. Current charge unknown"))); return; }

            GridInterface.LateTick();

            var percentCharge = (float)Mathf.Floor(ChargeData.Charge / Capacity * 100);
            pips = (float)Mathf.Floor(percentCharge / 10);

            SetStatusMessage(percentCharge);
            Parent.SetAnimatedState("Charge", Pips);
        }

        private PowerGrid GetNearestGrid()
        {
            // have to loop through all objects with power components and check distance.... slllllllllooooow.
            foreach (var obj in ServiceHolder<IWorldObjectManager>.Obj.All)
            {
                if (obj == this.Parent) continue; // skip me
                if (!obj.HasComponent<PowerGridComponent>()) continue; // skip anything that we can't connect to

                float distance = this.Parent.Position.WrappedDistance(obj.Position);
                foreach (var comp in obj.GetComponents<PowerGridComponent>())
                {
                    if (distance <= comp.Radius && comp.EnergyType.GetType() == typeof(ElectricPower)) return comp.PowerGrid; // return the first found grid (overlapping grids should be the same anyway)
                }
            }
            return null;
        }

        private void SetStatusMessage(float percentCharge)
        {
            LocString disabledMessage = Localizer.DoStr(string.Format(Localizer.DoStr("Battery is not attached to grid. Current charge: {0}%"), percentCharge));

            if (percentCharge >= 100)
                disabledMessage += string.Format(Localizer.DoStr("\n      Battery is fully charged and there is a surplus of power"));
            else if (percentCharge <= 0)
                disabledMessage += string.Format(Localizer.DoStr("\n      Battery is fully discharged and there is not enough surplus power to charge"));
            else
                disabledMessage += string.Format(Localizer.DoStr("\n      The current grid conditions have disabled this battery"));

            LocString enabledMessage;
            if (Charging)
                enabledMessage = Localizer.DoStr(string.Format(Localizer.DoStr("Battery is in Charge Mode. Current charge {0}%."), percentCharge));
            else
                enabledMessage = Localizer.DoStr(string.Format(Localizer.DoStr("Battery is in Discharge Mode. Current charge: {0}%."), percentCharge));

            this.status.SetStatusMessage(this.attached, enabledMessage, disabledMessage);
        }

        public override void Destroy()
        {
            if (GridInterface != null)
                GridInterface.RemoveCell(this);
            base.Destroy();
        }
    }
}