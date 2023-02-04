using Eco.Gameplay.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eco.EM;

namespace Eco.EM.TP
{
    public class TeleportRequest
    {
        public string Requester { get; set; }
        public string Receiver { get; set; }
        public double Timestamp { get; set; }
    }
}
