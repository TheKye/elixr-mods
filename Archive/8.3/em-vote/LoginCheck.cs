namespace Eco.TSO
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;

    public class ExtendedUser : IModKitPlugin
    {
        static readonly ExtendedUser _instance = new ExtendedUser();
        public static ExtendedUser Instance
        {
            get {
                return _instance;
            }
        }
        public override string ToString() => "Auto Vote Checker";

        public string GetStatus()
        {
            return "Active";
        }

        public ExtendedUser() {
            UserManager.OnUserLoggedIn.Add(CheckVotes);
        }

        private void CheckVotes( User user ) {

            var claimedCount = VoteMechanics.Instance.UnclaimedVotes( user );

            if (claimedCount > 0)
                ChatManager.ServerMessageToPlayer( Localizer.DoStr( "Thank you for voting on Top Servers Online, you have received your reward."  ), user );
        }
    }
}
