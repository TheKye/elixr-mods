using Eco.EM.Framework.Groups;
using Eco.Gameplay.Players;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Daily
{
    public class DailyData
    {
        public Dictionary<string, DailyUserData> Users { get; private set; }

        public DailyData()
        {
            Users = new Dictionary<string, DailyUserData>();
        }

        internal DailyUserData GetDailyUserData(string user)
        {
            if (Users.ContainsKey(user))
                return Users[user];

            return null;
        }

        internal int GetMaxRewardExperience(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int maxRewardXP = DailyManager.Config.RewardExperience;

            groups.ForEach(grp =>
            {
                var dailyPermission = grp.Permissions.Find(p => p.Identifier == DailyManager.ID);

                if (dailyPermission != null)
                {
                    var config = (DailyConfig)dailyPermission;

                    if (config.RewardExperience > maxRewardXP)
                        maxRewardXP = config.RewardExperience;
                }
            });

            return maxRewardXP;
        }

        internal int GetHighestStartTier(User user)
        {
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int highestTier = DailyManager.Config.StartTier;

            groups.ForEach(grp =>
            {
                var dailyPermission = grp.Permissions.Find(p => p.Identifier == DailyManager.ID);

                if (dailyPermission != null)
                {
                    var config = (DailyConfig)dailyPermission;

                    if (config.StartTier > highestTier)
                        highestTier = config.StartTier;
                }
            });

            return highestTier;
        }

        internal int GetMinimumLoggedInTime(User user)
        {
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int minTime = DailyManager.Config.MinLoggedInTime;

            groups.ForEach(grp =>
            {
                var dailyPermission = grp.Permissions.Find(p => p.Identifier == DailyManager.ID);

                if (dailyPermission != null)
                {
                    var config = (DailyConfig)dailyPermission;

                    if (config.MinLoggedInTime < minTime)
                        minTime = config.MinLoggedInTime;
                }
            });

            return minTime;
        }
    }
}
