using System;

namespace Eco.EM.Admin.ReportsSystem
{
    [Serializable]
    class InvalidOperationException : Exception
    {
        public InvalidOperationException() { }

        public InvalidOperationException(string name) : base(name) { }
    }

    public abstract class Issuable
    {
        public DateTime Issued { get; private set; }
        public string IssueReason { get; private set; }
        public string Issuer { get; private set; }

        public DateTime WarningExiry { get; private set; }

        public bool isActive { get; private set; }

        public Issuable(string issuer, string reason, int warningExiry)
        {
            Issuer = issuer;
            IssueReason = reason;
            Issued = DateTime.Now;
            WarningExiry = DateTime.Now.AddDays(warningExiry); 
            isActive = true;
        }

        public void Archive() => isActive = false;

        public override string ToString()
        {
            var readout = "";

            var reason = IssueReason ?? "No Reason Recorded";
            readout += $"{Issued} by {Issuer} for:\n";
            readout += $"   {reason}\n";

            return readout;
        }
    }

    public abstract class Revokable : Issuable
    {
        public Action onRevoke;

        public DateTime? Revoked { get; protected set; }
        public string Revoker { get; protected set; }
        public string RevokeReason { get; protected set; }

        public Revokable(string issuer, string reason, int warningExpiry) : base(issuer, reason, warningExpiry) { }

        public void Revoke(string revoker, string reason)
        {
            if (Revoked != null) throw new InvalidOperationException($"{GetType().Name} already revoked");

            Revoker = revoker;
            RevokeReason = reason;
            Revoked = DateTime.Now;

            Archive();

            if (onRevoke != null) onRevoke.Invoke();
        }

        public override string ToString()
        {
            var readout = base.ToString();

            if (Revoked != null)
            {
                readout += $"{Revoked} by {Revoker} for:\n";
                readout += $"   {RevokeReason ?? "Admin fiat"}\n";
            }

            return readout;
        }
    }


    public class Warning : Revokable
    {
        public Warning(string issuer, string reason, int warningExpiry) : base(issuer, reason, warningExpiry) { }

    }

    public enum BanType { temporary, permanent }

    public class Ban : Revokable
    {
        public BanType type { get; private set; }

        public Ban(BanType t, string issuer, string reason, int warningExpiry) : base(issuer, reason, warningExpiry)
        {
            type = t;
        }

        public override string ToString()
        {
            var readout = "";

            readout += $"{type.ToString().ToUpper()}\n";
            readout += base.ToString();

            return readout;
        }
    }
}
