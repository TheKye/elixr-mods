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
    public class AffilFlagData : IController, INotifyPropertyChanged, IClearRequestHandler
    {
        #region IController
        public event PropertyChangedEventHandler PropertyChanged;
        int controllerID;
        public ref int ControllerID => ref this.controllerID;
        #endregion

        [Serialized, SyncToView] public AffiliationFlag FlagOption { get; set; }

        public Result TryHandleClearRequest(Player player)
        {
            this.FlagOption = AffiliationFlag.None;
            return Result.Succeeded;
        }
    }

    [Eco]
    public enum AffiliationFlag 
    {
        None,
        ElixrMods,
         Cornwall,
           UnitedFederationOfPlanets
    }

    [Serialized, AutogenClass, LocDisplayName("Affiliates Flag Selection"), NoIcon]
    public partial class AffiliationFlagComponent : FlagComponent, IPersistentData
    {

        public AffilFlagData affilFlagData { get; set; }

        public new object PersistentData { get => affilFlagData; set => affilFlagData = value as AffilFlagData ?? new AffilFlagData(); }
        private AffiliationFlag flagOption {get; set;}

        [Eco, ClientInterfaceProperty, GuestHidden]
        [Serialized, SyncToView]
        public AffiliationFlag FlagOption { get => flagOption; set { flagOption = value; this.Changed(nameof(FlagOption)); } }

        [RPC, Autogen("Set Flag")]
        public void SetFlag(Player player)
        {
            affilFlagData.FlagOption = FlagOption;
            Parent.SetAnimatedState("FlagChange", affilFlagData.FlagOption.GetName());
            this.Changed(nameof(FlagOption));
        }

        public override void Initialize()
        {
            base.Initialize();
            this.affilFlagData ??= new AffilFlagData();
            this.FlagOption = affilFlagData.FlagOption;
            Parent.SetAnimatedState("FlagChange", affilFlagData.FlagOption.GetName());
            this.Changed(nameof(FlagOption));
        }
    }
}