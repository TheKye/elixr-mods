namespace Eco.EM.Jokes
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay;
    using Eco.Gameplay.Systems.Chat;
    using Eco.EM;
    using System.Collections.Generic;
    using System;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Eco.EM.Framework;
    using Eco.EM.Framework.ChatBase;
    using Eco.EM.Framework.FileManager;

    public class Jokes :  IChatCommandHandler
    {
        static List<string> bodyParts = new List<string>();
        static JokesConfig config;
        static bool loaded = false;

        public Jokes()
        {
            Load();
        }

        public static void Load()
        {
            if (!loaded)
            {
                bodyParts.Add("Face");
                bodyParts.Add("Head");
                bodyParts.Add("Arm");
                bodyParts.Add("Stomach");
                bodyParts.Add("Knee");
                bodyParts.Add("Elbow");
                bodyParts.Add("Thigh");
                bodyParts.Add("Neck");

                config = FileManager<JokesConfig>.ReadFromFile(Base.SaveLocation, "JokesConfig.EM");

                loaded = true;
            }
        }

        public static string RandomBodyPart
        {
            get
            {
                var random = new Random();
                if (bodyParts.Count == 0)
                    Load();

                int partIndex = random.Next(0, bodyParts.Count - 1);

                return bodyParts[partIndex];
            }
        }

        [ChatCommand("Slap a friend, for the fun of it")]
        public static void Slap(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBaseExtended.CBError("Unable to find user \"" + target + "\"", user);
                return;
            }

            ChatBaseExtended.CBChat(user.Name + " slapped " + targetUser.Name + " with a stinky sock in the " + RandomBodyPart, ChatBase.MessageType.Temporary);
        }

        [ChatCommand("Friendly punch someone, just like the aussie\'s do")]
        public static void Punch(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBaseExtended.CBError($"Error: Unable to find user \"{target}\"", user);
                return;
            }

            ChatBaseExtended.CBChat($"{user.Name} punched {targetUser.Name} in the {RandomBodyPart}", ChatBase.MessageType.Temporary);
        }

        [ChatCommand("Wave at a friend")]
        public static void Wave(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBaseExtended.CBError($"Error: Unable to find user \"{target}\"", user);
                return;
            }

            ChatBaseExtended.CBChat($"{user.Name} waved at {targetUser.Name}", ChatBase.MessageType.Temporary);
        }

        [ChatCommand("Show a friend some love, by hugging them")]
        public static void Hug(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBaseExtended.CBError($"Error: Unable to find user \"{target}\"", user);
                return;
            }

            ChatBaseExtended.CBChat($"{user.Name} hugged {targetUser.Name}", ChatBase.MessageType.Temporary);
        }

        [ChatCommand("Suggest a joke to be added to the Toolkit")]
        public static void SuggestJoke(User user, string Joke)
        {
            var response = JokesHelper.SuggestJoke(Joke, user);

            ChatBaseExtended.CBInfoBox(response, user);
        }

        [ChatCommand("Get a random joke")]
        public static void Joke(User user)
        {
            Load();
            
            var joke = JokesHelper.GetRandom(config.IncludeAdult);

            if (joke == null)
            {
                ChatBaseExtended.CBError("Error: Unable to get joke at this time.", user);
                return;
            }

            ChatBaseExtended.CBInfoBox(joke.Text, user);
        }

        [ChatCommand("Should /joke return adult jokes or not? Default is off.", "adult-jokes", ChatAuthorizationLevel.Admin)]
        public static void AdultJokes(User user)
        {
            Load();

            config.IncludeAdult = !config.IncludeAdult;

            if (config.IncludeAdult)
                ChatBaseExtended.CBInfoBox("Adult jokes has been turn on.", user);
            else
                ChatBaseExtended.CBInfoBox("Adult jokes has been turn off.", user);
        }
    }
}
