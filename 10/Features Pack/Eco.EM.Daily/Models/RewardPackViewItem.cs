using Eco.Core.Controller;
using Eco.Core.Systems;
using Eco.Gameplay.Items;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System.ComponentModel;

namespace Eco.EM.Daily
{
    // This class is to store the item reward in a gift box and the amount. 
    // This allows us to have multiple reward items in a giftbox just creating a list of these.
    [Serialized]
    public class RewardPackViewItem : IController, INotifyPropertyChanged
    {
        Item packItem { get; set; }

        [Eco, ClientInterfaceProperty] 
        public Item PackItem 
        {
            get => packItem;
            set
            {
                if (value == packItem) return;
                packItem = value;
                this.Changed(nameof(PackItem));
            }
        }
        
        float amount { get; set; }
        [Eco, ClientInterfaceProperty]
        public float Amount
        {
            get => amount;
            set
            {
                if (value == amount) return;
                amount = value;
                this.Changed(nameof(Amount));
            }
        }

        #region IController
        private int controllerID;

        public event PropertyChangedEventHandler PropertyChanged;

        ref int IHasUniversalID.ControllerID => ref this.controllerID;
        #endregion
    }
}
