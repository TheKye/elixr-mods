using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.StatTracking.Models
{
    public interface BaseTracker
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
    }
}
