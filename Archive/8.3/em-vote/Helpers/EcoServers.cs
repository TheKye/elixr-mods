using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.VoteRewards
{
    class EcoServers
    {
        public static string GetServerURL(string ServerApiKey)
        {
            try
            {
                string Response = Base.GetRequest(EndPoints.ServerDetails.Replace("<apikey>", ServerApiKey));

                string ServerURL = Response.Remove(0, Response.IndexOf("\"url\"") + 7);
                ServerURL = ServerURL.Remove(ServerURL.IndexOf(",") - 2);

                return ServerURL;
            }
            catch (WebException)
            {
                ChatBase.Send(new ChatBase.Message("EcoServers.io is unavailable at this time."));
            }

            return string.Empty;
        }
    }
}
