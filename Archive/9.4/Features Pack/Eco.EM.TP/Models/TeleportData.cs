using Eco.EM.Framework.Groups;
using Eco.Gameplay.Players;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Eco.EM.TP
{
    [Serializable]
    public class TeleportData
    {
        public DateTime LastReset { get; private set; } = DateTime.MinValue;
        public DateTime NextReset { get; private set; } = DateTime.MinValue;

        public Dictionary<string, TeleportUserData> Users { get; private set; }
        private HashSet<TeleportRequest> Requests { get; }

        public TeleportData()
        {
            Requests = new HashSet<TeleportRequest>();
            Users = new Dictionary<string, TeleportUserData>();

            if (LastReset == DateTime.MinValue)
                LastReset = DateTime.Now;

            if (NextReset == DateTime.MinValue)
                NextReset = LastReset + TimeSpan.FromDays(1);
        }

        internal TeleportUserData GetTeleportUserData(string user)
        {
            if (Users.ContainsKey(user))
                return Users[user];

            return null;
        }

        internal int GetMaxTeleports(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int maxTeleports = TeleportManager.Config.MaxTeleports == -1 ? int.MaxValue : TeleportManager.Config.MaxTeleports;

            if (groups == null)
                return maxTeleports;

            foreach (var grp in groups)
            {
                var tpPermission = grp.Permissions.Find(p => p.Identifier == TeleportManager.ID);

                if (tpPermission != null)
                {
                    var config = (TeleportConfig)tpPermission;
                    if (config.MaxTeleports == -1)
                        maxTeleports = int.MaxValue;

                    if (config.MaxTeleports > maxTeleports)
                        maxTeleports = config.MaxTeleports;
                }
            }

            return maxTeleports;
        }

        internal int GetMinCoolDownTime(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int minCoolDown = TeleportManager.Config.CooldownSeconds;

            if (groups == null)
                return minCoolDown;

            foreach (var grp in groups)
            {
                var tpPermission = grp.Permissions.Find(p => p.Identifier == TeleportManager.ID);

                if (tpPermission != null)
                {
                    var config = (TeleportConfig)tpPermission;
                    if (config.CooldownSeconds < minCoolDown)
                        minCoolDown = config.CooldownSeconds;
                }
            }

            return minCoolDown;
        }

        internal int GetMinCalorieCost(User user)
        {
            // get all the groups the user is in.
            var groups = GroupsManager.API.AllGroups().FindAll(grp => grp.GroupUsers.Any(sgu => sgu.Name == user.Name));

            int minCalories = TeleportManager.Config.CalorieCost;

            if (groups == null)
                return minCalories;

            foreach (var grp in groups)
            {
                var tpPermission = grp.Permissions.Find(p => p.Identifier == TeleportManager.ID);

                if (tpPermission != null)
                {
                    var config = (TeleportConfig)tpPermission;
                    if (config.CalorieCost < minCalories)
                        minCalories = config.CalorieCost;
                }
            }

            return minCalories;
        }

        internal bool AddRequest(TeleportRequest tpr)
        {
            if (!Requests.Any(request => request.Requester == tpr.Requester))
            {
                Requests.Add(tpr);
                return true;
            }

            return false;
        }

        internal void ClearRequest(TeleportRequest tpr)
        {
            Requests.Remove(tpr);
        }

        internal TeleportRequest GetTeleportRequestViaReceiver(string rec)
        {
            return Requests.FirstOrDefault(tpr => tpr.Receiver == rec);
        }

        internal void ClearExpired(DateTime check)
        {
            List<TeleportRequest> expired = new List<TeleportRequest>();

            Requests.ForEach(tpr =>
            {
                if (check > tpr.Timestamp + TimeSpan.FromSeconds(TeleportManager.Config.Expiry))
                {
                    expired.Add(tpr);
                    Users[tpr.Requester].SetPendingRequest(false);
                    Users[tpr.Receiver].SetPendingAccept(false);
                }
            });

            expired.ForEach(tpr =>
            {
                Requests.Remove(tpr);
            });

            expired.Clear();
        }

        internal void ClearCoolDown(DateTime check, User user)
        {
            int minCoolDown = GetMinCoolDownTime(user);

            TeleportUserData data = GetTeleportUserData(user.Name);

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
                TeleportManager.SaveData();
            }
        }
    }
}