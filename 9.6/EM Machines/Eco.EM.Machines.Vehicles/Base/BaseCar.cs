using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System.ComponentModel;

namespace Eco.EM.Machines.Vehicles
{
    [Serialized]
    public class CarColorData : IController, INotifyPropertyChanged, IClearRequestHandler
    {
        #region IController
        public event PropertyChangedEventHandler PropertyChanged;
        int controllerID;
        public ref int ControllerID => ref this.controllerID;
        #endregion

        [Serialized, SyncToView] public CarColor SelectedCarColor { get; set; }

        public Result TryHandleClearRequest(Player player)
        {
            this.SelectedCarColor = CarColor.Original;
            return Result.Succeeded;
        }
    }


    [Eco]
    public enum CarColor
    {
        Original,
        Black,
        Blue,
        Brown,
        Green,
        Grey,
        Orange,
        Pink,
        Purple,
        Red,
        Yellow,
        White
    }

    [Serialized, AutogenClass, LocDisplayName("Car Color Picker")]
    [NoIcon]
    public partial class CarColorPickerComponent : WorldObjectComponent, INotifyPropertyChanged, IPersistentData
    {
        public override bool Enabled => true;
        public CarColorData carColor { get; set; }

        private CarColor ocarColor { get; set; }

        [Eco, ClientInterfaceProperty, GuestHidden]
        [Serialized, SyncToView]
        public CarColor CarColor 
        {
            get => ocarColor;
            set
            {
                if (value == ocarColor) return;
                ocarColor = value;
                this.Changed(nameof(CarColor));
            }
        }

        [Serialized, SyncToView, NewTooltipChildren(CacheAs.Global, flags: TTFlags.AllowNonControllerTypeForChildren)]
        public object PersistentData { get => carColor; set => carColor = value as CarColorData ?? new CarColorData(); }

        [RPC, Autogen, GuestHidden]
        public void SetColor(Player player)
        {
            carColor.SelectedCarColor = CarColor;
            Parent.SetAnimatedState("ColorChange", carColor.SelectedCarColor.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.carColor ??= new CarColorData();
            this.CarColor = carColor.SelectedCarColor;
            this.Changed(nameof(CarColor));
            Parent.SetAnimatedState("ColorChange", carColor.SelectedCarColor.GetName());
        }
    }
}
