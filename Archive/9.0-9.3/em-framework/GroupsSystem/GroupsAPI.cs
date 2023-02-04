using Eco.Gameplay.Players;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Framework.Groups
{
    public sealed class GroupsAPI
    {
        public Group GetGroup(string group, bool create = false)
        {
            return GroupsManager.Data.GetorAddGroup(group, create);
        }

        public List<Group> AllGroups()
        {
            return GroupsManager.Data.Groups.ToList();
        }

        public bool UserPermitted(SimpleGroupUser user, IGroupAuthorizable permission)
        {
            return permission.Permit(user);
        }

        public bool UserPermitted(User user, IGroupAuthorizable permission)
        {
            var sgu = GroupsManager.Data.GetGroupUser(user);
            return UserPermitted(sgu, permission);
        }   

        public void SaveData()
        {
            GroupsManager.SaveData();
        }
    }
}
