namespace Eco.EM.Homes
{
    using Eco.EM.Framework.Groups;
    using Eco.Gameplay.Players;
    using Eco.Shared.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    [Serializable]
    public class HomeData
    {
        public DateTime LastReset { get; private set; } = DateTime.MinValue;
        public DateTime NextReset { get; private set; } = DateTime.MinValue;

        public Dictionary<string, HomeUserData> Users { get; private set; }

        public HomeData()
        {
            Users = new Dictionary<string, HomeUserData>();

            if (LastReset == DateTime.MinValue)
                LastReset = DateTime.Now;

            if (NextReset == DateTime.MinValue)
                NextReset = LastReset + TimeSpan.FromDays(1);
        }

        internal HomeUserData GetHomeUserData(string user)
        {
            if (Users.ContainsKey(user))
                return Users[user];

            return null;
        }

        internal int GetMinCoolDownTime(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int minCoolDown = HomeManager.Config.CoolDown;

            if (groups == null)
                return minCoolDown;

            foreach (var grp in groups)
            {
                var tpPermission = grp.Permissions.Find(p => p.Identifier == HomeManager.ID);

                if (tpPermission != null)
                {
                    var config = (HomeConfig)tpPermission;
                    if (config.CoolDown < minCoolDown)
                        minCoolDown = config.CoolDown;
                }
            }

            return minCoolDown;
        }

        internal void ClearCoolDown(DateTime check, User user)
        {
            int minCoolDown = GetMinCoolDownTime(user);

            HomeUserData data = GetHomeUserData(user.Name);

            if (!data.OnCoolDown)
                return;

            if (check.Ticks > (data.CoolDownSetTime + TimeSpan.FromSeconds(minCoolDown)).Ticks)
                data.ClearCoolDown();

        }

        internal int GetMaxTeleports(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int maxTeleports = HomeManager.Config.MaxTeleports == -1 ? int.MaxValue : HomeManager.Config.MaxTeleports;

            if (groups == null)
                return maxTeleports;

            groups.ForEach(grp =>
            {
                var homePermission = grp.Permissions.Find(p => p.Identifier == HomeManager.ID);

                if (homePermission != null)
                {

                    var config = (HomeConfig)homePermission;
                    if (config.MaxTeleports == -1)// -1 set to max possible
                        maxTeleports = int.MaxValue;

                    if (config.MaxTeleports > maxTeleports)
                        maxTeleports = config.MaxTeleports;
                }
            });

            return maxTeleports;
        }

        internal int GetMinCalorieCost(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int minCalories = HomeManager.Config.CalorieCost;

            if (groups == null)
                return minCalories;

            groups.ForEach(grp =>
            {
                var homePermission = grp.Permissions.Find(p => p.Identifier == HomeManager.ID);

                if (homePermission != null)
                {
                    var config = (HomeConfig)homePermission;
                    if (config.CalorieCost < minCalories)
                        minCalories = config.CalorieCost;
                }
            });

            return minCalories;
        }

        internal int GetMaxHomes(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int maxHomes = HomeManager.Config.MaxHomeCount;

            if (HomeManager.Config.MaxHomeCount == -1) // -1 set to max possible
                maxHomes = int.MaxValue;

            if (groups == null)
                return maxHomes;

            groups.ForEach(grp =>
            {
                var homePermission = grp.Permissions.Find(p => p.Identifier == HomeManager.ID);

                if (homePermission != null)
                {
                    var config = (HomeConfig)homePermission;
                    if (config.MaxHomeCount== -1) // -1 set to max possible
                        maxHomes = int.MaxValue;

                    if (config.MaxHomeCount > maxHomes)
                        maxHomes = config.MaxHomeCount;
                }
            });

            return maxHomes;
        }

        internal List<Home> ListHomes(User user)
        {
            return Users[user.Name].Homes;
        }

        internal Home GetHome(string homeName, User user)
        {
            return Users[user.Name].GetHome(homeName);
        }

        internal void ResetTeleports(DateTime check)
        {
            if (check > NextReset)
            {
                LastReset = NextReset;

                // progressively add 24hrs until next reset is beyond now.
                while (check > NextReset)
                {
                    NextReset += TimeSpan.FromDays(1);
                }

                Users.ForEach(u => u.Value.ResetTeleports());
                HomeManager.SaveData();
            }
        }
    }
}
