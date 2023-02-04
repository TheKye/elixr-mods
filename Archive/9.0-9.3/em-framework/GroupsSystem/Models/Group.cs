using Eco.Gameplay.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Framework.Groups
{
    [Serializable]
    public class Group
    {
         public string GroupName { get; private set; }
         public HashSet<SimpleGroupUser> GroupUsers { get; private set; }
         public List<IGroupAuthorizable> Permissions { get; private set; }

        public Group(string grpName, HashSet<SimpleGroupUser> users = null, List<IGroupAuthorizable> perms = null)
        {
            GroupName = grpName;
            Permissions = perms;
            GroupUsers = users;

            if (GroupUsers == null)
                GroupUsers = new HashSet<SimpleGroupUser>();

            if (Permissions == null)
                Permissions = new List<IGroupAuthorizable>();    
        }

        public bool AddPermission(IGroupAuthorizable perm)
        {
            if (!Permissions.Any(p => p.Identifier == perm.Identifier))
            {
                Permissions.Add(perm);
                return true;
            }

            return false;
        }

        public void DeletePermission(IGroupAuthorizable perm)
        {
            var found = Permissions.RemoveAll(p => p.Identifier == perm.Identifier);
        }

        public bool AddUser(SimpleGroupUser user)
        {
            return GroupUsers.Add(user);
        }

        public bool AddUser(User user)
        {
            var sgu = GroupsManager.Data.GetGroupUser(user);
            if (sgu != null)
                return AddUser(sgu);
            else
                return false;
        }

        public bool RemoveUser(SimpleGroupUser user)
        {
            return GroupUsers.Remove(user);
        }

        public bool RemoveUser(User user)
        {
            var entry = GroupUsers.FirstOrDefault(u => u.Name == user.Name);
            
            if (entry == null)
                return false;

            return RemoveUser(entry);
        }
    }
}
