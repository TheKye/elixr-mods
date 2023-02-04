using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Admin
{
    public class MakeUserVomit : IChatCommandHandler
    {
        [ChatCommand("Makes the target player Vomit, Emptying their stomach.", "", ChatAuthorizationLevel.Admin)]
        public static void BeSick(User user, string targetUser)
        {
            User target = UserManager.FindUserByName(targetUser);
            var stomach = target.Player.User.Stomach;
            stomach.ClearCalories(user.Player);
            stomach.Contents.RemoveAll(entry => true);
            stomach.RecalcAverageNutrients();

            target.Player.MsgLocStr("Bad elk meat?");
            user.Player.MsgLocStr("Done");
        }

    }
}
