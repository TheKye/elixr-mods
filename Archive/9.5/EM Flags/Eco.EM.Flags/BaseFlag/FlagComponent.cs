using Eco.Gameplay.Objects;
using Eco.Shared.Networking;
using Eco.Core.Controller;
using Eco.Shared.Localization;
using Eco.Gameplay.Players;
using Eco.Shared.Serialization;
using Eco.Gameplay.Items;
using System.ComponentModel;
using Eco.Shared.Utils;
using Eco.EM.Framework.Helpers;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Flags
{
    // If you have more textures for the flag pole add them here.
    [Eco]
    public enum FlagPoleMaterial
    {
        IronGold,
        Redwood,
    }

    // The base component for all flags, implements the selector for the flag pole material so it doesn't need to be implemented on all flags individually.
    [Serialized]
    public abstract class FlagComponent : WorldObjectComponent
    {
        public FlagComponent() { }

        FlagPoleMaterial materialOption;

        [Eco, ClientInterfaceProperty, GuestHidden]
        public FlagPoleMaterial MaterialOption
        {
            get => materialOption;
            set
            {
                if (value == materialOption) return;
                materialOption = value;
                this.Changed(nameof(MaterialOption));
            }
        }

        [RPC, Autogen]
        public void SetFlagPole(Player player)
        {
            Parent.SetAnimatedState("PoleChange", MaterialOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            Parent.SetAnimatedState("PoleChange", MaterialOption.GetName());
        }
    }
}
