using Eco.Shared.Math;

namespace Eco.EM.Warp
{
    public class WarpPoint
    {
        public string PointName { get; set; }
        public Vector3 Location { get; set; }
        public Quaternion Rotation { get; set; }

        public WarpPoint(string pointName, Vector3 loc, Quaternion rot)
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
