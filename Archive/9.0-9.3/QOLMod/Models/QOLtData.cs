using Eco.EM.Framework.Groups;
using Eco.Gameplay.Players;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Eco.EM.QOL
{
    [Serializable]
    public class QOLData
    {
        public DateTime LastReset { get; private set; } = DateTime.MinValue;
        public DateTime NextReset { get; private set; } = DateTime.MinValue;

        public Dictionary<string, QOLUserData> Users { get; private set; }

        public QOLData()
        {
            Users = new Dictionary<string, QOLUserData>();

            if (LastReset == DateTime.MinValue)
                LastReset = DateTime.Now;

            if (NextReset == DateTime.MinValue)
                NextReset = LastReset + TimeSpan.FromDays(1);
        }

        internal QOLUserData GetQOLUserData(string user)
        {
            if (Users.ContainsKey(user))
                return Users[user];

            return null;
        }

        internal int GetMaxSkills(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int maxSkills = QOLManager.Config.MaxSkills;

            if (groups == null)
                return maxSkills;

            foreach (var grp in groups)
            {
                var tpPermission = grp.Permissions.Find(p => p.Identifier == QOLManager.ID);

                if (tpPermission != null)
                {
                    var config = (QOLConfig)tpPermission;
                    if (config.MaxSkills > maxSkills)
                        maxSkills = config.MaxSkills;
                }
            }

            return maxSkills;
        }

        internal int GetMaxTalents(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int maxTalents = QOLManager.Config.MaxTalents;

            if (groups == null)
                return maxTalents;

            foreach (var grp in groups)
            {
                var tpPermission = grp.Permissions.Find(p => p.Identifier == QOLManager.ID);

                if (tpPermission != null)
                {
                    var config = (QOLConfig)tpPermission;
                    if (config.MaxSkills > maxTalents)
                        maxTalents = config.MaxSkills;
                }
            }

            return maxTalents;
        }

        internal void ResetSkills(DateTime check)
        {
            if (check > NextReset)
            {
                LastReset = NextReset;

                // progressively add 24hrs until next reset is beyond now.
                while (check > NextReset)
                {
                    NextReset += TimeSpan.FromDays(1);
                }

                Users.ForEach(u => u.Value.ResetUsers());
                QOLManager.SaveData();
            }
        }
    }
}