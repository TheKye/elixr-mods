using System;

namespace Eco.EM.TP
{
    public class TeleportRequest
    {
        public string Requester { get; }
        public string Receiver { get; }
        public DateTime Timestamp { get; }

        public TeleportRequest(string req, string rec)
        {
            Requester = req;
            Receiver = rec;
            Timestamp = DateTime.Now;
        }

        public string Log()
        {
            return $"{Requester} teleported to {Receiver} at {Timestamp.TimeOfDay} on {Timestamp.ToShortDateString()}";
        }
    }
}
