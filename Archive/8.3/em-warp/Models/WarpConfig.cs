using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Warp
{
    public class WarpConfig
    {
        public bool Enable { get; set; } = true;
        public int CalorieCost { get; set; } = 100;
        public int Cooldown { get; set; }
        public List<Warp> Warps { get; set; } = new List<Warp>();
        public List<WarpLog> Logs { get; set; } = new List<WarpLog>();
    }
}
