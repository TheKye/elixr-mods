using Eco.Gameplay.Objects;
using Eco.Shared.Networking;
using Eco.Core.Controller;
using Eco.Shared.Localization;
using Eco.Gameplay.Players;
using Eco.Shared.Serialization;
using Eco.Gameplay.Items;
using System.ComponentModel;
using Eco.Shared.Utils;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Flags
{
    // If you have more trextures for the flag pole add them here.
    [Eco]
    public enum FlagMaterial
    {
        IronGold = 0,
        Redwood = 1,
    }

    // The base component for all flags, implements the selector for the flag pole material so it doesn't need to be implemented on all flags individually.
    [Serialized]
    public abstract class FlagComponent : WorldObjectComponent
    {
        FlagMaterial materialOption;

        [Eco, ClientInterfaceProperty, GuestHidden]
        public FlagMaterial MaterialOption
        {
            get => this.materialOption;
            set
            {
                if (value == this.materialOption) return;
                this.materialOption = value;
                this.Changed(nameof(this.MaterialOption));
            }
        }

        [RPC, Autogen, GuestHidden]
        public void SetFlagPole(Player player)
        {
            this.Parent.SetAnimatedState("PoleChange", MaterialOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Parent.SetAnimatedState("PoleChange", MaterialOption.GetName());
        }
    }
}