using Eco.Shared.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Admin
{
    public class UserHistory
    {
        public int        UserId { get; set; }
        public long       Timestamp { get; set; }
        public Vector2    Cursor { get; set; }
        public Vector3    Position { get; set; }
        public Direction Facing { get; set; }
        public Quaternion Rotation { get; set; }
    }
}
