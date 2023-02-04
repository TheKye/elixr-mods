using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM
{
    public class Homes
    {
        public List<HomeItem> List { get; set; } = new List<HomeItem>();
        public List<LogItem> Logs { get; set; } = new List<LogItem>();
        public int CaloriesCost { get; set; } = 500;
        public int LimitPerDay { get; set; } = 10;
        public int MaxHomeCount { get; set; } = 5;
    }
}