namespace Eco.EM.Homes
{
    using Eco.EM.Framework;
    using Eco.Shared.Math;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    [Serializable]
    public class HomeUserData
    {
        public int Teleports { get; private set; }
        public List<Home> Homes { get; private set; }
        private bool onCoolDown;
        private DateTime coolDownSetTime;

        public HomeUserData(List<Home> homes = null, int tps = 0, bool onCD = false)
        {
            Teleports = tps;
            Homes = homes;
            onCoolDown = onCD;
            if (Homes == null)
                Homes = new List<Home>();
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

        public Home GetHome(string dirtyName)
        {
            var cleanName = Base.Sanitize(dirtyName);

            var home = Homes.Find(home => home.HomeName == cleanName);

            return home;
        }

        public bool AddHome(string dirtyName, Vector3 loc)
        {
            var cleanName = Base.Sanitize(dirtyName);

            if (Homes.Any(home => home.HomeName == cleanName))
                return false;

            Homes.Add(new Home(cleanName, loc));
            return true;
        }

        public bool RemoveHome(string dirtyName)
        {
            var cleanName = Base.Sanitize(dirtyName);

            var home = Homes.Find(home => home.HomeName == cleanName);

            if (home == null)
            {
                return false;
            }

            Homes.Remove(home);
            return true;
        }

        public void Teleport()
        {
            Teleports++;
        }

        public void ResetTeleports()
        {
            Teleports = 0;
        }

        public void ClearHomes()
        {
            Homes = new List<Home>();
        }
    }
}