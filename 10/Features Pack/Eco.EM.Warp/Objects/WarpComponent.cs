using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Utils;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Warp.Objects
{
    [Serialized, AutogenClass, LocDisplayName("Warp"), NoIcon]
    public partial class WarpComponent : WorldObjectComponent, IHasClientControlledContainers
    {
        public override bool Enabled => true;
        private IEnumerable<WarpPoint> warpPoints = WarpManager.Data.ListPoints();
         

        [Serialized] public string SelectedWarpPoint { get; set; }

        [Eco, ClientInterfaceProperty, ThreadSafe]
        public IEnumerable<WarpPoint> WarpPoint
        {
            get { return warpPoints; }
            set
            {
                if (warpPoints != value)
                {
                    warpPoints = value;
                    SelectedWarpPoint = value.FirstOrDefault().PointName;
                    this.Changed(nameof(SelectedWarpPoint));
                    this.Changed(nameof(WarpPoint));
                }
            }
        }

        [RPC, Autogen]
        public void Warp(Player player)
        {
            WarpCommands.SignWarpto(player.User, SelectedWarpPoint);
        }
    }
}
