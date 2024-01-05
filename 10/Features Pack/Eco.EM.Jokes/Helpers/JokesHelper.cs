namespace Eco.EM.Jokes
{
    using Eco.EM.Framework;
    using Eco.EM.Framework.ChatBase;
    using Eco.EM.Framework.Networking;
    using Eco.Gameplay.Players;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal static class JokesHelper
    {
        internal static string EM_api = "https://claystk.info/jokes/";

        internal static Joke GetRandom(bool IncludeAdult = false)
        {
            if (IncludeAdult)
            {
                var response = Network.GetRequest($"{EM_api}getrandomadult");

                return Eco.Core.Serialization.SerializationUtils.DeserializeJson<Joke>(response);
            }
            else
            {
                var response = Network.GetRequest($"{EM_api}getrandom");

                return Eco.Core.Serialization.SerializationUtils.DeserializeJson<Joke>(response);
            }
        }

        internal static string SuggestJoke(string joke, User user)
        {
            if (string.IsNullOrWhiteSpace(joke))
                return "Joke cannot be left empty";

            ChatBaseExtended.CBInfoPane("Suggested Joke!", $"{joke}, {user.Name}, {Base.WhoAmI(user)}", "Jokes", user);

            var response = Network.PostRequest($"{EM_api}suggestjoke", new Dictionary<string, string>()
            {
                { "Joke"    , joke },
                { "UserName", user.Name },
                { "UserID"  , Base.WhoAmI(user) }
            });

            return response;
        }
    }
}
