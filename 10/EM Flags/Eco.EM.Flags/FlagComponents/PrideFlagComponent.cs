using Eco.Shared.Networking;
using Eco.Core.Controller;
using Eco.Shared.Localization;
using Eco.Gameplay.Players;
using Eco.Shared.Serialization;
using System.ComponentModel;
using System;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Systems.NewTooltip;

namespace Eco.EM.Flags
{
    [Serialized]
    public class PrideFlagData : IController, INotifyPropertyChanged, IClearRequestHandler
    {
        #region IController
        public event PropertyChangedEventHandler PropertyChanged;
        int controllerID;
        public ref int ControllerID => ref this.controllerID;
        #endregion

        [Serialized, SyncToView] public PrideFlag FlagOption { get; set; }

        public Result TryHandleClearRequest(Player player)
        {
            this.FlagOption = PrideFlag.None;
            return Result.Succeeded;
        }
    }

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
    public partial class PrideFlagComponent : FlagComponent, IPersistentData
    {
        public PrideFlagData prideFlagData { get; set; }

        public new object PersistentData { get => prideFlagData; set => prideFlagData = value as PrideFlagData ?? new PrideFlagData(); }

        [Eco, ClientInterfaceProperty, GuestHidden]
        [Serialized, SyncToView]
        public PrideFlag FlagOption { get; set; }

        [RPC, Autogen("Set Flag")]
        public void SetFlag(Player player)
        {
            prideFlagData.FlagOption = FlagOption;
            Parent.SetAnimatedState("FlagChange", prideFlagData.FlagOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.prideFlagData ??= new PrideFlagData();
            this.FlagOption = prideFlagData.FlagOption;
            Parent.SetAnimatedState("FlagChange", prideFlagData.FlagOption.GetName());
        }
    }
}