using Eco.EM;
using Eco.Gameplay.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM
{
    internal static class JokesHelper
    {
        internal static string EM_api = "https://claystk.info/jokes/";

        internal static Joke GetRandom(bool IncludeAdult = false)
        {
            if (IncludeAdult)
            {
                var response = Base.GetRequest($"{EM_api}getrandomadult");

                return Eco.Core.Serialization.SerializationUtils.DeserializeJson<Joke>(response);
            }
            else
            {
                var response = Base.GetRequest($"{EM_api}getrandom");

                return Eco.Core.Serialization.SerializationUtils.DeserializeJson<Joke>(response);
            }
        }

        internal static string SuggestJoke(string joke, User user)
        {
            if (string.IsNullOrWhiteSpace(joke))
                return "Joke cannot be left empty";

            ChatBase.Send(new ChatBase.Message($"{joke}, {user.Name}, {Base.WhoAmI(user)}"));

            var response = Base.PostRequest($"{EM_api}suggestjoke", new Dictionary<string, string>()
            {
                { "Joke"    , joke },
                { "UserName", user.Name },
                { "UserID"  , Base.WhoAmI(user) }
            });
            
            return response;
        }
    }
}
