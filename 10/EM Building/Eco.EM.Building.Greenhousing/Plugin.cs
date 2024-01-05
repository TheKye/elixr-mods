using Eco.Core.Plugins.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eco.EM.Framework.Utils;

namespace Eco.EM.Building.Greenhousing
{
    public class GreenhousingBasePlugin : IModKitPlugin, IModInit
    {
        public string GetStatus() => "Ignore Me";

        public static void Initialize()
        {
            EcopediaGenerator.GenerateEcopediaPageFromFile("ModDocumentation;EM Building.xml", "Eco.EM.Building.Greenhousing.Ecopedia", "Elixr Mods");
            EcopediaGenerator.GenerateEcopediaPageFromFile("ModDocumentation;EM Building;Greenhousing.xml", "Eco.EM.Building.Greenhousing.Ecopedia", "Elixr Mods");
        }

        public override string ToString() => "EM Greenhousing";

        public string GetCategory() => "Elixr Mods";
    }
}
