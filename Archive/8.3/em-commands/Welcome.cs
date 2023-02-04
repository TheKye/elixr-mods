namespace Eco.EM
{
    using System;
    using Core.Utils;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Networking;

    public class ExtendedUser : IModKitPlugin
    {
        static readonly ExtendedUser _instance = new ExtendedUser();
        public static ExtendedUser Instance
        {
            get {
                return _instance;
            }
        }
        public override string ToString() => "Notifications";

        public string GetStatus()
        {
            return "Active";
        }
    }
}
