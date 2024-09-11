using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Utils;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Warp.Objects
{
    [Serialized, AutogenClass, LocDisplayName("Warp"), NoIcon]
    public partial class WarpComponent : WorldObjectComponent, IHasClientControlledContainers, INotifyPropertyChanged
    {
        public override bool Enabled => true;
        private WarpData warpPoints { get; set; }
        private string SelectedWarpPoint { get; set; }

        public WarpComponent()
        {
        }

        [Eco]
        public WarpData WarpPoint
        {
            get => warpPoints;
            set
            {
                if (value == warpPoints)
                    return;
                warpPoints = value;
                SelectedWarpPoint = value.Points.First().PointName;
                this.Changed(nameof(WarpPoint));

            }
        }

        [RPC, Autogen]
        public void Warp(Player player)
        {
            if (string.IsNullOrEmpty(SelectedWarpPoint))
            {
                player.ErrorLocStr("No warp point selected");
                return;
            }
            WarpCommands.SignWarpto(player.User, SelectedWarpPoint);
        }
    }
}
