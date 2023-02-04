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
        None                  ,
        Australia             ,
        AustralianAboriginal  ,
        Austria               ,
        Belgium               ,
        Canada                ,
        China                 ,
        Egypt                 ,
        England               ,
        Fiji                  ,
        Finland               ,
        France                ,
        Germany               ,
        Gibralter             ,
        GreatBritan           ,
        Hungary               ,
        Iceland               ,
        Indonesia             ,
        Israel                ,
        Italy                 ,
        Jamaica               ,
        Japan                 ,
        Lithuania             ,
        Malta                 ,
        Mexico                ,
        Netherlands           ,
        NewZealand            ,
        NorthernIreland       ,
        Norway                ,
        Phillipines           ,
        Poland                ,
        RepublicOfIreland     ,
        Romania               ,
        Russia                ,
        Scotland              ,
        SouthKorea            ,
        Sweden                ,
        Switzerland           ,
        Ukraine               ,
        UnitedKingdom         ,
        UnitedNations         ,
        UnitedStatesOfAmerica ,
        Wales                 ,
    }

    [Serialized, AutogenClass, LocDisplayName("National Flag Selection")]
    public partial class NationalFlagComponent : FlagComponent
    {
        NationalFlag flagOption;
        [Eco, ClientInterfaceProperty, GuestHidden]
        public NationalFlag FlagOption
        {
            get => flagOption;
            set
            {
                if (value == flagOption) return;
                flagOption = value;
                this.Changed(nameof(FlagOption));
            }
        }

        [RPC, Autogen, GuestHidden]
        public void SetFlag(Player player)
        {
            Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }
    }
}