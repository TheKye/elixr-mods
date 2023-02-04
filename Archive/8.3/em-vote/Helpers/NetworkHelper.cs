using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Eco.TSO
{
    public class NetworkHelper
    {
        public static string GET( string URL, string UserIP = "" ) {
            var request = WebRequest.Create(URL) as HttpWebRequest;
            request.Timeout = 10;
            request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);

            if ( !string.IsNullOrEmpty( UserIP ) )
                request.Headers.Add( "TSO-CONNECTING-IP", UserIP );

            var response = (HttpWebResponse)request.GetResponseAsync().Result;

            var header = response.Headers;
            var content = string.Empty;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.ASCII))
            {
                return reader.ReadToEnd();
            }
        }

        public static string POST( string URL ) {
            var request = WebRequest.Create(URL) as HttpWebRequest;
            request.Method = "POST";
            request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            var response = (HttpWebResponse)request.GetResponse();

            var header = response.Headers;

            var encoding = Encoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                return reader.ReadToEnd();
            }
        }
    }
}