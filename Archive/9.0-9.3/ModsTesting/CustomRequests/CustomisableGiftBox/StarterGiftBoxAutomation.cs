using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;

namespace ECO.EM.CustomRequests
{
    /* Instructions for the automation of giving a new user a gift:
     * You can change the giftbox being recieved on new user joined.
    */
    public class StartGiftBoxAutmoation : IModKitPlugin, IInitializablePlugin
    {
        IGiftBox starterBox;
        CustomisableGiftBoxItem gift;

        public string GetStatus() => Localizer.DoStr($"Starter Pack Automation");
        public void Initialize(TimedTask timer)
        {
            // Edit this line to change the initial box contents to be recieved
            starterBox = new StarterPack();

            gift = new CustomisableGiftBoxItem() { Box = starterBox };

            UserManager.OnNewUserJoined.Add((target) =>
            {
                var result = target.Inventory.TryAddItem(gift);

                if (result.Success)
                    target.MsgLocStr(string.Format("Welcome to the server friend! Please enjoy this gift from us to help you get started"));
                else
                    target.MsgLocStr(string.Format("Welcome to the server friend! We attempted to gift you an item, but something went wrong please contact an admin"));
            });
        }
    }
}
