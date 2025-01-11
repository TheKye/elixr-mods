using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Players;
using System;
using System.Linq;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR
/*
namespace Eco.EM.Misc.NoPlayerCurrency
{
    /// <summary>
    /// The Currency Manipulator is designed to remove all player Credits from the world
    /// It will then create a new "Bot" Character to generate the new currency
    /// Then when players login for the first time they are then granted the currency 
    /// This Mod needs to remain in for the entire world's run, so be sure to keep this mod in until you finish your cycle otherwise the 
    /// player currencies will return 
    /// 
    /// While not officially supported this may work on existing worlds, use at your own risk on already established worlds.
    /// </summary>
    public class CurrencyManipulator : IModKitPlugin, IInitializablePlugin
    {
        // Change these values for customisation.
        private const string BOTName                = "EMBOT"; //Name your Bot it can be anything
        private const string BaseCurrencyName       = "Coin"; // Name your Currency This currency can also never be minted
        private const float InitialAmountOfCurrency = 2000; // The initial Amount all players who join the server will start with

        // Avoid changing anything below.
        public static User CurrencyController { get; private set; }
        public static Currency BaselineCurrency { get; private set; }

        
        public void Initialize(TimedTask timer)
        {
            CurrencyController = UserManager.FindUserByName(BOTName) ?? ActivateController();
            BaselineCurrency = CurrencyManager.Currencies.FirstOrDefault(x => x.Name == BaseCurrencyName) ?? AcitivateCurrency();

            // Fix the Bot Currency if it has not been done.
            var botCreditname = CurrencyManager.PlayerCreditName(BOTName);
            var botCredit = (Currency)CurrencyManager.Registrar.GetByName(botCreditname);
            if (botCredit != null)
                CurrencyManager.Registrar.Remove(botCredit);

            var botCurrency = CurrencyManager.GetPlayerCurrency(CurrencyController);
            if (botCurrency == null || botCurrency != BaselineCurrency)
                CurrencyManager.UsernameToCurrency[CurrencyController.Name] = BaselineCurrency;


            // Don't do anything if the player is the discord bot or if the player has already got the baseline currency
            UserManager.NewUserJoinedEvent.Add(u =>
            {
                if (u.StrangeId == "DiscordLinkSlg") return;
                if (CurrencyManager.UsernameToCurrency[u.Name] == BaselineCurrency) return;

                // Set-up logging in player with the baseline currency and nuke the reference to their personal credit
                u.BankAccount.SetAccountName(u.Player, u.Player.DisplayName);
                u.BankAccount.AddCurrency(BaselineCurrency, InitialAmountOfCurrency);

            });
            UserManager.OnUserLoggedIn.Add(u =>
            {
                var playerCurrency = CurrencyManager.GetPlayerCurrency(CurrencyManager.PlayerCreditName(u.Player.DisplayName));
                u.BankAccount.RemoveCurrency(playerCurrency);
                u.BankAccount.SetAccountName(u.Player, u.Player.DisplayName);
                CurrencyManager.Registrar.Remove(playerCurrency);
                CurrencyManager.UsernameToCurrency[u.Name] = BaselineCurrency;
            });

        }

        // Set up the baseline currency.
        private static Currency AcitivateCurrency()
        {
            return CurrencyManager.AddCurrency(CurrencyController, BaseCurrencyName, Shared.Items.CurrencyType.Backed);
        }

        // Add the BOT Controller as the owner of the baseline currency.
        private static User ActivateController()
        {
            UserManager.RequireAuthentication = false;
            var user = UserManager.GetOrCreateUser("1234", BOTName);
            user.IsLocal();
            UserManager.RequireAuthentication = true;
            return user;
        }

        public string GetStatus() => String.Empty;

        public string GetCategory() => "";
    }
}
*/