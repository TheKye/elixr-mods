using Eco.EM.Framework.Helpers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Shared.Utils;
using Eco.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Energy.Sensors.Components
{
    public partial class Helpers
    {
        // Helper for toggling Daylight Sensor for day/night cycles
        public static void toggleDaylight(WorldObject sensor)
        {
            if (!sensor.HasComponent<OnOffComponent>())
                return;

            var daylight = DaylightSensorHelper.IsDayLight();
            if (sensor.GetComponent<OnOffComponent>().On)
            {
                sensor.SetAnimatedState("IsTurnedOn", true);
                sensor.SetAnimatedState("IsDaytime", daylight);
                return;
            }
            else
            {
                sensor.SetAnimatedState("IsTurnedOn", false);
                return;
            }
        }

        // Helper for toggling the proximity sensors for player proximity detection
        public static void toggleProxim(WorldObject sensor)
        {
            if (!sensor.HasComponent<OnOffComponent>())
                return;

            var anyoneNear = (PlayerSensor.AnyoneNear(sensor));
            if (sensor.GetComponent<OnOffComponent>().On)
            {
                sensor.SetAnimatedState("IsWorking", true);
                sensor.SetAnimatedState("HasDetection", anyoneNear);
                return;
            }
            else
            {
                sensor.SetAnimatedState("IsWorking", false);
                return;
            }
        }

        // Simple Check Top Block
        public static void checkTopBlock(WorldObject obj)
        {
            var placement = obj.Position3i;

        }

        // Power Overload Switch to turn off everything connected to the grid in the same room
        public static void PowerOverloadSwitch(WorldObject sensor)
        {
            if (!sensor.HasComponent<OnOffComponent>())
                return;

            var grid = sensor.GetComponent<PowerGridComponent>();
            bool powerOverloaded = grid.PowerGrid.EnergyDemand > grid.PowerGrid.EnergySupply;
            bool powerBalanced = grid.PowerGrid.EnergyDemand == grid.PowerGrid.EnergySupply;
            var senStorage = sensor.GetComponent<PublicStorageComponent>();
            if (powerOverloaded && !powerBalanced)
            {
                sensor.SetAnimatedState("On", false);
                //Todo Add Chance for Blown Fuse instead of constantly breaking
                if(senStorage.Inventory.TotalNumberOfItems<FuseItem>() != 0)
                {
                    senStorage.Inventory.TryRemoveItem<FuseItem>();
                    senStorage.Inventory.TryAddItem<BrokenFuseItem>();
                }

                Framework.Helpers.Sensors.PowerSensor(sensor);
                return;
            }
        }
    }
}
