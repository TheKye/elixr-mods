using Eco.Core.Systems;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Gameplay.Utils;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System.Linq;

namespace Eco.EM.Admin.AdminExtentsions
{
    static class ToolTipExtentsions
    {
        [Tooltip(99), NewTooltip(Shared.Items.CacheAs.User, 99)]
        public static LocString UsersTooltipExtension(this User user, User viewer)
        {
            if (!viewer.IsAdmin || !AdminPlugin.Obj.Config.EnableExtraAdminInfo)
                return Localizer.DoStr("");
            var sb = new LocStringBuilder();
            //var entryLink = TextLinkManager.GetLinkId(Registrars.Get<OpenAdminUI>().FirstOrDefault(entry => entry.RelatedUser == viewer));

            sb.Append(TextLoc.HeaderLoc($"User Information \n"));
            sb.Append(TextLoc.SubtextLoc($"{AdminControlUI.DisplayUserAdminInformation(user)}"));

            //sb.Append(TextLoc.RPCButtonLocStr($"\nActions", entryLink, nameof(OpenAdminUI.OpenAdminUtils), Color.PaperGreen, 40, viewer.Id.ToString()));

            return sb.ToLocString();
        }
        
    }

    public class OpenAdminUI : SimpleEntry, ILinkable
    {
        [Serialized] public User RelatedUser { get; set; }

        [RPC] public void OpenAdminUtils(string userId) 
        {
            var user = UserManager.FindUserByID(int.Parse(userId));
            user.Player.MsgLocStr("Just Making Sure it works");
        }
    }
}
