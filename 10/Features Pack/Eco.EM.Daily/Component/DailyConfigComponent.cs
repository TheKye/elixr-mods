using Eco.Core.Controller;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Daily.Component
{
    [Serialized, AutogenClass, LocDisplayName("Daily Config"), NoIcon]
    public partial class DailyConfigComponent : WorldObjectComponent
    {
        private int value { get; set; }

        [Eco(AccessType.Admin), ClientInterfaceProperty, GuestHidden, LocDescription("The value to set the config setting too, does not default to the setting currently set")]
        public int Value
        {
            get => value;
            set
            {
                if (value == this.value) return;
                this.value = value;
                this.Changed(nameof(Value));
            }
        }

        private DailyConfign dailyConfig { get; set; }
        [Eco(AccessType.Admin), ClientInterfaceProperty, GuestHidden, LocDescription("Config Setting to change")]
        public DailyConfign DailyConfig
        {
            get => dailyConfig;
            set
            {
                if (value == dailyConfig) return;
                dailyConfig = value;
                this.Changed(nameof(DailyConfig));
            }
        }

        [RPC, Autogen, GuestHidden, LocDescription("Submit your Settings")]
        public void Set(Player player)
        {
            GetAndSetDailyConfig(player);
        }

        private void GetAndSetDailyConfig(Player player)
        {
            switch (dailyConfig)
            {
                case DailyConfign.XP:
                    DailyCommands.ConfigureDaily(player.User, "xp", Value);
                    return;
                case DailyConfign.StartTier:
                    DailyCommands.ConfigureDaily(player.User, "starttier", Value);
                    return;
                case DailyConfign.Timer:
                    DailyCommands.ConfigureDaily(player.User, "timer", Value);
                    return;
                case DailyConfign.Time:
                    DailyCommands.ConfigureDaily(player.User, "time", Value);
                    return;
            }
        }
    }

    [Eco]
    public enum DailyConfign
    {
        XP,
        StartTier,
        Timer,
        Time
    }
}
