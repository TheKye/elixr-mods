using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Property;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Utils;
using System;

namespace ModsTesting.Unused.Testing
{
    public class SimpleInitTester : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus() => Localizer.DoStr($"Init Tester");
        public void Initialize(TimedTask timer)
        {
            PropertyManager.OnPropertyClaimed.Add(SingleOwnerCheck);
        }

        private void SingleOwnerCheck(bool added, Deed deed, User user)
        {      
            deed.Changed.Add(() =>
            {
                if (deed.Accessors.Count > 1)
                {
                    user.Player.OpenCustomPanel("Blah", "This is an Anti-Socialist server, Captialism ONLY! no Sharing", "blah");
                    var refList = deed.Owners;
                    deed.Accessors.RemoveAll(alias => !refList.Contains(alias));
                }
            });
        }

    }
}