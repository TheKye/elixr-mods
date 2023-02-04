using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.TSO
{
    public class EndPoints
    {
        public static string CastVote        = "https://topservers.online/api/castvote?apikey={0}&votersteam64={1}";
        public static string UnclaimedVotes  = "https://topservers.online/api/claimvotes?apikey={0}&steamid={1}";

        public static string CastVoteURL( string ApiKey, string SteamdID )
        {
            return string.Format(CastVote, ApiKey, SteamdID);
        }
        
        public static string UnclaimedVotesURL( string ApiKey, string SteamdID )
        {
            return string.Format(UnclaimedVotes, ApiKey, SteamdID);
        }
    }
}