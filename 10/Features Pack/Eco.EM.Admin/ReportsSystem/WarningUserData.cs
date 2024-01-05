using Eco.Core.Plugins;
using Eco.Gameplay.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Admin.ReportsSystem
{
    /// <summary>
    /// Holds the warning and ban data specific to a user.
    /// 
    /// Only active warnings considered in calculations.
    /// </summary>
    public class WarningUserData
    {
        // Lists of user bans and warnings
        public List<Warning> Warnings { get; private set; }
        public List<Ban> Bans { get; private set; }

        // Currently active user bans and warnings.
        public List<Warning> ActiveWarnings => Warnings.Where((w) => w.isActive).ToList();
        public Ban ActiveBan => Bans.FirstOrDefault((b) => b.isActive);  
        public List<Ban> UnrevokedBans => Bans.Where((b) => b.Revoked != null).ToList();

        public WarningUserData(List<Warning> warnings = null, List<Ban> bans = null)
        {
            Warnings = warnings ?? new();
            Bans = bans ?? new();
        }

        /// <summary>
        /// Create new lists for the user. The "fresh start" method.
        /// </summary>
        public void clearLists()
        {
            if (Warnings != null && Warnings.Count > 0) Warnings = new();
            if (Bans != null && Bans.Count > 0) Bans = new();
        }

        /// <summary>
        /// Archived warnings will have no impact on automated temporary or permanent bans.
        /// </summary>
        public void ArchiveWarnings() => ActiveWarnings.ForEach((w) => w.Archive());

        /// <summary>
        /// Archived bans that were not revoked will contribute to potential perma-ban calculations.
        /// </summary>
        public void ArchiveBans() => ActiveBan.Archive();

        /// <summary>
        /// A human-readable listing of the active warnings on a player.
        /// </summary>
        /// <returns></returns>
        public string ListActiveWarnings() => PrintList(ActiveWarnings);

        /// <summary>
        /// A human-readable listing of the warning history for a player.
        /// </summary>
        /// <returns></returns>
        public string ListWarningHistory() => PrintList(Warnings);

        /// <summary>
        /// A human-readable listing of the ban history for a player.
        /// </summary>
        /// <returns></returns>
        public string ListBanHistory() => PrintList(Bans);

        /// <summary>
        /// A human-readable listing of the unrevoked ban history for a player.
        /// </summary>
        /// <returns></returns>
        public string ListUnrevokedBanHistory() => PrintList(UnrevokedBans);

        private string PrintList<T>(List<T> list) where T : Issuable
        {
            string readout = "";

            for (int i = 0; i < list.Count; i++)
            {
                readout += $"{i + 1}: {list[i]}\n";
            }

            return readout;
        }

        /// <summary>
        /// Revoke a warning, these are kept to maintain history data but are not considered in auto-ban calculations. 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="issuer"></param>
        /// <param name="reason"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RevokeWarning(int pos, string issuer, string reason)
        {
            if (!ActiveWarnings.Any()) return;
            if (pos < 1 || pos > ActiveWarnings.Count)
                throw new ArgumentOutOfRangeException(nameof(pos), $"Please input a value between 1 and {ActiveWarnings.Count}");

            ActiveWarnings[pos - 1].Revoke(issuer, reason);
        }

        /// <summary>
        /// Revoke a ban, there should only be one of these active. 
        /// </summary>
        /// <param name="issuer"></param>
        /// <param name="reason"></param>
        public void RevokeBan(string issuer, string reason)
        {
            if (ActiveBan == null) return;

            ActiveBan.Revoke(issuer, reason);
        }

        public bool IsWarningMaxExceeded => ActiveWarnings.Count >= WarningManager.Config.MaxWarningsUntilTempBan;
        public bool isTempBanMaxExceed => WarningManager.Config.ActivePermaBans && UnrevokedBans.Count >= WarningManager.Config.MaxTempBansUntilPermaBan;
    }
}
