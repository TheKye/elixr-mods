namespace Eco.EM
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay;
    using Eco.Gameplay.Systems.Chat;
    using Eco.EM;
    using System.Collections.Generic;
    using System;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;

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

        [ChatCommand("slap", "Slap a friend, for the fun of it")]
        public static void Slap(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBase.Send(new ChatBase.Message("Unable to find user \"" + target + "\"", user));
                return;
            }

            ChatBase.Send(new ChatBase.Message(user.Name + " slapped " + targetUser.Name + " with a stinky sock in the " + RandomBodyPart));
        }

        [ChatCommand("punch", "Friendly punch someone, just like the aussie\'s do")]
        public static void Punch(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error($"Error: Unable to find user \"{target}\""), user));
                return;
            }

            ChatBase.Send(new ChatBase.Message($"{user.Name} punched {targetUser.Name} in the {RandomBodyPart}"));
        }

        [ChatCommand("wave", "Wave at a friend")]
        public static void Wave(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error($"Error: Unable to find user \"{target}\""), user));
                return;
            }

            ChatBase.Send(new ChatBase.Message($"{user.Name} waved at {targetUser.Name}"));
        }

        [ChatCommand("hug", "Show a friend some love, by hugging them")]
        public static void Hug(User user, string target)
        {
            var targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error($"Error: Unable to find user \"{target}\""), user));
                return;
            }

            ChatBase.Send(new ChatBase.Message($"{user.Name} hugged {targetUser.Name}"));
        }

        [ChatCommand("suggest-joke", "Suggest a joke to be added to the Toolkit")]
        public static void SuggestJoke(User user, string Joke)
        {
            var response = JokesHelper.SuggestJoke(Joke, user);

            ChatBase.Send(new ChatBase.Message(response, user));
        }

        [ChatCommand("joke", "Get a random joke")]
        public static void Joke(User user)
        {
            Load();
            
            var joke = JokesHelper.GetRandom(config.IncludeAdult);

            if (joke == null)
            {
                ChatBase.Send(new ChatBase.Message(Text.Error("Error: Unable to get joke at this time."), user));
                return;
            }

            ChatBase.Send(new ChatBase.Message(joke.Text, user));
        }

        [ChatCommand("adult-jokes", "Should /joke return adult jokes or not? Default is off.", ChatAuthorizationLevel.Admin)]
        public static void AdultJokes(User user)
        {
            Load();

            config.IncludeAdult = !config.IncludeAdult;

            if (config.IncludeAdult)
                ChatBase.Send(new ChatBase.Message("Adult jokes has been turn on.", user));
            else
                ChatBase.Send(new ChatBase.Message("Adult jokes has been turn off.", user));
        }
    }
}
