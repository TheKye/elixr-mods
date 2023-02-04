using Eco.EM.Framework.Groups;
using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;

namespace Eco.EM.Framework.Permissions
{

    // Chat commands for interfacing with the Permisions Manager.
    public class CommandGroupsCommands : IChatCommandHandler
    {
        [ChatCommand("Permissions Command For the Permissions System", ChatAuthorizationLevel.Admin)]
        public static void CommandPermissions(User user) { }

        // Command Groups
        [ChatSubCommand("CommandPermissions", "Used to Grant Permissions to a Group", "grant-command", ChatAuthorizationLevel.Admin)]
        public static void Grant(User user, string command, string groupName)
        {
            Group group = GroupsManager.API.GetGroup(groupName);
            ChatCommandAdapter adapter = CommandGroupsManager.FindAdapter(command);
            try
            {
                if (adapter == null)
                {
                    ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("Command {0} was unable to be found in the commands set"),command), user);
                    return;
                }

                if (!group.AddPermission(adapter))
                {
                    ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("Command {0} was unable to be added to Group {1} permissions, its identifier already exists"), adapter.Identifier, group.GroupName), user);
                    return;
                }

                group.AddPermission(adapter);
                ChatBaseExtended.CBChat(Base.appName + string.Format(Localizer.DoStr("Command {0} was added to Group {1} permissions"), adapter.Identifier, group.GroupName), user);
                GroupsManager.API.SaveData();
            }
            catch
            {
                ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("Command {0} was unable to be added to Group {1}, please create the group first"), adapter.Identifier, groupName), user);
            }
        }

        [ChatSubCommand("CommandPermissions", "Used To Grant all Sub Commands to a group using the Parent Command", "grant-all", ChatAuthorizationLevel.Admin)]
        public static void GrantAll(User user, string command, string groupName)
        {
            Group group = GroupsManager.API.GetGroup(groupName);
            ChatCommandAdapter adapter = CommandGroupsManager.FindAdapter(command);
            try
            {
                if (adapter == null)
                {
                    ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("Command {0} was unable to be found in the commands set"), command), user);
                    return;
                }

                if (!group.AddPermission(adapter))
                {
                    ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("Command {0} was unable to be added to Group {1} permissions, its identifier already exists"), adapter.Identifier, group.GroupName), user);
                    return;
                }

                group.AddPermission(adapter);
                ChatBaseExtended.CBChat(Base.appName + string.Format(Localizer.DoStr("Command {0} was added to Group {1} permissions"), adapter.Identifier, group.GroupName), user);
                GroupsManager.API.SaveData();
            }
            catch
            {
                ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("Command {0} was unable to be added to Group {1}, please create the group first"), adapter.Identifier, groupName), user);
            }
        }

        [ChatSubCommand("CommandPermissions", "Used to Remove Permissions from a Group", "revoke-command", ChatAuthorizationLevel.Admin)]
        public static void Revoke(User user, string command, string groupName)
        {
            Group group = GroupsManager.API.GetGroup(groupName);
            ChatCommandAdapter adapter = CommandGroupsManager.FindAdapter(command);

            if (adapter == null)
            {
                ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("Command {0} was unable to be found in the commands set"), command), user);
                return;
            }

            group.DeletePermission(adapter);
            ChatBaseExtended.CBChat(Base.appName + string.Format(Localizer.DoStr("Command {0} was removed from Group {1} permissions"), adapter.Identifier, group.GroupName), user);
            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("CommandPermissions", "Used to set the default Admin and User behaviour. Use /Commandpermissions setbehaviour {admin/user},{true/false}", "behaviour-command", ChatAuthorizationLevel.Admin)]
        public static void SetBehaviour(User user, string behaviour, bool toggle)
        {
            behaviour = Base.Sanitize(behaviour);
            if (behaviour == "admin")
            {
                // protection from jamming everyone from commands
                if (!toggle)
                {
                    Group group = GroupsManager.API.GetGroup(CommandGroupsManager.protectorGroup, true);
                    Grant(user, "setbehaviour", CommandGroupsManager.protectorGroup);
                    group.AddUser(user);
                }

                CommandGroupsManager.Config.DefaultAdminBehaviour = toggle;
            }
            else if (behaviour == "user")
            {
                CommandGroupsManager.Config.DefaultUserBehaviour = toggle;
            }
            else
            {
                ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("{0} is not a valid toggle option"), behaviour), user);
                return;
            }

            ChatBaseExtended.CBChat(Base.appName + string.Format(Localizer.DoStr("{0} custom behaviour was set to {1}"), behaviour, toggle), user);
            CommandGroupsManager.SaveConfig();
            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("CommandPermissions", "Used to Blacklist a command for a group", "blacklist-command", ChatAuthorizationLevel.Admin)]
        public static void BlacklistCommand(User user, string command, string groupName)
        {
            Group group = GroupsManager.API.GetGroup(groupName);
            ChatCommandAdapter adapter = CommandGroupsManager.FindAdapter(command);
            try
            {
                if (adapter == null)
                {
                    ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("Command {0} was unable to be found in the commands set"), command), user);
                    return;
                }

                if (!group.AddPermission(adapter))
                {
                    group.DeletePermission(adapter);
                }
                adapter.BlackListed = true;
                group.BlacklistCommand(adapter);
                ChatBaseExtended.CBChat(Base.appName + string.Format(Localizer.DoStr("Command {0} was Blacklisted for Group {1}"), adapter.Identifier, group.GroupName), user);
                GroupsManager.API.SaveData();
            }
            catch
            {
                ChatBaseExtended.CBError(Base.appName + string.Format(Localizer.DoStr("Command {0} was unable to be added to Group {1}, please create the group first"), adapter.Identifier, groupName), user);
            }
        }
    }
}
