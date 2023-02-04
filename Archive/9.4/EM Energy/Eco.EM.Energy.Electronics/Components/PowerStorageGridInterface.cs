using Eco.Shared.IoC;
using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Energy.Electronics.Components
{
    [Serialized]
    public class PowerStorageGridInterface : PowerGridComponent
    {
        // the adapter for the grid/interfaces
        [ThreadSafe] public static Dictionary<PowerGrid, PowerStorageGridInterface> GridInterfaceLinks { get; private set; } = new Dictionary<PowerGrid, PowerStorageGridInterface>();
        [ThreadSafe] private List<PowerStorageComponent> cells = new(); // All batteries connected and storing energy for the grid

        public float TotalCellCapacity { get; private set; } // the total capacity of all cells on this interface
        public float ActiveThroughput { get; } // the total throughput of all cells on this interface (for discharge)

        private float cachedDemand = 0.0f;
        private float cachedSupply = 0.0f;
        private IEnumerable<PowerGridComponent> cachedComps;

        private bool dirty = true;

        public PowerStorageGridInterface() { }

        public void Init(PowerGrid grid)
        {   
            grid.Connect(this);
            GridInterfaceLinks.Add(grid, this);
            this.EnergySelfSupply = false; // batteries never accumulate to "Self Supply"
        }

        // Connects the cell and increases the total cell capacity cache, reorder by cell with the best throughput
        public void ConnectCell(PowerStorageComponent cell)
        {
            if (!cells.Contains(cell))
            {
                cells.Add(cell);
                cells = cells.OrderByDescending(x => x.Throughput).ToList();
                TotalCellCapacity += cell.Capacity;
                cell.OnStateChanged.Add(this.MarkDirty);
                this.MarkDirty();
            }
        }

        // Removes the cell and decreases the total cell capacity cache
        public void RemoveCell(PowerStorageComponent cell)
        {
            if (cells.Remove(cell))
            {
                TotalCellCapacity -= cell.Capacity;
                cell.OnStateChanged.Remove(this.MarkDirty);
                this.MarkDirty();
            }

            if (cells.Count <= 0)
                Destroy();
        }

        private void MarkDirty()
        {
            this.dirty = true;
            PowerGrid.MarkChanged();
        }

        public override void Tick()
        {
            if (!PowerGrid.Components.Any(x => x != this)) this.Destroy();

            // Get components that are not the interface to check for load
            var comps = PowerGrid.Components
                .OrderBy(x => x.OperatingPriority)
                .Where(comp => !(comp is PowerStorageGridInterface))
                .Where(comp => comp.Parent.Components.None(x => x != comp && (!x.Enabled || (x is IOperatingWorldObjectComponent operating && !operating.Operating))));

            var compsChanged = comps.CompareNullSafe(cachedComps);
            var demand = comps.Sum(x => x.EnergyDemand);
            var supply = comps.Sum(x => x.EnergySupply);

            if (demand != cachedDemand || supply != cachedSupply || compsChanged)
            {
                cachedDemand = demand;
                cachedSupply = supply;
                cachedComps = comps;
                MarkDirty();
            }

            if (dirty || !this.Enabled)
            {
                UpdateEnabled(true, true);
                this.Changed(comps);     
                dirty = false;
            }

            // Once the supply/demand is correctly set tick the grid to ensure updates occur.
            PowerGrid.Tick(ServiceHolder<IWorldObjectManager>.Obj.TickStartTime);
        }

        private void Changed(IEnumerable<PowerGridComponent> comps)
        {
            // reset our displays to the grid
            EnergyDemand = 0.0f;
            EnergySupply = 0.0f;

            var remainingSupply = cachedSupply;
            var remainingDemand = cachedDemand;
            var deficitComponents = new List<PowerGridComponent>();

            // Calculate if we are charging or discharging based on supply & demand
            foreach (var comp in comps)
            {
                var needs = !comp.EnergySelfSupply ? comp.EnergyDemand : 0.0f;

                if (remainingSupply >= needs)
                {
                    remainingSupply -= needs;
                    remainingDemand -= needs;
                }
                else { deficitComponents.Add(comp); }
            }

            var chargeMode = remainingSupply > 0.0f;
            var cellsToUse = chargeMode ? cells.Where(x => x.ChargeData.Charge < x.Capacity) : cells.Where(x => x.ChargeData.Charge > float.Epsilon);

            if (chargeMode)
            {
                // Go through each cell and decide if it is able to be charged based on remaining supply
                foreach (var c in cellsToUse)
                {
                    if ((remainingSupply -= c.Throughput) >= 0.0f)
                    {
                        c.Attached = true;
                        c.Charging = true;
                        EnergyDemand += c.Throughput;
                    }
                    else { c.Attached = false; }
                }
            }
            else
            {
                var dce = deficitComponents.GetEnumerator();
                var possibleCells = cellsToUse.GetEnumerator();
                var shortfallCells = new List<PowerStorageComponent>();

                // Go through each unsupplied component ..
                while (dce.MoveNext())
                {
                    var compReq = dce.Current.EnergyDemand;
                    // .. while batteries exist and it's needs are not being met ..
                    while (compReq > 0 && possibleCells.MoveNext())
                    {
                        // .. make sure cells is considered deactivated ..   
                        possibleCells.Current.Attached = false;
                        // .. attempt to meet its needs ..
                        compReq -= possibleCells.Current.Throughput;
                        shortfallCells.Add(possibleCells.Current);

                        // .. if needs met activate the cells in discharge mode ..
                        if (compReq <= 0)
                        {
                            shortfallCells.ForEach(c =>
                            {
                                c.Attached = true;
                                c.Charging = false;
                                EnergySupply += c.Throughput;
                            });
                            shortfallCells.Clear();
                        }
                    }
                }

                // .. deactive any unrequired cells
                while (possibleCells.MoveNext()) possibleCells.Current.Attached = false;
            }           
        }

        public override void LateTick()
        {
            // protection hack
            if (this.GetType().GetBaseAbstractType().GetField("<Parent>k__BackingField", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this) == null)
            {
                if (cells.First() != null)
                    this.GetType().GetBaseAbstractType().GetField("<Parent>k__BackingField", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, cells.First().Parent);
                else
                    this.Destroy();
            }
            // Once the supply/demand is correctly set tick the grid to ensure updates occur.
            this.PowerGrid.LateTick();

            // Then discharge / charge the cells accordingly for this tick
            cells.ForEach(c => c.UpdateStatus());
        }

        public override void Destroy()
        {
            if (cells.Any())
            {
                var destructCellStorage = cells.ToList();
                foreach (var c in destructCellStorage)
                {
                    c.Relink();
                    RemoveCell(c);
                }
            }

            if (GridInterfaceLinks.ContainsKey(PowerGrid))
                GridInterfaceLinks.Remove(PowerGrid);
            base.Destroy();
        }
    }
}