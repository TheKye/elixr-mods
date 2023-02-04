namespace Eco.EM.GreenEnergy
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
    using Eco.EM.Helpers;
    using Eco.EM.Components;
    using static Eco.EM.Components.AutoDoors;

    public static class Sensors
    {
        public static void MotionSensor(WorldObject sensor, float range = 20f)
        {
            if (!sensor.GetComponent<OnOffComponent>().On)
                return;

            var objRoom = RoomData.Obj.GetNearestRoom(sensor.Position);
            var anyoneNear = (PlayerSensor.AnyoneInSameRoom(sensor));
            NetObjectManager
                .GetObjectsWithin(sensor.Position.XZ, range)
                .ForEach(obj =>
                {
                    WorldObject wo = obj as WorldObject;
                    if (wo != null &&
                        wo.HasComponent<OnOffComponent>() &&
                        wo.HasComponent<MinimapComponent>() &&
                        Compare.IsLike(wo.GetComponent<MinimapComponent>().Category, "lights"))
                    {
                        var lightRoom = RoomData.Obj.GetNearestRoom(wo.Position);

                        if (lightRoom.Id == objRoom.Id)
                        {
                            wo.SetAnimatedState("IsOn", anyoneNear);
                            wo.GetComponent<OnOffComponent>().On = anyoneNear;
                        }
                    }

                    if (wo != null &&
                        wo.HasComponent<OnOffComponent>() &&
                        wo.HasComponent<MinimapComponent>() &&
                        Compare.IsLike(wo.GetComponent<MinimapComponent>().Category, "Misc"))
                    {
                        {
                            wo.SetAnimatedState("IsOff", !anyoneNear);
                            wo.GetComponent<OnOffComponent>().On = !anyoneNear;
                        }
                    }

                });
        }

        public static void ProximitySensor(WorldObject sensor, float range = 20f)
        {
            if (!sensor.GetComponent<OnOffComponent>().On)
                return;

            var anyoneNear = (PlayerSensor.AnyoneNear(sensor));
            NetObjectManager
                .GetObjectsWithin(sensor.Position.XZ, range)
                .ForEach(obj =>
                {
                    WorldObject wo = obj as WorldObject;
                    if (wo != null &&
                        wo.HasComponent<OnOffComponent>() &&
                        wo.HasComponent<MinimapComponent>() &&
                        Compare.IsLike(wo.GetComponent<MinimapComponent>().Category, "lights"))
                    {
                        wo.SetAnimatedState("IsOn", anyoneNear);
                        wo.GetComponent<OnOffComponent>().On = anyoneNear;
                    }

                    if (wo != null &&
                        wo.HasComponent<OnOffComponent>() &&
                        wo.HasComponent<MinimapComponent>() &&
                        Compare.IsLike(wo.GetComponent<MinimapComponent>().Category, "Misc"))
                    {
                        wo.SetAnimatedState("IsOff", !anyoneNear);
                        wo.GetComponent<OnOffComponent>().On = !anyoneNear;
                    }
                });
        }

        public static void AuthorizedProximitySensor(AutoDoor obj, float range = 20f)
        {
            if ((obj as WorldObject).GetComponent<OnOffComponent>().On == false) return;

            var IsAnyoneNear = (PlayerSensor.AuthorizedPersonnelNear(obj as WorldObject, (int)range));

            obj.SetState(IsAnyoneNear);
        }

        public static void AAuthorizedProximitySensor(LAutoDoor obj, float range = 20f)
        {
            if ((obj as WorldObject).GetComponent<OnOffComponent>().On == false) return;

            var IsAnyoneNear = (PlayerSensor.AuthorizedPersonnelNear(obj as WorldObject, (int)range));

            obj.SetState(IsAnyoneNear);
        }

        public static void DaylightSensor(WorldObject sensor, float range = 20f)
        {
            if (!sensor.GetComponent<OnOffComponent>().On)
                return;

            var isDaylight = DaylightSensorHelper.IsDayLight();
            NetObjectManager
                .GetObjectsWithin(sensor.Position.XZ, range)
                .ForEach(obj =>
                {
                    WorldObject wo = obj as WorldObject;
                    if (wo != null &&
                        wo.HasComponent<OnOffComponent>() &&
                        wo.HasComponent<MinimapComponent>() &&
                        Compare.IsLike(wo.GetComponent<MinimapComponent>().Category, "lights"))
                    {
                        wo.SetAnimatedState("IsOn", !isDaylight);
                        wo.GetComponent<OnOffComponent>().On = !isDaylight;
                    }

                });
        }
    }
}
