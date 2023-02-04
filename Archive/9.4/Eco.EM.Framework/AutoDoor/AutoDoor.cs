using Eco.Core.Controller;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Shared.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Framework.AutoDoor
{
    [Eco, AutogenClass]
    [RequireComponent(typeof(PublicStorageComponent))]
    public class AutoDoorComponent : WorldObjectComponent
    {

    }
}
