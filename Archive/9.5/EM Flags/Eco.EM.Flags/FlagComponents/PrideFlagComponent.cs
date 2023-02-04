using Eco.Shared.Networking;
using Eco.Core.Controller;
using Eco.Shared.Localization;
using Eco.Gameplay.Players;
using Eco.Shared.Serialization;
using System.ComponentModel;
using System;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;

namespace Eco.EM.Flags
{
    [Eco]
    public enum PrideFlag
    {
        None                     ,
        AgenderPride             ,
        AllyPride                ,
        AndrogynousPride         ,
        AromanticPride           ,
        AsexualPride             ,
        BearPride                ,
        BigenderPride            ,
        BisexualPride            ,
        DemiBoyPride             ,
        DemiGirlPride            ,
        DemiSexualPride          ,
        GayManPride              ,
        GenderFluidPride         ,
        GenderNonConformingPride ,
        GenderQueerPride         ,
        HermaphroditePride       ,
        IntersexPride            ,
        LesbianPride             ,
        LGBTPride                ,
        MoreColorMorePride       ,
        NonBinaryPride           ,
        PansexualPride           ,
        PolysexualPride          ,
        ProgressPride            ,
        QueerPeopleOfColorPride  ,
        RainbowPride             ,
        TransgenderPride         ,
        TwoSpiritPride           ,
    }

    [Serialized, AutogenClass, LocDisplayName("Pride Flag Selection")]
    public partial class PrideFlagComponent : FlagComponent
    {
        PrideFlag flagOption;
        [Eco, ClientInterfaceProperty, GuestHidden]
        public PrideFlag FlagOption
        {
            get => this.flagOption;
            set
            {
                if (value == this.flagOption) return;
                this.flagOption = value;
                this.Changed(nameof(FlagOption));
            }
        }

        [RPC, Autogen, GuestHidden]
        public void SetFlag(Player player)
        {
            this.Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }
    }
}