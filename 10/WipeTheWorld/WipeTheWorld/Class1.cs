using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;

namespace WipeTheWorld
{
    public class WipeTheWorld : IInitializablePlugin, IModKitPlugin
    {
        public string GetCategory() => "";

        public string GetStatus() => "";

        public void Initialize(TimedTask timer)
        {
            WipeTheWorldUsers();
        }

        public void WipeTheWorldUsers()
        {
            var userlist = UserManager.Users;

            foreach (var u in userlist)
            {
                UserManager.Obj.ResetUser(u);
            }
            UserManager.Obj.RefreshUserData();
        }
    }
}