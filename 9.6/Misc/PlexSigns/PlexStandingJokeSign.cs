using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PlexStandingJokeSignObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Plex Standing Joke Sign");

        public PlexStandingJokeSignObject() { }

    }

    [Serialized]
    [LocDisplayName("Plex Standing Joke Sign")]
    [MaxStackSize(100)]
    [Weight(500)]
    [Currency]
    public partial class PlexStandingJokeSignItem : WorldObjectItem<PlexStandingJokeSignObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("\"Les Franquois\"");
    }

}
