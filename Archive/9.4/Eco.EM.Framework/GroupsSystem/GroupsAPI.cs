using Eco.EM.Framework.Permissions;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
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

        public bool UserPermitted(IChatClient chatClient, IGroupAuthorizable permission)
        {
            var sgu = GroupsManager.Data.GetGroupUser(chatClient);
            return UserPermitted(sgu, permission);
        }

        public bool CommandPermitted(IChatClient chatClient, IGroupAuthorizable permission)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().Where(grp => grp.GroupUsers.Any(sgu => sgu.Name == chatClient.Name));

            // check if any of those groups have the permission.
            if (groups.Any(grp => grp.Permissions.Any(p => p.Identifier == permission.Identifier && p.BlackListed == true)))
                return false;
            return true;
        }

        public void SaveData()
        {
            GroupsManager.SaveData();
        }
    }
}
