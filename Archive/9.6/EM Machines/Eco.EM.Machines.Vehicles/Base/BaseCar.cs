using Eco.Core.Controller;
using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Gameplay.Systems.Tooltip;
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
    public partial class CarColorPickerComponent : WorldObjectComponent, INotifyPropertyChanged, IPersistentData
    {
        public CarColorData carColor { get; set; }

        private CarColor ocarColor { get; set; }

        [Eco, ClientInterfaceProperty, GuestHidden]
        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren(CacheAs.Global)]
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
