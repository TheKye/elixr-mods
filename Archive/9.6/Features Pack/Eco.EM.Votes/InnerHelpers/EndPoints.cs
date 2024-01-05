using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Votes
{
    public class EndPoints
    {
        //TSO Endpoints
        public static string TSOCastVote        = "https://playeco.online/api/castvote?apikey={0}&votersteam64={1}";
        public static string TSOUnclaimedVotes  = "https://playeco.online/api/claimvotes?apikey={0}&steamid={1}";
        public static string TSOTopVoters       = "https://playeco.online/api/topvoters?apikey={0}";

        //Ecoservers.io Endpoints
        public static string ESUnclaimedVotes = "https://ecoservers.io/api/?object=votes&element=claim&key={0}&steamid={1}";
        public static string ESUnclaimedVotesuser = "https://ecoservers.io/api/?object=votes&element=claim&key={0}&username={1}";
        public static string ESTopVoters = "https://ecoservers.io/api/?object=servers&element=voters&key={0}&month=current&format=json";

        public static string CastVoteTSOURL(string ApiKey, string SteamdID )
        {
            return string.Format(TSOCastVote, ApiKey, SteamdID);
        }
        
        public static string UnclaimedVotesTSOURL(string ApiKey, string SteamdID )
        {
            return string.Format(TSOUnclaimedVotes, ApiKey, SteamdID);
        }

        public static string TopVotersTSOURL(string ApiKey)
        {
            return string.Format(TSOTopVoters, ApiKey);
        }

        public static string UnclaimedVotesESURL(string ApiKey, string SteamdID)
        {
            return string.Format(ESUnclaimedVotes, ApiKey, SteamdID);
        }

        public static string UnclaimedVotesESURLuser(string ApiKey, string username)
        {
            return string.Format(ESUnclaimedVotesuser, ApiKey, username);
        }

        public static string TopVotersESURL(string ApiKey)
        {
            return string.Format(ESTopVoters, ApiKey);
        }
    }
}