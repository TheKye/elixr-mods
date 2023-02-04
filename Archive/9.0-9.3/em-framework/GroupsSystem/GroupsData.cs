using Eco.Gameplay.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Framework.Groups
{
    [Serializable]
    public class GroupsData
    {
         public HashSet<Group> Groups { get; private set; }
         public HashSet<SimpleGroupUser> AllUsers { get; private set; }

        public GroupsData() 
        {
            Groups = new HashSet<Group>();
            AllUsers = new HashSet<SimpleGroupUser>();
        }

        // May return null if not set to create, so make sure to protect for those cases.
        public Group GetorAddGroup(string dirtyGroupName, bool create = false)
        {
            var cleanGroupName = Base.Sanitize(dirtyGroupName);
            Group group = Groups.FirstOrDefault(g => g.GroupName == cleanGroupName);

            if (group == null && create)
            {
                group = new Group(cleanGroupName);
                Groups.Add(group);
            }

            return group;
        }

        public bool DeleteGroup(string dirtyGroupName)
        {
            var cleanGroupName = Base.Sanitize(dirtyGroupName);

            Group group = Groups.FirstOrDefault(g => g.GroupName == cleanGroupName);

            if (group == null)
                return false;

            return Groups.Remove(group);
        }

        public SimpleGroupUser GetGroupUser(User user)
        {
            return AllUsers.FirstOrDefault(entry => entry.Name == user.Name || entry.SlgID == user.SlgId || entry.SteamID == user.SteamId);
        }
    }
}