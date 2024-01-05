using Eco.Shared.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Admin
{
    public class AFKConfiguration
    {
        public bool Enabled { get; set; } = false;
        public int Interval { get; set; } = 30;
        public bool KickAdmins { get; set; } = false;
    }
}
