using Eco.Core.Controller;
using Eco.Core.Plugins.Interfaces;
using Eco.Gameplay.Migrations.V0_9_5;
using Eco.Gameplay.Utils;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Simulation.Types;
using System.Collections.Generic;
using static Eco.Mods.TechTree.Agouti;
using static Eco.Mods.TechTree.BighornSheep;
using static Eco.Mods.TechTree.Bison;
using static Eco.Mods.TechTree.Hare;
using static Eco.Mods.TechTree.MountainGoat;
using static Eco.Mods.TechTree.Turkey;
using System.Reflection;
using Eco.Gameplay.Aliases;
using Eco.Gameplay.Civics.Misc;
using System.Collections;
using System.Linq;
using System.ComponentModel;

namespace Eco.EM.Warp
{
    [Serialized]
    public class WarpPoint : SimpleEntry
    {
        public string DisplayName => string.IsNullOrWhiteSpace(PointName) ? WarpManager.Data.GetPoint(PointName).PointName : "";
        [ClientInterfaceProperty] public string PointName { get; set; }
        public System.Numerics.Vector3 Location { get; set; }
        public Quaternion Rotation { get; set; }

        public WarpPoint(string pointName, System.Numerics.Vector3 loc, Quaternion rot)
        {
            PointName = pointName;
            Location = loc;
            Rotation = rot;
        }

        public void ChangeName(string newName)
        {
            PointName = newName;
        }
    }
}