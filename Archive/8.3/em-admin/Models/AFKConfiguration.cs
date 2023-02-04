using Eco.Shared.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM
{
    public class AFKConfiguration
    {
        public bool Enabled { get; set; } = true;
        public int Interval { get; set; } = 1200000;
    }
}
