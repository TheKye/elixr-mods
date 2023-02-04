namespace Eco.EM
{
    using Eco.EM.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;

    public static class Base
    {
        internal const string oldLocation = "ElixrMods";
        internal const string saveLocation = "/Mods/ElixrMods/Configs";
        internal const string fileFormat = ".EM";
        public const string version = "2.0.0";
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        public const string appNameCon = "[Elixr Mods]: ";

        public static List<User> OnlineUsers => UserManager.OnlineUsers.ToList();
        public static List<User> Users => UserManager.Users.ToList();
        public static List<User> Admins => UserManager.Admins.ToList();
        public static List<User> OnlineAdmins => OnlineUsers.Where(u => u.IsAdmin == true).ToList();

        public static string SaveLocation => GetRelevantDirectory();
        public static string AssemblyLocation => Directory.GetCurrentDirectory();

        public static double UTime => DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

        static string GetRelevantDirectory()
        {
            if (saveLocation.StartsWith("/"))

                return AssemblyLocation + saveLocation;
            return saveLocation;
        }

        static void CreateDirectoryIfNotExist()
        {
            if (!Directory.Exists(SaveLocation))
                Directory.CreateDirectory(SaveLocation);
            
        }

        static string GetPathOf(string FileName)
        {
            if (FileName.Contains(fileFormat))
                return Path.Combine(SaveLocation, FileName);
            return Path.Combine(SaveLocation, FileName + fileFormat);
        }

        public static bool ConfigExists(string FileName) => File.Exists(GetPathOf(FileName));
        static string GetPath(string FileName)
        {
            if (!FileName.EndsWith(fileFormat))
                FileName += fileFormat;

            return Path.Combine(SaveLocation, FileName);
        }

        public static User GetUserByName(string UserName) => UserManager.FindUserByName(UserName);
        public static Player GetPlayerByName(string PlayerName) => GetUserByName(PlayerName).Player;
        public static User GetUser(string Filter) => UserManager.Users.FirstOrDefault(u => u.Name == Filter || u.SlgId == Filter || u.SteamId == Filter);

        public static string WhoAmI(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.SteamId))
                return user.SteamId;
            return user.SlgId;
        }

        #region Network Components
        public static string GetRequest(string URL)
        {
            var request = WebRequest.Create(URL) as HttpWebRequest;
            request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            var response = (HttpWebResponse)request.GetResponse();

            var header = response.Headers;

            var encoding = Encoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                return reader.ReadToEnd();
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
        #endregion

        public static BaseConfig Config
        {
            get
            {
                return FileManager<BaseConfig>.ReadFromFile(SaveLocation, "Base.EM");
            }
            set
            {
                FileManager<BaseConfig>.WriteToFile(value, SaveLocation, "Base.EM");
            }
        }
    }
}