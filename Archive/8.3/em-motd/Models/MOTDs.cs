using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM
{
    public class MOTDs
    {
        public List<string> Messages { get; set; } = new List<string>();
        public bool SlowMode { get; set; } = true;
        public int Interval { get; set; } = 900;
    }
}
