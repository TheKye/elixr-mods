using Eco.EM.Framework;
using Eco.EM.Framework.Groups;
using Eco.Gameplay.Players;
using Eco.Shared.Math;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Warp
{
    [Serializable]
    public class WarpData
    {
        public DateTime LastReset { get; private set; } = DateTime.MinValue;
        public DateTime NextReset { get; private set; } = DateTime.MinValue;

        public Dictionary<string, WarpUserData> Users { get; private set; }
        public List<WarpPoint> Points { get; private set; }

        public WarpData()
        {
            Users = new Dictionary<string, WarpUserData>();
            Points = new List<WarpPoint>();

            if (LastReset == DateTime.MinValue)
                LastReset = DateTime.Now;

            if (NextReset == DateTime.MinValue)
                NextReset = LastReset + TimeSpan.FromDays(1);
        }

        internal WarpUserData GetWarpUserData(string user)
        {
            if (Users.ContainsKey(user))
                return Users[user];

            return null;
        }

        internal bool AddPoint(string pointName, Vector3 loc, Quaternion rot)
        {           
            if (Points.Any(point => point.PointName == pointName))
            {
                return false;
            }

            Points.Add(new WarpPoint(pointName, loc, rot));
            return true;
        }

        internal bool RemovePoint(string pointName)
        {         
            var point = Points.FirstOrDefault(p => p.PointName == pointName);
            
            if (point == null)
            {
                return false;
            }

            Points.Remove(point);
            return true;
        }

        internal bool ChangePointName(Vector3 location, string newName)
        {
            var point = Points.FirstOrDefault(p => p.Location == location);

            if (point == null)
            {
                return false;
            }

            point.ChangeName(newName);
            return true;
        }

        internal int GetMaxTeleports(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int maxTeleports = WarpManager.Config.MaxTeleports == -1 ? int.MaxValue : WarpManager.Config.MaxTeleports;

            if (groups == null)
                return maxTeleports;

            groups.ForEach(grp =>
            {
                var homePermission = grp.Permissions.Find(p => p.Identifier == WarpManager.ID);

                if (homePermission != null)
                {

                    var config = (WarpConfig)homePermission;
                    if (config.MaxTeleports == -1)
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

            int minCalories = WarpManager.Config.CalorieCost;

            if (groups == null)
                return minCalories;

            groups.ForEach(grp =>
            {
                var homePermission = grp.Permissions.Find(p => p.Identifier == WarpManager.ID);

                if (homePermission != null)
                {
                    var config = (WarpConfig)homePermission;
                    if (config.CalorieCost < minCalories)
                        minCalories = config.CalorieCost;
                }
            });

            return minCalories;
        }

        internal int GetMinCoolDownTime(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int minCoolDown = WarpManager.Config.CooldownSeconds;

            if (groups == null)
                return minCoolDown;

            groups.ForEach(grp =>
            {
                var tpPermission = grp.Permissions.Find(p => p.Identifier == WarpManager.ID);

                if (tpPermission != null)
                {
                    var config = (WarpConfig)tpPermission;
                    if (config.CooldownSeconds < minCoolDown)
                        minCoolDown = config.CooldownSeconds;
                }
            });

            return minCoolDown;
        }

        internal List<WarpPoint> ListPoints()
        {
            return Points;
        }

        internal WarpPoint GetPoint(string pointName)
        {
            pointName = Base.Sanitize(pointName);
            return Points.FirstOrDefault(point => point.PointName == pointName);
        }

        internal void ClearCoolDown(DateTime check, User user)
        {
            int minCoolDown = GetMinCoolDownTime(user);

            WarpUserData data = GetWarpUserData(user.Name);

            if (!data.OnCoolDown)
                return;

            if (check.Ticks > (data.CoolDownSetTime + TimeSpan.FromSeconds(minCoolDown)).Ticks)
                data.ClearCoolDown();
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
                WarpManager.SaveData();
            }
        }
    }
}