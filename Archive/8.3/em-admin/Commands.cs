namespace Eco.EM
{
    using Eco.Core.Utils;
    using Eco.Gameplay;
    using Eco.Gameplay.Disasters;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Shared.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    class Admin : IChatCommandHandler
    {
        [ChatCommand("tp-here", "Teleport others to yourself, Admins Only", ChatAuthorizationLevel.Admin)]
        public static void TPHere(User user, string target)
        {
            User targetUser = Base.GetUserByName(target);

            if (targetUser == null)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr(string.Format("Unable to find user \"{0}\"", target)), user));
                return;
            }

            if (targetUser.Player == null)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr(string.Format("{0} is not online", targetUser.Name)), user.Player));
                return;
            }

            targetUser.Player.SetPosition(user.Player.Position);
            targetUser.Player.Rotation = user.Player.Rotation;

            ChatBase.Send(new ChatBase.Message(Localizer.DoStr(string.Format("{0} has been teleported to you", targetUser.Name)), user.Player));
            ChatBase.Send(new ChatBase.Message(Localizer.DoStr(string.Format("You have been teleported to {0}", user.Player.DisplayName)), user.Player));
        }

        [ChatCommand("meteor-on", "Turn on Meteor", ChatAuthorizationLevel.Admin)]
        public static void MeteorOn(User user)
        {
            DisasterPlugin.Settings.CreateMeteor = true;
            ChatBase.Send(new ChatBase.Message(Localizer.DoStr("Meteor has been enabled"), user));
        }

        [ChatCommand("meteor-off", "Turn off Meteor", ChatAuthorizationLevel.Admin)]
        public static void MeteorOff(User user)
        {
            DisasterPlugin.Settings.CreateMeteor = false;
            ChatBase.Send(new ChatBase.Message(Localizer.DoStr("Meteor has been diabled"), user));
        }

        public static string ListToString(List<User> Users)
        {
            string[] userlines = new string[Users.Count];

            for (int i = 0; i <= Users.Count; i++)
            {
                userlines[i] += $"{Users[i].Name} - {Users[i].Reputation} - {Users[i].Player.SkillTitle}";
            }

            return string.Join("\n", userlines);
        }

    }
}
