using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System.Linq;
using System.Text;
using Eco.EM.Framework.ChatBase;

namespace Eco.EM.Framework.Groups
{
    public class GroupsCommands : IChatCommandHandler
    {
        [ChatCommand("Groups System Commands", ChatAuthorizationLevel.Admin)]
        public static void Groups(User user) { }

        [ChatSubCommand("Groups", "Used to Create a New Group", "grp-add", ChatAuthorizationLevel.Admin)]
        public static void AddGroup(User user, string groupName)
        {
            Group group = GroupsManager.Data.GetorAddGroup(groupName, true);
            ChatBaseExtended.CBInfo(string.Format(Base.appName + "Group {0} was created", group.GroupName), user);

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("Groups", "Used to Delete an Existing Group", "grp-del", ChatAuthorizationLevel.Admin)]
        public static void DeleteGroup(User user, string groupName)
        {
            var maingroups = Base.Sanitize(groupName);
            if (maingroups == "admin" || maingroups == "default")
            {
                ChatBaseExtended.CBError(string.Format(Base.appName + "Group {0} can not be deleted, it is a core group", maingroups), user);
                return;
            }


            if (GroupsManager.Data.DeleteGroup(groupName))
                ChatBaseExtended.CBInfo(string.Format(Base.appName + "Group {0} was deleted", Base.Sanitize(groupName)), user);
            else
                ChatBaseExtended.CBError(string.Format(Base.appName + "Group {0} was unable to be found", Base.Sanitize(groupName)), user);

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("Groups", "Used to print a list of groups to the chat window", "grp-list", ChatAuthorizationLevel.Admin)]
        public static void ListGroups(User user)
        {
            StringBuilder sb = new StringBuilder();
            var groups = GroupsManager.Data.Groups;
            groups.ForEach(g =>
            {
                sb.Append(g.GroupName + "\n");

                if (g != groups.Last())
                    sb.Append(", ");
            });

            ChatBaseExtended.CBInfoPane(Base.appName + "Groups:", sb.ToString(), "EMGroupList",user);
        }

        [ChatSubCommand("Groups", "Used to print a list permissions assigned to a group", "grp-perms", ChatAuthorizationLevel.Admin)]
        public static void GroupPermissions(User user, string groupName)
        {
            Group group = GroupsManager.Data.GetorAddGroup(groupName, true);

            StringBuilder sb = new StringBuilder();
            group.Permissions.ForEach(perm =>
            {
                sb.Append(perm.Identifier);

                if (perm != group.Permissions.Last())
                    sb.Append(", ");
            });

            ChatBaseExtended.CBInfoPane($"Permissions for Group: {group.GroupName}", string.Format("Group {0}:\nPermissions: {1}", group.GroupName, sb.ToString()), "EMGroupList",user);
        }

        [ChatSubCommand("Groups", "Used to add a user to a groupp", "grp-adduser", ChatAuthorizationLevel.Admin)]
        public static void AddUserToGroup(User user, string userName, string groupName)
        {
            Group group = GroupsManager.Data.GetorAddGroup(groupName, true);
            User toAdd = Base.GetUserByName(userName);
            if (toAdd == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"User {userName} was unable to be found", user);
                return;
            }

            if (group.AddUser(toAdd))
                ChatBaseExtended.CBInfo(Base.appName + $"User {toAdd.Name} was added to Group {group.GroupName}", user);
            else
                ChatBaseExtended.CBError(Base.appName + $"User {toAdd.Name} already exists in Group {group.GroupName}", user);

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("Groups", "Used to add a user to a groupp", "grp-remuser", ChatAuthorizationLevel.Admin)]
        public static void RemoveUserFromGroup(User user, string userName, string groupName)
        {
            Group group = GroupsManager.Data.GetorAddGroup(groupName, false);
            if (group == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"Group {groupName} was unable to be found", user);
            }

            User toRemove = Base.GetUser(userName);
            if (toRemove == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"User {userName} was unable to be found", user);
                return;
            }

            if (group.RemoveUser(toRemove))
                ChatBaseExtended.CBInfo(Base.appName + $"User {userName} was removed from Group {group.GroupName}", user);
            else
                ChatBaseExtended.CBError(Base.appName + $"User {userName} was unable to be found in Group {group.GroupName}", user);

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("Groups", "Used to print a list permissions assigned to a group", "grp-fs", ChatAuthorizationLevel.Admin)]
        public static void ForceSave(User user)
        {
            GroupsManager.API.SaveData();
        }
    }
}
