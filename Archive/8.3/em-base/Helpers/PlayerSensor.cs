namespace Eco.EM.GreenEnergy
{
    using Eco.Gameplay.Auth;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Rooms;
    using Eco.Shared.Items;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using System;
    using Eco.EM;

    public static class PlayerSensor
    {
        public static bool AnyoneNear( WorldObject obj, int MaxSensorDistance = 20 )
        {
            foreach (var user in Base.OnlineUsers)
            {
                float dist = Vector3.Distance( obj.Position, user.Position );
                return ( dist <= MaxSensorDistance );
            }

            return false;
        }

        public static bool AuthorizedPersonnelNear(WorldObject obj, int MaxSensorDistance = 20)
        {
            foreach (var user in Base.OnlineUsers)
            {
                var auth = obj?.GetComponent<AuthComponent>();
                if (auth != null)
                {
                    float dist = Vector3.Distance(obj.Position, user.Position);
                    if (dist <= MaxSensorDistance)
                        return true;
                }
            }

            return false;
        }
        public static bool AnyoneInSameRoom( WorldObject obj, int MaxSensorDistance = 20 )
        {
            var objRoom = RoomData.Obj.GetNearestRoom( obj.Position );

            foreach (var user in Base.OnlineUsers)
            {
                float dist = Vector3.Distance( obj.Position, user.Position );
                if (dist <= MaxSensorDistance)
                {
                    int x = user.Position.Ceiling.x,
                        y = user.Position.Ceiling.y,
                        z = user.Position.Ceiling.z;

                    var userRoom = RoomData.Obj.GetNearestRoom( new Vector3( x, y, z ) );

                    if (userRoom != null &&
                        userRoom.Id == objRoom.Id)
                        return true;
                }
            }

            return false;
        }

        public static User GetNear( WorldObject obj, int MaxSensorDistance = 20 )
        {
            foreach (var user in Base.OnlineUsers)
            {
                float dist = Vector3.Distance( obj.Position, user.Position );
                if (dist <= MaxSensorDistance)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
