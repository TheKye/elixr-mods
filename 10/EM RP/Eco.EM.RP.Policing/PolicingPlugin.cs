using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.Groups;
using Eco.EM.Framework.Permissions;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Animals;
using Eco.Gameplay.Civics.Demographics;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using Eco.Simulation.Types;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.RP.Policing
{
    public class PolicingPlugin : IModKitPlugin, IModInit, IInitializablePlugin
    {
        public string GetStatus()
        {
            return "";
        }

        public void Initialize(TimedTask timer)
        {



        }

        public override string ToString()
        {
            return "";
        }

        public static void GenerateRanks()
        {
            List<Group> allGroups = GroupsManager.API.AllGroups();
            Group cadetRank = allGroups.FirstOrDefault(x => x.GroupName == "Cadet");
            Group officerRank = allGroups.FirstOrDefault(x => x.GroupName == "Police Officer");
            Group sgtRank = allGroups.FirstOrDefault(x => x.GroupName == "Police Sargent");
            Group chiefRank = allGroups.FirstOrDefault(x => x.GroupName == "Chief Of Police");

            if (cadetRank == null)
                GroupsManager.Data.GetorAddGroup("Cadet", true);

            if (officerRank == null)
                GroupsManager.Data.GetorAddGroup("Police Officer", true);

            if (sgtRank == null)
                GroupsManager.Data.GetorAddGroup("Police Sargent", true);

            if (chiefRank == null)
                GroupsManager.Data.GetorAddGroup("Chief Of Police", true);



            CommandGroupsCommands.Grant(null, "", chiefRank.GroupName);
            CommandGroupsCommands.Grant(null, "", chiefRank.GroupName);
            CommandGroupsCommands.Grant(null, "", chiefRank.GroupName);
            CommandGroupsCommands.Grant(null, "", chiefRank.GroupName);
        }
    }
}
