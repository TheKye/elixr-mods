using Eco.Shared.Networking;
using Eco.Core.Controller;
using Eco.Shared.Localization;
using Eco.Gameplay.Players;
using Eco.Shared.Serialization;
using System.ComponentModel;

namespace Eco.EM.Flags
{
    [Eco]
    public enum NationalFlag
    {
        Australia,
        AustralianAboriginal,
        Austria,
        Canada,
        China,
        Egypt,
        England,
        Fiji,
        Finland,
        France,
        Germany,
        Gibralter,
        GreatBritan,
        Hungary,
        Iceland,
        Indonesia,
        Israel,
        Italy,
        Japan,
        Lithuania,
        Malta,
        Mexico,
        Netherlands,
        NewZealand,
        NorthernIreland,
        Norway,
        Phillipines,
        Poland,
        RepublicOfIreland,
        Romania,
        Russia,
        Scotland,
        SouthKorea,
        Sweden,
        Switzerland,
        UnitedKingdom,
        UnitedNations,
        UnitedStatesofAmerica,
        Wales,
    }

    [Serialized, AutogenClass, LocDisplayName("National Flag Selection")]
    public partial class NationalFlagComponent : FlagComponent
    {
        NationalFlag flagOption;
        [Eco, ClientInterfaceProperty, GuestHidden]
        public NationalFlag FlagOption
        {
            get => this.flagOption;
            set
            {
                if (value == this.flagOption) return;
                this.flagOption = value;
                this.Changed(nameof(this.FlagOption));
            }
        }

        [RPC, Autogen, GuestHidden]
        public void SetFlag(Player player)
        {
            this.Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
            this.Changed(nameof(FlagOption));
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }
    }
}