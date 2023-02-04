using Eco.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM
{
    public class TeleportConfig
    {
        public int CalorieCost                { get; set; } = 500;
        public int CooldownSeconds            { get; set; } = 900;
        public int Expiry                     { get; set; } = 15;
    }
    
    public class TeleportLogs
    {
        public List<TeleportLog>     List     { get; set; } = new List<TeleportLog>();
        public List<TeleportRequest> Requests { get; set; } = new List<TeleportRequest>();
    }
}
