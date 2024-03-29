﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Eco.EM.Framework.Networking
{
    public static class Network
    {
        public static string GetRequest(string URL)
        {
            try
            {
                var request = WebRequest.Create(URL) as HttpWebRequest;
                request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                var response = (HttpWebResponse)request.GetResponse();

                var header = response.Headers;

                var encoding = Encoding.ASCII;
                using (var reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string PostRequest(string URL, Dictionary<string, string> Parameters)
        {
            try
            {
                var Request = WebRequest.Create(URL) as HttpWebRequest;
                var PostData = string.Empty;

                foreach (var param in Parameters)
                {
                    if (!string.IsNullOrWhiteSpace(PostData))
                    {
                        PostData += "&";
                    }

                    PostData += $"{param.Key}={param.Value}";
                }
                var data = Encoding.ASCII.GetBytes(PostData);

                Request.Method = "POST";
                Request.ContentType = "application/x-www-form-urlencoded";
                Request.ContentLength = data.Length;

                using (var stream = Request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var Response = Request.GetResponse() as HttpWebResponse;
                var ResponseString = new StreamReader(Response.GetResponseStream()).ReadToEnd();

                return ResponseString;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string PostRequestResponse(string URL, Dictionary<string, string> Parameters)
        {
            try
            {
                if (Parameters != null)
                    foreach (var parameter in Parameters)
                    {
                        URL += (URL.Contains("?")) ? "&" : "?";
                        URL += $"{parameter.Key}={parameter.Value}";
                    }

                using (var client = new WebClient())
                {
                    return client.UploadString(URL, "POST", string.Empty);
                }
            }
            catch (Exception e)
            {
                return URL + " " + e.Message;
            }
        }
    }
}
