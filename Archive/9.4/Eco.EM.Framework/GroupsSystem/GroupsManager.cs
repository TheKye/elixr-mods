using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Shared.Utils;
using System.IO;
using System.Linq;
using Eco.EM.Framework.FileManager;
using Eco.Shared.Localization;

namespace Eco.EM.Framework.Groups
{
    public class GroupsManager : IModKitPlugin, IInitializablePlugin
    {
        private const string _dataFile = "ElixrMods-GroupsData.json";
        private const string _subPath = "/EM/Groups";

        public static GroupsData Data { get; private set; }

        public static GroupsAPI API { get; private set; }

        public GroupsManager()
        {
            Data = LoadData();
            API = new GroupsAPI();

            if (!File.Exists(Base.SaveLocation + _subPath + _dataFile))
                SaveData();
        }

        public void Initialize(TimedTask timer)
        {
            if (Data.Groups.Count == 0)
            {
                Data.GetorAddGroup("admin", true);
                Data.GetorAddGroup("default", true);
            }

            foreach(var usr in Base.Users)
            {
                lock (Data.AllUsers)
                {
                    if (!Data.AllUsers.Any(entry => entry.Name == usr.Name || entry.SteamID == usr.SteamId || entry.SlgID == usr.SlgId))
                    {
                        Data.AllUsers.Add(new SimpleGroupUser(usr.Name, usr.SlgId ?? "", usr.SteamId ?? ""));
                        SaveData();
                    }

                    /* Only implement if we think this is necessary , it will basically disable server configs for TP's, Homes and Warps*/
                    Group group;

                    if (usr.IsAdminOrDev)
                        group = Data.GetorAddGroup("admin");
                    else
                        group = Data.GetorAddGroup("default");

                    if (!group.GroupUsers.Any(entry => entry.Name == usr.Name || entry.SteamID == usr.SteamId || entry.SlgID == usr.SlgId))
                    {
                        group.AddUser(usr);
                        SaveData();
                    }
                }
            }

            UserManager.OnUserLoggedIn.Add(u =>
            {
                lock (Data.AllUsers)
                {
                    if (!Data.AllUsers.Any(entry => entry.Name == u.Name || entry.SteamID == u.SteamId || entry.SlgID == u.SlgId))
                    {
                        Data.AllUsers.Add(new SimpleGroupUser(u.Name, u.SlgId ?? "", u.SteamId ?? ""));
                        SaveData();
                    }

                    /* Only implement if we think this is necessary , it will basically disable server configs for TP's, Homes and Warps*/
                    Group group;

                    if (u.IsAdminOrDev)
                        group = Data.GetorAddGroup("admin");
                    else
                        group = Data.GetorAddGroup("default");

                    if (!group.GroupUsers.Any(entry => entry.Name == u.Name || entry.SteamID == u.SteamId || entry.SlgID == u.SlgId))
                    {
                        group.AddUser(u);
                        SaveData();
                    }
                }
            });

        }

        public string GetStatus() => "Groups System Active";

        public override string ToString()
        {
            return Localizer.DoStr("EM - Groups System");
        }

        private static GroupsData LoadData()
        {
            return FileManager<GroupsData>.ReadTypeHandledFromFile(Base.SaveLocation + _subPath, _dataFile);
        }

        internal static void SaveData()
        {
            FileManager<GroupsData>.WriteTypeHandledToFile(Data, Base.SaveLocation + _subPath, _dataFile);
        }
    }
}
