using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework.Permissions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Property;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Utils;
using System;

namespace ModsTesting.Unused.Testing
{
    public class CustomProcessorEventTest : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus() => Localizer.DoStr($"Init Tester");
        public void Initialize(TimedTask timer)
        {
            EMCustomChatProcessor.CommandProcessed += OnCommandProcessed;
        }

        private void OnCommandProcessed(ChatCommand com, User user, bool success)
        {
            var status = success ? "successful" : "failed";
            ChatManager.GlobalNotification($"{user} made a {status} attempt to invoke the command {com.Name}");
        }
    }
}