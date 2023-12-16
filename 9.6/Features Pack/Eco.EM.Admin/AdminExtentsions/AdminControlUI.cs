using Eco.EM.Framework.Text;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using Eco.Simulation.Time;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Eco.EM.Framework.Utils.ColoredText;

namespace Eco.EM.Admin.AdminExtentsions
{
    public class AdminControlUI
    {

        public static LocString DisplayUserAdminInformation(User user)
        {
            var statsDisplay = new LocStringBuilder();
            var ip = user.Client.Connection.GetPropertyValueByName<IPEndPoint>("RemoteEndPoint").Address.ToString();

            var calc = TimeFormatter.FormatSpan(WorldTime.Seconds - user.LoginTime);

            statsDisplay.Append("User: " + user.Name + "\n");
            statsDisplay.Append("SteamID: " + user.SteamId + "\n");
            statsDisplay.Append("SLGID: " + user.SlgId + "\n");
            statsDisplay.Append("Is Admin: " + string.Format(user.IsAdmin ? "Yes".Green() : "No".Red()) + "\n");
            statsDisplay.Append("IP: " + ip + "\n");
            statsDisplay.Append("Current Playtime: " + calc + "\n"); 


            return statsDisplay.ToLocString();
        }

    }
}
