using Eco.Core.Controller;
using Eco.Gameplay.Items;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System.ComponentModel;

namespace Eco.EM.Daily
{
    // This class is to store the item reward in a gift box and the amount. 
    // This allows us to have multiple reward items in a giftbox just creating a list of these.
    [Serialized]
    public class RewardPackViewItem : IController
    {
        [Eco] public Item PackItem { get; set; }
        [Eco] public float Amount { get; set; }

        #region IController
        private int controllerID;
        ref int IController.ControllerID => ref this.controllerID;
        #endregion
    }
}
