using Eco.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.TSO
{
    public class VoteLogs
    {
        public ThreadSafeList<VoteItem> Votes { get; set; } = new ThreadSafeList<VoteItem>();
    }
}
