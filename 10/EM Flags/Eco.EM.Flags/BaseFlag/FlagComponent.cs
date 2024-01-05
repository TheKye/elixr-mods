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
using Eco.Core.Utils;
using Eco.Gameplay.Systems.NewTooltip;
using PropertyChanged;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Flags
{

    [Serialized]
    public class FlagPoleData : IController, INotifyPropertyChanged, IClearRequestHandler
    {
        #region IController
        public event PropertyChangedEventHandler PropertyChanged;
        int controllerID;
        public ref int ControllerID => ref this.controllerID;
        #endregion

        [Serialized, SyncToView] public FlagPoleMaterial MaterialOption { get; set; }

        public Result TryHandleClearRequest(Player player)
        {
            this.MaterialOption = FlagPoleMaterial.IronGold;
            return Result.Succeeded;
        }
    }

    // If you have more textures for the flag pole add them here.
    [Eco]
    public enum FlagPoleMaterial
    {
        IronGold,
        Redwood,
    }

    // The base component for all flags, implements the selector for the flag pole material so it doesn't need to be implemented on all flags individually.
    [Serialized]
    [DoNotNotify]
    public abstract class FlagComponent : WorldObjectComponent, INotifyPropertyChanged, IPersistentData
    {
        public FlagComponent() { }

        public FlagPoleData flagPoleData { get; set; }

        public object PersistentData { get => flagPoleData; set => flagPoleData = value as FlagPoleData ?? new FlagPoleData(); }

        [Eco, ClientInterfaceProperty, GuestHidden]
        [Serialized, SyncToView]
        public FlagPoleMaterial MaterialOption { get; set; }

        [RPC, Autogen]
        public void SetFlagPole(Player player)
        {
            flagPoleData.MaterialOption = MaterialOption;
            Parent.SetAnimatedState("PoleChange", flagPoleData.MaterialOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.flagPoleData ??= new FlagPoleData();
            this.MaterialOption = flagPoleData.MaterialOption;
            Parent.SetAnimatedState("PoleChange", flagPoleData.MaterialOption.GetName());
        }
    }
}
