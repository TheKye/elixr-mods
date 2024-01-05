using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eco.EM.Admin.ReportsSystem
{
    [Serializable]
    public class WarningData
    {
        public Dictionary<string, WarningUserData> Users { get; private set; }

        public Dictionary<int, string> PredefinedWarnings { get; set; }

        public WarningData()
        {
            Users = new();
            PredefinedWarnings = new();
        }

        /// <summary>
        /// Get a warning data instance for a user if it exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal WarningUserData GetWarningDataUser(string user)
        {
            if (Users.ContainsKey(user))
                return Users[user];

            return null;
        }

        /// <summary>
        ///  Creates a warning data instance for a user and returns it
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal WarningUserData MakeWarningDataUser(string user)
        {
            var u = PlayerUtils.Users.Find((entry) => entry.Name == user);
            if (u == null) throw new Exception("Unable to find a matching user");

            var data = new WarningUserData();
            Users.Add(u.Name, data);
            WarningManager.SaveData();

            return data;
        }

        internal User GetUser(string u) => PlayerUtils.Users.Find((entry) => entry.Name == u);

        internal void AddToPreDefined(string message)
        {
            int id = PredefinedWarnings.Keys.Count + 1;
            while (PredefinedWarnings.ContainsKey(id))
                id++;
            PredefinedWarnings.Add(id, message);
        }

        internal void RemoveFromPreDefined(int id)
        {
            PredefinedWarnings.Remove(id);
        }

        internal string GetPredefined(int id)
        {
            var msg = PredefinedWarnings.Where(x => x.Key == id).Select(x => x.Value).ToString();

            if (msg != null)
                return msg;
            else return "";
        }

        internal string ListPreDefined()
        {
            var sb = new StringBuilder();

            foreach(var i in PredefinedWarnings)
            {
                sb.Append($"Id: {i.Key}, Warning: {i.Value} \n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Issue a new warning.
        /// </summary>
        /// <param name="issuer"></param>
        /// <param name="u"></param>
        /// <param name="reason"></param>
        internal void WarnUser(User issuer, string u, string reason, int warningExpiry, int preDefinedwarning = 0)
        {
            WarningUserData data;
            User user;
            try
            {
                data = GetWarningDataUser(u) ?? MakeWarningDataUser(u);
                user = GetUser(u) ?? throw new Exception($"Unable to find user {u}");
            }
            catch
            {
                throw;
            }
            if(preDefinedwarning == 0)
                data.Warnings.Add(new Warning(issuer.Name, reason, warningExpiry));

            else
            {
                var preReason = PredefinedWarnings.Where(x => x.Key == preDefinedwarning).Select(x => x.Value).ToString();
                data.Warnings.Add(new Warning(issuer.Name, preReason, warningExpiry));
            }

            if (!data.IsWarningMaxExceeded) return;

            ApplyBan(data, user, issuer, 0);
        }


        /// <summary>
        /// Automated ban application, should not be called via command.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user"></param>
        /// <param name="issuer"></param>
        private void ApplyBan(WarningUserData data, User user, User issuer, int expiry)
        {
            string reason = "System Ban - Max Warnings Exceeded";
            data.Bans.Add(new Ban(BanType.temporary, issuer.Name, reason, expiry));

            if (data.isTempBanMaxExceed)
            {
                data.ArchiveBans(); // just in case there is a lingering ban though there should not be.
                reason = "System Ban - Max temp bans exceeded";
                data.Bans.Add(new Ban(BanType.permanent, issuer.Name, reason, expiry));
            }

            UserManagerCommands.Ban(issuer, user.Name, reason);
        }

        /// <summary>
        /// Automated ban expiry on Tick
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user"></param>
        public void BanExpire(WarningUserData data, User user)
        {
            if (data.ActiveBan == null) return;
            if (data.ActiveBan.type == BanType.permanent) return;

            var issuer = GetUser(data.ActiveBan.Issuer);
            if (issuer == null)
            {
                foreach (var admin in UserManager.Admins)
                    ChatBaseExtended.CBMail($"User {user.Name} could not be unbanned due to an error with the stored issuer as {data.ActiveBan.Issuer}", admin);
                     
                return;
            }

            var time = DateTime.Now;
           
            if (data.ActiveBan.Issued.AddHours(WarningManager.Config.DefaultBanTimeHours).CompareTo(time) <= 0)
            {
                data.ActiveBan.Archive();
                UserManagerCommands.UnBan(issuer, user.Name, "Ban timer concluded");
            }
        }
    }
}
