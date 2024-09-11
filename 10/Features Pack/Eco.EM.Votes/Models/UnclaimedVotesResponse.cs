using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Votes
{
    public class UnclaimedVotesResponse
    {
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public UnclaimedVotesResponseResult Result { get; set; }
    }

    public class UnclaimedVotesResponseResult
    {
        public int Claimed { get; set; }
        public string User { get; set; }
    }
}
