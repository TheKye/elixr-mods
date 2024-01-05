using Eco.Gameplay.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.RP.Policing.Helpers
{
    public class FinesHelper
    {
        private static readonly IEnumerable<Fine> fines;
        public static Fine GetFineType(string fineName)
        {
            Fine fine = null;
            foreach(var f in fines)
            {
                if (f.FineName.ToLower() == fineName.ToLower())
                    return f;
            }
            return fine;
        }

        public static void SetPlayerFine(User user, Fine fine)
        {
            // store a new fine 
        }
    }

    public class Fine
    {
        public string FineName { get; set; }

        public float FineAmount { get; set; }

        public string FineWriteup { get; set; }

        public Fine(string fineName, float fineAmount, string fineWriteup)
        {
            FineName = fineName;
            FineAmount = fineAmount;
            FineWriteup = fineWriteup;
        }
    }
}
