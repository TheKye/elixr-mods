namespace Eco.EM.Commands
{
    using System;
    using Core.Utils;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Networking;

    public class ExtendedUser : IModKitPlugin, IInitializablePlugin
    {
        static readonly ExtendedUser _instance = new ExtendedUser();
        public static ExtendedUser Instance
        {
            get {
                return _instance;
            }
        }

        public string GetCategory() => "Elixr Mods";

        public string GetStatus()
        {
            return "Active";
        }

        public void Initialize(TimedTask timer)
        {
           
        }

        public override string ToString() => Localizer.DoStr("EM - Basic Commands");

    }
}
