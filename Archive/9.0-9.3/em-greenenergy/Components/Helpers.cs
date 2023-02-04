using Eco.EM.Framework.Helpers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.GreenEnergy.Components
{
    public partial class Helpers
    {
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

        public static void checkTopBlock(WorldObject obj)
        {
            var placement = obj.Position3i;

        }
    }
}
