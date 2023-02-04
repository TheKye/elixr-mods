using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Admin
{
    public class MakeUserVomit : IChatCommandHandler
    {
        [ChatCommand("Makes the target player Vomit, Emptying their stomach.", "makevomit", ChatAuthorizationLevel.Admin)]
        public static void BeSick(User user, User targetUser)
        {
            if (targetUser == null)
            {
                user.ErrorLocStr($"Couldn't Find a User with the name: {targetUser}");
                return;
            }

            var stomach = targetUser.Player.User.Stomach;
            stomach.ClearCalories(user.Player);
            stomach.Contents.RemoveAll(entry => true);
            stomach.RecalcAverageNutrients();

            targetUser.Player.MsgLocStr("Bad elk meat?");
            user.Player.MsgLocStr("Done");
        }

    }
}