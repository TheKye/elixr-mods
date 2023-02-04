using Eco.Gameplay.Objects;
using Eco.Gameplay.Rooms;
using Eco.Shared.Networking;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFlagPack.Helper
{
    class FlagHelper
    {
        public void CheckRoom(WorldObject flag, float range = 1f)
        {
            var objRoom = RoomData.Obj.GetNearestRoom(flag.Position);
            NetObjectManager
              .GetObjectsWithin(flag.Position.XYZi, range)
              .ForEach(obj =>
              {
                  WorldObject wo = obj as WorldObject;
                  if (wo != null && objRoom.RoomStats.Contained == true)
                  {
                      flag.SetAnimatedState("Enabled", true);
                  }
                  if (wo != null && objRoom.RoomStats.Contained == false)
                  {
                      flag.SetAnimatedState("Enabled", false);
                  }
              });
        }
    }
}
