using Eco.Shared.Networking;
using Eco.Core.Controller;
using Eco.Shared.Localization;
using Eco.Gameplay.Players;
using Eco.Shared.Serialization;
using System.ComponentModel;
using Eco.Gameplay.Items;
using Eco.Core.Utils;
using Eco.Gameplay.Systems.NewTooltip;

namespace Eco.EM.Flags
{

    [Serialized]
    public class NatFlagData : IController, INotifyPropertyChanged, IClearRequestHandler
    {
        #region IController
        public event PropertyChangedEventHandler PropertyChanged;
        int controllerID;
        public ref int ControllerID => ref this.controllerID;
        #endregion

        [Serialized, SyncToView] public NationalFlag FlagOption { get; set; }

        public Result TryHandleClearRequest(Player player)
        {
            this.FlagOption = NationalFlag.None;
            return Result.Succeeded;
        }
    }
    
    [Eco]
    public enum NationalFlag
    {
        None                  ,
        Australia             ,
        AustralianAboriginal  ,
        Austria               ,
        Belgium               ,
        Brazil                ,
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
        India                 ,
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
        SouthAfrica           ,
        Spain                 ,
        Sweden                ,
        Switzerland           ,
        Ukraine               ,
        UnitedKingdom         ,
        UnitedNations         ,
        UnitedStatesOfAmerica ,
        Wales                 ,
    }

    [Serialized, AutogenClass, LocDisplayName("National Flag Selection"), NoIcon]
    public partial class NationalFlagComponent : FlagComponent, IPersistentData
    {
        public NatFlagData natFlagData { get; set; }

        public new object PersistentData { get => natFlagData; set => natFlagData = value as NatFlagData ?? new NatFlagData(); }

        private NationalFlag flagOption { get; set; }

        [Eco, ClientInterfaceProperty, GuestHidden]
        [Serialized, SyncToView]
        public NationalFlag FlagOption { get => flagOption; set { flagOption = value; this.Changed(nameof(FlagOption)); } }

        [RPC, Autogen("Set Flag")]
        public void SetFlag(Player player)
        {
            natFlagData.FlagOption = FlagOption;
            Parent.SetAnimatedState("FlagChange", natFlagData.FlagOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.natFlagData ??= new NatFlagData();
            this.FlagOption = natFlagData.FlagOption;
            Parent.SetAnimatedState("FlagChange", natFlagData.FlagOption.GetName());
        }
    }
}