using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Housing.VanillaDoors
{
    public class Init : IInitializablePlugin, IModKitPlugin
    {
        public string GetStatus()
        {
            return "";
        }

        public void Initialize(TimedTask timer)
        {
            VanillaDoors.ReplaceVanillaDoors();
        }
    }
}
