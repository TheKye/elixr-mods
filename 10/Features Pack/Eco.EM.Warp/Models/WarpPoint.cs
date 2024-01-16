using Eco.Core.Controller;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;

namespace Eco.EM.Warp
{
    [Serialized]
    public class WarpPoint
    {
        [Eco, ClientInterfaceProperty]
        public string PointName { get; set; }
        public System.Numerics.Vector3 Location { get; set; }
        public Quaternion Rotation { get; set; }

        public WarpPoint(string pointName, System.Numerics.Vector3 loc, Quaternion rot)
        {
            PointName = pointName;
            Location = loc;
            Rotation = rot;
        }

        public void ChangeName(string newName)
        {
            PointName = newName;
        }
    }
}
