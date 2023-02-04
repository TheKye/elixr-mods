using System;
using System.Collections.Generic;

namespace Eco.EM
{
    public class DailyLog
    {
        public string User { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class DailyLogs
    {
        public List<DailyLog> Logs { get; set; } = new List<DailyLog>();
    }
}
