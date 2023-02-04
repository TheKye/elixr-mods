using Eco.EM.StatTracking.Models;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.StatTracking
{
    public class AnimalTracker : BaseTracker
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string User { get; set; }

        public static void GetAnimalStats(User user) { }

        private void LogStats(User user)
        {
        }
    }
}
