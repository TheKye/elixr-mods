
namespace Eco.EM.Framework.Permissions
{
    using Eco.EM.Framework.Groups;
    using Eco.EM.Framework.ChatBase;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;

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
            ChatCommandAdapter adapter = CommandGroupsManager.FindApapter(command);
            try
            {
                if (adapter == null)
                {
                    ChatBaseExtended.CBError(Base.appName + $"Command {command} was unable to be found in the commands set", user);
                    return;
                }

                if (!group.AddPermission(adapter))
                {
                    ChatBaseExtended.CBError(Base.appName + $"Command {adapter.Identifier} was unable to be added to Group {group.GroupName} permissions, its identifier already exists", user);
                    return;
                }

                group.AddPermission(adapter);
                ChatBaseExtended.CBChat(Base.appName + $"Command {adapter.Identifier} was added to Group {group.GroupName} permissions", user);
                GroupsManager.API.SaveData();
            }
            catch
            {
                ChatBaseExtended.CBError(Base.appName + $"Command {adapter.Identifier} was unable to be added to Group {groupName}, please create the group first", user);
            }
        }

        [ChatSubCommand("CommandPermissions", "Used to Remove Permissions from a Group", "revoke-command", ChatAuthorizationLevel.Admin)]
        public static void Revoke(User user, string command, string groupName)
        {
            Group group = GroupsManager.API.GetGroup(groupName);
            ChatCommandAdapter adapter = CommandGroupsManager.FindApapter(command);

            if (adapter == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"Command {command} was unable to be found in the commands set", user);
                return;
            }

            group.DeletePermission(adapter);
            ChatBaseExtended.CBChat(Base.appName + $"Command {adapter.Identifier} was removed from Group {group.GroupName} permissions", user);
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
                ChatBaseExtended.CBError(Base.appName + $"{behaviour} is not a valid toggle option", user);
                return;
            }

            ChatBaseExtended.CBChat(Base.appName + $"{behaviour} custom behaviour was set to {toggle}", user);
            CommandGroupsManager.SaveConfig();
            GroupsManager.API.SaveData();
        }
    }
}
