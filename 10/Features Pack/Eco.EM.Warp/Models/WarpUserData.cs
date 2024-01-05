using System;

namespace Eco.EM.Warp
{
    [Serializable]
    public class WarpUserData
    {
        public int Teleports { get; private set; }

        private bool onCoolDown;

        private DateTime coolDownSetTime;

        public WarpUserData(int tps = 0, bool onCD = false)
        {
            Teleports = tps;
            onCoolDown = onCD;
        }

        public bool OnCoolDown { get { return onCoolDown; } }
        public DateTime CoolDownSetTime { get { return coolDownSetTime; } }

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
