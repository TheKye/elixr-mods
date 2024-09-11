using Newtonsoft.Json;
using System;

namespace Eco.EM.TP
{
    [Serializable]
    public class TeleportUserData
    {
        public int Teleports { get; private set; }

        private bool pendingRequest;
        private bool pendingAccept;
        private bool onCoolDown;

        private DateTime coolDownSetTime;

        public TeleportUserData(int tps = 0, bool onCD = false)
        {
            Teleports = tps;
            onCoolDown = onCD;
        }

        [JsonIgnore] public bool PendingRequest { get { return pendingRequest; } }
        [JsonIgnore] public bool PendingAccept { get { return pendingAccept; } }
        public bool OnCoolDown { get { return onCoolDown; } }
        public DateTime CoolDownSetTime { get { return coolDownSetTime; } }

        public void SetPendingRequest(bool toggle) => pendingRequest = toggle;
        public void SetPendingAccept(bool toggle) => pendingAccept = toggle;
        public void SetCoolDown()
        {
            onCoolDown = true;
            coolDownSetTime = DateTime.Now;
        }

        public void ClearCoolDown()
        {
            onCoolDown = false;
        }

        public void Teleport()
        {
            Teleports++;
        }

        public void ResetTeleports()
        {
            Teleports = 0;
        }
    }
}
