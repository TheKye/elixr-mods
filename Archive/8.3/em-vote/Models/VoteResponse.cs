using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.TSO
{
    public class VoteResponse
    {
        public string name { get; set; }
        public string address { get; set; }
        public string port { get; set; }
        public string month { get; set; }
        public List<VoteItem> votes { get; set; }
    }
}
