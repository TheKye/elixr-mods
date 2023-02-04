namespace Eco.EM.Framework.Helpers
{
    using Eco.EM;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Serialization;
    using Eco.Mods.TechTree;
    using Eco.Shared.Networking;
    using Eco.Gameplay.Rooms;
    using Eco.Shared.Utils;
    using System;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Housing;

    public static class Sensors
    {
        public static void MotionSensor(WorldObject sensor, float range = 20f)
        {
            if (!sensor.HasComponent<OnOffComponent>())
                return;
            if (!sensor.GetComponent<OnOffComponent>().On)
                return;

            var objRoom = RoomData.Obj.GetNearestRoom(sensor.Position);
            var anyoneNear = (PlayerSensor.AnyoneInSameRoom(sensor));
            NetObjectManager
                .GetObjectsWithin(sensor.Position.XYZi, range)
                .ForEach(obj =>
                {
                    WorldObject wo = obj as WorldObject;
                    if (wo != null &&
                        wo.HasComponent<OnOffComponent>() &&
                        wo.HasComponent<HousingComponent>() &&
                        Compare.IsLike(wo.GetComponent<HousingComponent>().HousingVal.TypeForRoomLimit, "Lights"))
                    {
                        var lightRoom = RoomData.Obj.GetNearestRoom(wo.Position);

                        if (lightRoom.Id == objRoom.Id)
                        {
                            wo.SetAnimatedState("IsOn", anyoneNear);
                            wo.GetComponent<OnOffComponent>().On = anyoneNear;
                            return;
                        }
                    }
                });
        }
        public static void ProximitySensor(WorldObject sensor, float range = 20f)
        {
            if (!sensor.HasComponent<OnOffComponent>())
                return;
            if (!sensor.GetComponent<OnOffComponent>().On)
                return;

            var anyoneNear = (PlayerSensor.AnyoneNear(sensor));
            NetObjectManager
                .GetObjectsWithin(sensor.Position.XYZi, range)
                .ForEach(obj =>
                {
                    WorldObject wo = obj as WorldObject;
                    if (wo != null &&
                        wo.HasComponent<OnOffComponent>() &&
                        wo.HasComponent<HousingComponent>() &&
                        Compare.IsLike(wo.GetComponent<HousingComponent>().HousingVal.TypeForRoomLimit, "Lights"))
                    {
                        wo.SetAnimatedState("IsOn", anyoneNear);
                        wo.GetComponent<OnOffComponent>().On = anyoneNear;
                        return;
                    }
                });
        }
        public static void AuthorizedSensor(WorldObject sensor, float range = 20f)
        {
            if (!sensor.HasComponent<OnOffComponent>())
                return;
            if (!sensor.GetComponent<OnOffComponent>().On)
                return;

            var anyoneNear = (PlayerSensor.AuthorizedPersonnelNear(sensor, (int)range));
            NetObjectManager
                .GetObjectsWithin(sensor.Position.XYZi, range)
                .ForEach(obj =>
                {
                    WorldObject wo = obj as WorldObject;
                    if (wo != null &&
                        wo.HasComponent<OnOffComponent>() &&
                        wo.HasComponent<HousingComponent>() &&
                        Compare.IsLike(wo.GetComponent<HousingComponent>().HousingVal.TypeForRoomLimit, "Lights"))
                    {
                        wo.SetAnimatedState("IsOn", anyoneNear);
                        wo.GetComponent<OnOffComponent>().On = anyoneNear;
                        return;
                    }
                });
        }
        public static void DaylightSensor(WorldObject sensor, float range = 20f)
        {
            if (!sensor.HasComponent<OnOffComponent>())
                return;
            if (!sensor.GetComponent<OnOffComponent>().On)
                return;

            var isDaylight = DaylightSensorHelper.IsDayLight();
            NetObjectManager
                .GetObjectsWithin(sensor.Position.XYZi, range)
                .ForEach(obj =>
                {
                    WorldObject wo = obj as WorldObject;
                    if (wo != null &&
                        wo.HasComponent<OnOffComponent>() &&
                        wo.HasComponent<HousingComponent>() &&
                        Compare.IsLike(wo.GetComponent<HousingComponent>().HousingVal.TypeForRoomLimit, "Lights") && !isDaylight)
                    {
                        wo.SetAnimatedState("IsOn", true);
                        wo.GetComponent<OnOffComponent>().On = true;
                        return;
                    }
                    if (wo != null &&
                         wo.HasComponent<OnOffComponent>() &&
                         wo.HasComponent<HousingComponent>() &&
                         Compare.IsLike(wo.GetComponent<HousingComponent>().HousingVal.TypeForRoomLimit, "Lights") && isDaylight)
                    {
                        wo.SetAnimatedState("IsOn", false);
                        wo.GetComponent<OnOffComponent>().On = false;
                        return;
                    }
                });
        }
    }
}
